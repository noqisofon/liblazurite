using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;


namespace lazurite.etherial.utils {


    /// <summary>
    /// 
    /// </summary>
    public abstract class ConnectionFactory {
        /// <summary>
        /// 
        /// </summary>
        private AccountDisk account_ = new AccountDisk();
        /// <summary>
        /// 
        /// </summary>
        private string data_source_;
        /// <summary>
        /// 
        /// </summary>
        private bool security_;
        /// <summary>
        /// 
        /// </summary>
        private string catalog_;
        /// <summary>
        /// 
        /// </summary>
        private DbConnection product_;
        /// <summary>
        /// 
        /// </summary>
        private string connecting_text_ = null;


        /// <summary>
        /// 
        /// </summary>
        public string user_id {
            get {
                return account_.user_id;
            }
            set {
                account_.user_id = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string password {
            get {
                return account_.password;
            }
            set {
                account_.password = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string dataSource {
            get {
                return data_source_;
            }
            set {
                data_source_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool security {
            get {
                return security_;
            }
            set {
                security_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string catalog {
            get {
                return catalog_;
            }
            set {
                catalog_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected ConnectionFactory() {
            this.data_source_    = "(local)";
            this.security_      = true;
            this.catalog_       = string.Empty;
        }
        protected ConnectionFactory(string __catalog) {
            this.data_source_ = "(local)";
            this.security_ = true;
            this.catalog_ = __catalog;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="security"></param>
        /// <param name="catalog"></param>
        protected ConnectionFactory(string __data_source, bool __security, string __catalog) {
            this.data_source_ = __data_source;
            this.security_ = __security;
            this.catalog_ = __catalog;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source"></param>
        /// <param name="__security"></param>
        /// <param name="__catalog"></param>
        /// <param name="__account_disk"></param>
        protected ConnectionFactory(string __data_source, bool __security, string __catalog, AccountDisk __account_disk) {
            this.data_source_ = __data_source;
            this.security_ = __security;
            this.catalog_ = __catalog;

            this.account_.user_id = __account_disk.user_id;
            this.account_.password = __account_disk.password;
        }


        /// <summary>
        /// 接続オブジェクトを作成します。
        /// </summary>
        /// <remarks>
        /// 他の引数のある createConnection(3 .. 4) を纏めています。
        /// get_connection() 内で呼ばれるのはこちらです。
        /// </remarks>
        protected void internalCreateConnection() {
            /* 
             * product_ が null なら接続オブジェクトを作成します。
             */
            if ( this.product_ == null ) {

                if ( this.account_.user_id == string.Empty && this.account_.password == string.Empty ) {
                    // 
                    // アカウント＆パスワード無し。
                    // 
                    this.product_ = internalCreateConnection( this.data_source_, this.security_, this.catalog_ );
                } else {
                    // 
                    // アカウント＆パスワード有り。
                    // 
                    this.product_ = internalCreateConnection( this.data_source_, this.security_, this.catalog_, this.account_ );
                }
                // 作成された接続文字列をとりあえず保持しておく。
                this.connecting_text_ = this.product_.ConnectionString;

            } else if (this.product_.ConnectionString.Length == 0 ) {
                /* 
                 * 使い終わった接続オブジェクトは接続文字列が無いので、
                 * 前に作成されたそれを入れるだけでリサイクルできる。
                 */ 
                this.product_.ConnectionString = this.connecting_text_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="security"></param>
        /// <param name="catalog"></param>
        /// <returns></returns>
        protected abstract DbConnection internalCreateConnection(string __data_source, bool __security, string __catalog);
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="security"></param>
        /// <param name="catalog"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        protected abstract DbConnection internalCreateConnection(string __data_source, bool __security, string __catalog, AccountDisk __account);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbConnection get_connection() {
            internalCreateConnection();

            return this.product_;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbConnection createConnection() {
            internalCreateConnection();

            return this.product_;
        }


        /// <summary>
        /// それぞれの型に相応しい DataAdapter を返します。
        /// </summary>
        /// <returns></returns>
        public abstract DbDataAdapter createAdapter();


        /// <summary>
        /// アカウントとパスワードのペアです。
        /// </summary>
        public class AccountDisk {
            /// <summary>
            /// アカウント。
            /// </summary>
            private string user_id_;
            /// <summary>
            /// パスワード。
            /// </summary>
            private string password_;


            /// <summary>
            /// 
            /// </summary>
            public AccountDisk() {
                this.user_id_ = string.Empty;
                this.password_ = string.Empty;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="user_id"></param>
            /// <param name="password"></param>
            public AccountDisk(string user_id, string password) {
                this.user_id_ = user_id;
                this.password_ = password;
            }


            /// <summary>
            /// 
            /// </summary>
            public string user_id {
                get {
                    return user_id_;
                }
                set {
                    user_id_ = value;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            public string password {
                get {
                    return password_;
                }
                set {
                    password_ = value;
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString() {
                return string.Format( "User ID={0},Password={1}", user_id_, password_ );
            }
        }
    }
}