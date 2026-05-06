
##### Table of Contents

# Class McpServerServiceCollectionExtensions

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.dll

Provides extension methods for configuring MCP servers with dependency injection.

```
public static class McpServerServiceCollectionExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerServiceCollectionExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### AddMcpServer(IServiceCollection, Action<McpServerOptions>?)

Adds the Model Context Protocol (MCP) server to the service collection with default options.

```
public static IMcpServerBuilder AddMcpServer(this IServiceCollection services, Action<McpServerOptions>? configureOptions = null)
```

#### Parameters

`services` [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)
:   The [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) to add the server to.

`configureOptions` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html)>
:   An optional callback to configure the [McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html).

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   An [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html) that can be used to further configure the MCP server.




