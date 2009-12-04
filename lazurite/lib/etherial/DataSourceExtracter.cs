using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


namespace lazurite.etherial {


    /// <summary>
    /// �f�[�^�\�[�X�𒊏o���邽�߂̏������ȗ�������N���X�ł��B
    /// </summary>
    public class DataSourceExtracter {
        /// <summary>
        /// SQL Server �ւ̐ڑ��I�u�W�F�N�g���쐬���邽�߂̃N���X�ł��B
        /// </summary>
        private SQLClientConnectionFactory ssc_factory_;
        /// <summary>
        /// �����f�[�^�Z�b�g�ł��B
        /// </summary>
        private DataSet content_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__factory"></param>
        public DataSourceExtracter(SQLClientConnectionFactory __factory) {
            this.ssc_factory_ = __factory;
            this.content_ = new DataSet( __factory.dataSource );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        public DataSourceExtracter(string __data_source_name, string __initial_catalog) {
            initialize( __data_source_name, true, __initial_catalog, null );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        /// <param name="__having_security"></param>
        public DataSourceExtracter(string __data_source_name, string __initial_catalog, bool __having_security) {
            initialize( __data_source_name, __having_security, __initial_catalog, null );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        /// <param name="__having_security"></param>
        /// <param name="__disk"></param>
        public DataSourceExtracter(string __data_source_name, string __initial_catalog, bool __having_security, utils.ConnectionFactory.AccountDisk __disk) {
            initialize( __data_source_name, __having_security, __initial_catalog, __disk );
        }


        /// <summary>
        /// �R���X�g���N�^�Ŏg�p���鏉���������ł��B
        /// </summary>
        /// <param name="__data_source_name"></param>
        /// <param name="__initial_catalog"></param>
        /// <param name="__having_security"></param>
        private void initialize(string __data_source_name, bool __having_security, string __initial_catalog, utils.ConnectionFactory.AccountDisk __disk) {
            if ( __disk == null ) {
                this.ssc_factory_ = new SQLClientConnectionFactory( __data_source_name,
                                                                    __having_security,
                                                                    __initial_catalog
                                                                  );
            } else {
                this.ssc_factory_ = new SQLClientConnectionFactory( __data_source_name,
                                                                    __having_security,
                                                                    __initial_catalog,
                                                                    __disk
                                                                  );
            }
            this.content_ = new DataSet( __data_source_name );
        }


        /// <summary>
        /// �����f�[�^�Z�b�g�Ɏw�肳�ꂽ���O�̃e�[�u�������邩���ׂ܂��B
        /// </summary>
        /// <param name="__table_name">���ׂ����e�[�u���̖��O�B</param>
        /// <returns></returns>
        public bool has_table(string __table_name) {
            //bool result = true;
            if ( this.content_.Tables.Count == 0 ) {
                // ���������e�[�u���������ĂȂ��Ȃ�A�ⓚ���p�ŋU��Ԃ��܂��B
                return false;
            }
            // �e�[�u���� 1 �ł����݂��Ă�����
            // �w�肳�ꂽ���O�̃e�[�u�������邩�ǂ������ׂ܂��B
            return this.content_.Tables.Contains( __table_name ) ? true : false;
        }


        /// <summary>
        /// �f�[�^�x�[�X����e�[�u����ǂݍ���ł����Ԃ��܂��B
        /// </summary>
        /// <param name="__command">�e�[�u����ǂݍ��ނ��߂� select �R�}���h�B</param>
        /// <param name="__table_name">�e�[�u�����B</param>
        /// <returns></returns>
        public DataTable fill_table(SqlCommand __command, string __table_name) {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = __command;

            if ( has_table( __table_name ) ) {
                this.content_.Tables.Remove( this.content_.Tables[__table_name] );
            }
            adapter.Fill( this.content_, __table_name );

            return this.content_.Tables[__table_name];
        }


        /// <summary>
        /// �N�G��������ƃe�[�u�������󂯎���āA�ǂݍ��܂ꂽ�e�[�u����
        /// DataView �ɓ���ĕԂ��܂��B
        /// </summary>
        /// <param name="__sql_query">�e�[�u����ǂݍ��ނ��߂̃N�G��������B</param>
        /// <param name="__table_name">�ǂݍ��ރe�[�u���̖��O�B</param>
        /// <returns></returns>
        public ICollection getDataSource(SqlCommand __command, string __table_name) {
            return getDataSource( __command, __table_name, false );
        }
        /// <summary>
        /// �N�G��������ƃe�[�u�������󂯎���āA�ǂݍ��܂ꂽ�e�[�u����
        /// DataView �ɓ���ĕԂ��܂��B
        /// </summary>
        /// <remarks>
        /// __fly_weight ���^�Ȃ�A�f�[�^�Z�b�g���ɓ����̃e�[�u�����������Ƃ��A
        /// �f�[�^�x�[�X��ǂݍ��܂��ɁA�f�[�^�Z�b�g������o���ĕԂ��܂��B
        /// </remarks>
        /// <param name="__sql_query">�e�[�u����ǂݍ��ނ��߂̃N�G��������B</param>
        /// <param name="__table_name">�ǂݍ��ރe�[�u���̖��O�B</param>
        /// <param name="__fly_weight">�t���C�E�F�C�g���邩�ǂ���</param>
        /// <returns></returns>
        public ICollection getDataSource(SqlCommand __command, string __table_name, bool __fly_weight) {
            DataTable tmp_table = null;
            if ( has_table( __table_name ) && __fly_weight == false ) {
                tmp_table = this.content_.Tables[__table_name];
            } else {
                using ( SqlConnection connection = this.ssc_factory_.getConnection() ) {
                    if ( connection.State == ConnectionState.Closed ) {
                        connection.Open();
                    }
                    __command.Connection = connection;

                    tmp_table = fill_table( __command, __table_name );
                }
            }
            return new DataView( tmp_table );
        }


        /// <summary>
        /// 
        /// </summary>
        public bool is_empty {
            get {
                return content_.Tables.Count == 0;
            }
        }
    }
}