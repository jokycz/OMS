using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FiStar.OMS.Core;

public static class ModuleExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> representing DI container configuration.</param>
    /// <param name="assembliesPath">The module assemblies path.</param>
    /// <returns><see cref="IServiceCollection"/> with configured services.</returns>
    // ReSharper disable once UnusedMember.Global
    public static IServiceCollection AddModules(this IServiceCollection services, string[] assembliesPath)
    {
        return AddModules(services, assembliesPath.Select(Assembly.LoadFrom).ToArray());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> representing DI container configuration.</param>
    /// <param name="moduleAssemblies">The modules.</param>
    /// <returns><see cref="IServiceCollection"/> with configured services.</returns>
    public static IServiceCollection AddModules(this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var assembly in moduleAssemblies)
        {
            services = AddModule(services, assembly);
        }

        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> representing DI container configuration.</param>
    /// <param name="moduleAssembly">The module assembly.</param>
    /// <returns><see cref="IServiceCollection"/> with configured services.</returns>
    public static IServiceCollection AddModule(this IServiceCollection services, Assembly moduleAssembly)
    {
        var moduleInitializerNames = moduleAssembly
            .GetTypes()
            .Where(t => typeof(IModuleInitializer).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false })
            .Select(t => t.FullName)
            .ToList();

        // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
        foreach (var initializerName in moduleInitializerNames)
        {
            if (initializerName == null)
            {
                continue;
            }

            var instance = (IModuleInitializer)moduleAssembly.CreateInstance(initializerName)!;
            services = AddModule(services, instance);
        }

        return services;
    }

    /// <summary>
    /// Adds the module to the Dependency Injection container.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> representing DI container configuration.</param>
    /// <param name="moduleInitializer">The module initializer.</param>
    /// <returns><see cref="IServiceCollection"/> with configured services.</returns>
    public static IServiceCollection AddModule(this IServiceCollection services, IModuleInitializer moduleInitializer)
    {
        return moduleInitializer.ConfigureServices(services);
    }
}