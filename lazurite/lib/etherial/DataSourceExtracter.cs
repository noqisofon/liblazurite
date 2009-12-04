using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


namespace lazurite.etherial {


    /// <summary>
    /// データソースを抽出するための処理を簡略化するクラスです。
    /// </summary>
    public class DataSourceExtracter {
        /// <summary>
        /// SQL Server への接続オブジェクトを作成するためのクラスです。
        /// </summary>
        private SQLClientConnectionFactory ssc_factory_;
        /// <summary>
        /// 内部データセットです。
        /// </summary>
        private DataSet content_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__factory"></param>
        public DataSourceExtracter(SQLClientConnectionFactory __factory) {
            this.ssc_factory_ = __factory;
            this.content_ = new DataSet( __factory.dataSource );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        public DataSourceExtracter(string __data_source_name, string __initial_catalog) {
            initialize( __data_source_name, true, __initial_catalog, null );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        /// <param name="__having_security"></param>
        public DataSourceExtracter(string __data_source_name, string __initial_catalog, bool __having_security) {
            initialize( __data_source_name, __having_security, __initial_catalog, null );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        /// <param name="__having_security"></param>
        /// <param name="__disk"></param>
        public DataSourceExtracter(string __data_source_name, string __initial_catalog, bool __having_security, utils.ConnectionFactory.AccountDisk __disk) {
            initialize( __data_source_name, __having_security, __initial_catalog, __disk );
        }


        /// <summary>
        /// コンストラクタで使用する初期化処理です。
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        /// <param name="__having_security"></param>
        private void initialize(string __data_source_name, bool __having_security, string __initial_catalog, utils.ConnectionFactory.AccountDisk __disk) {
            if ( __disk == null ) {
                this.ssc_factory_ = new SQLClientConnectionFactory( __data_source_name,
                                                                    __having_security,
                                                                    __initial_catalog
                                                                  );
            } else {
                this.ssc_factory_ = new SQLClientConnectionFactory( __data_source_name,
                                                                    __having_security,
                                                                    __initial_catalog,
                                                                    __disk
                                                                  );
            }
            this.content_ = new DataSet( __data_source_name );
        }


        /// <summary>
        /// 内部データセットに指定された名前のテーブルがあるか調べます。
        /// </summary>
        /// <param name="__table_name">調べたいテーブルの名前。</param>
        /// <returns></returns>
        public bool has_table(string __table_name) {
            //bool result = true;
            if ( this.content_.Tables.Count == 0 ) {
                // そもそもテーブルが入ってないなら、問答無用で偽を返します。
                return false;
            }
            // テーブルが 1 つでも存在していたら
            // 指定された名前のテーブルがあるかどうか調べます。
            return this.content_.Tables.Contains( __table_name ) ? true : false;
        }


        /// <summary>
        /// データベースからテーブルを読み込んでそれを返します。
        /// </summary>
        /// <param name="__command">テーブルを読み込むための select コマンド。</param>
        /// <param name="__table_name">テーブル名。</param>
        /// <returns></returns>
        public DataTable fill_table(SqlCommand __command, string __table_name) {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = __command;

            if ( has_table( __table_name ) ) {
                this.content_.Tables.Remove( this.content_.Tables[__table_name] );
            }
            adapter.Fill( this.content_, __table_name );

            return this.content_.Tables[__table_name];
        }


        /// <summary>
        /// クエリ文字列とテーブル名を受け取って、読み込まれたテーブルを
        /// DataView に入れて返します。
        /// </summary>
        /// <param name="__sql_query">テーブルを読み込むためのクエリ文字列。</param>
        /// <param name="__table_name">読み込むテーブルの名前。</param>
        /// <returns></returns>
        public ICollection getDataSource(SqlCommand __command, string __table_name) {
            return getDataSource( __command, __table_name, false );
        }
        /// <summary>
        /// クエリ文字列とテーブル名を受け取って、読み込まれたテーブルを
        /// DataView に入れて返します。
        /// </summary>
        /// <remarks>
        /// __fly_weight が真なら、データセット内に同名のテーブルがあったとき、
        /// データベースを読み込まずに、データセットから取り出して返します。
        /// </remarks>
        /// <param name="__sql_query">テーブルを読み込むためのクエリ文字列。</param>
        /// <param name="__table_name">読み込むテーブルの名前。</param>
        /// <param name="__fly_weight">フライウェイトするかどうか</param>
        /// <returns></returns>
        public ICollection getDataSource(SqlCommand __command, string __table_name, bool __fly_weight) {
            DataTable tmp_table = null;
            if ( has_table( __table_name ) && __fly_weight == false ) {
                tmp_table = this.content_.Tables[__table_name];
            } else {
                using ( SqlConnection connection = this.ssc_factory_.getConnection() ) {
                    if ( connection.State == ConnectionState.Closed ) {
                        connection.Open();
                    }
                    __command.Connection = connection;

                    tmp_table = fill_table( __command, __table_name );
                }
            }
            return new DataView( tmp_table );
        }


        /// <summary>
        /// 
        /// </summary>
        public bool is_empty {
            get {
                return content_.Tables.Count == 0;
            }
        }
    }
}