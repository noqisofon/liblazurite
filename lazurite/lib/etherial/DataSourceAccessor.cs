using System;
using System.Data;
using System.Data.Common;


namespace lazurite.etherial {


    /// <summary>
    /// 
    /// </summary>
    public class DataSourceConnectEventArgs : EventArgs {
        private DbConnection connection_;


        /// <summary>
        /// 
        /// </summary>
        public DataSourceConnectEventArgs(DbConnection __connection) {
            this.connection_ = __connection;
        }


        /// <summary>
        /// 
        /// </summary>
        public DbConnection connection {
            get {
                return connection_;
            }
        }
    }


    /// <summary>
    /// DataSourceConnect �C�x���g���������郁�\�b�h��\���܂��B
    /// </summary>
    /// <param name="__sender"></param>
    /// <param name="__dscea"></param>
    public delegate void DataSourceConnectEventHandler(object __sender, DataSourceConnectEventArgs __dscea);


    /// <summary>
    /// �f�[�^�\�[�X�ւ̃A�N�Z�X�������肵�A�C�x���g�Ńe�[�u���ւ̃A�N�Z�X��񋟂��܂��B
    /// </summary>
    public class DataSourceAccessor {


        /// <summary>
        /// �f�[�^�\�[�X�ւ̐ڑ����I�������Ƃ��ɌĂяo����܂��B
        /// </summary>
        public event DataSourceConnectEventHandler connecting;


        /// <summary>
        /// �ڑ��I�u�W�F�N�g�쐬�p�B
        /// </summary>
        private utils.ConnectionFactory factory_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        public DataSourceAccessor(utils.ConnectionFactory __factory) {
            this.factory_ = __factory;
        }


        /// <summary>
        /// �f�[�^�x�[�X�ւ̐ڑ����J���܂��B
        /// </summary>
        public void connect() {
            onConnecting();
        }


        /// <summary>
        /// connecting �C�x���g�𔭐������܂��B
        /// </summary>
        protected virtual void onConnecting() {
            if ( this.connecting != null ) {
                using ( DbConnection connection = factory_.get_connection() ) {

                    if ( connection.State == ConnectionState.Closed ) {
                        // �����Ă�����J���܂��B
                        connection.Open();
                    }

                    // 
                    this.connecting( this, new DataSourceConnectEventArgs( connection ) );
                }
            }
        }


        /// <summary>
        /// �����Ŏg�p���Ă���ڑ��I�u�W�F�N�g�t�@�N�g���[��Ԃ��܂��B
        /// </summary>
        public utils.ConnectionFactory factory {
            get {
                return factory_;
            }
        }
    }

}