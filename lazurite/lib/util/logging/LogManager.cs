using System;
using System.Collections.Generic;


namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class LogManager {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Logger> logger_book_ = new Dictionary<string, Logger>();


        /// <summary>
        /// 
        /// </summary>
        private static LogManager shared_instance_ = new LogManager( Logger.global );


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__default_logger"></param>
        private LogManager(Logger __default_logger) {
            this.addLogger( __default_logger );
        }
        /// <summary>
        /// 
        /// </summary>
        protected LogManager() {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static LogManager getLogManager() {
            return shared_instance_;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__logger"></param>
        public void addLogger(Logger __logger) {
            this.logger_book_.Add( __logger.name, __logger );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__name"></param>
        /// <returns></returns>
        public Logger getLogger(string __name) {
            return this.logger_book_[__name];
        }
    
    
    }


}