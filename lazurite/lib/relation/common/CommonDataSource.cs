using System.IO;


namespace lazurite.relation.common {


    /// <summary>
    /// DataSource �ɋ��ʂ̃v���p�e�B���`���܂��B
    /// </summary>
    public interface CommonDataSource {
        /// <summary>
        /// �f�[�^�x�[�X�̐ڑ����s���ɂ��̃f�[�^�\�[�X���ҋ@�ł���Œ����ԂɃA�N�Z�X���܂��B
        /// </summary>
        int loginTimeout {
            get;
            set;
        }


        /// <summary>
        /// ���̃f�[�^�\�[�X�̃��O���C�^�[�ɃA�N�Z�X���܂��B
        /// </summary>
        TextWriter logWriter {
            get;
            set;
        }

    }
}