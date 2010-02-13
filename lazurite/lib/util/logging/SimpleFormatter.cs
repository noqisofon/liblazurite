using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace lazurite.util.logging {


    /// <summary>
    /// 
    /// </summary>
    public class SimpleFormatter : Formatter {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__record"></param>
        /// <returns></returns>
        public override string format(LogRecord __record) {
            StringBuilder message_builder = new StringBuilder();
            message_builder.AppendFormat( "{0}. {1:o} {2}: ",
                                          __record.sequenceNumber,
                                          __record.registerTime,
                                          __record.level.localizedName
                                        );
            if ( __record.sourceClassName.Length > 0 ) {
                message_builder.AppendFormat( "{0}#", __record.sourceClassName );
            }
            if ( __record.sourceMethodName.Length > 0 ) {
                message_builder.AppendFormat( "{0} - ", __record.sourceMethodName );
            }
            if ( __record.message.Length > 0 ) {
                message_builder.AppendFormat( "{0}", __record.message );
            }
            if ( __record.thrown != null ) {
                message_builder.Append( __record.thrown );
                if ( __record.thrown.Data != null ) {
                    foreach ( DictionaryEntry entry in __record.thrown.Data ) {
                        message_builder.AppendFormat( "{0}=>{1}, ", entry.Key, entry.Value );
                    }
                }
            }

            return message_builder.ToString();
        }
    }
}
