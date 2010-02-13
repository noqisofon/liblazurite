using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class BasicFilter : Filter {
        /// <summary>
        /// 
        /// </summary>
        private Level filter_level_ = Level.FINE;


        /// <summary>
        /// 
        /// </summary>
        public Level level {
            get {
                return filter_level_;
            }
            set {
                filter_level_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool isLoggable(LogRecord __record) {
            return filter_level_.intValue() <= __record.level.intValue();
        }
    }
}
