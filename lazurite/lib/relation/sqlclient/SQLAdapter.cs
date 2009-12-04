using System.Data.SqlClient;


namespace lazurite.relation.sqlclient {
    
    
    /// <summary>
    /// DataSource をラップしてアダプター用に SqlConnection を返すメソッドを定義します。
    /// </summary>
    public interface SQLAdapter {
        /// <summary>
        /// 
        /// </summary>
        common.IADODataSource dataSource { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SqlConnection getConnection();
    }
}