using System.Data;
using System.Data.SqlClient;


namespace lazurite.etherial {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="__connection"></param>
    public delegate void ConnectingBlock(IDbConnection __connection);


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public delegate string CommandTextCreator(string __table_name);
}