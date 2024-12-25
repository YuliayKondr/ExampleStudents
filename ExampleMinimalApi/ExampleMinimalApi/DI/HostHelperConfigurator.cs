using System.Data;
using ExampleInfrastructure.DbContexts;
using ExampleInfrastructure.Repositories;
using ExampleInfrastructure.WorkDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace ExampleMinimalApi.DI;

internal static class HostHelperConfigurator
{
    public static  WebApplicationBuilder DatabaseDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ExampleContext>(
            x => x.UseMySql(BuildConnection(builder).ConnectionString,
                new MySqlServerVersion(new Version(5, 7, 26)),
                mySqlOptions =>
                {
                    mySqlOptions.CommandTimeout(120);
                }),
            ServiceLifetime.Scoped);

        builder.Services.AddScoped<IDbConnection, MySqlConnection>(_ => new MySqlConnection(BuildConnection(builder).ConnectionString));
        builder.Services.AddScoped<IDataContext, ExampleContext>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
        return builder;
    }

    private static MySqlConnectionStringBuilder BuildConnection(WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("Database")!;

        MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new (connectionString)
        {
            TreatTinyAsBoolean = true,
            GuidFormat = MySqlGuidFormat.None,
            AllowLoadLocalInfile = true
        };

        return mySqlConnectionStringBuilder;
    }
}