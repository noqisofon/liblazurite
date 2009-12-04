using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace lazurite.pattern.building {


    /// <summary>
    /// IDataReader を使用して、DataTable を作成します。
    /// </summary>
    public class DataTableBuilder : DataColumnBuilder {
        /// <summary>
        /// 
        /// </summary>
        private IDataReader reader_;
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__reader"></param>
        public DataTableBuilder(string __table_name, IDataReader __reader)
            : base( new DataTable( __table_name ) ) 
        {
            this.reader_ = __reader;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void buildPart() {
            if ( !DataColumnBuilder.buildFromSchema( content, this.reader_ ) ) {
                return;
            }

            string[] captions = getCaptions();
            while ( this.reader_.Read() ) {
                DataRow row = content.NewRow();
                foreach ( string caption in captions ) {
                    row[caption] = this.reader_[caption];
                }
                base.content.Rows.Add( row );
            }
        }
    }
}
