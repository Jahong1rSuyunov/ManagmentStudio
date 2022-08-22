using ManagmentStudio.Shared;

namespace ManagmentStudio.Cleant.Services
{
    public class QueryService : IQueryService
    {
        private readonly HttpClient _httpClient;

        public QueryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<bool> CheckName(string name, string ConnectorType)
        {
            return await _httpClient.GetFromJsonAsync<bool>($"api/Query/CheckName/{name}/{ConnectorType}");
        }

        public async Task Create(Query query)
        {
            await _httpClient.PostAsJsonAsync($"api/Query/CreateQuery", query);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Query/DeleteQuery/{id}");
        }

        public async Task<List<Query>> GetQueries(string ConnectorType)
        {
            var result = await _httpClient.GetFromJsonAsync<Query[]>($"api/Query/GetQueries/{ConnectorType}");
            return result.ToList();
        }

        public async Task<Query> GetQuery(int id)
        {
            return await _httpClient.GetFromJsonAsync<Query>($"api/Query/GetQuery/{id}");
        }

        public async Task UpdateQuery(Query query)
        {
            await _httpClient.PutAsJsonAsync($"api/Query/UpdateQuery", query);
        }
    }
}
