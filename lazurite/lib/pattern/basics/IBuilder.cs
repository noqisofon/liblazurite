using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.basics {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_Target">��������^�B</typeparam>
    public interface IBuilder<_Target> {
        /// <summary>
        /// �����Ώۂ��\�z���܂��B
        /// </summary>
        void buildPart();
        

        /// <summary>
        /// �������������Ώۂ�Ԃ��܂��B
        /// </summary>
        _Target result { get; }
    }
}
