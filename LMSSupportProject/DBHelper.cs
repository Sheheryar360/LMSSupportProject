using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LMSSupportProject
{
    public class DBHelper
    {
        private readonly string connectionString;

        public DBHelper(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public DataTable GetData(string QueryName, Dictionary<string, object> parameters = null)
        {
            var dt = new DataTable();


            using (var conn = new SqlConnection(connectionString))
            {
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = GetQueryFromResources(QueryName);

                if (parameters != null)
                    foreach (var parameter in parameters)
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));

                conn.Open();

                var reader = command.ExecuteReader();

                dt.Load(reader);
            }

            return dt;
        }

        public object Insert(string QueryName, Dictionary<string, object> parameters = null)
        {
            object retVal = null;


            using (var conn = new SqlConnection(connectionString))
            {
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = GetQueryFromResources(QueryName);

                if (parameters != null)
                    foreach (var parameter in parameters)
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));

                conn.Open();

                retVal = command.ExecuteScalar();
            }

            return retVal;
        }

        public int UpdateOrDelete(string QueryName, Dictionary<string, object> parameters = null)
        {
            int retVal = -1;

            using (var conn = new SqlConnection(connectionString))
            {
                var command = conn.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = GetQueryFromResources(QueryName);

                if (parameters != null)
                    foreach (var parameter in parameters)
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));

                conn.Open();

                retVal = command.ExecuteNonQuery();
            }

            return retVal;
        }

        private string GetQueryFromResources(string QueryName)
        {
            return ResourceUtil.GetResourceValue(QueryName);

        }
    }
}
