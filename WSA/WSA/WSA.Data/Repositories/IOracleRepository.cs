using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSA.Shared.DTOs;
using WSA.Shared.Models;


namespace WSA.Data.Repositories
{
    public interface IOracleRepository
    {
        Task<List<TableInfo>> GetTablesAsync(string schema = "USER");
        Task<QueryResult> GetTableDataAsync(DataRequest request);
        Task<List<string>> GetSchemasAsync();
        Task<TableInfo> GetTableDetailsAsync(string schema, string tableName);
    }
}
