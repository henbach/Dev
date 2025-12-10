using WSA.Shared.DTOs;
using WSA.Shared.Models;

namespace WSA.Client.Services
{
    public interface IDataService
    {
        Task<List<string>> GetSchemasAsync();
        Task<List<TableInfo>> GetTablesAsync(string schema);
        Task<QueryResult> GetTableDataAsync(DataRequest request);
    }
}
