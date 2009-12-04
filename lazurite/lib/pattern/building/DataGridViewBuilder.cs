using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace lazurite.pattern.building {


    /// <summary>
    /// 
    /// </summary>
    public class DataGridViewBuilder : DataGridViewColumnBuilder {
        /// <summary>
        /// 
        /// </summary>
        private DataTable target_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__gridview"></param>
        /// <param name="__target"></param>
        public DataGridViewBuilder(DataGridView __gridview, DataTable __target)
            : base( __gridview ) 
        {
            this.target_ = __target;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {
            List<string> colnames = new List<string>();
            foreach ( DataColumn data_col in this.target_.Columns ) {
                // DataGridViewColumn はカラムの基底クラスなので、
                // その派生クラス(たとえば、TextBoxColumn など)を作成しましょう。
                DataGridViewColumn col = new DataGridViewTextBoxColumn();

                col.Name = col.HeaderText = data_col.Caption;
                col.ValueType = data_col.DataType;
                if ( col.ValueType == typeof( Decimal ) || 
                     col.ValueType == typeof(short) ||
                     col.ValueType == typeof(int) 
                   ) 
                {
                    // カラムのタイプが整数や実数だったら、右そろえにします。
                    col.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                } else {
                    // それ以外なら─文字列とか─左揃えにします。
                    col.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                // カラムそのものを追加します。
                append( col );
                // (後で使うので)カラムの名前を追加します。
                colnames.Add( col.Name );
            }

            // データグリッドビューの行数をテーブルの行数まで広げます。
            content.RowCount = this.target_.Rows.Count;

            int current_line = 0;
            foreach ( DataRow data_row in this.target_.Rows ) {
                foreach ( string name in colnames ) {
                    // あとは手作業でグルグル追加します。
                    content[name, current_line].Value = data_row[name];
                }
                ++current_line;
            }
        }
    }
}