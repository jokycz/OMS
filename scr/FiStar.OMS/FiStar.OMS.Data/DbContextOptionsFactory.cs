using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FiStar.OMS.Data;

public class DbContextOptionsFiStarOmrFactory
{
    public static DbContextOptions<TContext> GetDbContextOptions<TContext>(IConfiguration configuration, string nameCS) where TContext : DbContext
    {
        var builder = new DbContextOptionsBuilder<TContext>();
        builder.UseSqlServer(configuration.GetConnectionString(nameCS),
            sqlServerOptions => sqlServerOptions.CommandTimeout(Convert.ToInt32(
                configuration.GetSection("CommandTimeOut").Value ?? "0", CultureInfo.CurrentCulture)));
        return builder.Options;
    }
}