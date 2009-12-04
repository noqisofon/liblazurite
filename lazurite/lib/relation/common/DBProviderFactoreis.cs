namespace lazurite.relation.common {
    
    
    /// <summary>
    /// 
    /// </summary>
    public static class DBProviderFactoreis {
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__provider_name"></param>
        /// <returns></returns>
        public static DBProviderFactory getFactory(string __provider_name) {
            DBProviderFactory result = null;
            
            switch ( __provider_name ) {
                case "OleDb":
                    result = new oledb.OLEDBProviderFactory();
                    break;
                
                case "SqlClient":
                    result = new sqlclient.SQLServerProviderFactory();
                    break;
            }
            return result;
        }
    }
}
