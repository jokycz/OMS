using Microsoft.Extensions.DependencyInjection;

namespace FiStar.OMS.Core;

public interface IModuleInitializer
{
    /// <summary>
    /// Configures module services.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> representing DI container configuration.</param>
    /// <returns><see cref="IServiceCollection"/> with configured services.</returns>
    IServiceCollection ConfigureServices(IServiceCollection services);
}
