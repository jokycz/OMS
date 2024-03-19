using Autofac;
using Autofac.Extensions.DependencyInjection;
using FiStar.OMS;
using System.Reflection;
using FiStar.OMS.Data.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Ui.Web;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;
    config.AddJsonFile("appsettings.json",
        optional: true,
        reloadOnChange: true);
    config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    config.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

    if (env.IsDevelopment())
    {
        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        config.AddUserSecrets(appAssembly, optional: true);
    }

    config.AddEnvironmentVariables();

    config.AddCommandLine(args);
});

var assembly = System.Reflection.Assembly.GetExecutingAssembly();

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterAssemblyModules(assembly));

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});

var startup = new Startup(builder.Configuration);
builder.Host.ConfigureContainer<ContainerBuilder>(startup.ConfigureContainer);
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();


builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
});

app.UseSerilogRequestLogging();

using var scope = app.Services.CreateScope();

ILogger<Program>? logger = scope.ServiceProvider.GetService<ILogger<Program>>();
try
{
    var db = scope.ServiceProvider.GetService<FiStarOmrDBContextMigrate>();
    db?.Database.Migrate();
}
catch (Exception e)
{
    logger.LogError(e, "Error migrating database");
    throw;
}



// Configure the HTTP request pipeline.

app.UseSerilogUi(options =>
{
    options.Authorization.AuthenticationType = AuthenticationType.Jwt;
    options.Authorization.Filters = new[]
    {
        new CustomAuthorizeFilter()
    };
    options.RoutePrefix = "log-dashboard";
});

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();

app.Run();
