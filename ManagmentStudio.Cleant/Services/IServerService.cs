using ManagmentStudio.Shared;

namespace ManagmentStudio.Cleant.Services
{
    public interface IServerService
    {
        Task<List<string>> GetDatabases();

        Task<List<string>> GetTables(string databaseName);

        Task<ResultSet> ExecuteQuery(string databaseName, string query);

        Task<bool> CheckConnect(ServerSet serverSet);
    }
}
