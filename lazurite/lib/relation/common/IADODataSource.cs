using System;
using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// ADO.NET で使用する接続文字列の為のパラメータを定義します。
    /// </summary>
    public interface IADODataSource : DataSource {
        /// <summary>
        /// 接続するプロバイダーの名前にアクセスします。
        /// </summary>
        string dataSource {
            get;
            set;
        }


        /// <summary>
        /// 接続するときに使う認証のセキュリティの有無にアクセスします。
        /// </summary>
        bool integralSecurity {
            get;
            set;
        }


        /// <summary>
        /// 接続するデータベース名にアクセスします。
        /// </summary>
        string initialCatalog {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        string providerName {
            get;
        }
    }
}
