using System;
using System.IO;
using System.Text;


namespace lazurite.util.searching {
    /// <summary>
    /// 
    /// </summary>
    public class SearchEvent : common.Event {
        /// <summary>
        /// 
        /// </summary>
        private TextWriter writer_;
        /// <summary>
        /// 
        /// </summary>
        private FileSystemInfo content_;


        /// <summary>
        /// 
        /// </summary>
        public TextWriter output {
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
        public FileSystemInfo content {
            get {
                return content_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source"></param>
        /// <param name="__content"></param>
        public SearchEvent(object __source, FileSystemInfo __content)
            : base( __source ) 
        {
            this.writer_ = null;
            this.content_ = __content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__writer"></param>
        /// <param name="__content"></param>
        public SearchEvent(object __source, TextWriter __writer, FileSystemInfo __content) 
            : base(__source)
        {
            this.writer_ = __writer;
            this.content_ = __content;
        }
    }
}
