using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;



namespace lazurite.relation.sqlclient {


    /// <summary>
    /// SQL Server �p�̃f�[�^�\�[�X�ł��B
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
        /// ���[�J���p�\�R���p�B
        /// </summary>
        /// <param name="__initial_catalog"></param>
        public SQLDataSource(string __initial_catalog) 
            : base(__initial_catalog, "(local)", true)
        {
        }
        /// <summary>
        /// �O�p�\�R�� �� Windows �F�ؗp�B
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__data_source"></param>
        public SQLDataSource(string __initial_catalog, string __data_source) 
            : base(__initial_catalog, __data_source, true)
        {
        }
        /// <summary>
        /// �O�p�\�R�� �� SQL Sercer �F�ؗp�B
        /// </summary>
        /// <param name="__initial_catalog"></param>
        /// <param name="__data_source"></param>
        /// <param name="__integrated_security"></param>
        public SQLDataSource(string __initial_catalog, string __data_source, bool __integrated_security) 
            : base(__initial_catalog, __data_source, __integrated_security)
        {
        }


        /// <summary>
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
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
        /// ���� DataSource ���\���f�[�^�\�[�X�ւ̐ڑ������݂܂��B
        /// </summary>
        /// <param name="username">���[�U�[���B</param>
        /// <param name="password">���[�U�[�̃p�X���[�h�B</param>
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
        /// �C�x���g�n���h���p���\�b�h�ł��B
        /// </summary>
        /// <param name="__sender"></param>
        /// <param name="__e"></param>
        protected virtual void onInfoMessage(object __sender, SqlInfoMessageEventArgs __simergs) {
            if ( base.logWriter != null ) {
                base.logWriter.WriteLine( "----" );
                base.logWriter.WriteLine( __simergs.Source );
                base.logWriter.WriteLine( __simergs.Message );
                /*
                 * ��O�R���N�V�������Ԃ�񂵂ĕ\�����܂��B
                 */
                foreach ( SqlException se in __simergs.Errors ) {
                    base.logWriter.WriteLine( "�v���o�C�_�[��: {0}", se.Source );
                    base.logWriter.WriteLine( "�R���s���[�^�[��: {0}", se.Server );
                    base.logWriter.WriteLine( "�d��x: {0}", se.Class );
                    base.logWriter.WriteLine( "HRESULT: {0:x}", se.ErrorCode );
                    base.logWriter.WriteLine( "�G���[���: ", se.Number );
                    base.logWriter.WriteLine( "�s��: {0}", se.LineNumber );
                    base.logWriter.WriteLine( "�w���v: {0}", se.HelpLink );
                    base.logWriter.WriteLine( "�v���V�[�W��: {0}", se.Procedure );
                    base.logWriter.WriteLine( "�^�[�Q�b�g�T�C�g: {0}", se.TargetSite );
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
