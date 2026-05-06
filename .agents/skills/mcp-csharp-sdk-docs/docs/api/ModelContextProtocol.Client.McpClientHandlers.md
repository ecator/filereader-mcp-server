
##### Table of Contents

# Class McpClientHandlers

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a container for handlers used in the creation of an MCP client.

```
public sealed class McpClientHandlers
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpClientHandlers

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class provides a centralized collection of delegates that implement various capabilities of the Model Context Protocol.

Each handler in this class corresponds to a specific client endpoint in the Model Context Protocol and
is responsible for processing a particular type of message. The handlers are used to customize
the behavior of the MCP client by providing implementations for the various protocol operations.

When a server sends a message to the client, the appropriate handler is invoked to process it
according to the protocol specification. Which handler is selected
is done based on an ordinal, case-sensitive string comparison.

## Properties

### ElicitationHandler

Gets or sets the handler for processing [ElicitationCreate](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ElicitationCreate) requests.

```
public Func<ElicitRequestParams?, CancellationToken, ValueTask<ElicitResult>>? ElicitationHandler { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html)>>

#### Remarks

This handler function is called when an MCP server requests the client to provide additional
information during interactions. The client must set this property for the elicitation capability to work.

The handler receives message parameters and a cancellation token.
It should return a [ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html) containing the response to the elicitation request.

### NotificationHandlers

Gets or sets notification handlers to register with the client.

```
public IEnumerable<KeyValuePair<string, Func<JsonRpcNotification, CancellationToken, ValueTask>>>? NotificationHandlers { get; set; }
```

#### Property Value

[IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[KeyValuePair](https://learn.microsoft.com/dotnet/api/system.collections.generic.keyvaluepair-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[JsonRpcNotification](ModelContextProtocol.Protocol.JsonRpcNotification.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>>>

#### Remarks

When constructed, the client will enumerate these handlers, which might contain multiple handlers per notification method key, once.
The client will not re-enumerate the sequence after initialization.

Notification handlers allow the client to respond to server-sent notifications for specific methods.
Each key in the collection is a notification method name, and each value is a callback that will be invoked
when a notification with that method is received.

Handlers provided via [NotificationHandlers](ModelContextProtocol.Client.McpClientHandlers.html#ModelContextProtocol_Client_McpClientHandlers_NotificationHandlers) will be registered with the client for the lifetime of the client.
For transient handlers, you can use [RegisterNotificationHandler(string, Func<JsonRpcNotification, CancellationToken, ValueTask>)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_RegisterNotificationHandler_System_String_System_Func_ModelContextProtocol_Protocol_JsonRpcNotification_System_Threading_CancellationToken_System_Threading_Tasks_ValueTask__) to register a handler that can
then be unregistered by disposing of the [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) returned from the method.

### RootsHandler

Gets or sets the handler for [RootsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_RootsList) requests.

```
public Func<ListRootsRequestParams?, CancellationToken, ValueTask<ListRootsResult>>? RootsHandler { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[ListRootsRequestParams](ModelContextProtocol.Protocol.ListRootsRequestParams.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListRootsResult](ModelContextProtocol.Protocol.ListRootsResult.html)>>

#### Remarks

This handler is invoked when the server sends a [RootsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_RootsList) request to retrieve available roots.
The handler receives request parameters and should return a [ListRootsResult](ModelContextProtocol.Protocol.ListRootsResult.html) containing the collection of available roots.

### SamplingHandler

Gets or sets the handler for processing [SamplingCreateMessage](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_SamplingCreateMessage) requests.

```
public Func<CreateMessageRequestParams?, IProgress<ProgressNotificationValue>, CancellationToken, ValueTask<CreateMessageResult>>? SamplingHandler { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-4)<[CreateMessageRequestParams](ModelContextProtocol.Protocol.CreateMessageRequestParams.html), [IProgress](https://learn.microsoft.com/dotnet/api/system.iprogress-1)<[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)>, [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html)>>

#### Remarks

This handler function is called when an MCP server requests the client to generate content
using an AI model. The client must set this property for the sampling capability to work.

The handler receives message parameters, a progress reporter for updates, and a
cancellation token. It should return a [CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html) containing the
generated content.

You can create a handler using the [CreateSamplingHandler(IChatClient, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_CreateSamplingHandler_Microsoft_Extensions_AI_IChatClient_System_Text_Json_JsonSerializerOptions_) extension
method with any implementation of Microsoft.Extensions.AI.IChatClient.

### TaskStatusHandler

Gets or sets the handler for processing [TaskStatusNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_TaskStatusNotification) notifications.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public Func<McpTask, CancellationToken, ValueTask>? TaskStatusHandler { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[McpTask](ModelContextProtocol.Protocol.McpTask.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>

#### Remarks

This handler is called when the server sends a task status notification to inform the client
about changes to a task's state. These notifications are optional and clients MUST NOT rely
on receiving them.

The handler receives the updated [McpTask](ModelContextProtocol.Protocol.McpTask.html) object containing the current task state,
including its status, status message, and timestamps.

This handler is typically used to update UI or trigger actions based on task progress
without requiring explicit polling.




