using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace lazurite.etherial {


    /// <summary>
    /// SQL サーバー用の接続オブジェクトを作成するファクトリークラスです。
    /// </summary>
    public class SQLClientConnectionFactory : utils.ConnectionFactory {


        /// <summary>
        /// 
        /// </summary>
        public SQLClientConnectionFactory() 
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__catalog"></param>
        public SQLClientConnectionFactory(string __catalog)
            : base(__catalog ) {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initial_catalog"></param>
        public SQLClientConnectionFactory(string __data_source, bool __security, string __catalog)
            : base( __data_source, __security, __catalog ) 
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source"></param>
        /// <param name="__security"></param>
        /// <param name="__catalog"></param>
        /// <param name="__account_disk"></param>
        public SQLClientConnectionFactory(string __data_source, bool __security, string __catalog, AccountDisk __account_disk)
            : base( __data_source, __security, __catalog, __account_disk ) 
        {
        }


        /// <summary>
        /// 指定されたパラメータから接続オブジェクトを作成して返します。
        /// </summary>
        /// <param name="data_source"></param>
        /// <param name="integrated_security"></param>
        /// <param name="initial_catalog"></param>
        /// <returns></returns>
        protected override DbConnection internalCreateConnection( string __data_source,
                                                                  bool __integrated_security,
                                                                  string __initial_catalog
                                                                ) 
        {
            SqlConnectionStringBuilder connection_builder = new SqlConnectionStringBuilder();

            connection_builder["Data Source"]           = __data_source;
            connection_builder["Integrated Security"]   = __integrated_security;
            connection_builder["Initial Catalog"]       = __initial_catalog;

            return new SqlConnection( connection_builder.ToString() );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="security"></param>
        /// <param name="catalog"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        protected override DbConnection internalCreateConnection( string __data_source, 
                                                                  bool __integrated_security, 
                                                                  string __initial_catalog, 
                                                                  AccountDisk __account
                                                                ) 
        {
            SqlConnectionStringBuilder connection_builder = new SqlConnectionStringBuilder();
            
            connection_builder["Data Source"]           = __data_source;
            connection_builder["Integrated Security"]   = __integrated_security;
            connection_builder["Initial Catalog"]       = __initial_catalog;

            connection_builder["User ID"]   = __account.user_id;
            connection_builder["Password"]  = __account.password;

            return new SqlConnection( connection_builder.ToString() );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection() {
            return base.get_connection() as SqlConnection;
        }


        /// <summary>
        /// それぞれの型に相応しい DataAdapter を返します。
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter createAdapter() {
            return new SqlDataAdapter();
        }
    }

}