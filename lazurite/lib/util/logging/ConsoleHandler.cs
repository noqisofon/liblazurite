using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class ConsoleHandler : StreamHandler {
        /// <summary>
        /// 
        /// </summary>
        public ConsoleHandler()
            : base( Console.Error,  new SimpleFormatter() ) 
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override void close() {
        }
    }
}
