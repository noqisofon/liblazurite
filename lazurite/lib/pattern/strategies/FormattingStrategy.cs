using System;


namespace lazurite.pattern.strategies {


    using basics = lazurite.pattern.basics;


    /// <summary>
    /// 
    /// </summary>
    public abstract class FormattingStrategy : basics::tag_Strategy {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__cell"></param>
        /// <returns></returns>
        protected string default_format(object __cell) {
            return __cell.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public abstract string format(Type __type, object __cell);


        /// <summary>
        /// 
        /// </summary>
        public abstract string name { get; }
    }
}