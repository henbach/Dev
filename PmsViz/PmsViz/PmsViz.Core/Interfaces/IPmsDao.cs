using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Interfaces
{
    public interface IPmsDao
    {
        public List<Dictionary<string, object>> ExecuteDynamicQuery(string sqlQuery);
        public bool TestConnection();
    }
}
