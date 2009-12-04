namespace lazurite.pattern.strategies {


    /// <summary>
    /// 
    /// </summary>
    public class Context {
        private basics.IStrategy strategy_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strategy"></param>
        public Context(basics.IStrategy strategy) {
            this.strategy_ = strategy;
        }


        /// <summary>
        /// 
        /// </summary>
        public void execute() {
            this.strategy_.execute();
        }
    }
}