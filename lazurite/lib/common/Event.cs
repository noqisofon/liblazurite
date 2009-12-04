using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.common {


    /// <summary>
    /// 
    /// </summary>
    public class Event {
        /// <summary>
        /// 
        /// </summary>
        private object source_;


        /// <summary>
        /// 
        /// </summary>
        public object source {
            get {
                return source_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Event(object __source) {
            this.source_ = __source;
        }
    }
}
