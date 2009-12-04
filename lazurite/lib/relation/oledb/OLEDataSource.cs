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
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
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
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
        /// </summary>
        /// <param name="username">���[�U�[���B</param>
        /// <param name="password">���[�U�[�̃p�X���[�h�B</param>
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
        /// �C�x���g�n���h���p���\�b�h�ł��B
        /// </summary>
        /// <param name="__sender"></param>
        /// <param name="__e"></param>
        protected virtual void onInfoMessage(object __sender, OleDbInfoMessageEventArgs __simergs) {
            if ( base.logWriter != null ) {
                base.logWriter.WriteLine( "----" );
                base.logWriter.WriteLine( __simergs.Source );
                base.logWriter.WriteLine( __simergs.Message );
                /*
                 * ��O�R���N�V�������Ԃ�񂵂ĕ\�����܂��B
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
