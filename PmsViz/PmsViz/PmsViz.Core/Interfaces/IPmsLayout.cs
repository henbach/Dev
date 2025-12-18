using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Interfaces
{
    public interface IPmsLayout
    {
        string Name { get;}
        Dictionary<string, string> Directions { get;}
        Dictionary<string, string> ZonePositionMapping { get; }
        string[] Zones { get;}
    }
}
