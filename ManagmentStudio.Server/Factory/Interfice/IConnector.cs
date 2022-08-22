using ManagmentStudio.Shared;

namespace ManagmentStudio.Server.Factory.Interfice
{
    public interface IConnector
    {
        public List<string> GetDatabases();

        public List<string> GetTables(string databaseName);

        public ResultSet ExecuteQuery(string databaseName, string query);

        public bool CheckConnect();
    }
}
