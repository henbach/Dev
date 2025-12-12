using PmsViz.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Models
{
    public class AreaZoneInGridHelper
    {
        public List<List<string>> LoopData => loopData;
        public string MainGridStyle => loopGridStyle;
        public List<AreaZoneInGrid> AreaZones
        {
            get
            {
                foreach(var areaZone in areaZones)
                {
                    areaZone.Direction = GetLayoutDirectionForZone(areaZone.Id);
                    areaZone.ZonePositionMapping = LoopDefinition.ZonePositionMapping;
                    areaZone.ZoneData = GetDataForZone(_rgvData, areaZone.Id);
                }
                return areaZones;
            }
        }

            
        public Dictionary<string, string> ZoneDirections => LoopDefinition.Directions;
        public Dictionary<string, string> ZonePositionMapping => LoopDefinition.ZonePositionMapping;


        List<List<string>> loopData = new();
        private int maxRows => loopData.Count;
        private int maxColumns => loopData.Select(x => x.Count).Max();
        List<string> distinctZones = new List<string>();
        List<string> nonZones = new List<string>();
        List<Dictionary<string, object>> _rgvData { get; set; } = new();


        string loopGridStyle;

        public const string nonZonesDefinition = "--;ww;ss;nn;ee;XX";
        List<AreaZoneInGrid> areaZones = new List<AreaZoneInGrid>();

        private PmsLayoutDefinition LoopDefinition;

        public AreaZoneInGridHelper()
        {
        }
        public AreaZoneInGridHelper(PmsLayoutDefinition loopDefinition)
        {
            LoopDefinition = loopDefinition;
            Process();
        }

        public void SetData(List<Dictionary<string, object>> rgvData)
        {
            _rgvData = rgvData;
        }

        public void Process()
        {
            fillDataLoop();
            NormalizeDataLoop();
            CreateZoneSizeMatrix();
        }

        private void fillDataLoop()
        {
            loopData = new();

            foreach (var line in LoopDefinition.Zones)
            {
                loopData.Add(line.Split(',').ToList());
            }

            loopGridStyle = $"grid-template-columns: repeat({maxColumns}, minmax(0,70px));";
            loopGridStyle += $"grid-template-rows: repeat({maxRows}, minmax(0,50px));";
        }

        private void NormalizeDataLoop()
        {
            foreach (var row in loopData)
            {
                int i = 0;
                while (row.Count < maxColumns)
                {
                    row.Add("--");
                }
            }


            foreach (var row in loopData)
            {
                foreach (var cel in row)
                {
                    if (nonZonesDefinition.Contains(cel))
                    {
                        nonZones.Add(cel);
                    }
                    else if(distinctZones.Contains(cel) == false)
                    {
                        distinctZones.Add(cel);
                    }
                }
            }
        }

        private void CreateZoneSizeMatrix()
        {
            foreach (var zone in distinctZones)
            {
                var zoneSize = new AreaZoneInGrid();
                zoneSize.Id = zone;

                for (int y = 0; y < loopData.Count; y++)
                {
                    var row = loopData[y];
                    for (int x = 0; x < row.Count; x++)
                    {
                        if (row[x] == zoneSize.Id)
                        {
                            zoneSize.positions.Add(new(x, y));
                        }
                    }
                }
                areaZones.Add(zoneSize);
            }
                           
            for (int y = 0; y < loopData.Count; y++)
            {
                var row = loopData[y];
                for (int x = 0; x < row.Count; x++)
                {
                    if (nonZonesDefinition.Contains(row[x]))
                    {
                        var zoneSize = new AreaZoneInGrid();
                        zoneSize.Id = row[x];
                        zoneSize.positions.Add(new(x, y));
                        areaZones.Add(zoneSize);
                    }
                }
            }                
            
        }

        public string GetLayoutDirectionForZone(string zone)
        {
            //var zoneDirections = LoopDefinition.Directions;
            //int zoneNo = int.Parse(new string(zone.Where(char.IsDigit).ToArray()));

            //foreach (var paar in zoneDirections)
            //{
            //    foreach (var part in paar.Value.Split(','))
            //    {
            //        if (part.Contains('-'))
            //        {
            //            int a = int.Parse(part.Split('-')[0]);
            //            int b = int.Parse(part.Split('-')[1]);
            //            if (zoneNo >= a && zoneNo <= b)
            //                return paar.Key;
            //        }
            //        else if (part == zoneNo.ToString())
            //        {
            //            return paar.Key;
            //        }
            //    }
            //}
            return "E";
        }

        public FlcLoopHuDevice GetDeviceInfo(List<Dictionary<string, object>> _data, string rgv)
        {
            var data = _data.Where(x => x.GetValueAsString("fdzp_device") == rgv).FirstOrDefault();
            if (data == null)
                return new FlcLoopHuDevice();
            return new FlcLoopHuDevice(data);
        }

        public List<Dictionary<string, object>> GetDataForZone(
            List<Dictionary<string, object>> _data,
            string zoneId)
        {
            if (_data == null || _data.Count == 0)
                return new();

            string zone = zoneId;

            if(zone =="A0")
            {
                string g = "";
            }
                        
            var zonePosMappings = LoopDefinition.ZonePositionMapping;
            if (zonePosMappings.TryGetValue(zone, out _))
            {
                zone = zonePosMappings[zone];
            }            

            var dataZone = _data
                .Where(x => x.GetValueAsString("mpos_ident") == zone              
            );

            return dataZone.ToList();            
        }
    }
}
