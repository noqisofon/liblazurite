using System;
using System.Text;
using System.IO;


namespace lazurite.util {


    /// <summary>
    /// 
    /// </summary>
    public class Logger /*: ILoggable*/ {
        /// <summary>
        /// 
        /// </summary>
        private StringBuilder message_builder_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__e"></param>
        public Logger(Exception __e) {
            this.message_builder_ = new StringBuilder();

            initialize( __e );
        }


        /// <summary>
        /// 
        /// </summary>
        private void initialize(Exception __e) {
            this.message_builder_.AppendLine( "<br /> <hr /> <br />" );
            this.message_builder_.AppendFormat( "<h4>{0}</h4>", DateTime.Now.ToString() );
            this.message_builder_.Append( "<table border=\"1\" cellspacing=\"1\" style=\"font-size:13px;" );
            this.message_builder_.AppendLine( " font-family: 'Tahoma';\">" );
            this.message_builder_.AppendFormat( " <caption>{0}</caption>\n", __e.GetType().ToString() );

            this.message_builder_.AppendLine( " <tr>" );
            this.message_builder_.AppendLine( "  <th>HyperLink</th>" );
            if ( __e.HelpLink == null ) {
                this.message_builder_.AppendFormat( "  <td>{0}</td>\n", __e.HelpLink );
            } else {
                this.message_builder_.AppendLine( " <td style=\"text-align: right;\">nill</td>" );
            }
            this.message_builder_.AppendLine( " </tr>" );

            this.message_builder_.AppendLine( " <tr>" );
            this.message_builder_.AppendLine( "  <th>InnerException</th>" );
            if ( __e.InnerException == null ) {
                this.message_builder_.AppendLine( " <td style=\"text-align: right;\">nill</td>" );
            } else {
                this.message_builder_.AppendFormat( "  <td>{0}</td>\n", __e.InnerException.GetType().ToString() );
            }
            this.message_builder_.AppendLine( " </tr>" );

            this.message_builder_.AppendLine( " <tr>" );
            this.message_builder_.AppendLine( "  <th>Message</th>" );
            this.message_builder_.AppendFormat( "  <td>{0}</td>\n", __e.Message );
            this.message_builder_.AppendLine( " </tr>" );

            this.message_builder_.AppendLine( " <tr>" );
            this.message_builder_.AppendLine( "  <th>Source</th>" );
            this.message_builder_.AppendFormat( "  <td>{0}</td>\n", __e.Source );
            this.message_builder_.AppendLine( " </tr>" );

            this.message_builder_.AppendLine( " <tr>" );
            this.message_builder_.AppendLine( "  <th>StackTrace</th>" );
            this.message_builder_.AppendFormat( "  <td>{0}</td>\n", __e.StackTrace );
            this.message_builder_.AppendLine( " </tr>" );

            this.message_builder_.AppendLine( " <tr>" );
            this.message_builder_.AppendLine( "  <th>TargetSite</th>" );
            if ( __e.TargetSite == null ) {
                this.message_builder_.AppendLine( " <td style=\"text-align: right;\">nill</td>" );
            } else {
                this.message_builder_.AppendFormat( "  <td>{0}#{1}()</td>\n",
                                                   __e.TargetSite.DeclaringType,
                                                   __e.TargetSite.Name
                                                 );
            }
            this.message_builder_.AppendLine( " </tr>" );
            this.message_builder_.AppendLine( "</table>" );
            this.message_builder_.AppendLine( "<br /> <hr /> <br />" );
        }


        /// <summary>
        /// 
        /// </summary>
        public void write() {
            try {
                StreamWriter writer = new StreamWriter(
                            File.Open( "stderr.txt.html",
                                       FileMode.Append,
                                       FileAccess.Write
                                     ),
                            Encoding.UTF8
                );

                try {
                    writer.Write( this.message_builder_.ToString() );
                } finally {
                    writer.Close();
                }

            } catch ( Exception e ) {
                StreamWriter log_writer = new StreamWriter( "stdout.txt" );
                try {
                    log_writer.Write( e.Message );
                } finally {
                    log_writer.Close();
                }
            }
        }
    }
}