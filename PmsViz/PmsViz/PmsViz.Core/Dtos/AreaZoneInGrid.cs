using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class AreaZoneInGrid
    {
        public const string DIRECTIONAL_SYMBOLS = "ee;ww;nn;ss;XX";
        public const string NON_ZONE_SYMBOLS = "--";

        public string Id { get; set; }
        public List<(int, int)> positions { get; set; } = new();
        public Dictionary<string, string> ZonePositionMapping { get; set; } = new();
        public string Direction { get; set; }
        public List<Dictionary<string, object>> ZoneData { get; set; } = new();

        public List<Dictionary<string, object>> ElementsInsideZoneData
        {
            get 
            {
                List<Dictionary<string, object>> rgvs = new();
                foreach (var item in ZoneData)
                {
                    rgvs.Add(new Dictionary<string, object>()
                        {
                            { "Hu",  item.GetValueAsString("mtru_ident") },                   
                        });
                }
                return rgvs;                
            }
        }

        public bool IsAreaToShowDirection
        {
            get
            {
                return DIRECTIONAL_SYMBOLS.Contains(Id);
            }
        }
        public string ZoneDisplayName
        {
            get
            {
                if(NON_ZONE_SYMBOLS.Contains(Id))
                {
                    return string.Empty;
                }
                if(Id == "ee")
                {
                    return "→";
                }
                if (Id == "ww")
                {
                    return "←";
                }
                if (Id == "nn")
                {
                    return "↑";
                }
                if (Id == "ss")
                {
                    return "↓";
                }
                if (Id == "XX")
                {
                    return "°";
                }

                if (ZonePositionMapping != null && ZonePositionMapping.ContainsKey(Id))
                {
                    return ZonePositionMapping[Id];
                }
                return Id;
            }
        }

        public string GetCssClassForPositionState()
        {
            if ("nn;ss;ee;ww;XX".Contains(Id))
            {
                return "loop-grid-direction-item";
            }
            else if ("--".Contains(Id))
            {
                return "loop-grid-empty-item";
            }

            var zoneData = ZoneData.FirstOrDefault();
            if (zoneData != null)
            {
                int? op_mode_plc = zoneData.GetValueAsInt("MPOS_OP_MODE_PLC");

                if(op_mode_plc == null )
                {
                    return "loop-grid-item";
                }
                else if(op_mode_plc == 0) // Automatic
                {
                    return "loop-grid-item automatic";
                }
                else if (op_mode_plc == 1 || op_mode_plc == 2) // Manual
                {
                    return "loop-grid-item manual";
                }
                else if (op_mode_plc == 3) // Out of service
                {
                    return "loop-grid-item error";
                }

            }
            return "loop-grid-item";
        }
        public string GetStyleForPosition()
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
