using Microsoft.Extensions.DependencyInjection;
using MrEfka.ToolBox.QueryString.Configuration;

namespace MrEfka.ToolBox.QueryString.IoC;

///<summary>Provides extension methods to register <see cref="IQueryStringHelper"/> into an IoC container.</summary>
public static class QueryStrings
{
    ///<summary>Registers <see cref="T:ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container with the defined <paramref name="configuration"/> and <paramref name="lifetime"/>.</summary>
    ///<param name="services">IoC container</param>
    ///<param name="configuration">Object to configure the <see cref="T:ToolBox.QueryString.IQueryStringHelper"/></param>
    ///<param name="lifetime">The <see cref="ServiceLifetime"/> of the service</param>
    public static IServiceCollection AddQueryStringHelper(
        this IServiceCollection services,
        QueryStringHelperConfiguration configuration,
        ServiceLifetime lifetime
        )
    {
        ArgumentNullException.ThrowIfNull(services);
        
        services.Add(new ServiceDescriptor(
            serviceType: typeof(IQueryStringHelper), 
            factory: (_) => new QueryStringHelper(configuration), 
            lifetime));
        return services;
    }
    
    ///<summary>Registers <see cref="T:ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container as a <see cref="ServiceLifetime.Scoped"/> service.</summary>
    ///<param name="services">IoC container</param>
    public static IServiceCollection AddQueryStringHelper(this IServiceCollection services)
        => services.AddScoped<IQueryStringHelper, QueryStringHelper>();

    ///<summary>Registers <see cref="T:ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container as a <see cref="ServiceLifetime.Scoped"/> service using the provided <paramref name="configuration"/>.</summary>
    ///<param name="services">IoC container</param>
    ///<param name="configuration">QueryString helper configuration to apply</param>
    public static IServiceCollection AddQueryStringHelper(this IServiceCollection services,
        QueryStringHelperConfiguration configuration)
        => services.AddScoped<IQueryStringHelper>((_) => new QueryStringHelper(configuration));

    ///<summary>Registers <see cref="T:ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container with the provided <paramref name="lifetime"/>.</summary>
    ///<param name="services">IoC container</param>
    ///<param name="configure">Custom configuration function</param>
    ///<param name="lifetime">The <see cref="ServiceLifetime"/> of the service</param>
    public static IServiceCollection AddQueryStringHelper(
        this IServiceCollection services,
        Action<QueryStringHelperConfiguration> configure,
        ServiceLifetime lifetime = ServiceLifetime.Scoped
        )
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(configure, nameof(configure));
        
        var config = new QueryStringHelperConfiguration();
        configure.Invoke(config);
        return AddQueryStringHelper(services, config, lifetime);
    }
}