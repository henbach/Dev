using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSA.Shared.DTOs;
using WSA.Shared.Models;
using System.Data;
using Dapper;
using WSA.Data.Utilities;
using Microsoft.Extensions.Configuration;

namespace WSA.Data.Repositories
{
    public class OracleRepository : IOracleRepository
    {
        private readonly string _connectionString;

        public OracleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection")
                ?? throw new ArgumentNullException("OracleConnection string is missing");
        }

        public async Task<List<TableInfo>> GetTablesAsync(string schema = "USER")
        {
            using var connection = new OracleConnection(_connectionString);

            var sql = @"
            SELECT 
                TABLE_NAME as TableName,
                OWNER as Schema,
                NUM_ROWS as RowCount,
                LAST_ANALYZED as LastUpdated
            FROM ALL_TABLES 
            WHERE OWNER = :schema 
            ORDER BY TABLE_NAME";

            var tables = await connection.QueryAsync<TableInfo>(sql, new { schema });
            return tables.ToList();
        }

        public async Task<QueryResult> GetTableDataAsync(DataRequest request)
        {
            var result = new QueryResult();

            using var connection = new OracleConnection(_connectionString);

            try
            {
                // Get column information
                var columnSql = @"
                SELECT 
                    COLUMN_NAME as Name,
                    DATA_TYPE as DataType,
                    case NULLABLE when 'N' then 0 else 1 end as IsNullable,
                    DATA_LENGTH as MaxLength,
                    DATA_PRECISION as Precision,
                    DATA_SCALE as Scale
                FROM ALL_TAB_COLUMNS 
                WHERE OWNER = :schema AND TABLE_NAME = :tableName
                ORDER BY COLUMN_ID";

                result.Columns = (await connection.QueryAsync<ColumnInfo>(columnSql,
                    new { schema = request.Schema, tableName = request.TableName })).ToList();

                if (!result.Columns.Any())
                    throw new Exception($"Table {request.Schema}.{request.TableName} not found or has no columns");

                // Build dynamic query with pagination
                var queryBuilder = new OracleQueryBuilder(request);
                var (dataSql, countSql, parameters) = queryBuilder.BuildQueries();

                // Get total count
                result.TotalRecords = await connection.ExecuteScalarAsync<int>(countSql, parameters);

                // Get data with pagination
                var data = await connection.QueryAsync(dataSql, parameters);

                // Convert to dictionary for JSON serialization
                foreach (var row in data)
                {
                    var dict = new Dictionary<string, object>();
                    var rowDict = (IDictionary<string, object>)row;

                    foreach (var col in result.Columns)
                    {
                        dict[col.Name] = rowDict.ContainsKey(col.Name.ToUpper())
                            ? rowDict[col.Name.ToUpper()] ?? DBNull.Value
                            : DBNull.Value;
                    }

                    result.Data.Add(dict);
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"Error retrieving data: {ex.Message}";
            }

            return result;
        }

        public async Task<List<string>> GetSchemasAsync()
        {
            using var connection = new OracleConnection(_connectionString);

            var sql = @"
            SELECT DISTINCT USERNAME 
            FROM ALL_USERS 
            WHERE USERNAME NOT IN ('SYS', 'SYSTEM', 'DBSNMP', 'XDB')
            ORDER BY USERNAME";

            var schemas = await connection.QueryAsync<string>(sql);
            return schemas.ToList();
        }
        public async Task<TableInfo> GetTableDetailsAsync(string schema, string tableName)
        {
            using var connection = new OracleConnection(_connectionString);

            var sql = @"
            SELECT 
                TABLE_NAME as TableName,
                OWNER as Schema,
                NUM_ROWS as RowCount,
                LAST_ANALYZED as LastUpdated
            FROM ALL_TABLES 
            WHERE OWNER = :schema AND TABLE_NAME = :tableName";

            var table = await connection.QueryFirstOrDefaultAsync<TableInfo>(sql, new { schema, tableName });

            if (table == null)
                throw new Exception($"Table {schema}.{tableName} not found");

            return table;
        }
    }
}
