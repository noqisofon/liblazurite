using System.Windows.Forms;


namespace lazurite.pattern.building {


    using lazurite.common;


    /// <summary>
    /// DataGridView に DataGridViewColumn を追加するだけのクラスです。
    /// </summary>
    public abstract class DataGridViewColumnBuilder : AbstractBuilder<DataGridView>, IStorage<DataGridViewColumn> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__gridview"></param>
        protected DataGridViewColumnBuilder(DataGridView __gridview)
            : base( __gridview ) 
        {
        }


        /// <summary>
        /// カラムを追加します。
        /// </summary>
        /// <param name="__column"></param>
        public void append(DataGridViewColumn __column) {
            content.Columns.Add( __column );
        }


        /// <summary>
        /// カラムの配列を順番に追加します。
        /// </summary>
        /// <param name="__columns"></param>
        /// <returns></returns>
        public int appendAll(DataGridViewColumn[] __columns) {
            content.Columns.AddRange( __columns );

            return __columns.Length;
        }


        /// <summary>
        /// 指定された位置にカラムを挿入します。
        /// </summary>
        /// <param name="__column_index"></param>
        /// <param name="__inserted_column"></param>
        public void insert(int __column_index, DataGridViewColumn __inserted_column) {
            if ( attributesAmount == 0 ) {
                append( __inserted_column );
            } else {
                content.Columns.Insert( __column_index, __inserted_column );
            }
        }


        /// <summary>
        /// 指定されたカラムの位置を返します。
        /// </summary>
        /// <param name="__column"></param>
        /// <returns></returns>
        public int indexOf(DataGridViewColumn __column) {
            return content.Columns.IndexOf( __column );
        }


        /// <summary>
        /// 指定された名前を持つカラムの位置を返します。
        /// </summary>
        /// <param name="__finded_name"></param>
        /// <returns></returns>
        public int indexOfName(string __finded_name) {
            int result_index = 0;
            foreach ( DataGridViewColumn column in content.Columns ) {
                if ( column.Name == __finded_name ) {
                    break;
                }
                ++result_index;
            }
            return result_index < attributesAmount ? result_index : -1;
        }


        /// <summary>
        /// 指定された名前のカラムがあるか、調べます。
        /// </summary>
        /// <param name="__contain_name"></param>
        /// <returns></returns>
        public bool contains(string __contain_name) {
            return content.Columns.Contains( __contain_name );
        }
        /// <summary>
        /// 指定されたカラムがあるか、調べます。
        /// </summary>
        /// <param name="__contain_column"></param>
        /// <returns></returns>
        public bool contains(DataGridViewColumn __contain_column) {
            return content.Columns.Contains( __contain_column );
        }


        /// <summary>
        /// 指定されたカラム名の配列を受け取って、
        /// そのカラム名を持つカラムが存在するかどうかを調べます。
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
        /// 
        /// </summary>
        /// <param name="__contain_columns"></param>
        /// <returns></returns>
        public bool containsAll(DataGridViewColumn[] __contain_columns) {
            foreach ( DataGridViewColumn column in __contain_columns ) {
                if ( !contains( column ) ) {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// データグリッドビューが所有しているカラムを配列にして返します。
        /// </summary>
        /// <returns></returns>
        public DataGridViewColumn[] to_a() {
            int last_arrival = content.Columns.Count;
            DataGridViewColumn[] result_columns = new DataGridViewColumn[last_arrival];
            for ( int i = 0; i < last_arrival; ++i ) {
                result_columns[i] = content.Columns[i];
            }
            return result_columns;
        }


        /// <summary>
        /// カラムの長さにアクセスします。
        /// </summary>
        public int attributesAmount {
            get { return content.ColumnCount; }
            set { content.ColumnCount = value; }
        }


        /// <summary>
        /// カラムの数を返します。
        /// </summary>
        public int entries {
            get { return content.ColumnCount; }
        }


        /// <summary>
        /// 行数にアクセスします。
        /// </summary>
        public int tupleAmount {
            get { return content.RowCount; }
            set { content.RowCount = value; }
        }
    }
}