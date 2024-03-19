using Autofac;
using FiStar.OMS.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FiStar.OMS.Model
{
    /// <summary>
    /// Provides DI configuration for HRSPEC Model layer.
    /// </summary>
    public class ModuleInitializer : IModuleInitializer
    {
        private readonly IModuleInitializer dataModuleInitializer;
        //private readonly IConfiguration configuration = _configuration;

        /// <summary>
        /// Provides DI configuration for HRSPEC Model layer.
        /// </summary>
        public ModuleInitializer(IModuleInitializer _dataModuleInitializer
            //,IConfiguration configuration
            )
        {
            dataModuleInitializer = _dataModuleInitializer ?? throw new ArgumentException(nameof(_dataModuleInitializer));
        }
        

        /// <summary>
        /// Configures module services.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /> representing DI container configuration.</param>
        /// <returns><see cref="IServiceCollection" /> with configured services.</returns>
        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddModule(dataModuleInitializer);


            return services;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // dao

            // models

            // logic
        }
    }
}
