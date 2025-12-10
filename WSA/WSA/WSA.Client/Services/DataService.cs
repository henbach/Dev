using WSA.Shared.DTOs;
using WSA.Shared.Models;

namespace WSA.Client.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetSchemasAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<string>>("api/data/schemas")
                    ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching schemas: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task<List<TableInfo>> GetTablesAsync(string schema)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<TableInfo>>($"api/data/tables/{schema}")
                    ?? new List<TableInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tables: {ex.Message}");
                return new List<TableInfo>();
            }
        }

        public async Task<QueryResult> GetTableDataAsync(DataRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/data/query", request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<QueryResult>()
                    ?? new QueryResult { ErrorMessage = "No data returned" };
            }
            catch (Exception ex)
            {
                return new QueryResult { ErrorMessage = $"Error: {ex.Message}" };
            }
        }
    }
}
