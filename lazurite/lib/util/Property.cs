namespace lazurite.util {


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_T"></typeparam>
    public abstract class Property<_T> : NotifyProperty {
        /// <summary>
        /// �l���擾���܂��B
        /// </summary>
        /// <returns></returns>
        public abstract _T getValue();


        /// <summary>
        /// �l��ݒ肵�܂��B
        /// </summary>
        /// <param name="__property">�ݒ肷��l�B</param>
        public abstract void setValue(_T __property);
    }
}