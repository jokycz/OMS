using Autofac;
using FiStar.OMS.Data.Data;
using Microsoft.Extensions.Configuration;

namespace FiStar.OMS.Data;

public class DataModule : Module
{
    public IConfiguration configuration;

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<FiStarOmrDBContextMigrate>()
            .WithParameter("options",   DbContextOptionsFiStarOmrFactory.GetDbContextOptions<FiStarOmrDBContextMigrate>(configuration, "FiStarOMSDBMigrate"))
            .InstancePerLifetimeScope();

        builder
            .RegisterType<FiStarOmrDBContext>()
            .WithParameter("options", DbContextOptionsFiStarOmrFactory.GetDbContextOptions<FiStarOmrDBContext>(configuration, "FiStarOMSDB"))
            .InstancePerLifetimeScope();
    }
}