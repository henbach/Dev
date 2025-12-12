using PmsViz.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Interfaces
{
    public interface IDataService
    {
        public IEnumerable<DtoMfsPosTu> GetMfsPosTuData();
        public string GetSqlQueryForMfsPosTuData();

        public IEnumerable<Dictionary<string,object>> GetDictMfsPosTuData();
    }
}
