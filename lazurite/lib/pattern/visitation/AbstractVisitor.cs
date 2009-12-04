using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.visitation {


    using util = lazurite.util;
    using common = lazurite.common;


    /// <summary>
    /// AbstractVisitor �N���X�� basics.Visitable �ւ̒��ۓI�ȃA�N�Z�X�̕��@��񋟂��܂��B
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
    /// AbstractVisitor �N���X�� _Target �ւ̒��ۓI�ȃA�N�Z�X�̕��@��񋟂��܂��B
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public abstract class AbstractVisitor<_Target> : util::RoutineWorkerTraits<_Target>, basics.IVisitor<_Target> {
        /// <summary>
        /// �w�肳�ꂽ�f���Q�[�g���󂯎���āAAbstractVisitor ���\�z���܂��B
        /// </summary>
        /// <param name="__proc"></param>
        protected AbstractVisitor(util::subroutine<_Target> __visit_routine) 
            : base(__visit_routine)
        {
        }


        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�ɖK��܂��B
        /// </summary>
        /// <param name="__target"></param>
        /// <returns></returns>
        public abstract bool visit(_Target __target);
    }
}
