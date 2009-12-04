using System;
using System.Data;


namespace lazurite.etherial {


    using lazurite.common;


    /// <summary>
    /// �f�[�^�x�[�X����X�L�[�}��ǂݎ���āA�J�����w�b�_�݂̂̋�̃e�[�u�����쐬���܂��B
    /// </summary>
    /// <remarks>���̃N���X�͔񐄏��̃N���X�ł��B</remarks>
    public class EmptyTableBuilder {
        /// <summary>
        /// 
        /// </summary>
        private DataTable table_;
        private bool completed_ = false;


        /// <summary>
        /// �w�肳�ꂽ�e�[�u�������󂯎���āA
        /// �V���� EmptyTableCreator �I�u�W�F�N�g���쐬���܂��B 
        /// </summary>
        /// <param name="__table_name">�쐬����e�[�u�����B</param>
        public EmptyTableBuilder(string __table_name) {
            this.table_ = new DataTable( __table_name );
        }
        /// <summary>
        /// �V���� EmptyTableCreator �I�u�W�F�N�g���쐬���܂��B 
        /// </summary>
        /// <param name="__table_name">�쐬����e�[�u�����B</param>
        /// <param name="__reader">�f�[�^�x�[�X�ւ̓ǂݎ��C�e���[�^�B</param>
        public EmptyTableBuilder(string __table_name, IDataReader __reader) {
            this.table_ = new DataTable( __table_name );

            create( __reader );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table"></param>
        public EmptyTableBuilder(DataTable __table) {
            this.table_ = __table;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table"></param>
        /// <param name="__reader"></param>
        public EmptyTableBuilder(DataTable __table, IDataReader __reader) {
            this.table_ = __table;

            create( __reader );
        }


        /// <summary>
        /// �J�����w�b�_��ǉ����ċ�̃e�[�u�����쐬���܂��B
        /// </summary>
        /// <param name="__reader">�f�[�^�x�[�X�ւ̓ǂݎ��C�e���[�^�B</param>
        /// <returns>����������^�B</returns>
        public bool create(IDataReader __reader) {
            if ( !completed_ ) {
                if ( __reader.IsClosed ) {
                    return false;
                }
                DataTable schema = __reader.GetSchemaTable();
                foreach ( DataRow row in schema.Rows ) {
                    DataColumn col = new DataColumn( row["ColumnName"] as string );

                    //col.ColumnName = row["ColumnName"] as string;
                    //col.Caption = row["ColumnName"] as string;
                    col.Unique = (bool)row["IsUnique"];
                    col.DataType = row["DataType"] as Type;
                    //col.MaxLength = (int) row["ColumnSize"];

                    if ( !this.table_.Columns.Contains( col.ColumnName ) ) {
                        this.table_.Columns.Add( col );
                    }
                }
                completed_ = true;
                
            }
            return true;
        }


        /// <summary>
        /// �쐬������̃e�[�u����Ԃ��܂��B
        /// </summary>
        public DataTable result {
            get { return this.table_; }
        }
    }
}