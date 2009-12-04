namespace lazurite.common {
    
    
    /// <summary>
    /// オブジェクトを保管しておくためのメソッドを提供します。
    /// </summary>
    /// <typeparam name="_Colleague">保管されるオブジェクトの型。</typeparam>
    public interface IStorage<_Colleague> {
        /// <summary>
        /// 指定されたオブジェクトを追加します。
        /// </summary>
        /// <param name="__appended">追加したいオブジェクト。</param>
        void append(_Colleague __appended);
        
        
        /// <summary>
        /// 指定されたオブジェクトの配列を追加します。
        /// </summary>
        /// <param name="__appendeds">追加したいオブジェクトの配列。</param>
        /// <returns>追加した個数。</returns>
        int appendAll(_Colleague[] __appendeds);
        

        /// <summary>
        /// オブジェクトを指定された位置に挿入します。
        /// </summary>
        /// <param name="__insert_index">挿入したい位置。</param>
        /// <param name="__inserted">挿入したいオブジェクト。</param>
        void insert(int __insert_index, _Colleague __inserted);
        
        
        /// <summary>
        /// 指定されたオブジェクトが存在する最初の位置を返します。
        /// </summary>
        /// <param name="__that">調べたいオブジェクト。</param>
        /// <returns>最初の位置。</returns>
        int indexOf(_Colleague __that);
        

        /// <summary>
        /// 指定されたオブジェクトが存在するかどうか調べます。
        /// </summary>
        /// <param name="__that">調べたいオブジェクト。</param>
        /// <returns></returns>
        bool contains(_Colleague __that);


        /// <summary>
        /// 指定するオブジェクトの配列の要素が存在するかどうか調べます。
        /// </summary>
        /// <param name="__thats">オブジェクトの配列の要素。</param>
        /// <returns>全部あったら真。</returns>
        bool containsAll(_Colleague[] __thats);


        /// <summary>
        /// 保管していたオブジェクトを配列にして返します。
        /// </summary>
        /// <returns>レシーバの中身の配列。</returns>
        _Colleague[] to_a();
        

        /// <summary>
        /// 保管されているオブジェクトの数を取得します。
        /// </summary>
        int entries { get; }
    }
}