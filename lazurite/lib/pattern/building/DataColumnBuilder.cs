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
    /// DataColumnBuilder クラスは、IDataReader などから、DataColumn を作成します。
    /// </summary>
    /// <remarks>このクラスは EmptyTableBuilder の上位互換です。
    /// EmptyTableBuilder より、このクラスを使用してください。</remarks>
    public class DataColumnBuilder : AbstractBuilder<DataTable>, IStorage<DataColumn> {
        // 
        private IDataReader reader_ = null;


        /// <summary>
        /// 指定されたデータテーブルを受け取って、新しく DataColumnBuilder オブジェクトを作成します。
        /// </summary>
        /// <param name="__content"></param>
        public DataColumnBuilder(DataTable __content)
            : base( __content ) {
        }
        /// <summary>
        /// 指定されたデータテーブルとデータリーダーを受け取って、新しく DataColumnBuilder オブジェクトを作成します。
        /// </summary>
        /// <param name="__content"></param>
        /// <param name="__reader"></param>
        public DataColumnBuilder(DataTable __content, IDataReader __reader)
            : base( __content ) {
            this.reader_ = __reader;
        }


        /// <summary>
        /// カラムを追加します。
        /// </summary>
        /// <param name="__appended_column"></param>
        public void append(DataColumn __appended_column) {
            content.Columns.Add( __appended_column );
        }
        /// <summary>
        /// カラム名を指定して、その名前のカラムを追加します。
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
        /// カラムの配列を受け取って、それを追加します。
        /// </summary>
        /// <param name="__appended_columns"></param>
        /// <returns></returns>
        public int appendAll(DataColumn[] __appended_columns) {
            content.Columns.AddRange( __appended_columns );

            return __appended_columns.Length;
        }
        /// <summary>
        /// カラムコレクションを受け取って、それを追加します。
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
        /// 指定したインデックス位置にカラムを挿入します。
        /// </summary>
        /// <remarks>DataColumnCollection には Insert() が存在しないので、
        /// DataColumn の SetOrdinal() を使用しています。
        /// その為、処理が遅くなるかもしれません。</remarks>
        /// <param name="__column_index"></param>
        /// <param name="__inserted_column"></param>
        public void insert(int __column_index, DataColumn __inserted_column) {
            if ( __column_index < 0 || __column_index > content.Columns.Count ) {
                return;
            }
            if ( !content.Columns.Contains( __inserted_column.ColumnName ) ) {
                // まず、追加します。
                append( __inserted_column );
            }

            //for (int i = __column_index + 1; i < content.Columns.Count; ++ i ) {}
            // SetOrdinal() すると、前のカラム位置がどうなるかは不明。
            __inserted_column.SetOrdinal( __column_index );
        }


        /// <summary>
        /// 指定されたカラム名を持つカラムが存在するかどうかを調べます。
        /// </summary>
        /// <param name="__column_name"></param>
        /// <returns></returns>
        public bool contains(string __column_name) {
            return content.Columns.Contains( __column_name );
        }
        /// <summary>
        /// 指定されたカラム名を持つカラムが存在するかどうかを調べます。
        /// </summary>
        /// <param name="__column"></param>
        /// <returns></returns>
        public bool contains(DataColumn __column) {
            return content.Columns.Contains( __column.Caption );
        }


        /// <summary>
        /// 指定されたカラム名の配列を受け取って、そのカラム名を持つカラムが存在するかどうかを調べます。
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
        /// 指定されたカラム名の配列を受け取って、そのカラム名を持つカラムが存在するかどうかを調べます。
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
         * 指定されたカラム名を持つカラムの位置を返します。
         */
        public int indexOf(string __finded_column_name) {
            return content.Columns.IndexOf( __finded_column_name );
        }
        /**
         * 指定されたカラムの位置を返します。
         */
        public int indexOf(DataColumn __finded_column) {
            return content.Columns.IndexOf( __finded_column );
        }


        /// <summary>
        /// IDataReader インターフェイスを使用して、カラムを作成します。
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
        /// テーブルが所有しているカラムを配列にして返します。
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
        /// テーブルが所有しているカラムの個数を返します。
        /// </summary>
        public int entries {
            get { return content.Columns.Count; }
        }
    }
}
