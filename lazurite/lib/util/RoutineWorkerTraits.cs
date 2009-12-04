using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util {


    /// <summary>
    /// 
    /// </summary>
    public class RoutineWorkerTraits<_Target> {
        /// <summary>
        /// 
        /// </summary>
        protected subroutine<_Target> visit_routine_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="visit_routine"></param>
        protected RoutineWorkerTraits(subroutine<_Target> __visit_routine) {
            this.visit_routine_ = __visit_routine;
        }


        /// <summary>
        /// 
        /// </summary>
        protected subroutine<_Target> visit_routine {
            get {
                return visit_routine_;
            }
        }
    }
}
