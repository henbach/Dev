using Microsoft.AspNetCore.Mvc;
using WSA.Data.Repositories;
using WSA.Shared.DTOs;
using WSA.Shared.Models;

namespace WSA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly IOracleRepository _repository;
        private readonly ILogger<DataController> _logger;

        public DataController(IOracleRepository repository, ILogger<DataController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("schemas")]
        public async Task<ActionResult<List<string>>> GetSchemas()
        {
            try
            {
                var schemas = await _repository.GetSchemasAsync();
                return Ok(schemas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching schemas");
                return StatusCode(500, $"Error fetching schemas: {ex.Message}");
            }
        }

        [HttpGet("tables/{schema}")]
        public async Task<ActionResult<List<TableInfo>>> GetTables(string schema)
        {
            try
            {
                var tables = await _repository.GetTablesAsync(schema);
                return Ok(tables);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching tables for schema {Schema}", schema);
                return StatusCode(500, $"Error fetching tables: {ex.Message}");
            }
        }

        [HttpPost("query")]
        public async Task<ActionResult<QueryResult>> GetTableData([FromBody] DataRequest request)
        {
            try
            {
                var result = await _repository.GetTableDataAsync(request);

                if (!string.IsNullOrEmpty(result.ErrorMessage))
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching table data");
                return StatusCode(500, new QueryResult
                {
                    ErrorMessage = $"Error fetching data: {ex.Message}"
                });
            }
        }
    }
}
