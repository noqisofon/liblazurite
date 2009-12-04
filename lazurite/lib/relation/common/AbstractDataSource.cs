using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;


namespace lazurite.relation.common {


    /// <summary>
    /// データソースに共通の処理を予め実装してある抽象クラスです。
    /// </summary>
    public abstract class AbstractDataSource : DataSource {
        /// <summary>
        /// 接続試行時の最大待ち時間(多分秒)。
        /// </summary>
        private int timeout_ = 15;
        /// <summary>
        /// ログライター。
        /// </summary>
        /// <remarks></remarks>
        private TextWriter log_writer_ = Console.Out;


        /// <summary>
        /// 
        /// </summary>
        public AbstractDataSource() {
        }
        /// <summary>
        /// 
        /// </summary>
        public AbstractDataSource(int __timeout) {
            this.timeout_ = __timeout;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__out"></param>
        public AbstractDataSource(TextWriter __out) {
            this.log_writer_ = __out;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__timeout"></param>
        /// <param name="__out"></param>
        public AbstractDataSource(int __timeout, TextWriter __out) {
            this.timeout_ = __timeout;
            this.log_writer_ = __out;
        }


        /// <summary>
        /// データベースの接続試行中にこのデータソースが待機できる最長時間にアクセスします。
        /// </summary>
        public int loginTimeout {
            get {
                return timeout_;
            }
            set {
                timeout_ = value;
            }
        }


        /// <summary>
        /// このデータソースのログライターにアクセスします。
        /// </summary>
        public TextWriter logWriter {
            get {
                return log_writer_;
            }
            set {
                log_writer_ = value;
            }
        }


        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <returns></returns>
        public abstract DbConnection getConnection();


        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <param name="__username">ユーザー名。</param>
        /// <param name="__password">ユーザーのパスワード。</param>
        /// <returns></returns>
        public abstract DbConnection getConnection(string __username, string __password);
    }
}
