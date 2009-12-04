namespace lazurite.common {
    
    
    /// <summary>
    /// �I�u�W�F�N�g��ۊǂ��Ă������߂̃��\�b�h��񋟂��܂��B
    /// </summary>
    /// <typeparam name="_Colleague">�ۊǂ����I�u�W�F�N�g�̌^�B</typeparam>
    public interface IStorage<_Colleague> {
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g��ǉ����܂��B
        /// </summary>
        /// <param name="__appended">�ǉ��������I�u�W�F�N�g�B</param>
        void append(_Colleague __appended);
        
        
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�̔z���ǉ����܂��B
        /// </summary>
        /// <param name="__appendeds">�ǉ��������I�u�W�F�N�g�̔z��B</param>
        /// <returns>�ǉ��������B</returns>
        int appendAll(_Colleague[] __appendeds);
        

        /// <summary>
        /// �I�u�W�F�N�g���w�肳�ꂽ�ʒu�ɑ}�����܂��B
        /// </summary>
        /// <param name="__insert_index">�}���������ʒu�B</param>
        /// <param name="__inserted">�}���������I�u�W�F�N�g�B</param>
        void insert(int __insert_index, _Colleague __inserted);
        
        
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�����݂���ŏ��̈ʒu��Ԃ��܂��B
        /// </summary>
        /// <param name="__that">���ׂ����I�u�W�F�N�g�B</param>
        /// <returns>�ŏ��̈ʒu�B</returns>
        int indexOf(_Colleague __that);
        

        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�����݂��邩�ǂ������ׂ܂��B
        /// </summary>
        /// <param name="__that">���ׂ����I�u�W�F�N�g�B</param>
        /// <returns></returns>
        bool contains(_Colleague __that);


        /// <summary>
        /// �w�肷��I�u�W�F�N�g�̔z��̗v�f�����݂��邩�ǂ������ׂ܂��B
        /// </summary>
        /// <param name="__thats">�I�u�W�F�N�g�̔z��̗v�f�B</param>
        /// <returns>�S����������^�B</returns>
        bool containsAll(_Colleague[] __thats);


        /// <summary>
        /// �ۊǂ��Ă����I�u�W�F�N�g��z��ɂ��ĕԂ��܂��B
        /// </summary>
        /// <returns>���V�[�o�̒��g�̔z��B</returns>
        _Colleague[] to_a();
        

        /// <summary>
        /// �ۊǂ���Ă���I�u�W�F�N�g�̐����擾���܂��B
        /// </summary>
        int entries { get; }
    }
}