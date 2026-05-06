
##### Table of Contents

# Class McpServerHandlers

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a container for handlers used in the creation of an MCP server.

```
public sealed class McpServerHandlers
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerHandlers

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class provides a centralized collection of delegates that implement various capabilities of the Model Context Protocol.
Each handler in this class corresponds to a specific endpoint in the Model Context Protocol and
is responsible for processing a particular type of message. The handlers are used to customize
the behavior of the MCP server by providing implementations for the various protocol operations.

When a client sends a message to the server, the appropriate handler is invoked to process it
according to the protocol specification. Which handler is selected
is done based on an ordinal, case-sensitive string comparison.

## Properties

### CallToolHandler

Gets or sets the handler for [ToolsCall](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsCall) requests.

```
public McpRequestHandler<CallToolRequestParams, CallToolResult>? CallToolHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html), [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>

#### Remarks

This handler is invoked when a client makes a call to a tool that isn't found in the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) collection.
The handler should implement logic to execute the requested tool and return appropriate results.

### CompleteHandler

Gets or sets the handler for [CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete) requests.

```
public McpRequestHandler<CompleteRequestParams, CompleteResult>? CompleteHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[CompleteRequestParams](ModelContextProtocol.Protocol.CompleteRequestParams.html), [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)>

#### Remarks

This handler provides auto-completion suggestions for prompt arguments or resource references in the Model Context Protocol.
The handler processes auto-completion requests, returning a list of suggestions based on the
reference type and current argument value.

### GetPromptHandler

Gets or sets the handler for [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) requests.

```
public McpRequestHandler<GetPromptRequestParams, GetPromptResult>? GetPromptHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html), [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>

#### Remarks

This handler is invoked when a client requests details for a specific prompt that isn't found in the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) collection.
The handler should implement logic to fetch or generate the requested prompt and return appropriate results.

### ListPromptsHandler

Gets or sets the handler for [PromptsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsList) requests.

```
public McpRequestHandler<ListPromptsRequestParams, ListPromptsResult>? ListPromptsHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html), [ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html)>

#### Remarks

The handler should return a list of available prompts when requested by a client.
It supports pagination through the cursor mechanism, where the client can make
repeated calls with the cursor returned by the previous call to retrieve more prompts.

This handler works alongside any prompts defined in the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) collection.
Prompts from both sources will be combined when returning results to clients.

### ListResourceTemplatesHandler

Gets or sets the handler for [ResourcesTemplatesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesTemplatesList) requests.

```
public McpRequestHandler<ListResourceTemplatesRequestParams, ListResourceTemplatesResult>? ListResourceTemplatesHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html), [ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html)>

#### Remarks

The handler should return a list of available resource templates when requested by a client.
It supports pagination through the cursor mechanism, where the client can make
repeated calls with the cursor returned by the previous call to retrieve more resource templates.

### ListResourcesHandler

Gets or sets the handler for [ResourcesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesList) requests.

```
public McpRequestHandler<ListResourcesRequestParams, ListResourcesResult>? ListResourcesHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html), [ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html)>

#### Remarks

The handler should return a list of available resources when requested by a client.
It supports pagination through the cursor mechanism, where the client can make
repeated calls with the cursor returned by the previous call to retrieve more resources.

### ListToolsHandler

Gets or sets the handler for [ToolsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsList) requests.

```
public McpRequestHandler<ListToolsRequestParams, ListToolsResult>? ListToolsHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html), [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html)>

#### Remarks

The handler should return a list of available tools when requested by a client.
It supports pagination through the cursor mechanism, where the client can make
repeated calls with the cursor returned by the previous call to retrieve more tools.

This handler works alongside any tools defined in the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) collection.
Tools from both sources will be combined when returning results to clients.

### NotificationHandlers

Gets or sets notification handlers to register with the server.

```
public IEnumerable<KeyValuePair<string, Func<JsonRpcNotification, CancellationToken, ValueTask>>>? NotificationHandlers { get; set; }
```

#### Property Value

[IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[KeyValuePair](https://learn.microsoft.com/dotnet/api/system.collections.generic.keyvaluepair-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[JsonRpcNotification](ModelContextProtocol.Protocol.JsonRpcNotification.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>>>

#### Remarks

When constructed, the server will enumerate these handlers, which may contain multiple handlers per notification method key, once.
The server will not re-enumerate the sequence after initialization.

Notification handlers allow the server to respond to client-sent notifications for specific methods.
Each key in the collection is a notification method name, and each value is a callback that will be invoked
when a notification with that method is received.

Handlers provided via [NotificationHandlers](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_NotificationHandlers) will be registered with the server for the lifetime of the server.
For transient handlers, [RegisterNotificationHandler(string, Func<JsonRpcNotification, CancellationToken, ValueTask>)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_RegisterNotificationHandler_System_String_System_Func_ModelContextProtocol_Protocol_JsonRpcNotification_System_Threading_CancellationToken_System_Threading_Tasks_ValueTask__) may be used to register a handler that can
then be unregistered by disposing of the [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) returned from the method.

### ReadResourceHandler

Gets or sets the handler for [ResourcesRead](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesRead) requests.

```
public McpRequestHandler<ReadResourceRequestParams, ReadResourceResult>? ReadResourceHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html), [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>

#### Remarks

This handler is invoked when a client requests the content of a specific resource identified by its URI.
The handler should implement logic to locate and retrieve the requested resource.

### SetLoggingLevelHandler

Gets or sets the handler for [LoggingSetLevel](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_LoggingSetLevel) requests.

```
public McpRequestHandler<SetLevelRequestParams, EmptyResult>? SetLoggingLevelHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[SetLevelRequestParams](ModelContextProtocol.Protocol.SetLevelRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>

#### Remarks

This handler processes [LoggingSetLevel](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_LoggingSetLevel) requests from clients. When set, it enables
clients to control which log messages they receive by specifying a minimum severity threshold.

After handling a level change request, the server typically begins sending log messages
at or above the specified level to the client as notifications/message notifications.

### SubscribeToResourcesHandler

Gets or sets the handler for [ResourcesSubscribe](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesSubscribe) requests.

```
public McpRequestHandler<SubscribeRequestParams, EmptyResult>? SubscribeToResourcesHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>

#### Remarks

This handler is invoked when a client wants to receive notifications about changes to specific resources or resource patterns.
The handler should implement logic to register the client's interest in the specified resources
and set up the necessary infrastructure to send notifications when those resources change.

After a successful subscription, the server should send resource change notifications to the client
whenever a relevant resource is created, updated, or deleted.

### UnsubscribeFromResourcesHandler

Gets or sets the handler for [ResourcesUnsubscribe](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesUnsubscribe) requests.

```
public McpRequestHandler<UnsubscribeRequestParams, EmptyResult>? UnsubscribeFromResourcesHandler { get; set; }
```

#### Property Value

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>

#### Remarks

This handler is invoked when a client wants to stop receiving notifications about previously subscribed resources.
The handler should implement logic to remove the client's subscriptions to the specified resources
and clean up any associated resources.

After a successful unsubscription, the server should no longer send resource change notifications
to the client for the specified resources.




