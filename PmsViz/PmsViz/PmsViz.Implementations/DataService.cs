using PmsViz.Core.Dtos;
using PmsViz.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Implementations
{
    public class DataService : IDataService
    {
        private IPmsDao _pmsDao;
        public DataService(IPmsDao pmsDao)
        {
            _pmsDao = pmsDao;
        }

        public IEnumerable<Dictionary<string, object>> GetDictMfsPosTuData()
        {
            string sql = GetSqlQueryForMfsPosTuData();
            return _pmsDao.ExecuteDynamicQuery(sql);
        }

        public IEnumerable<DtoMfsPosTu> GetMfsPosTuData()
        {
            string sql = GetSqlQueryForMfsPosTuData();

            var result = _pmsDao.ExecuteDynamicQuery(sql);
            List<DtoMfsPosTu> list = new List<DtoMfsPosTu>();
            foreach (var item in result)
            {
                list.Add(DtoMfsPosTu.CreateFromDictionary(item));
            }
            
            return list;    
        }

        public string GetSqlQueryForMfsPosTuData()
        {
            string sql = @"select mpos_ident, mpos_state, 
                                  mpos_block_state, mpos_op_mode_plc, 
                                  mpos_deny_out, mpos_deny_in,mpos_tu, 
                                  mtru_ident, mtru_failure, mtru_weight, mtru_height, 
                                  mtru_length, mtru_contour
                            from  tblmfs_positions
                       left join  tblmfs_tu t1 on mtru_pos_cur = mpos_ident and mtru_state <= 100 
                                    and t1.mtru_date_mov in 
                                    (   
                                        select max(t2.mtru_date_mov) 
                                          from tblmfs_tu t2 
                                         where t2.mtru_state <= 100 and t2.mtru_pos_cur = mpos_ident
                                    )";
            return sql;
        }
    }
}
