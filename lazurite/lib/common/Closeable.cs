namespace lazurite.common {
    /**
     * 
     */
    public interface Closable {
        /**
         * �R���e�L�X�g����܂��B
         */
        void close();


        /**
         * ���Ă��邩�ǂ������ׂ܂��B
         */
        bool is_closed { get; }
    }
}
