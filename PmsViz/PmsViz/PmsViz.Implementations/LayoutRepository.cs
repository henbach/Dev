using PmsViz.Core.Dtos;
using PmsViz.Core.Interfaces;
using PmsViz.Implementations.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Implementations
{
    public class LayoutRepository : IPmsLayoutRepository
    {
        private List<IPmsLayout> _layouts = new();
        public LayoutRepository()
        {
            _layouts = new();
            _layouts.Add(new PowerCoGroundFloor());
            _layouts.Add(new PowerCoLevel2());

        }
        public IEnumerable<IPmsLayout> GetAllLayouts()
        {            
            return _layouts;
        }      
    }
}
