using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;


namespace lazurite.relation.common {


    /// <summary>
    /// �f�[�^�\�[�X�ɋ��ʂ̏�����\�ߎ������Ă��钊�ۃN���X�ł��B
    /// </summary>
    public abstract class AbstractDataSource : DataSource {
        /// <summary>
        /// �ڑ����s���̍ő�҂�����(�����b)�B
        /// </summary>
        private int timeout_ = 15;
        /// <summary>
        /// ���O���C�^�[�B
        /// </summary>
        /// <remarks></remarks>
        private TextWriter log_writer_ = Console.Out;


        /// <summary>
        /// 
        /// </summary>
        public AbstractDataSource() {
        }
        /// <summary>
        /// 
        /// </summary>
        public AbstractDataSource(int __timeout) {
            this.timeout_ = __timeout;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__out"></param>
        public AbstractDataSource(TextWriter __out) {
            this.log_writer_ = __out;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__timeout"></param>
        /// <param name="__out"></param>
        public AbstractDataSource(int __timeout, TextWriter __out) {
            this.timeout_ = __timeout;
            this.log_writer_ = __out;
        }


        /// <summary>
        /// �f�[�^�x�[�X�̐ڑ����s���ɂ��̃f�[�^�\�[�X���ҋ@�ł���Œ����ԂɃA�N�Z�X���܂��B
        /// </summary>
        public int loginTimeout {
            get {
                return timeout_;
            }
            set {
                timeout_ = value;
            }
        }


        /// <summary>
        /// ���̃f�[�^�\�[�X�̃��O���C�^�[�ɃA�N�Z�X���܂��B
        /// </summary>
        public TextWriter logWriter {
            get {
                return log_writer_;
            }
            set {
                log_writer_ = value;
            }
        }


        /// <summary>
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
        /// </summary>
        /// <returns></returns>
        public abstract DbConnection getConnection();


        /// <summary>
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
        /// </summary>
        /// <param name="__username">���[�U�[���B</param>
        /// <param name="__password">���[�U�[�̃p�X���[�h�B</param>
        /// <returns></returns>
        public abstract DbConnection getConnection(string __username, string __password);
    }
}
