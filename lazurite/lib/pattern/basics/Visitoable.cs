using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.basics {


    /// <summary>
    /// Visitor �I�u�W�F�N�g�̎󂯓����ł��B
    /// </summary>
    public interface Visitable {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__visitor"></param>
        /// <returns></returns>
        bool accept(IVisitor __visitor);
    }
}
