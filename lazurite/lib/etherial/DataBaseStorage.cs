using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace lazurite.etherial {


    using lazurite.common;


    /**
     * @class   DataBaseStorage     DataBaseStorage.cs
     * DataBaseStorage �N���X�́A�����̃I�u�W�F�N�g����e�[�u�����g�p�ł���悤�ɁA
     * ���ʂ����v���g�R����񋟂��܂��B
     */
    public class DataBaseStorage  {
        /**
         * �e�[�u���̓��ꕨ�ł��B
         */
        private DataSet dataset_;
        /**
         * ��L�� 2 ���g�p���ăf�[�^�x�[�X����e�[�u�������[�h���܂��B
         */
        private DataBaseLoader loader_;


        /**
         * �f�[�^�x�[�X�����w�肵�āA���̖������f�[�^�Z�b�g�Ȃǂ��\�z���܂��B
         *      @param  __database_name �f�[�^�x�[�X���B
         */
        public DataBaseStorage(string __database_name) {
            this.dataset_ = new DataSet( __database_name );
            this.loader_ = new DataBaseLoader( new SqlDataAdapter(), dataset_ );
        }
        /**
         * �f�[�^�x�[�X�����w�肵�āA���̖������f�[�^�Z�b�g�Ȃǂ��\�z���܂��B
         *      @param  __database_name �f�[�^�x�[�X���B
         */
        public DataBaseStorage(string __database_name, DbDataAdapter __adapter) {
            this.dataset_ = new DataSet( __database_name );
            this.loader_ = new DataBaseLoader( __adapter, dataset_ );
        }


        /**
         * �w�肳�ꂽ�e�[�u�������󂯎���ăf�[�^�x�[�X����e�[�u����ǂݍ��݂܂��B
         *      @param  __table_name    �ǂݍ��݂����e�[�u�����B
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
         * �w�肳�ꂽ�e�[�u�����̃e�[�u���̃C���f�b�N�X�ԍ���Ԃ��܂��B
         */
        public int indexOf(string __table_name) {
            return this.dataset_.Tables.IndexOf( __table_name );
        }


        /**
         * �w�肳�ꂽ�e�[�u���������邩�ǂ������ׂ܂��B
         */
        public bool contains(string __table_name) {
            return this.dataset_.Tables.Contains( __table_name );
        }


        /**
         * �w�肳�ꂽ�e�[�u�����폜���܂��B
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
         * �w�肳�ꂽ�e�[�u�����f���Q�[�g�ɓn���܂��B
         *      @param  �e�[�u�����B
         *      @param  �e�[�u���Ɍ������čs�������B
         */
        public void invoke_table(TableInvoker __invoker) {
            foreach ( DataTable table in this.dataset_.Tables ) {
                __invoker( table );
            }
        }
    }
}