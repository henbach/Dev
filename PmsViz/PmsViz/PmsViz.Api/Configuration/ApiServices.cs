
using PmsViz.Core.Dtos;
using PmsViz.Core.Interfaces;
using PmsViz.Implementations;
using System.Net.NetworkInformation;

public static class ApiServices
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        ApiSettings configuration,
        bool isDevelopment)
    {       
        string dbHost = isDevelopment ? configuration.DatabaseHost : configuration.ProductionDatabaseHost;
        string dbUser = isDevelopment ? configuration.DatabaseUser : configuration.ProductionDatabaseUser;
        OracleDao oracle = new OracleDao(dbHost, dbUser);
        services.AddSingleton<IPmsDao>(oracle);

        return services;
    }
}

