using ManagmentStudio.Shared;

namespace ManagmentStudio.Cleant.Services
{
    public class ServerService : IServerService
    {
        private readonly HttpClient _httpClient;

        public ServerService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<bool> CheckConnect(ServerSet serverSet)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Server/CheckConnect", serverSet);
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<ResultSet> ExecuteQuery(string databaseName, string query)
        {
            var resultSet = new ResultSet();
            //var result = await _httpClient.GetFromJsonAsync<ResultSet>($"api/Server/GetExecuteQuery/{databaseName}/{query}");
            var result = _httpClient.GetAsync($"api/Server/GetExecuteQuery/{databaseName}/{query}").GetAwaiter().GetResult();
             if (result.IsSuccessStatusCode)
            {
                resultSet = result.Content.ReadFromJsonAsync<ResultSet>().GetAwaiter().GetResult();
                return resultSet;
            }
            else
                return resultSet;
        }

        public async Task<List<string>> GetDatabases()
        {
            List<string> list = new();
            //var result = await _httpClient.GetFromJsonAsync<string[]>("api/Server/GetDatabases");
            var result = await _httpClient.GetAsync("api/Server/GetDatabases");
            if (result.IsSuccessStatusCode)
            {
                var read = await result.Content.ReadFromJsonAsync<string[]>();
                return list = read.ToList();
            }
            else
                return list;
            
        }

        public async  Task<List<string>> GetTables(string databaseName)
        {
            List<string> list = new();
            //var result = await _httpClient.GetFromJsonAsync<string[]>($"api/Server/GetTables/{databaseName}");
            var result = _httpClient.GetAsync($"api/Server/GetTables/{databaseName}").GetAwaiter().GetResult();
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadFromJsonAsync<string[]>().GetAwaiter().GetResult();
                return list = read.ToList();
            }
            else
                return list;
        }
    }
}
