using Oracle.ManagedDataAccess.Client;
using PmsViz.Core.Interfaces;

namespace PmsViz.Implementations
{
    public class OracleDao : IPmsDao
    {
        // Connection string format
        string user = "E01100546";// _JHE";
        const string password = "i5ihsmpeAS";

        string host = "10.88.160.102";// "YAREN";
        const string service = "PROD";

        string connectionString { get { return $"User Id={user};Password={password};Data Source=//{host}:1521/{service}"; } }


        public OracleDao(string host, string user)
        {
            this.host = host;
            this.user = user;
        }

        public List<Dictionary<string, object>> ExecuteDynamicQuery(string sqlQuery)
        {
            var list = new List<Dictionary<string, object>>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Execute queries or commands here
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sqlQuery;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var value = reader.GetValue(i);
                                    if (value is System.DBNull)
                                        value = string.Empty;
                                    row[reader.GetName(i)] = value;
                                }
                                list.Add(row);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return list;
        }

        public bool TestConnection()
        {
            bool rc = false;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to Oracle database!");

                    // Execute queries or commands here
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT 1 from dual";
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rc = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return rc;
        }
    }
}

