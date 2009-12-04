namespace lazurite.util {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    public abstract class Property<_T> : NotifyProperty {
        /// <summary>
        /// 値を取得します。
        /// </summary>
        /// <returns></returns>
        public abstract _T getValue();


        /// <summary>
        /// 値を設定します。
        /// </summary>
        /// <param name="__property">設定する値。</param>
        public abstract void setValue(_T __property);
    }
}