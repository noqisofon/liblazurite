using System;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// 特定のシステムコンポーネントやアプリケーションコンポーネントなどのメッセージをロギングするために使用されます。
    /// </summary>
    public class Logger {
        /// <summary>
        /// 
        /// </summary>
        private string name_;
        /// <summary>
        /// 
        /// </summary>
        private List<Handler> handlers_ = new List<Handler>();
        /// <summary>
        /// 
        /// </summary>
        private Level level_ = Level.FINER;
        /// <summary>
        /// 
        /// </summary>
        private Filter filter_ = null;


        /// <summary>
        /// 
        /// </summary>
        private static Logger __global = new Logger( new ConsoleHandler() );


        /// <summary>
        /// 
        /// </summary>
        public string name {
            get {
                return name_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Filter filter {
            get {
                return filter_;
            }
            set {
                filter_ = value;
            }
        }


        public Level level {
            get {
                return level_;
            }
            set {
                level_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static Logger global {
            get {
                return __global;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static string globalName {
            get {
                return "::global::";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__default_handler"></param>
        private Logger(Handler __default_handler) {
            this.name_ = Logger.globalName;
            this.addHandler( __default_handler );
        }
        /// <summary>
        /// 
        /// </summary>
        protected Logger(string __name) {
            this.name_ = __name;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__handler"></param>
        public void addHandler(Handler __handler) {
            this.handlers_.Add( __handler );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void config(string __message) {
            log( Level.CONFIG, __message );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <param name="__param1"></param>
        public void config(string __message, object __param1) {
            config( string.Format( __message, __param1 ) );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <param name="__params"></param>
        public void config(string __message, params object[] __params) {
            config( string.Format( __message, __params ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        public void entering(string __source_class, string __source_method) {
            log( Level.FINER, __source_class, __source_method, "entering" );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__param1"></param>
        public void entering(string __source_class, string __source_method, object __param1) {
            log( Level.FINER, __source_class, __source_method, "entering {0} ", __param1 );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__params"></param>
        public void entering(string __source_class, string __source_method, params object[] __params) {
            StringBuilder message_builder = new StringBuilder();
            message_builder.Append( "entering " );
            foreach ( object param in __params ) {
                message_builder.AppendFormat( "{0} ", param );
            }
            log( Level.FINER, __source_class, __source_method, message_builder.ToString() );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        public void exiting(string __source_class, string __source_method) {
            log( Level.FINER, __source_class, __source_method, "exiting" );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__result"></param>
        public void exiting(string __source_class, string __source_method, object __result) {
            log( Level.FINER, __source_class, __source_method, "exiting returns {0}", __result );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void fine(string __message) {
            log( Level.FINE, __message );
        }
        public void fine(string __format, params object[] __params) {
            fine( string.Format( __format, __params ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void finer(string __message) {
            log( Level.FINER, __message );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__format"></param>
        /// <param name="__params"></param>
        public void finer(string __format, params object[] __params) {
            finer( string.Format( __format, __params ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void finest(string __message) {
            log( Level.FINEST, __message );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__format"></param>
        /// <param name="__params"></param>
        public void finest(string __format, params object[] __params) {
            finest( string.Format( __format, __params ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void info(string __message) {
            log( Level.INFO, __message );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <param name="__param1"></param>
        public void info(string __message, object __param1) {
            info( string.Format( __message, __param1 ) );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        /// <param name="__params"></param>
        public void info(string __message, params object[] __params) {
            info( string.Format( __message, __params ) );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void log(Level __level, string __message) {
            LogRecord record = new LogRecord( __level, __message );
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__message"></param>
        /// <param name="__thrown"></param>
        public void log(Level __level, string __message, Exception __thrown) {
            LogRecord record = new LogRecord( __level, __message );
            record.thrown = __thrown;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__message"></param>
        /// <param name="__param1"></param>
        public void log(Level __level, string __message, object __param1) {
            LogRecord record = new LogRecord( __level, string.Format( __message, __param1 ) );
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__message"></param>
        /// <param name="__params"></param>
        public void log(Level __level, string __message, params object[] __params) {
            LogRecord record = new LogRecord( __level, string.Format( __message, __params ) );
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__thrown"></param>
        public void log(Level __level, string __source_class, string __source_method) {
            LogRecord record = new LogRecord( __level, string.Empty );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__message"></param>
        public void log(Level __level, string __source_class, string __source_method, string __message) {
            LogRecord record = new LogRecord( __level, __message );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__message"></param>
        /// <param name="__param1"></param>
        public void log(Level __level, string __source_class, string __source_method, string __message, object __param1) {
            LogRecord record = new LogRecord( __level, string.Format( __message, __param1 ) );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__message"></param>
        /// <param name="__params"></param>
        public void log(Level __level, string __source_class, string __source_method, string __message, params object[] __params) {
            LogRecord record = new LogRecord( __level, string.Format( __message, __params ) );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__thrown"></param>
        public void log(Level __level, string __source_class, string __source_method, Exception __thrown) {
            LogRecord record = new LogRecord( __level, string.Empty );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            record.thrown = __thrown;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__message"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__thrown"></param>
        public void log(Level __level, string __source_class, string __source_method, string __message, Exception __thrown) {
            LogRecord record = new LogRecord( __level, __message );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            record.thrown = __thrown;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__message"></param>
        /// <param name="__param1"></param>
        /// <param name="__thrown"></param>
        public void log(Level __level, string __source_class, string __source_method, string __message, object __param1, Exception __thrown) {
            LogRecord record = new LogRecord( __level, string.Format( __message, __param1 ) );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            record.thrown = __thrown;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__message"></param>
        /// <param name="__thrown"></param>
        /// <param name="__params"></param>
        public void log(Level __level, string __source_class, string __source_method, string __message, Exception __thrown, object[] __params) {
            LogRecord record = new LogRecord( __level, string.Format( __message, __params ) );
            record.sourceClassName = __source_class;
            record.sourceMethodName = __source_method;
            record.thrown = __thrown;
            log( record );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__record"></param>
        public void log(LogRecord __record) {
            if ( isLoggable( __record.level ) ) {
                foreach ( Handler handler in handlers_ ) {
                    handler.publish( __record );
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__thrown"></param>
        public void throwing(string __source_class, string __source_method, Exception __thrown) {
            log( Level.WARNING, __source_class, __source_method, __thrown );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source_class"></param>
        /// <param name="__source_method"></param>
        /// <param name="__message"></param>
        /// <param name="__thrown"></param>
        public void throwing(string __source_class, string __source_method, string __message, Exception __thrown) {
            log( Level.WARNING, __source_class, __source_method, __message, __thrown );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void severe(string __message) {
            log( Level.SEVERE, __message );//疑問
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public void warning(string __message) {
            log( Level.WARNING, __message );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__level"></param>
        /// <returns></returns>
        public bool isLoggable(Level __level) {
            return this.level_.intValue() <= __level.intValue();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Logger getLogger(string __name) {
            LogManager manager = LogManager.getLogManager();

            return manager.getLogger( __name );
        }
    }
}
