namespace lazurite.pattern.building {


    /// <summary>
    /// âΩÇ…Ç‡ÇµÇ»Ç¢êªë¢ã@Ç≈Ç∑ÅB
    /// </summary>
    /// <typeparam name="_Target"></typeparam>
    public sealed class NilBuilder<_Target> : AbstractBuilder<_Target> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__content"></param>
        public NilBuilder(_Target __content)
            : base( __content )
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {}
    }


}