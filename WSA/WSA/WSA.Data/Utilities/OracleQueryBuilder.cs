using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSA.Shared.DTOs;

namespace WSA.Data.Utilities
{
    public class OracleQueryBuilder
    {
        private readonly DataRequest _request;

        public OracleQueryBuilder(DataRequest request)
        {
            _request = request;
        }

        public (string dataSql, string countSql, DynamicParameters parameters) BuildQueries()
        {
            var parameters = new DynamicParameters();
            var whereClauses = new List<string>();

            // Build filter conditions
            if (_request.Filters != null && _request.Filters.Any())
            {
                for (int i = 0; i < _request.Filters.Count; i++)
                {
                    var filter = _request.Filters[i];
                    var paramName = $"@filterValue{i}";
                    whereClauses.Add($"{filter.ColumnName} {filter.Operator} {paramName}");
                    parameters.Add(paramName, filter.Value);
                }
            }

            var whereClause = whereClauses.Any()
                ? "WHERE " + string.Join(" AND ", whereClauses)
                : string.Empty;

            // Build order by clause
            var orderByClause = !string.IsNullOrEmpty(_request.SortColumn)
                ? $"ORDER BY {_request.SortColumn} {(_request.SortDescending ? "DESC" : "ASC")}"
                : string.Empty;

            // Pagination using Oracle's ROWNUM
            var dataSql = $@"
            SELECT * FROM (
                SELECT a.*, ROWNUM rnum FROM (
                    SELECT * FROM {_request.Schema}.{_request.TableName}
                    {whereClause}
                    {orderByClause}
                ) a
                WHERE ROWNUM <= :pageEnd
            )
            WHERE rnum > :pageStart";

            var countSql = $@"
            SELECT COUNT(*) FROM {_request.Schema}.{_request.TableName}
            {whereClause}";

            // Calculate pagination
            var pageStart = (_request.PageNumber - 1) * _request.PageSize;
            var pageEnd = _request.PageNumber * _request.PageSize;

            parameters.Add(":pageStart", pageStart);
            parameters.Add(":pageEnd", pageEnd);

            return (dataSql, countSql, parameters);
        }
    }
}
