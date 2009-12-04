using System;
using System.Data;
using System.Data.Common;


namespace lazurite.etherial {


    /// <summary>
    /// 
    /// </summary>
    public class DataSourceConnectEventArgs : EventArgs {
        private DbConnection connection_;


        /// <summary>
        /// 
        /// </summary>
        public DataSourceConnectEventArgs(DbConnection __connection) {
            this.connection_ = __connection;
        }


        /// <summary>
        /// 
        /// </summary>
        public DbConnection connection {
            get {
                return connection_;
            }
        }
    }


    /// <summary>
    /// DataSourceConnect イベントを処理するメソッドを表します。
    /// </summary>
    /// <param name="__sender"></param>
    /// <param name="__dscea"></param>
    public delegate void DataSourceConnectEventHandler(object __sender, DataSourceConnectEventArgs __dscea);


    /// <summary>
    /// データソースへのアクセスを肩代わりし、イベントでテーブルへのアクセスを提供します。
    /// </summary>
    public class DataSourceAccessor {


        /// <summary>
        /// データソースへの接続が終了したときに呼び出されます。
        /// </summary>
        public event DataSourceConnectEventHandler connecting;


        /// <summary>
        /// 接続オブジェクト作成用。
        /// </summary>
        private utils.ConnectionFactory factory_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        public DataSourceAccessor(utils.ConnectionFactory __factory) {
            this.factory_ = __factory;
        }


        /// <summary>
        /// データベースへの接続を開きます。
        /// </summary>
        public void connect() {
            onConnecting();
        }


        /// <summary>
        /// connecting イベントを発生させます。
        /// </summary>
        protected virtual void onConnecting() {
            if ( this.connecting != null ) {
                using ( DbConnection connection = factory_.get_connection() ) {

                    if ( connection.State == ConnectionState.Closed ) {
                        // 閉じられていたら開きます。
                        connection.Open();
                    }

                    // 
                    this.connecting( this, new DataSourceConnectEventArgs( connection ) );
                }
            }
        }


        /// <summary>
        /// 内部で使用している接続オブジェクトファクトリーを返します。
        /// </summary>
        public utils.ConnectionFactory factory {
            get {
                return factory_;
            }
        }
    }

}