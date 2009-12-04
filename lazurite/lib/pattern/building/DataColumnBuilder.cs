using System;
using System.Collections.Generic;
using System.Data;


namespace lazurite.pattern.building {

    /**
         * 
         * 
         * <pre>
         * 
         * </pre>
         */
    using lazurite.common;





    /// <summary>
    /// DataColumnBuilder �N���X�́AIDataReader �Ȃǂ���ADataColumn ���쐬���܂��B
    /// </summary>
    /// <remarks>���̃N���X�� EmptyTableBuilder �̏�ʌ݊��ł��B
    /// EmptyTableBuilder ���A���̃N���X���g�p���Ă��������B</remarks>
    public class DataColumnBuilder : AbstractBuilder<DataTable>, IStorage<DataColumn> {
        // 
        private IDataReader reader_ = null;


        /// <summary>
        /// �w�肳�ꂽ�f�[�^�e�[�u�����󂯎���āA�V���� DataColumnBuilder �I�u�W�F�N�g���쐬���܂��B
        /// </summary>
        /// <param name="__content"></param>
        public DataColumnBuilder(DataTable __content)
            : base( __content ) {
        }
        /// <summary>
        /// �w�肳�ꂽ�f�[�^�e�[�u���ƃf�[�^���[�_�[���󂯎���āA�V���� DataColumnBuilder �I�u�W�F�N�g���쐬���܂��B
        /// </summary>
        /// <param name="__content"></param>
        /// <param name="__reader"></param>
        public DataColumnBuilder(DataTable __content, IDataReader __reader)
            : base( __content ) {
            this.reader_ = __reader;
        }


