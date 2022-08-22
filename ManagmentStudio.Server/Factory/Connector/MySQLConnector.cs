using MySqlConnector;

namespace ManagmentStudio.Server.Factory.Connector
{
    public class MySQLConnector : BaseConnector
    {
        public MySQLConnector(string connectionString) : base(connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }
        public override List<string> GetDatabases()
        {
            var resault = new List<string>();

            var mySqlQuery = "show databases;";

            var reqset = ExecuteQuery("", mySqlQuery);

            foreach (var row in reqset.Rows)
            {
                if (row.Data.Count > 0) resault.Add(row.Data[0].ToString());
            }

            return resault;
        }

        public override List<string> GetTables(string databaseName)
        {

            var resault = new List<string>();

            var mySqlQuery = $"show tables";

            var reqset = ExecuteQuery(databaseName, mySqlQuery);

            foreach (var row in reqset.Rows)
            {
                if (row.Data.Count > 0) resault.Add(row.Data[0].ToString());
            }

            return resault;
        }
    }
}
