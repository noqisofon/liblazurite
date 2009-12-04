using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;



namespace lazurite.relation.sqlclient {


    /// <summary>
    /// SQL Server 用のデータソースです。
    /// </summary>
    public class SQLDataSource : common.ADODataSource {
        /// <summary>
        /// 
        /// </summary>
        public override string providerName {
            get {
                return "SqlClient";
            }
        }
        

        /// <summary>
        /// ローカルパソコン用。
        /// </summary>
        /// <param name="__initial_catalog"></param>
        public SQLDataSource(string __initial_catalog) 
            : base(__initial_catalog, "(local)", true)
        {
        }
        /// <summary>
        /// 外パソコン ＆ Windows 認証用。
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__data_source"></param>
        public SQLDataSource(string __initial_catalog, string __data_source) 
            : base(__initial_catalog, __data_source, true)
        {
        }
        /// <summary>
        /// 外パソコン ＆ SQL Sercer 認証用。
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__data_source"></param>
        /// <param name="__integrated_security"></param>
        public SQLDataSource(string __initial_catalog, string __data_source, bool __integrated_security) 
            : base(__initial_catalog, __data_source, __integrated_security)
        {
        }


        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <returns></returns>
        public override DbConnection getConnection() {
            SqlConnectionStringBuilder connection_builder = new SqlConnectionStringBuilder();
            connection_builder.ConnectTimeout = base.loginTimeout;

            connection_builder["Data Source"] = this.data_source_;
            connection_builder["Integrated Security"] = this.integrated_security_;
            connection_builder["Initial Catalog"] = this.initial_catalog_;

            SqlConnection connection = new SqlConnection( connection_builder.ToString() );
            connection.InfoMessage += onInfoMessage;

            return connection;
        }


        /// <summary>
        /// この DataSource が表すデータソースへの接続を試みます。
        /// </summary>
        /// <param name="username">ユーザー名。</param>
        /// <param name="password">ユーザーのパスワード。</param>
        /// <returns></returns>
        public override DbConnection getConnection(string __username, string __password) {
            SqlConnectionStringBuilder connection_builder = new SqlConnectionStringBuilder();
            connection_builder.ConnectTimeout = base.loginTimeout;

            connection_builder["Data Source"] = this.data_source_;
            connection_builder["Integrated Security"] = this.integrated_security_;
            connection_builder["Initial Catalog"] = this.initial_catalog_;

            connection_builder["User ID"] = __username;
            connection_builder["Password"] = __password;

            SqlConnection connection = new SqlConnection( connection_builder.ToString() );
            connection.InfoMessage += onInfoMessage;

            return connection;
        }


        /// <summary>
        /// イベントハンドラ用メソッドです。
        /// </summary>
        /// <param name="__sender"></param>
        /// <param name="__e"></param>
        protected virtual void onInfoMessage(object __sender, SqlInfoMessageEventArgs __simergs) {
            if ( base.logWriter != null ) {
                base.logWriter.WriteLine( "----" );
                base.logWriter.WriteLine( __simergs.Source );
                base.logWriter.WriteLine( __simergs.Message );
                /*
                 * 例外コレクションをぶん回して表示します。
                 */
                foreach ( SqlException se in __simergs.Errors ) {
                    base.logWriter.WriteLine( "プロバイダー名: {0}", se.Source );
                    base.logWriter.WriteLine( "コンピューター名: {0}", se.Server );
                    base.logWriter.WriteLine( "重大度: {0}", se.Class );
                    base.logWriter.WriteLine( "HRESULT: {0:x}", se.ErrorCode );
                    base.logWriter.WriteLine( "エラー種類: ", se.Number );
                    base.logWriter.WriteLine( "行数: {0}", se.LineNumber );
                    base.logWriter.WriteLine( "ヘルプ: {0}", se.HelpLink );
                    base.logWriter.WriteLine( "プロシージャ: {0}", se.Procedure );
                    base.logWriter.WriteLine( "ターゲットサイト: {0}", se.TargetSite );
                    base.logWriter.WriteLine( se.Data );
                    base.logWriter.WriteLine( se.Message );

                    base.logWriter.WriteLine();
                }
                base.logWriter.WriteLine();
                base.logWriter.Flush();
            }
        }
    }
}
