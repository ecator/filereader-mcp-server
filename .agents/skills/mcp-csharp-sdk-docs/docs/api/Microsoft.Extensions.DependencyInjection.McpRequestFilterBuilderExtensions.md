
##### Table of Contents

# Class McpRequestFilterBuilderExtensions

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.dll

Provides extension methods for configuring request-specific MCP server filters.

```
public static class McpRequestFilterBuilderExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpRequestFilterBuilderExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### AddCallToolFilter(IMcpRequestFilterBuilder, McpRequestFilter<CallToolRequestParams, CallToolResult>)

Adds a filter to the call tool handler pipeline.

```
public static IMcpRequestFilterBuilder AddCallToolFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<CallToolRequestParams, CallToolResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html), [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddCompleteFilter(IMcpRequestFilterBuilder, McpRequestFilter<CompleteRequestParams, CompleteResult>)

Adds a filter to the complete handler pipeline.

```
public static IMcpRequestFilterBuilder AddCompleteFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<CompleteRequestParams, CompleteResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[CompleteRequestParams](ModelContextProtocol.Protocol.CompleteRequestParams.html), [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddGetPromptFilter(IMcpRequestFilterBuilder, McpRequestFilter<GetPromptRequestParams, GetPromptResult>)

Adds a filter to the get prompt handler pipeline.

```
public static IMcpRequestFilterBuilder AddGetPromptFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<GetPromptRequestParams, GetPromptResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html), [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddListPromptsFilter(IMcpRequestFilterBuilder, McpRequestFilter<ListPromptsRequestParams, ListPromptsResult>)

Adds a filter to the list prompts handler pipeline.

```
public static IMcpRequestFilterBuilder AddListPromptsFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<ListPromptsRequestParams, ListPromptsResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html), [ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddListResourceTemplatesFilter(IMcpRequestFilterBuilder, McpRequestFilter<ListResourceTemplatesRequestParams, ListResourceTemplatesResult>)

Adds a filter to the list resource templates handler pipeline.

```
public static IMcpRequestFilterBuilder AddListResourceTemplatesFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<ListResourceTemplatesRequestParams, ListResourceTemplatesResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html), [ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddListResourcesFilter(IMcpRequestFilterBuilder, McpRequestFilter<ListResourcesRequestParams, ListResourcesResult>)

Adds a filter to the list resources handler pipeline.

```
public static IMcpRequestFilterBuilder AddListResourcesFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<ListResourcesRequestParams, ListResourcesResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html), [ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddListToolsFilter(IMcpRequestFilterBuilder, McpRequestFilter<ListToolsRequestParams, ListToolsResult>)

Adds a filter to the list tools handler pipeline.

```
public static IMcpRequestFilterBuilder AddListToolsFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<ListToolsRequestParams, ListToolsResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html), [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddReadResourceFilter(IMcpRequestFilterBuilder, McpRequestFilter<ReadResourceRequestParams, ReadResourceResult>)

Adds a filter to the read resource handler pipeline.

```
public static IMcpRequestFilterBuilder AddReadResourceFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<ReadResourceRequestParams, ReadResourceResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html), [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddSetLoggingLevelFilter(IMcpRequestFilterBuilder, McpRequestFilter<SetLevelRequestParams, EmptyResult>)

Adds a filter to the set logging level handler pipeline.

```
public static IMcpRequestFilterBuilder AddSetLoggingLevelFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<SetLevelRequestParams, EmptyResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[SetLevelRequestParams](ModelContextProtocol.Protocol.SetLevelRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddSubscribeToResourcesFilter(IMcpRequestFilterBuilder, McpRequestFilter<SubscribeRequestParams, EmptyResult>)

Adds a filter to the subscribe-to-resources handler pipeline.

```
public static IMcpRequestFilterBuilder AddSubscribeToResourcesFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<SubscribeRequestParams, EmptyResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.

### AddUnsubscribeFromResourcesFilter(IMcpRequestFilterBuilder, McpRequestFilter<UnsubscribeRequestParams, EmptyResult>)

Adds a filter to the unsubscribe-from-resources handler pipeline.

```
public static IMcpRequestFilterBuilder AddUnsubscribeFromResourcesFilter(this IMcpRequestFilterBuilder builder, McpRequestFilter<UnsubscribeRequestParams, EmptyResult> filter)
```

#### Parameters

`builder` [IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The request filter builder instance.

`filter` [McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>
:   The filter function that wraps the handler.

#### Returns

[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)
:   The builder provided in `builder`.




