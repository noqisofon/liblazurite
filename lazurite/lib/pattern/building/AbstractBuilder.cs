namespace lazurite.pattern.building {


    /// <summary>
    /// この抽象的な Builder クラスは、必要最低限のメソッドを実装し、派生クラスを作りやすくします。
    /// </summary>
    /// <typeparam name="_Target">製造する型。</typeparam>
    public abstract class AbstractBuilder<_Target> : basics.IBuilder<_Target> {
        // Builder が製造対象とするオブジェクトです。
        private _Target content_;


        /// <summary>
        /// 指定された製造対象を受け取って、AbstractBuilder を構築します。
        /// </summary>
        /// <param name="__content">製造対象のオブジェクト。</param>
        protected AbstractBuilder(_Target __content) {
            this.content_ = __content;
        }


        /// <summary>
        /// 製造対象を構築します。
        /// </summary>
        public abstract void buildPart();


        /// <summary>
        /// 派生 Builder 内で製造対象にアクセスするために必要です。
        /// </summary>
        protected _Target content {
            get { return content_; }
        }


        /// <summary>
        /// 完成した製造対象を返します。
        /// </summary>
        public _Target result {
            get { return content_; }
        }
    }
}