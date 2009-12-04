using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.factories {
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public abstract class AbstractPoolingFactory<_Target> : AbstractFactory<_Target> {


        /// <summary>
        /// 
        /// </summary>
        protected abstract class AbstractTargetPool<_Article> : common.Storeable<_Article> {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="__stored_article"></param>
            public abstract void store(_Article __stored_article);


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__stored_articles"></param>
            public abstract void storeAll(_Article[] __stored_articles);


            /// <summary>
            /// 
            /// </summary>
            public abstract int entries { get; }
        }
    }
}
