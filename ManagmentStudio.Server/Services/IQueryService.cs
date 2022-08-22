using ManagmentStudio.Shared;

namespace ManagmentStudio.Server.Services
{
    public interface IQueryService
    {
        public Task<List<Query>> GetQueries(string ConnectorType);
        public Task<Query> GetQuery(int id);
        public Task Delete(int id);
        public Task UpdateQuery(Query query);
        public Task<Query> Create(Query query);
        public Task<bool> CheckName(string name, string ConnectorType);
    }
}
