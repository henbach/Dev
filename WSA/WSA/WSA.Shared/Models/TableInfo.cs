using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSA.Shared.Models
{
    public class TableInfo
    {
        public string TableName { get; set; } = string.Empty;
        public string Schema { get; set; } = string.Empty;
        public int RowCount { get; set; }
        public DateTime? LastUpdated { get; set; }
        public List<ColumnInfo> Columns { get; set; } = new();
    }
}
