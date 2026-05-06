
##### Table of Contents

# Interface IMcpMessageFilterBuilder

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.dll

Provides a builder for configuring message-level MCP server filters.

```
public interface IMcpMessageFilterBuilder
```

Extension Methods
:   [McpMessageFilterBuilderExtensions.AddIncomingFilter(IMcpMessageFilterBuilder, McpMessageFilter)](Microsoft.Extensions.DependencyInjection.McpMessageFilterBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpMessageFilterBuilderExtensions_AddIncomingFilter_Microsoft_Extensions_DependencyInjection_IMcpMessageFilterBuilder_ModelContextProtocol_Server_McpMessageFilter_)

    [McpMessageFilterBuilderExtensions.AddOutgoingFilter(IMcpMessageFilterBuilder, McpMessageFilter)](Microsoft.Extensions.DependencyInjection.McpMessageFilterBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpMessageFilterBuilderExtensions_AddOutgoingFilter_Microsoft_Extensions_DependencyInjection_IMcpMessageFilterBuilder_ModelContextProtocol_Server_McpMessageFilter_)

## Properties

### Services

Gets the associated service collection.

```
IServiceCollection Services { get; }
```

#### Property Value

[IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)




