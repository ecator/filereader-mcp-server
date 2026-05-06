
##### Table of Contents

# Class McpRequestFilters

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides grouped request-specific filter collections.

```
public sealed class McpRequestFilters
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpRequestFilters

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### CallToolFilters

Gets or sets the filters for the call-tool handler pipeline.

```
public IList<McpRequestFilter<CallToolRequestParams, CallToolResult>> CallToolFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html), [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>>

#### Remarks

These filters wrap handlers that are invoked when a client makes a call to a tool that isn't found in the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) collection.
The filters can modify, log, or perform additional operations on requests and responses for
[ToolsCall](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsCall) requests. The handler should implement logic to execute the requested tool and return appropriate results.

### CompleteFilters

Gets or sets the filters for the complete-handler pipeline.

```
public IList<McpRequestFilter<CompleteRequestParams, CompleteResult>> CompleteFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[CompleteRequestParams](ModelContextProtocol.Protocol.CompleteRequestParams.html), [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)>>

#### Remarks

These filters wrap handlers that provide auto-completion suggestions for prompt arguments or resource references in the Model Context Protocol.
The filters can modify, log, or perform additional operations on requests and responses for
[CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete) requests. The handler processes auto-completion requests, returning a list of suggestions based on the
reference type and current argument value.

### GetPromptFilters

Gets or sets the filters for the get-prompt handler pipeline.

```
public IList<McpRequestFilter<GetPromptRequestParams, GetPromptResult>> GetPromptFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html), [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>>

#### Remarks

These filters wrap handlers that are invoked when a client requests details for a specific prompt that isn't found in the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) collection.
The filters can modify, log, or perform additional operations on requests and responses for
[PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) requests. The handler should implement logic to fetch or generate the requested prompt and return appropriate results.

### ListPromptsFilters

Gets or sets the filters for the list-prompts handler pipeline.

```
public IList<McpRequestFilter<ListPromptsRequestParams, ListPromptsResult>> ListPromptsFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html), [ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html)>>

#### Remarks

These filters wrap handlers that return a list of available prompts when requested by a client.
The filters can modify, log, or perform additional operations on requests and responses for
[PromptsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsList) requests. It supports pagination through the cursor mechanism,
where the client can make repeated calls with the cursor returned by the previous call to retrieve more prompts.

These filters work alongside any prompts defined in the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) collection.
Prompts from both sources will be combined when returning results to clients.

### ListResourceTemplatesFilters

Gets or sets the filters for the list-resource-templates handler pipeline.

```
public IList<McpRequestFilter<ListResourceTemplatesRequestParams, ListResourceTemplatesResult>> ListResourceTemplatesFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html), [ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html)>>

#### Remarks

These filters wrap handlers that return a list of available resource templates when requested by a client.
The filters can modify, log, or perform additional operations on requests and responses for
[ResourcesTemplatesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesTemplatesList) requests. It supports pagination through the cursor mechanism,
where the client can make repeated calls with the cursor returned by the previous call to retrieve more resource templates.

### ListResourcesFilters

Gets or sets the filters for the list-resources handler pipeline.

```
public IList<McpRequestFilter<ListResourcesRequestParams, ListResourcesResult>> ListResourcesFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html), [ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html)>>

#### Remarks

These filters wrap handlers that return a list of available resources when requested by a client.
The filters can modify, log, or perform additional operations on requests and responses for
[ResourcesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesList) requests. It supports pagination through the cursor mechanism,
where the client can make repeated calls with the cursor returned by the previous call to retrieve more resources.

### ListToolsFilters

Gets or sets the filters for the list-tools handler pipeline.

```
public IList<McpRequestFilter<ListToolsRequestParams, ListToolsResult>> ListToolsFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html), [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html)>>

#### Remarks

These filters wrap handlers that return a list of available tools when requested by a client.
The filters can modify, log, or perform additional operations on requests and responses for
[ToolsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsList) requests. It supports pagination through the cursor mechanism,
where the client can make repeated calls with the cursor returned by the previous call to retrieve more tools.

These filters work alongside any tools defined in the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) collection.
Tools from both sources will be combined when returning results to clients.

### ReadResourceFilters

Gets or sets the filters for the read-resource handler pipeline.

```
public IList<McpRequestFilter<ReadResourceRequestParams, ReadResourceResult>> ReadResourceFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html), [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>>

#### Remarks

These filters wrap handlers that are invoked when a client requests the content of a specific resource identified by its URI.
The filters can modify, log, or perform additional operations on requests and responses for
[ResourcesRead](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesRead) requests. The handler should implement logic to locate and retrieve the requested resource.

### SetLoggingLevelFilters

Gets or sets the filters for the set-logging-level handler pipeline.

```
public IList<McpRequestFilter<SetLevelRequestParams, EmptyResult>> SetLoggingLevelFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[SetLevelRequestParams](ModelContextProtocol.Protocol.SetLevelRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>>

#### Remarks

These filters wrap handlers that process [LoggingSetLevel](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_LoggingSetLevel) requests from clients. When set, it enables
clients to control which log messages they receive by specifying a minimum severity threshold.
The filters can modify, log, or perform additional operations on requests and responses for
[LoggingSetLevel](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_LoggingSetLevel) requests.

After handling a level change request, the server typically begins sending log messages
at or above the specified level to the client as notifications/message notifications.

### SubscribeToResourcesFilters

Gets or sets the filters for the subscribe-to-resources handler pipeline.

```
public IList<McpRequestFilter<SubscribeRequestParams, EmptyResult>> SubscribeToResourcesFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>>

#### Remarks

These filters wrap handlers that are invoked when a client wants to receive notifications about changes to specific resources or resource patterns.
The filters can modify, log, or perform additional operations on requests and responses for
[ResourcesSubscribe](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesSubscribe) requests. The handler should implement logic to register the client's interest in the specified resources
and set up the necessary infrastructure to send notifications when those resources change.

After a successful subscription, the server should send resource change notifications to the client
whenever a relevant resource is created, updated, or deleted.

### UnsubscribeFromResourcesFilters

Gets or sets the filters for the unsubscribe-from-resources handler pipeline.

```
public IList<McpRequestFilter<UnsubscribeRequestParams, EmptyResult>> UnsubscribeFromResourcesFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpRequestFilter](ModelContextProtocol.Server.McpRequestFilter-2.html)<[UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>>

#### Remarks

These filters wrap handlers that are invoked when a client wants to stop receiving notifications about previously subscribed resources.
The filters can modify, log, or perform additional operations on requests and responses for
[ResourcesUnsubscribe](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesUnsubscribe) requests. The handler should implement logic to remove the client's subscriptions to the specified resources
and clean up any associated resources.

After a successful unsubscription, the server should no longer send resource change notifications
to the client for the specified resources.




