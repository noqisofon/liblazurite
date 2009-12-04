using System;
using System.Data;
using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// 
    /// </summary>
    public abstract class ADODataSource : AbstractDataSource, IADODataSource {
        /// <summary>
        /// 接続するデータベースの名前(initial catalog)です。
        /// </summary>
        protected string initial_catalog_;
        /// <summary>
        /// 接続するデータベースシステムのインスタンス名、またはネットワークアドレス(data source)です。
        /// </summary>
        protected string data_source_;
        /// <summary>
        /// SQL Server 認証にするか、ユーザー名、パスワードの要らない Windows 認証にするかを決めます。
        /// </summary>
        /// <remarks>false ならSQL Server 認証、true なら Windows 認証。</remarks>
        protected bool integrated_security_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__data_source"></param>
        /// <param name="__integrated_security"></param>
        public ADODataSource(string __initial_catalog, string __data_source, bool __integrated_security) {
            this.initial_catalog_ = __initial_catalog;
            this.data_source_ = __data_source;
            this.integrated_security_ = __integrated_security;
        }


        /// <summary>
        /// 接続するプロバイダーの名前にアクセスします。
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
        /// 接続するときに使う認証のセキュリティの有無にアクセスします。
        /// </summary>
        public bool integralSecurity {
            get {
                return integrated_security_;
            }
            set {
                integrated_security_ = value;
            }
        }


        /// <summary>
        /// 接続するデータベース名にアクセスします。
        /// </summary>
        public string initialCatalog {
            get {
                return initial_catalog_;
            }
            set {
                initial_catalog_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public abstract string providerName {
            get;
        }
    }
}
