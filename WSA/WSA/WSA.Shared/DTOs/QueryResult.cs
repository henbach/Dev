using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSA.Shared.Models;

namespace WSA.Shared.DTOs
{
    public class QueryResult
    {
        public List<Dictionary<string, object>> Data { get; set; } = new();
        public List<ColumnInfo> Columns { get; set; } = new();
        public int TotalRecords { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
