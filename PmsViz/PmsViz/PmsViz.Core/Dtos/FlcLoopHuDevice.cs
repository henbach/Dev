using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class FlcLoopHuDevice
    {
        public string Id { get; set; }
        public string OpModus { get; set; }
        public string Hu { get; set; }
        public string SrcLoc { get; set; }
        public string DstLoc { get; set; }
        public string CurrentZone { get; set; }

        public FlcLoopHuDevice()
        {

        }
        public FlcLoopHuDevice(Dictionary<string, object> item)
        {
            Id = item.GetValueAsString("mtru_ident");
            OpModus = item.GetValueAsString("fdev_op_mode_sub");
            Hu = item.GetValueAsString("ftra_hu");
            SrcLoc = item.GetValueAsString("FTRA_SOURCE_LOC");
            DstLoc = item.GetValueAsString("FTRA_DEST_LOC");
            CurrentZone = item.GetValueAsString("flan_ident");
        }
    }
}
