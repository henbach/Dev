using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class PmsLayoutDefinition
    {
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, string> Directions { get; set; } = new();
        public Dictionary<string, string> ZonePositionMapping { get; set; } = new();
        public string[] Zones { get; set; } = Array.Empty<string>();
    }
}
