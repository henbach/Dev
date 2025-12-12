using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class PmsLayoutDefinition
    {
        public string ApiEndPoint { get; set; }
        public string QueryName { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; } = new();
        public Dictionary<string, string> Directions { get; set; } = new();
        public Dictionary<string, string> ZonePositionMapping { get; set; } = new();
        public string[] Zones { get; set; } = Array.Empty<string>();
    }
}
