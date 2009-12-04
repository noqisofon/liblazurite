using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.visitation {


    using util = lazurite.util;
    using common = lazurite.common;


    /// <summary>
    /// AbstractVisitor クラスは basics.Visitable への抽象的なアクセスの方法を提供します。
    /// </summary>
    public abstract class AbstractVisitor : util::RoutineWorkerTraits<basics.Visitable>, basics.IVisitor {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="visit_routine"></param>
        protected AbstractVisitor(util::subroutine<basics.Visitable> __visit_routine) 
            : base(__visit_routine)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__article"></param>
        /// <returns></returns>
        public virtual bool visit(basics.Visitable __article) {
            return __article.accept( this );
        }
    }


    /// <summary>
    /// AbstractVisitor クラスは _Target への抽象的なアクセスの方法を提供します。
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public abstract class AbstractVisitor<_Target> : util::RoutineWorkerTraits<_Target>, basics.IVisitor<_Target> {
        /// <summary>
        /// 指定されたデリゲートを受け取って、AbstractVisitor を構築します。
        /// </summary>
        /// <param name="__proc"></param>
        protected AbstractVisitor(util::subroutine<_Target> __visit_routine) 
            : base(__visit_routine)
        {
        }


        /// <summary>
        /// 指定されたオブジェクトに訪れます。
        /// </summary>
        /// <param name="__target"></param>
        /// <returns></returns>
        public abstract bool visit(_Target __target);
    }
}
