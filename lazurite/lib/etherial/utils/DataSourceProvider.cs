using System;
using System.Collections;
using System.Data;
using System.Data.Common;


namespace lazurite.etherial.utils {


    /// <summary>
    /// 
    /// </summary>
    public class DataSourceProvider {
        /// <summary>
        /// 
        /// </summary>
        private DataSet content_;
        /// <summary>
        /// 
        /// </summary>
        private ConnectionFactory factory_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__factory"></param>
        public DataSourceProvider(ConnectionFactory __factory) {
            this.content_ = new DataSet( "TablePool" );
            this.factory_ = __factory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__command"></param>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public DataTable satisfyTable(DbCommand __command, string __table_name) {
            using ( DbConnection connection = this.factory_.createConnection() ) {
                __command.Connection = connection;

                DbDataAdapter adapter = this.factory_.createAdapter();
                adapter.SelectCommand = __command;
                adapter.Fill( this.content_, __table_name );
            }
            return this.content_.Tables[__table_name];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public ICollection getDataSource(string __table_name) {
            DataView result_view = null;
            if ( this.content_.Tables.Count > 0 && this.content_.Tables.Contains( __table_name ) ) {
                /*
                 * 元からあるテーブルを検索して DataView に入れて返す。
                 */
                result_view = new DataView( this.content_.Tables[__table_name] );
            }
            return result_view;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__command"></param>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public ICollection getDataSource(DbCommand __command, string __table_name) {
            return new DataView( satisfyTable( __command, __table_name ) );
        }


        /// <summary>
        /// 
        /// </summary>
        public bool is_empty {
            get {
                return content_.Tables.Count == 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int amount {
            get {
                return content_.Tables.Count;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public DataTable[] to_a {
            get {
                DataTable[] result = new DataTable[content_.Tables.Count];
                int i = 0;
                foreach ( DataTable table in content_.Tables ) {
                    result[i] = table;
                    ++i;
                }
                return result;
            }
        }
    }
}
