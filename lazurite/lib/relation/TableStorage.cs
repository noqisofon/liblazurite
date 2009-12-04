using System;
using System.Data;
using System.Data.Common;


namespace lazurite.relation {


    /// <summary>
    /// 
    /// </summary>
    public class TableStorage : lazurite.common.ITableStorage {
        /// <summary>
        /// 
        /// </summary>
        protected DataSet dataset_;
        /// <summary>
        /// 
        /// </summary>
        protected common.IADODataSource data_source_;
        /// <summary>
        /// 
        /// </summary>
        protected DbDataAdapter adapter_;
        /// <summary>
        /// 
        /// </summary>
        private common.DBProviderFactory factory_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source"></param>
        public TableStorage(common.IADODataSource __data_source) {
            this.factory_ = common.DBProviderFactoreis.getFactory( __data_source.providerName );
            this.dataset_ = new DataSet( __data_source.initialCatalog );
            this.data_source_ = __data_source;
            this.adapter_ = this.factory_.createDataAdapter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source"></param>
        /// <param name="__detaset"></param>
        public TableStorage(common.IADODataSource __data_source, DataSet __detaset) {
            this.factory_ = common.DBProviderFactoreis.getFactory( __data_source.providerName );
            this.dataset_ = __detaset;
            this.data_source_ = __data_source;
            this.adapter_ = this.factory_.createDataAdapter();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__command"></param>
        /// <returns></returns>
        public virtual DataTable fetch(string __table_name, DbCommand __command) {
            if ( this.dataset_.Tables.Contains( __table_name ) ) {
                this.dataset_.Tables.Remove( __table_name );
            }

            using ( DbConnection connection = this.getConnection() ) {
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
            DbCommand command = this.factory_.createCommand();
            command.CommandText = __sql_query;

            return fetch( __table_name, command );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__sql_query"></param>
        /// <param name="__palams"></param>
        public DataTable fetch(string __table_name, string __sql_query, params DbParameter[] __palams) {
            DbCommand command = this.factory_.createCommand();
            command.CommandText = __sql_query;
            command.Parameters.AddRange( __palams );

            return fetch( __table_name, command );
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
        /// <param name="__name"></param>
        /// <returns></returns>
        public bool contains(string __name) {
            return this.dataset_.Tables.Contains( __name );
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
        /// <param name="__invoker"></param>
        public void invoke_table(lazurite.common.TableInvoker __invoker) {
            foreach ( DataTable table in this.dataset_.Tables ) {
                __invoker( table );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual DbConnection getConnection() {
            return this.data_source_.getConnection();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__index"></param>
        /// <returns></returns>
        public DataTable this[int __index] {
            get {
                return this.dataset_.Tables[__index];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        public DataTable this[string __name] {
            get {
                return this.dataset_.Tables[__name];
            }
        }
    }
}
