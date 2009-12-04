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
                // DataGridViewColumn �̓J�����̊��N���X�Ȃ̂ŁA
                // ���̔h���N���X(���Ƃ��΁ATextBoxColumn �Ȃ�)���쐬���܂��傤�B
                DataGridViewColumn col = new DataGridViewTextBoxColumn();

                col.Name = col.HeaderText = data_col.Caption;
                col.ValueType = data_col.DataType;
                if ( col.ValueType == typeof( Decimal ) || 
                     col.ValueType == typeof(short) ||
                     col.ValueType == typeof(int) 
                   ) 
                {
                    // �J�����̃^�C�v�������������������A�E���낦�ɂ��܂��B
                    col.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                } else {
                    // ����ȊO�Ȃ焟������Ƃ����������ɂ��܂��B
                    col.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                // �J�������̂��̂�ǉ����܂��B
                append( col );
                // (��Ŏg���̂�)�J�����̖��O��ǉ����܂��B
                colnames.Add( col.Name );
            }

            // �f�[�^�O���b�h�r���[�̍s�����e�[�u���̍s���܂ōL���܂��B
            content.RowCount = this.target_.Rows.Count;

            int current_line = 0;
            foreach ( DataRow data_row in this.target_.Rows ) {
                foreach ( string name in colnames ) {
                    // ���Ƃ͎��ƂŃO���O���ǉ����܂��B
                    content[name, current_line].Value = data_row[name];
                }
                ++current_line;
            }
        }
    }
}