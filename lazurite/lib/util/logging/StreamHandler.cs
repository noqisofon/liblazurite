using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class StreamHandler : Handler {
        /// <summary>
        /// 
        /// </summary>
        private TextWriter stream_ = null;
        /// <summary>
        /// 
        /// </summary>
        private Formatter formatter_ = null;


        /// <summary>
        /// 
        /// </summary>
        protected TextWriter stream {
            get {
                return stream_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected Formatter formatter {
            get {
                return formatter_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected StreamHandler() {
            this.stream_ = null;
            this.formatter_ = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__input_stream"></param>
        protected StreamHandler(TextWriter __input_stream) {
            this.stream_ = __input_stream;
            this.formatter_ = new SimpleFormatter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__input_stream"></param>
        protected StreamHandler(TextWriter __input_stream, Formatter __formatter) {
            this.stream_ = __input_stream;
            this.formatter_ = __formatter;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__record"></param>
        public override void publish(LogRecord __record) {
            this.stream.WriteLine( this.formatter.format( __record ) );
        }


        /// <summary>
        /// 
        /// </summary>
        public override void close() {
            this.stream.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        public override void flush() {
            this.stream.Flush();
        }
    }
}
