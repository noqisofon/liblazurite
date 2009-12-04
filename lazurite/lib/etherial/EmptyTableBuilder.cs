using System;
using System.Data;


namespace lazurite.etherial {


    using lazurite.common;


    /// <summary>
    /// データベースからスキーマを読み取って、カラムヘッダのみの空のテーブルを作成します。
    /// </summary>
    /// <remarks>このクラスは非推奨のクラスです。</remarks>
    public class EmptyTableBuilder {
        /// <summary>
        /// 
        /// </summary>
        private DataTable table_;
        private bool completed_ = false;


        /// <summary>
        /// 指定されたテーブル名を受け取って、
        /// 新しく EmptyTableCreator オブジェクトを作成します。 
        /// </summary>
        /// <param name="__table_name">作成するテーブル名。</param>
        public EmptyTableBuilder(string __table_name) {
            this.table_ = new DataTable( __table_name );
        }
        /// <summary>
        /// 新しく EmptyTableCreator オブジェクトを作成します。 
        /// </summary>
        /// <param name="__table_name">作成するテーブル名。</param>
        /// <param name="__reader">データベースへの読み取りイテレータ。</param>
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
        /// カラムヘッダを追加して空のテーブルを作成します。
        /// </summary>
        /// <param name="__reader">データベースへの読み取りイテレータ。</param>
        /// <returns>成功したら真。</returns>
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
        /// 作成した空のテーブルを返します。
        /// </summary>
        public DataTable result {
            get { return this.table_; }
        }
    }
}