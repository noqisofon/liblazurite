using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// Logger からログメッセージを受け取り、それらをエクスポートします。
    /// </summary>
    public abstract class Handler {
        /// <summary>
        /// 
        /// </summary>
        protected Handler() {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__record"></param>
        public abstract void publish(LogRecord __record);


        /// <summary>
        /// 
        /// </summary>
        public abstract void close();


        /// <summary>
        /// 
        /// </summary>
        public abstract void flush();
    }
}
