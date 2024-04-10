# ToolBox.Querystring.IoC

Provides extension methods to easily add [ToolBox.QueryString](https://www.nuget.org/packages/MrEfka.ToolBox.QueryString/#readme-body-tab) in your .Net services container.

### Available APIs
```csharp
    ///<summary>Registers <see cref="MrEfka.ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container with the defined <paramref name="configuration"/> and <paramref name="lifetime"/>.</summary>
    ///<param name="services">IoC container</param>
    ///<param name="configuration">Object to configure the <see cref="T:ToolBox.QueryString.IQueryStringHelper"/></param>
    ///<param name="lifetime">The <see cref="ServiceLifetime"/> of the service</param>
    IServiceCollection AddQueryStringHelper(this IServiceCollection services, QueryStringHelperConfiguration configuration, ServiceLifetime lifetime)

    ///<summary>Registers <see cref="MrEfka.ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container as a <see cref="ServiceLifetime.Scoped"/> service.</summary>
    ///<param name="services">IoC container</param>
    IServiceCollection AddQueryStringHelper(this IServiceCollection services)
    
    ///<summary>Registers <see cref="MrEfka.ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container as a <see cref="ServiceLifetime.Scoped"/> service using the provided <paramref name="configuration"/>.</summary>
    ///<param name="services">IoC container</param>
    ///<param name="configuration">QueryString helper configuration to apply</param>
    IServiceCollection AddQueryStringHelper(this IServiceCollection services, QueryStringHelperConfiguration configuration)
        
    ///<summary>Registers <see cref="MrEfka.ToolBox.QueryString.IQueryStringHelper"/> in the given <paramref name="services"/> container with the provided <paramref name="lifetime"/>.</summary>
    ///<param name="services">IoC container</param>
    ///<param name="configure">Custom configuration function</param>
    ///<param name="lifetime">The <see cref="ServiceLifetime"/> of the service</param>
    IServiceCollection AddQueryStringHelper(this IServiceCollection services, Action<QueryStringHelperConfiguration> configure, [ServiceLifetime lifetime = ServiceLifetime.Scoped])
```
## Authors

- **Mr Efka** - _Initial work_ - [Mr efka](https://github.com/mr-efka)

## License

This project is licensed under the BSD 2-Clause License - see the [LICENSE](LICENSE) file for details.
