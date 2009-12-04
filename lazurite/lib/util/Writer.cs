using System;
using System.IO;
using System.Text;


namespace lazurite.util {


    using lazurite.common;


    /// <summary>
    /// Writer クラスは、TextWriter によるファイルストリームへの書き込みへの
    /// 簡潔なインターフェイスを提供します。
    /// </summary>
    public class Writer : Writable {
        /// ファイルを作成するパスです。
        private DirectoryInfo filepath_ = null;
        /// ファイル名です。
        private string filename_ = null;
        /// テキスト単位でファイルに書き込むオブジェクトです。
        private TextWriter writer_ = null;
        /// エラー時に呼び出されるデリゲートです。
        private subroutine<Exception> settlement_ = delegate(Exception __e) {
            Logger logger = new Logger( __e );
            logger.write();
        };
        private bool is_closed_ = false;


        /**
         * 書き込む対象のファイル名を受け取って Writer オブジェクトを
         * 新しく作成します。
         */
        public Writer(string __filename) {
            this.filepath_ = new DirectoryInfo( Directory.GetCurrentDirectory() );
            this.filename_ = __filename;

            createDirectory();
            createWriter();
        }
        /**
         * フォルダ名と、書き込む対象のファイル名を受け取って 
         * Writer オブジェクトを新しく作成します。
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
         * ディレクトリを作成します。
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
         * デフォルトのエンコード(Shift_JIS)でライターオブジェクトを作成します。
         *      @return 成功したら真。
         */
        protected bool createWriter() {
            return createWriter( "Shift_JIS" );
        }
        /**
         * 指定されたキャラクターセットを利用してライターオブジェクトを作成します。
         *      @param __charset キャラクターセットを識別する文字列。
         *
         *      @return 成功したら真。
         */
        protected bool createWriter(string __charset) {
            return createWriter( Encoding.GetEncoding( __charset ) );
        }
        /**
         * 指定されたエンコードを利用してライターオブジェクトを作成します。
         *      @param  __enc エンコードオブジェクト。
         *
         *      @return 成功したら真。
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
         * 書き込めるかどうか判別します。
         */
        public bool can_write() {
            return this.writer_ != null;
        }


        /**
         * 指定された文字列を書き込みます。
         * @param __word 書き込みたい文字列。
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
         * 指定されたフォーマットを使用してオブジェクトの文字列表現を書き込みます。
         *      @param  __format    文字列のフォーマット。
         *      @param  __args      オブジェクト。
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
         * 指定された文字列を書き込んだあとに改行します。
         * @param __word 書き込みたい文字列。
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
         * 指定されたフォーマットを使用してオブジェクトの文字列表現を書き込んだあとに改行します。
         *      @param  __format    文字列のフォーマット。
         *      @param  __args      オブジェクト。
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
        /// ファイル・ストリームを閉じます。
        /// </summary>
        public void close() {
            if ( !is_closed ) {
                this.writer_.Close();
                this.is_closed_ = true;
            }
        }


        /// <summary>
        /// 例外がスローされたら呼ばれます。
        /// </summary>
        /// <param name="__e"></param>
        protected void onError(Exception __e) {
            this.settlement_( __e );
        }


        /// <summary>
        /// onError()で呼び出されるデリゲートを取得・設定します。
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
}//此の