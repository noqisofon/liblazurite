using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class FileHandler : StreamHandler {
        /// <summary>
        /// 
        /// </summary>
        public FileHandler()
            : base( new StreamWriter( File.Open( string.Format( "./{0:yyyy-MM-ddTHH.mm.ss.FFFFFF}.log", DateTime.Now ), FileMode.Append, FileAccess.Write, FileShare.Read ) ) ) 
        {
            ( (StreamWriter)base.stream ).AutoFlush = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__pattern"></param>
        public FileHandler(string __pattern)
            : base( new StreamWriter( File.Open( __pattern, FileMode.Create ) ) ) 
        {
            //( (StreamWriter)base.stream ).AutoFlush = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__pattern"></param>
        /// <param name="__append"></param>
        public FileHandler(string __pattern, bool __append)
            : base( new StreamWriter( File.Open( __pattern, __append ? FileMode.Append : FileMode.Create ) ) ) 
        {
            //( (StreamWriter)base.stream ).AutoFlush = true;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void close() {
            base.close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__record"></param>
        public override void publish(LogRecord __record) {
            base.publish( __record );
            //base.stream.Flush();
        }
    }
}
