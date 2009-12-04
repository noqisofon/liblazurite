namespace lazurite.pattern.building {


    /// <summary>
    /// ”Ä—pŠÄ“Â‚Å‚·B
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public class Director<_Target> {
        /// <summary>
        /// 
        /// </summary>
        private AbstractBuilder<_Target> builder_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__builder"></param>
        public Director(AbstractBuilder<_Target> __builder) {
            this.builder_ = __builder;
        }


        /// <summary>
        /// 
        /// </summary>
        public void construct() {
            this.builder_.buildPart();
        }
    }
}