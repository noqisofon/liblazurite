using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;


namespace lazurite.relation.oledb {


    /// <summary>
    /// 
    /// </summary>
    public class OLEDataSource : common.ADODataSource {
        /// <summary>
        /// 
        /// </summary>
        public override string providerName {
            get {
                return "OleDb";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__dbpath"></param>
        public OLEDataSource(string __initial_catalog, string __dbpath)
            : base( __initial_catalog, __dbpath, false ) 
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__dbpath"></param>
        public OLEDataSource(string __initial_catalog, FileInfo __dbpath)
            : base( __initial_catalog, __dbpath.FullName, false ) 
        {
        }


        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <returns></returns>
        public override DbConnection getConnection() {
            OleDbConnectionStringBuilder connection_builder = new OleDbConnectionStringBuilder();

            //connection_builder.ConnectTimeout = base.loginTimeout;

            connection_builder["Provider"] = OLEDBProviderFactory.provider;
            connection_builder["Persist Security Info"] = base.integrated_security_;
            connection_builder["Data Source"] = base.data_source_;

            OleDbConnection result_connection = new OleDbConnection( connection_builder.ToString() );
            result_connection.InfoMessage += onInfoMessage;

            return result_connection;
        }
        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <param name="username">ユーザー名。</param>
        /// <param name="password">ユーザーのパスワード。</param>
        /// <returns></returns>
        public override DbConnection getConnection(string __username, string __password) {
            OleDbConnectionStringBuilder connection_builder = new OleDbConnectionStringBuilder();

            //connection_builder.ConnectTimeout = base.loginTimeout;

            connection_builder["Provider"] = OLEDBProviderFactory.provider;
            connection_builder["Persist Security Info"] = base.integrated_security_;
            connection_builder["Data Source"] = base.data_source_;

            connection_builder["User ID"] = __username;
            connection_builder["Password"] = __password;

            OleDbConnection result_connection = new OleDbConnection( connection_builder.ToString() );
            result_connection.InfoMessage += onInfoMessage;

            return result_connection;
        }


        /// <summary>
        /// イベントハンドラ用メソッドです。
        /// </summary>
        /// <param name="__sender"></param>
        /// <param name="__e"></param>
        protected virtual void onInfoMessage(object __sender, OleDbInfoMessageEventArgs __simergs) {
            if ( base.logWriter != null ) {
                base.logWriter.WriteLine( "----" );
                base.logWriter.WriteLine( __simergs.Source );
                base.logWriter.WriteLine( __simergs.Message );
                /*
                 * 例外コレクションをぶん回して表示します。
                 */
                foreach ( OleDbError ode in __simergs.Errors ) {
                    base.logWriter.WriteLine( ode.Message );
                    base.logWriter.WriteLine( ode.NativeError );
                    base.logWriter.WriteLine( ode.Source );
                    base.logWriter.WriteLine( ode.SQLState );

                    base.logWriter.WriteLine();
                }
                base.logWriter.WriteLine();
                base.logWriter.Flush();
            }
        }
    }

}
