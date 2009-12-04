using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// データソースへの接続に対するファクトリーインターフェイスです。
    /// </summary>
    public interface DataSource : CommonDataSource {
        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <returns></returns>
        DbConnection getConnection();


        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <param name="__username">ユーザー名。</param>
        /// <param name="__password">ユーザーのパスワード。</param>
        /// <returns></returns>
        DbConnection getConnection(string __username, string __password);
    }
}