using Npgsql;

namespace ManagmentStudio.Server.Factory.Connector
{
    public class NpgSqlConnector : BaseConnector
    {
        public NpgSqlConnector(string connectionString) : base(connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }
        public override List<string> GetDatabases()
        {
            var resault = new List<string>();

            var NpgSqlQuery = "SELECT datname FROM pg_database;";

            var reqset = ExecuteQuery("", NpgSqlQuery);

            foreach (var row in reqset.Rows)
            {
                if (row.Data.Count > 0) resault.Add(row.Data[0].ToString());
            }

            return resault;
        }

        public override List<string> GetTables(string databaseName)
        {
            var resault = new List<string>();

            var NpgSqlQuery = $"SELECT * FROM information_schema.tables WHERE table_schema = '{databaseName}';";

            var reqset = ExecuteQuery(databaseName, NpgSqlQuery);

            foreach (var row in reqset.Rows)
            {
                if (row.Data.Count > 0) resault.Add(row.Data[0].ToString());
            }

            return resault;
        }
    }
}