        /// <summary>
        /// �J������ǉ����܂��B
        /// </summary>
        /// <param name="__appended_column"></param>
        public void append(DataColumn __appended_column) {
            content.Columns.Add( __appended_column );
        }
        /// <summary>
        /// �J���������w�肵�āA���̖��O�̃J������ǉ����܂��B
        /// </summary>
        /// <param name="__appended_column_name"></param>
        public DataColumn append(string __appended_column_name) {
            return content.Columns.Add( __appended_column_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__appended_column"></param>
        /// <param name="__type"></param>
        public DataColumn append(string __appended_column_name, Type __type) {
            return content.Columns.Add( __appended_column_name, __type );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__appended_column"></param>
        /// <param name="__type"></param>
        /// <param name="__expression"></param>
        public DataColumn append(string __appended_column_name, Type __type, string __expression) {
            return content.Columns.Add( __appended_column_name, __type, __expression );
        }



        /// <summary>
        /// �J�����̔z����󂯎���āA�����ǉ����܂��B
        /// </summary>
        /// <param name="__appended_columns"></param>
        /// <returns></returns>
        public int appendAll(DataColumn[] __appended_columns) {
            content.Columns.AddRange( __appended_columns );

            return __appended_columns.Length;
        }
        /// <summary>
        /// �J�����R���N�V�������󂯎���āA�����ǉ����܂��B
        /// </summary>
        /// <param name="__appended_collection"></param>
        /// <returns></returns>
        public int appendAll(DataColumnCollection __appended_collection) {
            foreach ( DataColumn col in __appended_collection ) {
                append( col );
            }
            return __appended_collection.Count;
        }


        /// <summary>
        /// �w�肵���C���f�b�N�X�ʒu�ɃJ������}�����܂��B
        /// </summary>
        /// <remarks>DataColumnCollection �ɂ� Insert() �����݂��Ȃ��̂ŁA
        /// DataColumn �� SetOrdinal() ���g�p���Ă��܂��B
        /// ���ׁ̈A�������x���Ȃ邩������܂���B</remarks>
        /// <param name="__column_index"></param>
        /// <param name="__inserted_column"></param>
        public void insert(int __column_index, DataColumn __inserted_column) {
            if ( __column_index < 0 || __column_index > content.Columns.Count ) {
                return;
            }
            if ( !content.Columns.Contains( __inserted_column.ColumnName ) ) {
                // �܂��A�ǉ����܂��B
                append( __inserted_column );
            }

            //for (int i = __column_index + 1; i < content.Columns.Count; ++ i ) {}
            // SetOrdinal() ����ƁA�O�̃J�����ʒu���ǂ��Ȃ邩�͕s���B
            __inserted_column.SetOrdinal( __column_index );
        }


        /// <summary>
        /// �w�肳�ꂽ�J�����������J���������݂��邩�ǂ����𒲂ׂ܂��B
        /// </summary>
        /// <param name="__column_name"></param>
        /// <returns></returns>
        public bool contains(string __column_name) {
            return content.Columns.Contains( __column_name );
        }
        /// <summary>
        /// �w�肳�ꂽ�J�����������J���������݂��邩�ǂ����𒲂ׂ܂��B
        /// </summary>
        /// <param name="__column"></param>
        /// <returns></returns>
        public bool contains(DataColumn __column) {
            return content.Columns.Contains( __column.Caption );
        }


        /// <summary>
        /// �w�肳�ꂽ�J�������̔z����󂯎���āA���̃J�����������J���������݂��邩�ǂ����𒲂ׂ܂��B
        /// </summary>
        /// <param name="__column_names"></param>
        /// <returns></returns>
        public bool containsAll(string[] __column_names) {
            foreach ( string column_name in __column_names ) {
                if ( !contains( column_name ) ) {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// �w�肳�ꂽ�J�������̔z����󂯎���āA���̃J�����������J���������݂��邩�ǂ����𒲂ׂ܂��B
        /// </summary>
        /// <param name="__columns"></param>
        /// <returns></returns>
        public bool containsAll(DataColumn[] __columns) {
            foreach ( DataColumn column in __columns ) {
                if ( !contains( column ) ) {
                    return false;
                }
            }
            return true;
        }


        /**
         * �w�肳�ꂽ�J�����������J�����̈ʒu��Ԃ��܂��B
         */
        public int indexOf(string __finded_column_name) {
            return content.Columns.IndexOf( __finded_column_name );
        }
        /**
         * �w�肳�ꂽ�J�����̈ʒu��Ԃ��܂��B
         */
        public int indexOf(DataColumn __finded_column) {
            return content.Columns.IndexOf( __finded_column );
        }


        /// <summary>
        /// IDataReader �C���^�[�t�F�C�X���g�p���āA�J�������쐬���܂��B
        /// </summary>
        /// <param name="__content"></param>
        /// <param name="__reader"></param>
        /// <returns></returns>
        protected static bool buildFromSchema(DataTable __content, IDataReader __reader) {
            return buildFromSchema( __content, __reader, false );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__content"></param>
        /// <param name="__reader"></param>
        /// <param name="_is_schema_write"></param>
        /// <returns></returns>
        protected static bool buildFromSchema(DataTable __content, IDataReader __reader, bool _is_schema_write) {
            if ( __reader.IsClosed ) { return false; }

            DataTable schema = __reader.GetSchemaTable();
            foreach ( DataRow row in schema.Rows ) {
                DataColumn column = new DataColumn( row["ColumnName"] as string,
                                                    row["DataType"] as Type
                                                  );
                column.Unique = (bool)row["IsUnique"]? true: false;

                if ( !__content.Columns.Contains( column.ColumnName ) ) {
                    __content.Columns.Add( column );
                }
            }
            if ( _is_schema_write ) {
                schema.WriteXml( __content.TableName + ".schema.xml", XmlWriteMode.WriteSchema, false );
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {
            buildFromSchema( content, this.reader_ );
        }


        /// <summary>
        /// �e�[�u�������L���Ă���J������z��ɂ��ĕԂ��܂��B
        /// </summary>
        /// <returns></returns>
        public DataColumn[] to_a() {
            int last_arrival = content.Columns.Count;
            DataColumn[] result_columns = new DataColumn[last_arrival];
            for ( int i = 0; i < last_arrival; ++i ) {
                result_columns[i] = content.Columns[i];
            }
            return result_columns;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] getCaptions() {
            int last_arrival = content.Columns.Count;
            string[] result_captions = new string[last_arrival];
            for ( int i = 0; i < last_arrival; ++i ) {
                result_captions[i] = content.Columns[i].Caption;
            }
            return result_captions;
        }


        /// <summary>
        /// �e�[�u�������L���Ă���J�����̌���Ԃ��܂��B
        /// </summary>
        public int entries {
            get { return content.Columns.Count; }
        }
    }
}
