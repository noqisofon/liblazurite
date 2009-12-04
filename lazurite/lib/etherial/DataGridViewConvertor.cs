using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;


namespace lazurite.etherial {


    /// <summary>
    /// DataTable から空の DataGridView にデータをコンバートするクラスです。
    /// </summary>
    /// <remarks>此のクラスは現在(2008-11-11T)推奨されていません。
    /// Builder シリーズを使ってください。</remarks>
    public class DataGridViewConvertor {
        private string tablename_;          //!< テーブル名。
        private DataGridView viewer_;       //!< ビュー。

        private List<DataGridViewColumn> columns_;  //!< コラム。


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__gridview"></param>
        /// <param name="__table_name"></param>
        public DataGridViewConvertor(DataGridView __gridview, string __table_name) {
            initialize( __gridview, __table_name );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__gridview"></param>
        /// <param name="__table_name"></param>
        private void initialize(DataGridView __gridview, string __table_name) {
            this.tablename_ = __table_name;
            this.viewer_ = __gridview;
            this.columns_ = new List<DataGridViewColumn>();

            foreach ( DataGridViewColumn column in columns_ ) {
                this.columns_.Add( column );
            }
        }


        /**
         * カラム名と、カラムのヘッダテキストをペアにした NameAndHeaderPair の配列を作成して返します。 
         */
        public NameAndHeaderPair[] pairs() {
            List<NameAndHeaderPair> li = new List<NameAndHeaderPair>();
            foreach ( DataGridViewColumn column in columns_ ) {
                li.Add( new NameAndHeaderPair( column.Name, column.HeaderText ) );
            }
            return li.ToArray();
        }


        /**
         * 指定された DataTable を元に、行を作成します。
         */
        public void binding(DataTable __converting_table, binary_cell_filter __bcfilter) {
            int count = __converting_table.Rows.Count;
            if ( viewer_.RowCount < count ) {
                viewer_.RowCount = count;
            } else if ( count == 0 ) {
                return;
            }

            for ( int i = 0; i < count; ++i ) {
                DataGridViewCell cell;
                foreach ( NameAndHeaderPair pair in pairs() ) {
                    cell = viewer_[pair.name, i];
                    __bcfilter( cell, __converting_table.Rows[i][pair.headerText] );
                }
            }
        }
        /**
         * 指定された DataTable を元に、行を作成します。
         */
        public void binding(DataTable __converting_table, binary_row_filter __brfilter) {
            int count = __converting_table.Rows.Count;
            if ( viewer_.RowCount < count ) {
                viewer_.RowCount = count;
            } else if ( count == 0 ) {
                return;
            }

            for ( int i = 0; i < count; ++i ) {
                DataGridViewCell cell;
                foreach ( NameAndHeaderPair pair in pairs() ) {
                    cell = viewer_[pair.name, i];
                    __brfilter( cell, __converting_table.Rows[i] );
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__cfilter"></param>
        public void binding(cell_filter __cfilter) {
            foreach ( DataGridViewRow row in viewer_.Rows ) {
                foreach ( DataGridViewCell cell in row.Cells ) {
                    __cfilter( cell );
                }
            }
        }

        public delegate void cell_filter(DataGridViewCell __cell);
        public delegate void binary_cell_filter(DataGridViewCell __cell, object __that);
        public delegate void binary_row_filter(DataGridViewCell __cell, DataRow __row);



        /// <summary>
        /// 
        /// </summary>
        public class NameAndHeaderPair {
            private string name_;
            private string headerText_;


            /// <summary>
            /// 
            /// </summary>
            /// <param name="__name"></param>
            /// <param name="__header_text"></param>
            public NameAndHeaderPair(string __name, string __header_text) {
                this.name = __name;
                this.headerText = __header_text;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="__other"></param>
            public NameAndHeaderPair(NameAndHeaderPair __other) {
                this.name_ = __other.name;
                this.headerText_ = __other.headerText;
            }


            /// <summary>
            /// 
            /// </summary>
            public string name {
                get { return name_; }
                set { name_ = value; }
            }


            /// <summary>
            /// 
            /// </summary>
            public string headerText {
                get { return headerText_; }
                set { headerText_ = value; }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString() {
                return string.Format("({0}.{1})", this.name_, this.headerText_ );
            }
        }
    }
}
