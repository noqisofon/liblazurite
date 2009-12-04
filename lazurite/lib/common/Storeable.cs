namespace lazurite.common {


    /// <summary>
    /// IStorage �C���^�[�t�F�C�X�ƈႢ�A�i�[����@�\���������C���^�[�t�F�C�X�ł��B
    /// </summary>
    /// <typeparam name="_Article"></typeparam>
    public interface Storeable<_Article> {
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g���i�[���܂��B
        /// </summary>
        /// <param name="__stored_article"></param>
        void store(_Article __stored_article);
        
        
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�̔z��̗v�f��S�Ċi�[���܂��B
        /// </summary>
        /// <param name="__stored_articles"></param>
        void storeAll(_Article[] __stored_articles);
        
        
        /// <summary>
        /// ���L���Ă���v�f�̐���Ԃ��܂��B
        /// </summary>
        int entries { get; }
    }


    /// <summary>
    /// IStorage �C���^�[�t�F�C�X�ƈႢ�A�i�[����@�\���������C���^�[�t�F�C�X�ł��B
    /// </summary>
    /// <typeparam name="_This">���̃C���^�[�t�F�C�X�����������N���X�B</typeparam>
    /// <typeparam name="_Article"></typeparam>
    public interface Storeable<_This, _Article> {
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g���i�[���܂��B
        /// </summary>
        /// <param name="__stored_article"></param>
        /// <returns></returns>
        _This store(_Article __stored_article);


        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�̔z��̗v�f��S�Ċi�[���܂��B
        /// </summary>
        /// <param name="__stored_articles"></param>
        /// <returns></returns>
        _This storeAll(_Article[] __stored_articles);


        /// <summary>
        /// ���L���Ă���v�f�̐���Ԃ��܂��B
        /// </summary>
        int entries { get; }
    }
}
