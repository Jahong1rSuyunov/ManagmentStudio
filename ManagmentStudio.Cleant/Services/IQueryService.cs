using ManagmentStudio.Shared;

namespace ManagmentStudio.Cleant.Services
{
    public interface IQueryService
    {
        Task<List<Query>> GetQueries(string ConnectorType);
        Task<Query> GetQuery(int id);
        Task Delete(int id);
        Task UpdateQuery(Query query);
        Task Create(Query query);
        Task<bool> CheckName(string name, string ConnectorType);


    }
}
