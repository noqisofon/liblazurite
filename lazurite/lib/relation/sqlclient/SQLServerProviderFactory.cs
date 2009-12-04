using System;
using System.Data.Common;
using System.Data.SqlClient;


namespace lazurite.relation.sqlclient {


    /// <summary>
    /// 
    /// </summary>
    public class SQLServerProviderFactory : common.DBProviderFactory {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection createConnection() {
            return new SqlConnection();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbCommand createCommand() {
            return new SqlCommand();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter createDataAdapter() {
            return new SqlDataAdapter();
        }
    }
}
