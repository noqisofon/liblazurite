using System;
using System.IO;
using System.Text;


namespace lazurite.util {


    using lazurite.common;


    /// <summary>
    /// Writer �N���X�́ATextWriter �ɂ��t�@�C���X�g���[���ւ̏������݂ւ�
    /// �Ȍ��ȃC���^�[�t�F�C�X��񋟂��܂��B
    /// </summary>
    public class Writer : Writable {
        /// �t�@�C�����쐬����p�X�ł��B
        private DirectoryInfo filepath_ = null;
        /// �t�@�C�����ł��B
        private string filename_ = null;
        /// �e�L�X�g�P�ʂŃt�@�C���ɏ������ރI�u�W�F�N�g�ł��B
        private TextWriter writer_ = null;
        /// �G���[���ɌĂяo�����f���Q�[�g�ł��B
        private subroutine<Exception> settlement_ = delegate(Exception __e) {
            Logger logger = new Logger( __e );
            logger.write();
        };
        private bool is_closed_ = false;


        /**
         * �������ޑΏۂ̃t�@�C�������󂯎���� Writer �I�u�W�F�N�g��
         * �V�����쐬���܂��B
         */
        public Writer(string __filename) {
            this.filepath_ = new DirectoryInfo( Directory.GetCurrentDirectory() );
            this.filename_ = __filename;

            createDirectory();
            createWriter();
        }
        /**
         * �t�H���_���ƁA�������ޑΏۂ̃t�@�C�������󂯎���� 
         * Writer �I�u�W�F�N�g��V�����쐬���܂��B
         */
        public Writer(string __folderName, string __filename) {
            string[] dirnames = __folderName.Split( '\\' );
            string dirname = ( dirnames.Length > 0 ) ? dirnames[dirnames.Length - 1] : __filename;
            this.filepath_ = new DirectoryInfo( Directory.GetCurrentDirectory() + "\\" + dirname );
            this.filename_ = __filename;

            createDirectory();
            createWriter();
        }


        /**
         * �f�B���N�g�����쐬���܂��B
         */
        public bool createDirectory() {
            bool test = false;
            if ( !this.filepath_.Exists ) {
                try {
                    this.filepath_.Create();
                    test = true;
                } catch ( IOException e ) {
                    onError( e );
                }
            }
            return test;
        }


        /**
         * �f�t�H���g�̃G���R�[�h(Shift_JIS)�Ń��C�^�[�I�u�W�F�N�g���쐬���܂��B
         *      @return ����������^�B
         */
        protected bool createWriter() {
            return createWriter( "Shift_JIS" );
        }
        /**
         * �w�肳�ꂽ�L�����N�^�[�Z�b�g�𗘗p���ă��C�^�[�I�u�W�F�N�g���쐬���܂��B
         *      @param __charset �L�����N�^�[�Z�b�g�����ʂ��镶����B
         *
         *      @return ����������^�B
         */
        protected bool createWriter(string __charset) {
            return createWriter( Encoding.GetEncoding( __charset ) );
        }
        /**
         * �w�肳�ꂽ�G���R�[�h�𗘗p���ă��C�^�[�I�u�W�F�N�g���쐬���܂��B
         *      @param  __enc �G���R�[�h�I�u�W�F�N�g�B
         *
         *      @return ����������^�B
         */
        protected bool createWriter(Encoding __encoding) {
            string path = this.filename_;
            if ( this.filepath_.FullName != Directory.GetCurrentDirectory() ) {
                path = this.filepath_.FullName + "\\" + path;
            }

            FileMode mode = FileMode.Create;
            if ( File.Exists( path ) ) {
                mode = FileMode.Append;
            }

            FileStream stream = File.Open( path,
                                           mode,
                                           FileAccess.Write
                                         );
            this.writer_ = new StreamWriter( stream, __encoding );

            return true;
        }


        /**
         * �������߂邩�ǂ������ʂ��܂��B
         */
        public bool can_write() {
            return this.writer_ != null;
        }


        /**
         * �w�肳�ꂽ��������������݂܂��B
         * @param __word �������݂���������B
         */
        public void write(string __writed_word) {
            try {
                this.writer_.Write( __writed_word );
            } catch ( NullReferenceException e ) {
                onError( e );
            } catch ( IOException e ) {
                onError( e );
            }
        }


        /**
         * �w�肳�ꂽ�t�H�[�}�b�g���g�p���ăI�u�W�F�N�g�̕�����\�����������݂܂��B
         *      @param  __format    ������̃t�H�[�}�b�g�B
         *      @param  __args      �I�u�W�F�N�g�B
         */
        public void write(string __format, params object[] __args) {
            try {
                this.writer_.Write( __format, __args );
            } catch ( NullReferenceException e ) {
                onError( e );
            } catch ( IOException e ) {
                onError( e );
            }
        }


        /**
         * �w�肳�ꂽ��������������񂾂��Ƃɉ��s���܂��B
         * @param __word �������݂���������B
         */
        public void writeln(string __word) {
            try {
                this.writer_.WriteLine( __word );
            } catch ( NullReferenceException e ) {
                onError( e );
            } catch ( IOException e ) {
                onError( e );
            }
        }
        /**
         * �w�肳�ꂽ�t�H�[�}�b�g���g�p���ăI�u�W�F�N�g�̕�����\�����������񂾂��Ƃɉ��s���܂��B
         *      @param  __format    ������̃t�H�[�}�b�g�B
         *      @param  __args      �I�u�W�F�N�g�B
         */
        public void writeln(string __format, params object[] __arg) {
            try {
                this.writer_.WriteLine( __format, __arg );
            } catch ( NullReferenceException e ) {
                onError( e );
            } catch ( IOException e ) {
                onError( e );
            }
        }


        /// <summary>
        /// �t�@�C���E�X�g���[������܂��B
        /// </summary>
        public void close() {
            if ( !is_closed ) {
                this.writer_.Close();
                this.is_closed_ = true;
            }
        }


        /// <summary>
        /// ��O���X���[���ꂽ��Ă΂�܂��B
        /// </summary>
        /// <param name="__e"></param>
        protected void onError(Exception __e) {
            this.settlement_( __e );
        }


        /// <summary>
        /// onError()�ŌĂяo�����f���Q�[�g���擾�E�ݒ肵�܂��B
        /// </summary>
        public subroutine<Exception> settlement {
            get { 
                return settlement_; 
            }
            set { 
                settlement_ = value; 
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool is_closed {
            get { return this.is_closed_; }
        }
    }
}//����