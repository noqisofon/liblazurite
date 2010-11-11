using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;
using System.IO;


namespace lazurite.etherial {


    /// <summary>
    /// 
    /// </summary>
    public class OLEConnectionFactory : utils.ConnectionFactory {
        /// <summary>
        /// 
        /// </summary>
        private static readonly string Provider = "Microsoft.Jet.OleDb.4.0";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="initial_catalog"></param>
        /// <param name="database_path"></param>
        public OLEConnectionFactory(string initial_catalog, string database_path)
            : base( database_path, false, initial_catalog ) {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data_source"></param>
        /// <param name="integrated_security"></param>
        /// <param name="initial_catalog"></param>
        /// <returns></returns>
        protected override DbConnection internalCreateConnection(string __data_source, bool __integrated_security, string __initial_catalog) {
            string datadase_path = Path.GetFullPath( __data_source ).Replace( '\\', '/' ) + "/" + __initial_catalog;

            OleDbConnectionStringBuilder connection_builder = new OleDbConnectionStringBuilder();

            connection_builder["Provider"] = Provider;
            connection_builder["Persist Security Info"] = __integrated_security;
            connection_builder["Data Source"] = datadase_path;

            return new OleDbConnection( connection_builder.ToString() );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="security"></param>
        /// <param name="catalog"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        protected override DbConnection internalCreateConnection(string __data_source, bool __integrated_security, string __initial_catalog, AccountDisk __account) {
            string datadase_path = Path.GetFullPath( __data_source ).Replace( '\\', '/' ) + "/" + __initial_catalog;

            OleDbConnectionStringBuilder connection_builder = new OleDbConnectionStringBuilder();

            connection_builder["Provider"] = Provider;
            connection_builder["Persist Security Info"] = __integrated_security;
            connection_builder["Data Source"] = datadase_path;

            connection_builder["User ID"] = this.user_id;
            connection_builder["Jet OLEDB:Database Password"] = this.password;

            return new OleDbConnection( connection_builder.ToString() );
        }


        /// <summary>
        /// ÇªÇÍÇºÇÍÇÃå^Ç…ëäâûÇµÇ¢ DataAdapter Çï‘ÇµÇ‹Ç∑ÅB
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter createAdapter() {
            return new OleDbDataAdapter();
        }
    }
}