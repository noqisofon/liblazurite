using System;


namespace lazurite.util.logging {


    /// <summary>
    /// ログのフレームワークと個々のログ Handler 間のロギングの要求を渡します。
    /// </summary>
    public class LogRecord {
        /// <summary>
        /// 
        /// </summary>
        private Level level_;
        /// <summary>
        /// 
        /// </summary>
        private long sequence_number_;
        /// <summary>
        /// 
        /// </summary>
        private string message_;
        /// <summary>
        /// 
        /// </summary>
        private DateTime register_time_;
        /// <summary>
        /// 
        /// </summary>
        private string source_class_name_;
        /// <summary>
        /// 
        /// </summary>
        private string source_method_name_;
        /// <summary>
        /// 
        /// </summary>
        private Exception thrown_;


        /// <summary>
        /// 
        /// </summary>
        private static long CurrentSequenceNumber = 0;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__message"></param>
        public LogRecord(Level __level, string __message) {
            this.level_ = __level;
            this.sequence_number_ = CurrentSequenceNumber++;
            this.message_ = __message;
            this.register_time_ = DateTime.Now;
            this.source_class_name_ = string.Empty;
            this.source_method_name_ = string.Empty;
            this.thrown_ = null;
        }


        /// <summary>
        /// 
        /// </summary>
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
        public long sequenceNumber {
            get {
                return sequence_number_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string message {
            get {
                return message_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public DateTime registerTime {
            get {
                return register_time_;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string sourceClassName {
            get {
                return source_class_name_;
            }
            set {
                source_class_name_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string sourceMethodName {
            get {
                return source_method_name_;
            }
            set {
                source_method_name_ = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Exception thrown {
            get {
                return thrown_;
            }
            set {
                thrown_ = value;
            }
        }
    }
}