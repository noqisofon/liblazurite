using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace lazurite.etherial {


    /*
     * �}���p�̃R�}���h���쐬���邽�߂� Factory �N���X�ł��B
     */
    public class InsertCommandFactory {
        private string tableName_;                      //!< �e�[�u�����ł��B
        private string statement_ = string.Empty;       //!< �R�}���h�e�L�X�g�ł��B
        private List<SqlCommand> commands_;             //!< �R�}���h���X�g�ł��B


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        public InsertCommandFactory(string __table_name) {
            initialize( __table_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table"></param>
        public InsertCommandFactory(DataTable __table) {
            initialize( __table.TableName );
            createSQLStatement( __table );
        }


        /**
         * �R���X�g���N�^�̏�������Z�߂ɂ��܂��B
         */
        private void initialize(string __table_name) {
            this.tableName_ = __table_name;
            this.commands_ = new List<SqlCommand>();
        }


        /**
         * ������̔z�񂩂�N�G���e�L�X�g���쐬���܂��B
         */
        private void createSQLStatement(string[] __columnNames) {
            StringBuilder sqlStatementBuilder = new StringBuilder();
            sqlStatementBuilder.AppendFormat( "insert into {0} (", this.tableName_ );

            int i = 0;
            int columnsLength = __columnNames.Length;
            StringBuilder palamBuilder = new StringBuilder();
            foreach ( string colname in __columnNames ) {
                sqlStatementBuilder.Append( colname );
                palamBuilder.AppendFormat( "@{0}", colname );
                if ( i < columnsLength - 1 ) {
                    sqlStatementBuilder.Append( ", " );
                    palamBuilder.Append( ", " );
                }
                ++i;
            }
            sqlStatementBuilder.AppendFormat( " ) values ( {0} )", palamBuilder.ToString() );
            this.statement_ = sqlStatementBuilder.ToString();
        }
        /**
         * DataTable �I�u�W�F�N�g���󂯎���āA�R�}���h�I�u�W�F�N�g���쐬���ĕԂ��܂��B
         */
        private void createSQLStatement(DataTable __table) {
            StringBuilder sqlStatementBuilder = new StringBuilder();
            sqlStatementBuilder.AppendFormat( "insert into {0} (", this.tableName_ );

            int i = 0;
            int columnsLength = __table.Columns.Count;
            StringBuilder palamBuilder = new StringBuilder();
            foreach ( DataColumn col in __table.Columns ) {
                sqlStatementBuilder.Append( col.ColumnName );
                palamBuilder.AppendFormat( "@{0}", col.ColumnName );
                if ( i < columnsLength - 1 ) {
                    sqlStatementBuilder.Append( ", " );
                    palamBuilder.Append( ", " );
                }
                ++i;
            }
            sqlStatementBuilder.AppendFormat( " ) values ( {0} )", palamBuilder.ToString() );

            this.statement_ = sqlStatementBuilder.ToString();
        }


        /**
         * DataRow �I�u�W�F�N�g���󂯎���āA�R�}���h�I�u�W�F�N�g���쐬���ĕԂ��܂��B
         */
        public SqlCommand createCommand(DataRow __row) {
            DataTable table = __row.Table;
            Dictionary<string, object> palamBook = new Dictionary<string, object>();
            /*
             * ������Ԃł� statement_ �͋󕶎���("")�ɂȂ��Ă��܂��B
             */
            if ( this.statement_ == string.Empty ) {
                createSQLStatement( table );
            }
            /*
             * 2 ��ڈȍ~�́A�����N�G���e�L�X�g���ł��Ă���̂ŁA
             * palamBook �Ƀp�����[�^�[�p�̖��O�ƒl������邾���ōς݂܂��B
             */
            foreach ( DataColumn col in table.Columns ) {
                palamBook.Add( col.ColumnName, __row[col.ColumnName] );
            }
            return createCommand( palamBook );
        }
        /**
         * �ϐ����ƒl�̘A�z�z����󂯎���āA�R�}���h�I�u�W�F�N�g���쐬���ĕԂ��܂��B
         */
        public SqlCommand createCommand(Dictionary<string, object> __palamBook) {
            /*
             * �N�G���e�L�X�g���쐬����ĂȂ���΁A�������܂���B 
             */
            if ( this.statement_ != null ) {
                SqlCommand command = new SqlCommand( this.statement_ );
                foreach ( KeyValuePair<string, object> pr in __palamBook ) {
                    command.Parameters.Add( new SqlParameter( pr.Key, pr.Value ) );
                }
                this.commands_.Add( command );

                return command;
            }
            return null;
        }


        /**
         * ���܂ō쐬�����R�}���h��z��ɂ��ĕԂ��܂��B
         */
        public SqlCommand[] commands {
            get { return this.commands_.ToArray(); }
        }


        /**
         * �R�}���h�̐���Ԃ��܂��B
         */
        public int amount {
            get { return this.commands_.Count; }
        }
    }
}
