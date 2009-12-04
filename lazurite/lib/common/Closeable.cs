namespace lazurite.common {
    /**
     * 
     */
    public interface Closable {
        /**
         * コンテキストを閉じます。
         */
        void close();


        /**
         * 閉じているかどうか調べます。
         */
        bool is_closed { get; }
    }
}
