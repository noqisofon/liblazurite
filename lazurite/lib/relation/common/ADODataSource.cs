using System;
using System.Data;
using System.Data.Common;


namespace lazurite.relation.common {


    /// <summary>
    /// 
    /// </summary>
    public abstract class ADODataSource : AbstractDataSource, IADODataSource {
        /// <summary>
        /// �ڑ�����f�[�^�x�[�X�̖��O(initial catalog)�ł��B
        /// </summary>
        protected string initial_catalog_;
        /// <summary>
        /// �ڑ�����f�[�^�x�[�X�V�X�e���̃C���X�^���X���A�܂��̓l�b�g���[�N�A�h���X(data source)�ł��B
        /// </summary>
        protected string data_source_;
        /// <summary>
        /// SQL Server �F�؂ɂ��邩�A���[�U�[���A�p�X���[�h�̗v��Ȃ� Windows �F�؂ɂ��邩�����߂܂��B
        /// </summary>
        /// <remarks>false �Ȃ�SQL Server �F�؁Atrue �Ȃ� Windows �F�؁B</remarks>
        protected bool integrated_security_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__data_source"></param>
        /// <param name="__integrated_security"></param>
        public ADODataSource(string __initial_catalog, string __data_source, bool __integrated_security) {
            this.initial_catalog_ = __initial_catalog;
            this.data_source_ = __data_source;
            this.integrated_security_ = __integrated_security;
        }


        /// <summary>
        /// �ڑ�����v���o�C�_�[�̖��O�ɃA�N�Z�X���܂��B
        /// </summary>
        public string dataSource {
            get {
                return data_source_;
            }
            set {
                data_source_ = value;
            }
        }


        /// <summary>
        /// �ڑ�����Ƃ��Ɏg���F�؂̃Z�L�����e�B�̗L���ɃA�N�Z�X���܂��B
        /// </summary>
        public bool integralSecurity {
            get {
                return integrated_security_;
            }
            set {
                integrated_security_ = value;
            }
        }


        /// <summary>
        /// �ڑ�����f�[�^�x�[�X���ɃA�N�Z�X���܂��B
        /// </summary>
        public string initialCatalog {
            get {
                return initial_catalog_;
            }
            set {
                initial_catalog_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public abstract string providerName {
            get;
        }
    }
}
