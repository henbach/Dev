using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnApps.Common.Models
{
    public class FindStrGroupedResult
    {
        public string FilePath { get; set; }
        public Dictionary<string, string> Result { get; set; } = new Dictionary<string,string>();
    }
}
