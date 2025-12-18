using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Types;
using PmsViz.Core.Dtos;
using PmsViz.Core.Interfaces;
using PmsViz.Implementations;
using System.Configuration;
using System.Reflection;

public static class AppServices
{
    public static IServiceCollection AddAppCustomServices(
         this IServiceCollection services,
        AppSettings configuration,
        bool isDevelopment)
    {
        string dbHost = isDevelopment ? configuration.DatabaseHost : configuration.ProductionDatabaseHost;
        string dbUser = isDevelopment ? configuration.DatabaseUser : configuration.ProductionDatabaseUser;
        OracleDao oracleDao = new OracleDao(dbHost, dbUser);
        services.AddSingleton<IPmsDao>(oracleDao);
        
        IDataService dataService = new DataService(oracleDao);
        services.AddSingleton<IDataService>(dataService);

        IPmsLayoutRepository layoutRepository = new LayoutRepository();
        services.AddSingleton<IPmsLayoutRepository>(layoutRepository);


        return services;
    }
}

