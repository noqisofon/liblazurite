using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

using building = lazurite.pattern.building;
using etherial = lazurite.etherial;


namespace lazurite.util {
    
    
    /// <summary>
    /// DataGridViewMaker �N���X�́ASQL Server ����ǂݍ��񂾃e�[�u�������Ƃ�
    /// DataGridView �Ƀo�C���h���鏈���������I�ɍs���܂��B
    /// </summary>
    class DataGridViewMaker {
        /// <summary>
        /// �N���X���Ŏg���܂킷���߂̃e�[�u���B
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
        /// �ڑ��ƃe�[�u�������󂯎���āA�e�[�u�������肵�܂��B
        /// </summary>
        /// <remarks>�f���Q�[�g�ɂ��Ȃ��Ă������񂾂��ǁA�����f���Q�[�g�������̂ŁB</remarks>
        private load_predicate load_handler_  = delegate(IDbConnection __connection, string __table_name) {
            if ( __connection.State == ConnectionState.Closed ) {
                // �ڑ������Ă�����A�J���܂��B
                __connection.Open();
            }

            // SQL �̃N�G���I�u�W�F�N�g���쐬���܂��B
            SqlCommand command = new SqlCommand( string.Format( "select * from {0}",
                                                                __table_name
                                                              ),
                                                 __connection as SqlConnection
                                               );
            // ���o�����e�[�u���̓��e��ǂݎ��I�u�W�F�N�g���擾���܂��B
            IDataReader reader = command.ExecuteReader();

            // DataTable �쐬�p�̐E�l������쐬���܂��B
            building::DataTableBuilder table_builder = new building::DataTableBuilder( __table_name, reader );

            // ������w������ėp�ē��쐬���܂��B
            building::Director<DataTable> director = new building::Director<DataTable>( table_builder );
            // �ēɎw�����o�����āA�E�l����Ƀe�[�u������点�܂��B
            director.construct();

            // �o���オ���� DataTable ��[�i���܂��B 
            return table_builder.result;
        };


        /// <summary>
        /// �����s��Ȃ��B
        /// </summary>
        /// <remark>loadDataTable() ���Ă񂾂��Ƃ� binding() ���Ă�ł��������B</remark>
        public DataGridViewMaker() {
        }
        /// <summary>
        /// �w�肳�ꂽ�f�[�^�x�[�X���ƃe�[�u�����ŁA�V���� GridViewMaker �I�u�W�F�N�g���\�z���܂��B
        /// </summary>
        /// <param name="__database_name">�f�[�^�x�[�X���B</param>
        /// <param name="__table_name">�e�[�u�����B</param>
        public DataGridViewMaker(string __database_name, string __table_name) {
            this.source_ = loadDataTable( __database_name, __table_name );
        }
        /// <summary>
        /// �w�肳�ꂽ�f�[�^�x�[�X���ƃe�[�u�����A�y�у��[�h�p�q��f���Q�[�g��
        /// �V���� GridViewMaker �I�u�W�F�N�g���\�z���܂��B
        /// </summary>
        /// <param name="__database_name">�f�[�^�x�[�X���B</param>
        /// <param name="__table_name">�e�[�u�����B</param>
        /// <param name="__pred">���[�h�p�̏q��f���Q�[�g�B</param>
        public DataGridViewMaker(string __database_name, string __table_name, load_predicate __pred) {
            this.load_handler_ = __pred;
            loadDataTable( __database_name, __table_name );
        }


        /// <summary>
        /// �w�肳�ꂽ�f�[�^�x�[�X����e�[�u��������Ă��܂��B
        /// </summary>
        /// <param name="__database_name">�f�[�^�x�[�X���B</param>
        /// <param name="__table_name">�e�[�u�����B</param>
        /// <returns>�ǂݍ��܂ꂽ�e�[�u���B</returns>
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
        /// �f�[�^�e�[�u�����g�p���ăf�[�^�O���b�h�r���[�ɃR���o�[�g���܂��B
        /// </summary>
        /// <param name="__dataGridView">�R���o�[�g������ �f�[�^�O���b�h�r���[�B</param>
        /// <returns>�R���o�[�g���ꂽ�f�[�^�O���b�h�r���[�B</returns>
        public DataGridView binding(DataGridView __dataGridView) {
            building::DataGridViewBuilder datagrid_builder = new building::DataGridViewBuilder( __dataGridView, this.source_ );
            building::Director<DataGridView> director = new building::Director<DataGridView>( datagrid_builder );

            director.construct();

            return datagrid_builder.result;
        }
    }
}
