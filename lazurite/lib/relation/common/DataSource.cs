using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// �f�[�^�\�[�X�ւ̐ڑ��ɑ΂���t�@�N�g���[�C���^�[�t�F�C�X�ł��B
    /// </summary>
    public interface DataSource : CommonDataSource {
        /// <summary>
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
        /// </summary>
        /// <returns></returns>
        DbConnection getConnection();


        /// <summary>
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
        /// </summary>
        /// <param name="__username">���[�U�[���B</param>
        /// <param name="__password">���[�U�[�̃p�X���[�h�B</param>
        /// <returns></returns>
        DbConnection getConnection(string __username, string __password);
    }
}