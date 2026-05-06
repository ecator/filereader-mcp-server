
##### Table of Contents

# Class HttpMcpServerBuilderExtensions

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Provides methods for configuring HTTP MCP servers via dependency injection.

```
public static class HttpMcpServerBuilderExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    HttpMcpServerBuilderExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### AddAuthorizationFilters(IMcpServerBuilder)

Adds authorization filters to support [AuthorizeAttribute](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute)
on MCP server tools, prompts, and resources. This method should always be called when using
ASP.NET Core integration to ensure proper authorization support.

```
public static IMcpServerBuilder AddAuthorizationFilters(this IMcpServerBuilder builder)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method automatically configures authorization filters for all MCP server handlers. These filters respect
authorization attributes such as [AuthorizeAttribute](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute)
and [AllowAnonymousAttribute](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authorization.allowanonymousattribute).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithDistributedCacheEventStreamStore(IMcpServerBuilder, Action<DistributedCacheEventStreamStoreOptions>?)

Registers a [DistributedCacheEventStreamStore](ModelContextProtocol.Server.DistributedCacheEventStreamStore.html) as the [ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html) for SSE resumability.

```
public static IMcpServerBuilder WithDistributedCacheEventStreamStore(this IMcpServerBuilder builder, Action<DistributedCacheEventStreamStoreOptions>? configureOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`configureOptions` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[DistributedCacheEventStreamStoreOptions](ModelContextProtocol.Server.DistributedCacheEventStreamStoreOptions.html)>
:   An optional action to configure [DistributedCacheEventStreamStoreOptions](ModelContextProtocol.Server.DistributedCacheEventStreamStoreOptions.html).

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

An [IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache) implementation must be registered in the service collection before calling this method.
The registered cache is automatically assigned to [Cache](ModelContextProtocol.Server.DistributedCacheEventStreamStoreOptions.html#ModelContextProtocol_Server_DistributedCacheEventStreamStoreOptions_Cache).

To use a specific [IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache) instance instead of the one registered in DI,
set the [Cache](ModelContextProtocol.Server.DistributedCacheEventStreamStoreOptions.html#ModelContextProtocol_Server_DistributedCacheEventStreamStoreOptions_Cache) property in the `configureOptions` callback.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithHttpTransport(IMcpServerBuilder, Action<HttpServerTransportOptions>?)

Adds the services necessary for McpEndpointRouteBuilderExtensions.MapMcp
to handle MCP requests and sessions using the MCP Streamable HTTP transport.

```
public static IMcpServerBuilder WithHttpTransport(this IMcpServerBuilder builder, Action<HttpServerTransportOptions>? configureOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`configureOptions` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[HttpServerTransportOptions](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html)>
:   Configures options for the Streamable HTTP transport. This allows configuring per-session
    [McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html) and running logic before and after a session.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

For more information on configuring the underlying HTTP server
to control things like port binding and custom TLS certificates, see the [Minimal APIs quick reference](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




