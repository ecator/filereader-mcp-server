
##### Table of Contents

# Class McpMessageFilterBuilderExtensions

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.dll

Provides extension methods for configuring message-level MCP server filters.

```
public static class McpMessageFilterBuilderExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpMessageFilterBuilderExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### AddIncomingFilter(IMcpMessageFilterBuilder, McpMessageFilter)

Adds a filter to intercept all incoming JSON-RPC messages.

```
public static IMcpMessageFilterBuilder AddIncomingFilter(this IMcpMessageFilterBuilder builder, McpMessageFilter filter)
```

#### Parameters

`builder` [IMcpMessageFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpMessageFilterBuilder.html)
:   The message filter builder instance.

`filter` [McpMessageFilter](ModelContextProtocol.Server.McpMessageFilter.html)
:   The filter function that wraps the message handler.

#### Returns

[IMcpMessageFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpMessageFilterBuilder.html)
:   The builder provided in `builder`.

### AddOutgoingFilter(IMcpMessageFilterBuilder, McpMessageFilter)

Adds a filter to intercept all outgoing JSON-RPC messages.

```
public static IMcpMessageFilterBuilder AddOutgoingFilter(this IMcpMessageFilterBuilder builder, McpMessageFilter filter)
```

#### Parameters

`builder` [IMcpMessageFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpMessageFilterBuilder.html)
:   The message filter builder instance.

`filter` [McpMessageFilter](ModelContextProtocol.Server.McpMessageFilter.html)
:   The filter function that wraps the message handler.

#### Returns

[IMcpMessageFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpMessageFilterBuilder.html)
:   The builder provided in `builder`.




