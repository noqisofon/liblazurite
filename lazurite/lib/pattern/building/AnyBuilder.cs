using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.building {


    /// <summary>
    /// ターゲットをデリゲートで作成するためのビルダーです。
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public class AnyBuilder<_Target> : AbstractBuilder<_Target> {
        /// <summary>
        /// 
        /// </summary>
        private util.subroutine<_Target> build_part_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public AnyBuilder(_Target target, util.subroutine<_Target> build_part)
            : base( target ) 
        {
            this.build_part_ = build_part;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {
            if ( this.build_part_ != null ) {
                this.build_part_( content );
            }
        }
    }
}
