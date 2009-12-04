using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace lazurite.relation.sqlclient {


    /// <summary>
    /// 
    /// </summary>
    public class SQLParameterFactory {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, string> sqltype_book_;
        /// <summary>
        /// 
        /// </summary>
        private string tablename_;
        /// <summary>
        /// 
        /// </summary>
        private SQLAdapter adapter_;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="__tablename"></param>
        public SQLParameterFactory(string __tablename, SQLAdapter __adapter) {
            this.sqltype_book_ = new Dictionary<int, string>();
            this.tablename_ = __tablename;
            this.adapter_ = __adapter;
            fetchTypeInfos();
        }


        /// <summary>
        /// 
        /// </summary>
        private void fetchTypeInfos() {

            string[] query_lines = new string[] {
                "select  name,",
                "        user_type_id",
                "    from",
                "        sys.types",
                "    order by",
                "        name"
            };

            StringBuilder query_builder = new StringBuilder();
            foreach ( string query_line in query_lines ) {
                query_builder.AppendLine( query_line );
            }

            using ( SqlConnection connection = this.adapter_.getConnection() ) {
                if ( connection.State == ConnectionState.Closed ) {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand( query_builder.ToString(), connection );
                using ( IDataReader reader = command.ExecuteReader() ) {
                    while ( reader.Read() ) {
                        int user_type_id = int.Parse( reader["user_type_id"].ToString() );
                        string name = reader["name"].ToString();

                        this.sqltype_book_.Add( user_type_id, name );
                    }
                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlParameter[] create(string[] __column_names) {
            List<SqlParameter> result_parameters = new List<SqlParameter>();
            StringBuilder query_builder = new StringBuilder();

            query_builder.AppendLine( "select  name," );
            query_builder.AppendLine( "        xtype" );
            query_builder.AppendLine( "    from" );
            query_builder.AppendLine( "        syscolumns" );
            query_builder.AppendLine( "    where " );
            query_builder.AppendLine( "        id = object_id('{0}') and" );
            query_builder.Append( "        name in (" );
            int i = 0, length = __column_names.Length;
            foreach ( string column_name in __column_names ) {
                query_builder.AppendFormat( "'{0}'", column_name );
                if ( i < ( length - 1 ) ) {
                    query_builder.Append( ", " );
                }
                ++i;
            }
            query_builder.AppendLine( ")" );
            query_builder.AppendLine( "    order by" );
            query_builder.AppendLine( "        colid" );

            using ( SqlConnection connection = this.adapter_.getConnection() ) {
                if ( connection.State == ConnectionState.Closed ) {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand( string.Format( query_builder.ToString(), this.tablename_ ), connection );
                util.Enumeration<SqlDbType> sqldb_type = new util.Enumeration<SqlDbType>();
                using ( IDataReader reader = command.ExecuteReader() ) {
                    while ( reader.Read() ) {
                        int xtype = int.Parse( reader["xtype"].ToString() );

                        string parameter_name = reader["name"].ToString().ToLower();
                        SqlDbType type = sqldb_type.valueOf( sqltype_book_[xtype], true );

                        result_parameters.Add( new SqlParameter( parameter_name, type ) );
                    }
                }
            }
            return result_parameters.ToArray();
        }
    }
}