namespace lazurite.common {



    /**
     * �R���e�L�X�g�ɏ������ރC���^�[�t�F�[�X��񋟂��܂��B
     */
    public interface Writable {
        /**
         * �������߂邩�ǂ������ʂ��܂��B
         *      @return �������ނ��Ƃ��ł�����^�B
         */
        bool can_write();
        
        
        /**
         * �w�肳�ꂽ��������������݂܂��B
         *      @param __word [in]  �������݂���������B
         */
        void write(string __word);
        /**
         * �w�肳�ꂽ�t�H�[�}�b�g�𗘗p���āA�I�u�W�F�N�g�̕�����\�����������݂܂��B
         *      @param  __format [in] �������ޕ�����̃t�H�[�}�b�g�B
         *      @param  __args   [in] (�I�u�W�F�N�g�^��)�ϒ������B
         */
        void write(string __format, params object[] __args);
    
    
        /**
         * �w�肳�ꂽ��������������݁A�����ɉ��s��ǉ����܂��B
         *      @param __word [in]  �������݂���������B
         */
        void writeln(string __word);
        /**
         * �w�肳�ꂽ�t�H�[�}�b�g�𗘗p���āA�I�u�W�F�N�g�̕�����\�����������݁A
         * �����ɉ��s��ǉ����܂��B
         *      @param  __format [in] �������ޕ�����̃t�H�[�}�b�g�B
         *      @param  __args   [in] (�I�u�W�F�N�g�^��)�ϒ������B
         */
        void writeln(string __format, params object[] __args);
    }
}