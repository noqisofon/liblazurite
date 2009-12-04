using System;
using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// Connection, DbCommand, DbAdapter を作成する抽象ファクトリークラスです。
    /// </summary>
    public abstract class DBProviderFactory {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract DbConnection createConnection();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract DbCommand createCommand();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract DbDataAdapter createDataAdapter();
    }
}
