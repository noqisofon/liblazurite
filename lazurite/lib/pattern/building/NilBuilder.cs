namespace lazurite.pattern.building {


    /// <summary>
    /// 何にもしない製造機です。
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