using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

using building = lazurite.pattern.building;
using etherial = lazurite.etherial;


namespace lazurite.util {
    
    
    /// <summary>
    /// DataGridViewMaker クラスは、SQL Server から読み込んだテーブルを手作業で
    /// DataGridView にバインドする処理を自動的に行います。
    /// </summary>
    class DataGridViewMaker {
        /// <summary>
        /// クラス内で使いまわすためのテーブル。
        /// </summary>
        private DataTable source_ = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__connection"></param>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public delegate DataTable load_predicate(IDbConnection __connection, string __table_name);


        /// <summary>
        /// 接続とテーブル名を受け取って、テーブルを手作りします。
        /// </summary>
        /// <remarks>デリゲートにしなくてもいいんだけど、元がデリゲートだったので。</remarks>
        private load_predicate load_handler_  = delegate(IDbConnection __connection, string __table_name) {
            if ( __connection.State == ConnectionState.Closed ) {
                // 接続が閉じていたら、開きます。
                __connection.Open();
            }

            // SQL のクエリオブジェクトを作成します。
            SqlCommand command = new SqlCommand( string.Format( "select * from {0}",
                                                                __table_name
                                                              ),
                                                 __connection as SqlConnection
                                               );
            // 取り出したテーブルの内容を読み取るオブジェクトを取得します。
            IDataReader reader = command.ExecuteReader();

            // DataTable 作成用の職人さんを作成します。
            building::DataTableBuilder table_builder = new building::DataTableBuilder( __table_name, reader );

            // それを指揮する汎用監督を作成します。
            building::Director<DataTable> director = new building::Director<DataTable>( table_builder );
            // 監督に指示を出させて、職人さんにテーブルを作らせます。
            director.construct();

            // 出来上がった DataTable を納品します。 
            return table_builder.result;
        };


        /// <summary>
        /// 何も行わない。
        /// </summary>
        /// <remark>loadDataTable() を呼んだあとに binding() を呼んでください。</remark>
        public DataGridViewMaker() {
        }
        /// <summary>
        /// 指定されたデータベース名とテーブル名で、新しい GridViewMaker オブジェクトを構築します。
        /// </summary>
        /// <param name="__database_name">データベース名。</param>
        /// <param name="__table_name">テーブル名。</param>
        public DataGridViewMaker(string __database_name, string __table_name) {
            this.source_ = loadDataTable( __database_name, __table_name );
        }
        /// <summary>
        /// 指定されたデータベース名とテーブル名、及びロード用述語デリゲートで
        /// 新しい GridViewMaker オブジェクトを構築します。
        /// </summary>
        /// <param name="__database_name">データベース名。</param>
        /// <param name="__table_name">テーブル名。</param>
        /// <param name="__pred">ロード用の述語デリゲート。</param>
        public DataGridViewMaker(string __database_name, string __table_name, load_predicate __pred) {
            this.load_handler_ = __pred;
            loadDataTable( __database_name, __table_name );
        }


        /// <summary>
        /// 指定されたデータベースからテーブルを取ってきます。
        /// </summary>
        /// <param name="__database_name">データベース名。</param>
        /// <param name="__table_name">テーブル名。</param>
        /// <returns>読み込まれたテーブル。</returns>
        public DataTable loadDataTable(string __database_name, string __table_name) {
            DataTable result;
            etherial::SQLClientConnectionFactory factory = new etherial::SQLClientConnectionFactory( __database_name, true, __table_name );
            using ( SqlConnection connection = factory.get_connection() as SqlConnection ) {
                result = this.load_handler_( connection, __table_name );
            }
            this.source_ = result;

            return result;
        }


        /// <summary>
        /// データテーブルを使用してデータグリッドビューにコンバートします。
        /// </summary>
        /// <param name="__dataGridView">コンバートしたい データグリッドビュー。</param>
        /// <returns>コンバートされたデータグリッドビュー。</returns>
        public DataGridView binding(DataGridView __dataGridView) {
            building::DataGridViewBuilder datagrid_builder = new building::DataGridViewBuilder( __dataGridView, this.source_ );
            building::Director<DataGridView> director = new building::Director<DataGridView>( datagrid_builder );

            director.construct();

            return datagrid_builder.result;
        }
    }
}
