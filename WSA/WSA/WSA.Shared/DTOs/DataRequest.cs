using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSA.Shared.DTOs
{
    public class DataRequest
    {
        public string TableName { get; set; } = string.Empty;
        public string Schema { get; set; } = "USER"; // Default schema
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public string? SortColumn { get; set; }
        public bool SortDescending { get; set; } = false;
        public List<FilterCondition>? Filters { get; set; }
    }
}
