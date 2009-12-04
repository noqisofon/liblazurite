using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace lazurite.relation.sqlclient {


    /// <summary>
    /// 
    /// </summary>
    /// <remarks>TableStorage とはまったく関係がありません。</remarks>
    public class SQLStorage : lazurite.common.ITableStorage, SQLAdapter {
        /// <summary>
        /// 
        /// </summary>
        private DataSet dataset_;
        /// <summary>
        /// 
        /// </summary>
        private SQLAdapter factory_;
        /// <summary>
        /// データベースのテーブルから ADO なテーブルに簡単にデータを渡します。
        /// </summary>
        private SqlDataAdapter adapter_;
        /// <summary>
        /// 
        /// </summary>
        private bool arrow_append_ = false;


        public common.IADODataSource dataSource {
            get {
                return factory_.dataSource;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable this[int index] {
            get {
                return dataset_.Tables[index];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable this[string tablename] {
            get {
                return dataset_.Tables[tablename];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool arrowAppend {
            get {
                return arrow_append_;
            }
            set {
                arrow_append_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__factory"></param>
        /// <param name="__dataset"></param>
        /// <param name="__adapter"></param>
        public SQLStorage(SQLAdapter __factory, DataSet __dataset, SqlDataAdapter __adapter) {
            this.factory_ = __factory;
            this.dataset_ = __dataset;
            this.adapter_ = __adapter;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__command"></param>
        /// <returns></returns>
        public DataTable fetch(string __table_name, SqlCommand __command) {
            if ( !this.arrow_append_ ) {
                if ( this.dataset_.Tables.Contains( __table_name ) ) {
                    this.dataset_.Tables.Remove( __table_name );
                }
            }
            using ( SqlConnection connection = this.factory_.getConnection() ) {
                if ( connection.State == ConnectionState.Closed ) {
                    connection.Open();
                }
                __command.Connection = connection;

                this.adapter_.SelectCommand = __command;
                this.adapter_.Fill( this.dataset_, __table_name );
            }
            return this.dataset_.Tables[__table_name];
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTable fetch(string __table_name, string __sql_query) {
            return fetch( __table_name, new SqlCommand( __sql_query ) );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__sql_query"></param>
        /// <param name="__palams"></param>
        public DataTable fetch(string __table_name, string __sql_query, params SqlParameter[] __palams) {
            SqlCommand command = new SqlCommand( __sql_query );
            command.Parameters.AddRange( __palams );

            return fetch( __table_name, command );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public bool contains(string __table_name) {
            return this.dataset_.Tables.Contains( __table_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table"></param>
        /// <returns></returns>
        public bool contains(DataTable __table) {
            return this.dataset_.Tables.Contains( __table.TableName );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        public int indexOf(string __name) {
            return this.dataset_.Tables.IndexOf( __name );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__removed_name"></param>
        public void remove(string __removed_name) {
            this.dataset_.Tables.Remove( __removed_name );
        }


        /// <summary>
        /// 
        /// </summary>
        public SqlConnection getConnection() {
            return this.factory_.getConnection();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <param name="__invoker"></param>
        public void invoke_table(lazurite.common.TableInvoker __invoker) {
            foreach ( DataTable table in dataset_.Tables ) {
                __invoker( table );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] tableNames {
            get {
                List<string> li = new List<string>();
                foreach ( DataTable table in dataset_.Tables ) {
                    li.Add( table.TableName );
                }
                return li.ToArray();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public int length {
            get {
                return dataset_.Tables.Count;
            }
        }
    }
}