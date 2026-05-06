
##### Table of Contents

# Class McpEndpointRouteBuilderExtensions

Namespace
:   [Microsoft](https://learn.microsoft.com/dotnet/api/microsoft).[AspNetCore](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore).[Builder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.builder)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Provides extension methods for [IEndpointRouteBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder) to add MCP endpoints.

```
public static class McpEndpointRouteBuilderExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpEndpointRouteBuilderExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### MapMcp(IEndpointRouteBuilder, string)

Sets up endpoints for handling MCP Streamable HTTP transport.

```
public static IEndpointConventionBuilder MapMcp(this IEndpointRouteBuilder endpoints, string pattern = "")
```

#### Parameters

`endpoints` [IEndpointRouteBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder)
:   The web application to attach MCP HTTP endpoints.

`pattern` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The route pattern prefix to map to.

#### Returns

[IEndpointConventionBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.builder.iendpointconventionbuilder)
:   Returns a builder for configuring additional endpoint conventions like authorization policies.

#### Remarks

For details about the Streamable HTTP transport, see the [2025-11-25 protocol specification](https://modelcontextprotocol.io/specification/2025-11-25/basic/transports#streamable-http).
When legacy SSE is enabled via [EnableLegacySse](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_EnableLegacySse), this method also maps legacy SSE endpoints at the path "/sse" and "/message". For details about the HTTP with SSE transport, see the [2024-11-05 protocol specification](https://modelcontextprotocol.io/specification/2024-11-05/basic/transports#http-with-sse).

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The required MCP services have not been registered. Ensure [WithHttpTransport(IMcpServerBuilder, Action<HttpServerTransportOptions>?)](Microsoft.Extensions.DependencyInjection.HttpMcpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_HttpMcpServerBuilderExtensions_WithHttpTransport_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_System_Action_ModelContextProtocol_AspNetCore_HttpServerTransportOptions__) has been called during application startup.




