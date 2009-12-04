using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.basics {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Target">製造する型。</typeparam>
    public interface IBuilder<_Target> {
        /// <summary>
        /// 製造対象を構築します。
        /// </summary>
        void buildPart();
        

        /// <summary>
        /// 完成した製造対象を返します。
        /// </summary>
        _Target result { get; }
    }
}
