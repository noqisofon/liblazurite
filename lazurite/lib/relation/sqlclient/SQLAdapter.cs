using System.Data.SqlClient;


namespace lazurite.relation.sqlclient {
    
    
    /// <summary>
    /// DataSource �����b�v���ăA�_�v�^�[�p�� SqlConnection ��Ԃ����\�b�h���`���܂��B
    /// </summary>
    public interface SQLAdapter {
        /// <summary>
        /// 
        /// </summary>
        common.IADODataSource dataSource { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SqlConnection getConnection();
    }
}