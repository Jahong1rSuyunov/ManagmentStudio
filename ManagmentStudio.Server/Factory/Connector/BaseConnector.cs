using ManagmentStudio.Server.Factory.Interfice;
using ManagmentStudio.Shared;
using System.Data;
using System.Data.SqlClient;

namespace ManagmentStudio.Server.Factory.Connector
{
    public abstract class BaseConnector : IConnector
    {
        protected IDbConnection connection = null;
        protected string? connectionString;

        public BaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual bool CheckConnect()
        {
            if (connection == null)
            {
                return false;
            }
            else
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
           
        }

        public virtual ResultSet ExecuteQuery(string databaseName, string query)
        {
            
            var resault = new ResultSet();
            

            try
            {
                connection.ConnectionString = connectionString + $"database={databaseName}";
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                connection.Open();
                var reader = cmd.ExecuteReader();

                if (reader.FieldCount > 0 )
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var colName = reader.GetName(i);
                        resault.Columns.Add(colName);
                    }

                    while (reader.Read())
                    {
                        var row = new Row();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var data = reader[i];
                            row.Data.Add(data);
                        }

                        resault.Rows.Add(row);
                    }
                }

            }
            catch (SqlException)
            {
                resault = null;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
             }
            return resault;
        }

        public abstract List<string> GetDatabases();

        public abstract List<string> GetTables(string databaseName);
    }
}
