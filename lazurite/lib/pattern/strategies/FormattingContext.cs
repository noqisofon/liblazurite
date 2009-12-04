using System;
using System.Collections.Generic;


namespace lazurite.pattern.strategies {


    /// <summary>
    /// 
    /// </summary>
    public class FormattingContext {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, FormattingStrategy> strategy_book_ = new Dictionary<string, FormattingStrategy>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__main_strategy"></param>
        public FormattingContext(FormattingStrategy __main_strategy) {
            this.strategy_book_.Add( __main_strategy.name, __main_strategy );
        }


        public string format(object __target) {
            return 
        }
    }
}