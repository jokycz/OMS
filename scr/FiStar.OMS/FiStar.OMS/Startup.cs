using Autofac.Extensions.DependencyInjection;
using Autofac;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FiStar.OMS.Core;
using FiStar.OMS.Data;

namespace FiStar.OMS
{
    public class Startup
    {
        private Model.ModuleInitializer ModelModuleInitializer { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ModelModuleInitializer =
            new Model.ModuleInitializer(
                    new Data.ModuleInitializer(configuration)
                    //, configuration
                );
        }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the ConfigureContainer method, below.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called. Don't create a ContainerBuilder
            // for Autofac here, and don't call builder.Populate() - that
            // happens in the AutofacServiceProviderFactory for you.
            services.AddOptions();
            services.AddControllers();
            services.AddModule(ModelModuleInitializer);
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            builder.RegisterModule(new DataModule() { configuration = Configuration});
        }

        // Configure is where you add middleware. This is called after
        // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
          IApplicationBuilder app,
          ILoggerFactory loggerFactory)
        {
            // If, for some reason, you need a reference to the built container, you
            // can use the convenience extension method GetAutofacRoot.
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            //app.UseMvc();
        }
    }
}
