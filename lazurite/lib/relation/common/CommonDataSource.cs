using System.IO;


namespace lazurite.relation.common {


    /// <summary>
    /// DataSource に共通のプロパティを定義します。
    /// </summary>
    public interface CommonDataSource {
        /// <summary>
        /// データベースの接続試行中にこのデータソースが待機できる最長時間にアクセスします。
        /// </summary>
        int loginTimeout {
            get;
            set;
        }


        /// <summary>
        /// このデータソースのログライターにアクセスします。
        /// </summary>
        TextWriter logWriter {
            get;
            set;
        }

    }
}