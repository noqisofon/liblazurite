using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace lazurite.etherial {


    /// <summary>
    /// DataBaseLoader クラスは、データアダプタを使用して、データベースから
    /// データセットに簡単にロードする機能を提供します。
    /// </summary>
    public class DataBaseLoader {
        /// <summary>
        /// 
        /// </summary>
        private DbDataAdapter adapter_;
        /// <summary>
        /// 
        /// </summary>
        private DataSet dataset_;
        /// <summary>
        /// 
        /// </summary>
        private utils.ConnectionFactory factory_;
        /// <summary>
        /// 
        /// </summary>
        private int timeout_;
        /// <summary>
        /// 
        /// </summary>
        private Queue<string> tablenames_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adapter"></param>
        /// <param name="__dataset"></param>
        public DataBaseLoader(DbDataAdapter __adapter, DataSet __dataset) {
            initialize( __adapter, __dataset, __dataset.DataSetName );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adapter"></param>
        /// <param name="__dataset"></param>
        public DataBaseLoader(DataSet __dataset, int __timeOut) {
            initialize( new SqlDataAdapter(), __dataset, __timeOut, __dataset.DataSetName );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adapter"></param>
        /// <param name="__dataset"></param>
        /// <param name="__database_name"></param>
        public DataBaseLoader(DbDataAdapter __adapter, string __database_name) {
            initialize( __adapter, new DataSet( __database_name ), __database_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adapter"></param>
        /// <param name="__dataset"></param>
        /// <param name="__database_name"></param>
        public DataBaseLoader(DbDataAdapter __adapter, DataSet __dataset, int __timeOut, string __database_name) {
            initialize( __adapter, __dataset, __timeOut, __database_name );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adapter"></param>
        /// <param name="__dataset"></param>
        /// <param name="__database_name"></param>
        private void initialize(DbDataAdapter __adapter, DataSet __dataset, string __database_name) {
            initialize( __adapter, __dataset, 30, __database_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__adapter"></param>
        /// <param name="__dataset"></param>
        /// <param name="__timeOut"></param>
        /// <param name="__database_name"></param>
        private void initialize(DbDataAdapter __adapter, DataSet __dataset, int __timeOut, string __database_name) {
            this.adapter_ = __adapter;
            this.dataset_ = __dataset;
            this.factory_ = new SQLClientConnectionFactory();
            this.factory_.catalog = __database_name;

            this.timeout_ = __timeOut;
            this.tablenames_ = new Queue<string>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public bool load(string __table_name) {
            CommandTextCreator creator = delegate(string name) {
                return string.Format( "select * from [{0}]", name );
            };
            load( __table_name, creator );

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__block"></param>
        /// <returns></returns>
        public bool load(string __table_name, CommandTextCreator __block) {
            using ( SqlConnection connection = this.factory_.get_connection() as SqlConnection ) {
                SqlCommand command = new SqlCommand( __block( __table_name ), connection );

                command.CommandTimeout = this.timeout_;

                try {
                    this.adapter_.SelectCommand = command;
                    this.adapter_.Fill( this.dataset_, __table_name );
                } catch ( SqlException e ) {
                    //SQLErrorLogger logger = new SQLErrorLogger( e );
                    //logger.write();

                    throw e;
                }
            }
            // テーブル名をキューに溜め込みます。
            this.tablenames_.Enqueue( __table_name );
            return true;
        }


        /// <summary>
        /// 前にロードしたテーブルを、データグリッドにバインディングします。
        /// </summary>
        /// <param name="__bindsrc"></param>
        /// <param name="__gridview"></param>
        public void binding(BindingSource __bindsrc, DataGridView __gridview) {
            //__bindsrc.DataSource = this.dataset_.Tables[this.dataset_.Tables.Count - 1];
            //__gridview.DataSource = __bindsrc;           
            binding( __bindsrc, __gridview, this.tablenames_.Peek() );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__bindsrc"></param>
        /// <param name="__gridview"></param>
        /// <param name="__table_name"></param>
        public void binding(BindingSource __bindsrc, DataGridView __gridview, string __table_name) {
            DataTableCollection dtc = this.dataset_.Tables;
            if ( dtc.Contains( __table_name ) ) {
                __bindsrc.DataSource = dtc[__table_name];
                __gridview.DataSource = __bindsrc;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__query_lines"></param>
        /// <param name="__table_name"></param>
        public void update(string[] __query_lines, string __table_name) {
            StringBuilder queryTextBuilder = new StringBuilder();
            /*
             * 1. クエリテキストを作成します。
             */
            int i = 0, stop = __query_lines.Length;
            foreach ( string line in __query_lines ) {
                queryTextBuilder.Append( line );

                if ( i < stop - 1 ) {
                    queryTextBuilder.AppendLine();
                }
                ++i;
            }
            update( queryTextBuilder.ToString(), __table_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__query_text"></param>
        /// <param name="__table_name"></param>
        public void update(string __query_text, string __table_name) {
            /*
             * 2. カブったテーブルを削除します。
             */
            DataTableCollection dtc = dataset_.Tables;
            if ( dtc.Contains( __table_name ) ) {
                dtc.Remove( __table_name );
            }
            /*
             * 3. データベースからテーブルを読み込みます。
             */
            using ( SqlConnection connection = factory_.get_connection() as SqlConnection ) {
                if ( connection.State == ConnectionState.Closed ) {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand( __query_text, connection );

                adapter_.SelectCommand = command;
                adapter_.Fill( dataset_, __table_name );

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__query_lines"></param>
        /// <param name="__table_name"></param>
        /// <param name="__bindsrc"></param>
        public void update(string[] __query_lines, string __table_name, BindingSource __bindsrc) {
            update( __query_lines, __table_name );
            __bindsrc.DataSource = dataset_.Tables[__table_name];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__query_text"></param>
        /// <param name="__table_name"></param>
        /// <param name="__bindsrc"></param>
        public void update(string __query_text, string __table_name, BindingSource __bindsrc) {
            update( __query_text, __table_name );
            __bindsrc.DataSource = dataset_.Tables[__table_name];
        }


        /// <summary>
        /// コマンド実行時の終了待機時間にアクセスします。
        /// </summary>
        public int timeOut {
            get { return timeout_; }
            set { timeout_ = value; }
        }


        /// <summary>
        /// これまで読み込んだテーブル名を配列にして返します。
        /// </summary>
        public string[] tableNames {
            get { return this.tablenames_.ToArray(); }
        }
    }
}
