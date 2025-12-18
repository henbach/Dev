using PmsViz.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Interfaces
{
    public interface IPmsLayoutRepository
    {
        public IEnumerable<IPmsLayout> GetAllLayouts();
    }
}
