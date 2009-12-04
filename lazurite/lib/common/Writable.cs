namespace lazurite.common {



    /**
     * コンテキストに書き込むインターフェースを提供します。
     */
    public interface Writable {
        /**
         * 書き込めるかどうか判別します。
         *      @return 書き込むことができたら真。
         */
        bool can_write();
        
        
        /**
         * 指定された文字列を書き込みます。
         *      @param __word [in]  書き込みたい文字列。
         */
        void write(string __word);
        /**
         * 指定されたフォーマットを利用して、オブジェクトの文字列表現を書き込みます。
         *      @param  __format [in] 書き込む文字列のフォーマット。
         *      @param  __args   [in] (オブジェクト型の)可変長引数。
         */
        void write(string __format, params object[] __args);
    
    
        /**
         * 指定された文字列を書き込み、末尾に改行を追加します。
         *      @param __word [in]  書き込みたい文字列。
         */
        void writeln(string __word);
        /**
         * 指定されたフォーマットを利用して、オブジェクトの文字列表現を書き込み、
         * 末尾に改行を追加します。
         *      @param  __format [in] 書き込む文字列のフォーマット。
         *      @param  __args   [in] (オブジェクト型の)可変長引数。
         */
        void writeln(string __format, params object[] __args);
    }
}