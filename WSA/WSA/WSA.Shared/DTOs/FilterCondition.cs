using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSA.Shared.DTOs
{
    public class FilterCondition
    {
        public string ColumnName { get; set; } = string.Empty;
        public string Operator { get; set; } = "="; // =, <>, >, <, LIKE, etc.
        public string Value { get; set; } = string.Empty;
    }
}
