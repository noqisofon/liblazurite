using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace lazurite.etherial {


    /*
     * 挿入用のコマンドを作成するための Factory クラスです。
     */
    public class InsertCommandFactory {
        private string tableName_;                      //!< テーブル名です。
        private string statement_ = string.Empty;       //!< コマンドテキストです。
        private List<SqlCommand> commands_;             //!< コマンドリストです。


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
         * コンストラクタの処理を一纏めにします。
         */
        private void initialize(string __table_name) {
            this.tableName_ = __table_name;
            this.commands_ = new List<SqlCommand>();
        }


        /**
         * 文字列の配列からクエリテキストを作成します。
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
         * DataTable オブジェクトを受け取って、コマンドオブジェクトを作成して返します。
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
         * DataRow オブジェクトを受け取って、コマンドオブジェクトを作成して返します。
         */
        public SqlCommand createCommand(DataRow __row) {
            DataTable table = __row.Table;
            Dictionary<string, object> palamBook = new Dictionary<string, object>();
            /*
             * 初期状態では statement_ は空文字列("")になっています。
             */
            if ( this.statement_ == string.Empty ) {
                createSQLStatement( table );
            }
            /*
             * 2 回目以降は、もうクエリテキストができているので、
             * palamBook にパラメーター用の名前と値をいれるだけで済みます。
             */
            foreach ( DataColumn col in table.Columns ) {
                palamBook.Add( col.ColumnName, __row[col.ColumnName] );
            }
            return createCommand( palamBook );
        }
        /**
         * 変数名と値の連想配列を受け取って、コマンドオブジェクトを作成して返します。
         */
        public SqlCommand createCommand(Dictionary<string, object> __palamBook) {
            /*
             * クエリテキストが作成されてなければ、何もしません。 
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
         * 今まで作成したコマンドを配列にして返します。
         */
        public SqlCommand[] commands {
            get { return this.commands_.ToArray(); }
        }


        /**
         * コマンドの数を返します。
         */
        public int amount {
            get { return this.commands_.Count; }
        }
    }
}
