using System.Globalization;
using FiStar.OMS.Core;
using FiStar.OMS.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiStar.OMS.Data;

/// <summary>
/// Configuration class for Dependency Injection based on <see cref="IServiceCollection" />.
/// </summary>
public class ModuleInitializer : IModuleInitializer
{
    private readonly IConfiguration configuration;

    public ModuleInitializer(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    /// <summary>
    /// Configures module services.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" /> representing DI container configuration.</param>
    /// <returns><see cref="IServiceCollection" /> with configured services.</returns>
    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<FiStarOmrDBContextMigrate>(
            options => options.UseSqlServer(configuration.GetConnectionString("FiStarOMSDBMigrate"),
                sqlServerOptions => sqlServerOptions.CommandTimeout(Convert.ToInt32(configuration.GetSection("CommandTimeOut").Value ?? "0", CultureInfo.CurrentCulture))));

        services.AddDbContext<FiStarOmrDBContext>(
            options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FiStarOMSDB"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(Convert.ToInt32(
                        configuration.GetSection("CommandTimeOut").Value ?? "0", CultureInfo.CurrentCulture)));
            });


        services.AddScoped<IUnitOfWork, EfCoreUnitOfWork<FiStarOmrDBContext>>();

        return services;
    }
}