using System;
using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// ADO.NET �Ŏg�p����ڑ�������ׂ̈̃p�����[�^���`���܂��B
    /// </summary>
    public interface IADODataSource : DataSource {
        /// <summary>
        /// �ڑ�����v���o�C�_�[�̖��O�ɃA�N�Z�X���܂��B
        /// </summary>
        string dataSource {
            get;
            set;
        }


        /// <summary>
        /// �ڑ�����Ƃ��Ɏg���F�؂̃Z�L�����e�B�̗L���ɃA�N�Z�X���܂��B
        /// </summary>
        bool integralSecurity {
            get;
            set;
        }


        /// <summary>
        /// �ڑ�����f�[�^�x�[�X���ɃA�N�Z�X���܂��B
        /// </summary>
        string initialCatalog {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        string providerName {
            get;
        }
    }
}
