using System;
using System.IO;
using System.Text;


namespace lazurite.util.searching {

    /// <summary>
    /// 
    /// </summary>
    public class FileSearcherEx {
        /// <summary>
        /// 
        /// </summary>
        DirectoryInfo current_dir_;
        /// <summary>
        /// 
        /// </summary>
        TextWriter writer_ = null;


        /// <summary>
        /// 
        /// </summary>
        protected TextWriter output {
            get {
                return writer_;
            }
            set {
                writer_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public FileSearcherEx(string __source_path) {
            this.current_dir_ = new DirectoryInfo( __source_path );
        }
        /// <summary>
        /// 
        /// </summary>
        public FileSearcherEx(DirectoryInfo __source_path) {
            this.current_dir_ = __source_path;
        }
        /// <summary>
        /// 
        /// </summary>
        public FileSearcherEx(string __source_path, TextWriter __writer) {
            this.current_dir_ = new DirectoryInfo( __source_path );
            this.writer_ = __writer;
        }
        /// <summary>
        /// 
        /// </summary>
        public FileSearcherEx(DirectoryInfo __source_path, TextWriter __writer) {
            this.current_dir_ = __source_path;
            this.writer_ = __writer;
        }


        /// <summary>
        /// 
        /// </summary>
        public void do_search() {
            onSearchStart( new SearchEvent( this, this.writer_, this.current_dir_ ) );

            foreach ( DirectoryInfo dir in this.current_dir_.GetDirectories() ) {
                SearchEvent dir_se = new SearchEvent( this, this.writer_, dir );

                onFolderChanging( dir_se );

                FileInfo[] files = dir.GetFiles();
                if ( files.Length > 0 ) {
                    foreach ( FileInfo file in files ) {
                        onFinded( new SearchEvent( this, this.writer_, file ) );
                    }
                } else {
                    onNotFound( dir_se );
                }

            }
            onSearchCompleted( new SearchEvent( this, this.writer_, this.current_dir_ ) );
        }


        /// <summary>
        /// 
        /// </summary>
        public event SearcherHandler searchStart;
        /// <summary>
        /// 
        /// </summary>
        public event SearcherHandler finded;
        /// <summary>
        /// 
        /// </summary>
        public event SearcherHandler notFound;
        /// <summary>
        /// 
        /// </summary>
        public event SearcherHandler folderChanging;
        /// <summary>
        /// 
        /// </summary>
        public event SearcherHandler searchCompleted;


        /// <summary>
        /// 
        /// </summary>
        protected virtual void onSearchStart(SearchEvent e) {
            if ( !this.current_dir_.Exists ) {
                this.current_dir_.Create();
            }
            if ( searchStart != null ) {
                searchStart( e );
            }
        }


        protected virtual void onFolderChanging(SearchEvent e) {
            if ( folderChanging != null ) {
                folderChanging( e );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onFinded(SearchEvent e) {
            if ( finded != null ) {
                finded( e );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onNotFound(SearchEvent e) {
            if ( notFound != null ) {
                notFound( e );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void onSearchCompleted(SearchEvent e) {
            if ( searchCompleted != null ) {
                searchCompleted( e );
            }
        }
    }


}