using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// ���O���x�����񋟂��鐧��ȏ�Ƀ��O�Ώۂ����ߍׂ������䂷��ׂɎg�p����܂��B
    /// </summary>
    public interface Filter {
        /// <summary>
        /// �w�肳�ꂽ���O���R�[�h���ʒm����邩�ǂ����𒲂ׂ܂��B
        /// </summary>
        bool isLoggable(LogRecord __record);
    }
}
