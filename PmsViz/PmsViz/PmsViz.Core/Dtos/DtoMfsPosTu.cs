using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class DtoMfsPosTu
    {
        public object mpos_ident { get; set; }
        public object mpos_state { get; set; }
        public object mpos_block_state { get; set; }
        public object mpos_op_mode_plc { get; set; }
        public object mpos_deny_out { get; set; }
        public object mpos_deny_in { get; set; }
        public object mpos_tu { get; set; }
        public object mtru_ident { get; set; }
        public object mtru_failure { get; set; }
        public object mtru_weight { get; set; }
        public object mtru_height { get; set; }
        public object mtru_length { get; set; }
        public object mtru_contour { get; set; }

        public DtoMfsPosTu()
        {
        }

        public static DtoMfsPosTu CreateFromDictionary(Dictionary<string,object> data)
        {
            DtoMfsPosTu dto = new DtoMfsPosTu();
            dto.mpos_ident = data.GetValue("mpos_ident");
            dto.mpos_state = data.GetValue("mpos_state");
            dto.mpos_block_state = data.GetValue("mpos_block_state");
            dto.mpos_op_mode_plc = data.GetValue("mpos_op_mode_plc");
            dto.mpos_deny_out = data.GetValue("mpos_deny_out");
            dto.mpos_deny_in = data.GetValue("mpos_deny_in");
            dto.mpos_tu = data.GetValue("mpos_tu");
            dto.mtru_ident = data.GetValue("mtru_ident");
            dto.mtru_failure = data.GetValue("mtru_failure");
            dto.mtru_weight = data.GetValue("mtru_weight");
            dto.mtru_height = data.GetValue("mtru_height");
            dto.mtru_length = data.GetValue("mtru_length");
            dto.mtru_contour = data.GetValue("mtru_contour");
            return dto;
        }
    }
}
