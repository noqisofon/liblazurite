using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace lazurite.etherial {


    using lazurite.common;


    /**
     * @class   DataBaseStorage     DataBaseStorage.cs
     * DataBaseStorage クラスは、複数のオブジェクトからテーブルを使用できるように、
     * 共通したプロトコルを提供します。
     */
    public class DataBaseStorage  {
        /**
         * テーブルの入れ物です。
         */
        private DataSet dataset_;
        /**
         * 上記の 2 つを使用してデータベースからテーブルをロードします。
         */
        private DataBaseLoader loader_;


        /**
         * データベース名を指定して、その名を持つデータセットなどを構築します。
         *      @param  __database_name データベース名。
         */
        public DataBaseStorage(string __database_name) {
            this.dataset_ = new DataSet( __database_name );
            this.loader_ = new DataBaseLoader( new SqlDataAdapter(), dataset_ );
        }
        /**
         * データベース名を指定して、その名を持つデータセットなどを構築します。
         *      @param  __database_name データベース名。
         */
        public DataBaseStorage(string __database_name, DbDataAdapter __adapter) {
            this.dataset_ = new DataSet( __database_name );
            this.loader_ = new DataBaseLoader( __adapter, dataset_ );
        }


        /**
         * 指定されたテーブル名を受け取ってデータベースからテーブルを読み込みます。
         *      @param  __table_name    読み込みたいテーブル名。
         */
        public void load(string __table_name) {
            this.loader_.load( __table_name );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__creater"></param>
        public void load(string __table_name, CommandTextCreator __creater) {
            this.loader_.load( __table_name, __creater );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <param name="__src"></param>
        /// <param name="__grid"></param>
        public void binding(string __table_name, BindingSource __src, DataGridView __grid) {
            __src.DataSource = this.dataset_.Tables[__table_name];
            __grid.DataSource = __src;
        }


        /**
         * 指定されたテーブル名のテーブルのインデックス番号を返します。
         */
        public int indexOf(string __table_name) {
            return this.dataset_.Tables.IndexOf( __table_name );
        }


        /**
         * 指定されたテーブル名があるかどうか調べます。
         */
        public bool contains(string __table_name) {
            return this.dataset_.Tables.Contains( __table_name );
        }


        /**
         * 指定されたテーブルを削除します。
         */
        public void remove(string __table_name) {
            this.dataset_.Tables.Remove( this.dataset_.Tables[__table_name] );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__index"></param>
        /// <returns></returns>
        public DataTable this[int __index] {
            get {
                return this.dataset_.Tables[__index];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__table_name"></param>
        /// <returns></returns>
        public DataTable this[string __table_name] {
            get {
                return this.dataset_.Tables[__table_name];
            }
        }


        /**
         * 指定されたテーブルをデリゲートに渡します。
         *      @param  テーブル名。
         *      @param  テーブルに向かって行う処理。
         */
        public void invoke_table(TableInvoker __invoker) {
            foreach ( DataTable table in this.dataset_.Tables ) {
                __invoker( table );
            }
        }
    }
}