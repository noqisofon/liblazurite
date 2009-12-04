using System;
using System.Text;
using System.IO;


namespace lazurite.util {


    using common = lazurite.common;


    /// <summary>
    /// 
    /// </summary>
    public class FileSearcher {
        /// <summary>
        /// 
        /// </summary>
        private SearchContext context_;
        //private string source_dirname_;


        /// <summary>
        /// 
        /// </summary>
        public FileSearcher() {
            this.context_ = new SearchContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDirName"></param>
        public FileSearcher(string __context_directory_name) {
            this.context_ = new SearchContext( __context_directory_name );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__path"></param>
        /// <param name="__source_directory"></param>
        /// <param name="eachsearching"></param>
        public void doSearchFile(string __source_directroy,
                                  subroutine<SearchContext, FileInfo> __each_searching
                                ) {
            doSearchFile( __source_directroy, "*.*", __each_searching );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__path"></param>
        /// <param name="__source_directory"></param>
        /// <param name="__pattern"></param>
        /// <param name="eachsearching"></param>
        public void doSearchFile(string __source_directory,
                                  string __pattern,
                                  subroutine<SearchContext, FileInfo> __each_searching
                                ) 
        {
            this.context_.createDirectory();
            DirectoryInfo current = new DirectoryInfo( __source_directory );

            if ( current.Exists ) {

                foreach ( DirectoryInfo dir in current.GetDirectories() ) {
                    foreach ( FileInfo file in dir.GetFiles() ) {
                        if ( file.Exists ) {
                            __each_searching( this.context_, file );
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public class SearchContext {
            /// <summary>
            /// コピー用のディレクトリ。
            /// </summary>
            private DirectoryInfo current_dir_;
            /// <summary>
            /// 
            /// </summary>
            //private TextWriter writer_ = null;


            /// <summary>
            /// 
            /// </summary>
            public SearchContext() {
                this.current_dir_ = new DirectoryInfo( Directory.GetCurrentDirectory() );
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="__dirname"></param>
            public SearchContext(string __dirname) {
                this.current_dir_ = new DirectoryInfo( __dirname );
            }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public DirectoryInfo createDirectory() {
                if ( !this.current_dir_.Exists ) {
                    // ディレクトリが無かったらディレクトリを作成します。
                    this.current_dir_.Create();

                    return this.current_dir_;
                }
                return null;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="__directory_name"></param>
            /// <returns></returns>
            public DirectoryInfo createDirectory(string __directory_name) {
                DirectoryInfo created_dir = this.current_dir_.CreateSubdirectory( __directory_name );
                if ( !created_dir.Exists ) {
                    // ディレクトリが無かったらディレクトリを作成します。
                    created_dir.Create();

                    return created_dir;
                }
                return null;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public DirectoryInfo createTargetDirectory() {
                return new DirectoryInfo( this.current_dir_.FullName );
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="directory_names"></param>
            /// <returns></returns>
            public FileInfo createLocalPath(params string[] directory_names) {
                StringBuilder path_builder = new StringBuilder( this.current_dir_.Name );

                foreach ( string directory_name in directory_names ) {
                    path_builder.AppendFormat( "{0}/", directory_name );
                }

                return new FileInfo( path_builder.ToString() );
            }


            /// <summary>
            /// 
            /// </summary>
            public string targetPath {
                get {
                    return current_dir_.FullName;
                }
            }
        }
    }
}
