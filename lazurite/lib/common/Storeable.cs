namespace lazurite.common {


    /// <summary>
    /// IStorage インターフェイスと違い、格納する機能だけを持つインターフェイスです。
    /// </summary>
    /// <typeparam name="_Article"></typeparam>
    public interface Storeable<_Article> {
        /// <summary>
        /// 指定されたオブジェクトを格納します。
        /// </summary>
        /// <param name="__stored_article"></param>
        void store(_Article __stored_article);
        
        
        /// <summary>
        /// 指定されたオブジェクトの配列の要素を全て格納します。
        /// </summary>
        /// <param name="__stored_articles"></param>
        void storeAll(_Article[] __stored_articles);
        
        
        /// <summary>
        /// 所有している要素の数を返します。
        /// </summary>
        int entries { get; }
    }


    /// <summary>
    /// IStorage インターフェイスと違い、格納する機能だけを持つインターフェイスです。
    /// </summary>
    /// <typeparam name="_This">このインターフェイスを実装したクラス。</typeparam>
    /// <typeparam name="_Article"></typeparam>
    public interface Storeable<_This, _Article> {
        /// <summary>
        /// 指定されたオブジェクトを格納します。
        /// </summary>
        /// <param name="__stored_article"></param>
        /// <returns></returns>
        _This store(_Article __stored_article);


        /// <summary>
        /// 指定されたオブジェクトの配列の要素を全て格納します。
        /// </summary>
        /// <param name="__stored_articles"></param>
        /// <returns></returns>
        _This storeAll(_Article[] __stored_articles);


        /// <summary>
        /// 所有している要素の数を返します。
        /// </summary>
        int entries { get; }
    }
}
