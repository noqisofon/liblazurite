using System;
using System.Data.Common;
using System.Data.OleDb;


namespace lazurite.relation.oledb {


    /// <summary>
    /// 
    /// </summary>
    public class OLEDBProviderFactory : common.DBProviderFactory {
        /// <summary>
        /// 
        /// </summary>
        private static readonly string provider_text = "Microsoft.Jet.OleDb.4.0";


        /// <summary>
        /// 
        /// </summary>
        public static string provider {
            get {
                return provider_text;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection createConnection() {
            return new OleDbConnection();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbCommand createCommand() {
            return new OleDbCommand();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter createDataAdapter() {
            return new OleDbDataAdapter();
        }
    }
}
