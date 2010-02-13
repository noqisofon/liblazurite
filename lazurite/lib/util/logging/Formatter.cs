using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// LogRecord のフォーマット文字列化をサポートします。
    /// </summary>
    public abstract class Formatter {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__record"></param>
        public abstract string format(LogRecord __record);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__handler"></param>
        /// <returns></returns>
        public string getHead(Handler __handler) {
            return string.Empty;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__handler"></param>
        /// <returns></returns>
        public string getTail(Handler __handler) {
            return string.Empty;
        }
    }
}
