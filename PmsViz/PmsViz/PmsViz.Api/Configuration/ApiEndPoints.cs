using Microsoft.AspNetCore.Mvc;
using PmsViz.Core.Interfaces;

public static class ApiEndPoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");

        group.MapPost("/sqlQuery", async ([FromBody] string query, [FromServices] IPmsDao daoConnection) =>
        {
            return daoConnection.ExecuteDynamicQuery(query);
        });

        group.MapGet("/test", async ([FromServices] IPmsDao daoConnection) =>
        {
            return daoConnection.TestConnection();
        });
    }
}

