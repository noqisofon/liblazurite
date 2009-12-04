using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.basics {


    /// <summary>
    /// 
    /// </summary>
    public interface Compositable : Visitable {
        /// <summary>
        /// 
        /// </summary>
        object item { get; set; }
    }
}
