using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class AreaZoneInGrid
    {
        public const string DIRECTIONAL_SYMBOLS = "ee;ww;nn;ss";
        public const string NON_ZONE_SYMBOLS = "XX;--";


        public string id { get; set; }
        public List<(int, int)> positions { get; set; } = new();
        public Dictionary<string, string> ZoneMappings { get; set; } = new();
        public string Direction { get; set; }
        public List<Dictionary<string, string>> RgvData { get; set; } = new();

        public bool isDirectional
        {
            get
            {
                return DIRECTIONAL_SYMBOLS.Contains(id);
            }
        }
        public string ZoneDisplayName
        {
            get
            {
                if(NON_ZONE_SYMBOLS.Contains(id))
                {
                    return string.Empty;
                }
                if(id == "ee")
                {
                    return "→";
                }
                if (id == "ww")
                {
                    return "←";
                }
                if (id == "nn")
                {
                    return "↑";
                }
                if (id == "ss")
                {
                    return "↓";
                }
                if (ZoneMappings != null && ZoneMappings.ContainsKey(id))
                {
                    return ZoneMappings[id];
                }
                return id;
            }
        }

        public string GetCssClass()
        {
            if ("nn;ss;ee;ww".Contains(id))
            {
                return "loop-grid-direction-item";
            }
            else if ("--".Contains(id))
            {
                return "loop-grid-empty-item";
            }

            return "loop-grid-item";
        }
        public string GetStyle()
        {
            int minX = positions.Select(x => x.Item1).Min();
            int maxX = positions.Select(x => x.Item1).Max();
            int minY = positions.Select(x => x.Item2).Min();
            int maxY = positions.Select(x => x.Item2).Max();


            string spanColumn = $"grid-column: {minX + 1} / {maxX + 2};";  /* Starts at column 2, ends before column 5 */
            string spanRow = $"grid-row: {minY + 1} / {maxY + 2};";    /* Starts at row 1, ends before row 3 */
            return spanColumn + spanRow;
        }
    }
}
