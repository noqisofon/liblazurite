using System;


namespace lazurite.pattern.strategies {


    /// <summary>
    /// 
    /// </summary>
    public class CurrencyFormattingStrategy : FormattingStrategy {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public override string format(Type __type, object __cell) {
            return string.Format( "{0:C}", __cell );
        }


        /// <summary>
        /// 
        /// </summary>
        public override string name {
            get {
                return "CurrencyFormatting";
            }
        }
    }
}