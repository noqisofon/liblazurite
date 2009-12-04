using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.pattern.basics {
    
    
    /// <summary>
    /// 
    /// </summary>
    interface IFormatStrategy<_Message> {
        string format(_Message __message, object __cell);
    }
}
