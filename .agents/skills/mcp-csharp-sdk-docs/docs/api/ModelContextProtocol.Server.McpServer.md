
##### Table of Contents

# Class McpServer

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an instance of a Model Context Protocol (MCP) server that connects to and communicates with an MCP client.

```
public abstract class McpServer : McpSession, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [McpSession](ModelContextProtocol.McpSession.html)

    McpServer

Implements
:   [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Inherited Members
:   [McpSession.SessionId](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SessionId)

    [McpSession.NegotiatedProtocolVersion](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_NegotiatedProtocolVersion)

    [McpSession.SendRequestAsync(JsonRpcRequest, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendRequestAsync_ModelContextProtocol_Protocol_JsonRpcRequest_System_Threading_CancellationToken_)

    [McpSession.SendMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_)

    [McpSession.RegisterNotificationHandler(string, Func<JsonRpcNotification, CancellationToken, ValueTask>)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_RegisterNotificationHandler_System_String_System_Func_ModelContextProtocol_Protocol_JsonRpcNotification_System_Threading_CancellationToken_System_Threading_Tasks_ValueTask__)

    [McpSession.DisposeAsync()](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_DisposeAsync)

    [McpSession.SendRequestAsync<TParameters, TResult>(string, TParameters, JsonSerializerOptions, RequestId, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendRequestAsync__2_System_String___0_System_Text_Json_JsonSerializerOptions_ModelContextProtocol_Protocol_RequestId_System_Threading_CancellationToken_)

    [McpSession.SendNotificationAsync(string, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendNotificationAsync_System_String_System_Threading_CancellationToken_)

    [McpSession.SendNotificationAsync<TParameters>(string, TParameters, JsonSerializerOptions, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendNotificationAsync__1_System_String___0_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)

    [McpSession.NotifyProgressAsync(ProgressToken, ProgressNotificationValue, RequestOptions, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_NotifyProgressAsync_ModelContextProtocol_Protocol_ProgressToken_ModelContextProtocol_ProgressNotificationValue_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_)

    [McpSession.NotifyProgressAsync(ProgressNotificationParams, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_NotifyProgressAsync_ModelContextProtocol_Protocol_ProgressNotificationParams_System_Threading_CancellationToken_)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### McpServer()

Initializes a new instance of the [McpServer](ModelContextProtocol.Server.McpServer.html) class.

```
[Experimental("MCPEXP002", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp002")]
protected McpServer()
```

## Properties

### ClientCapabilities

Gets the capabilities supported by the client.

```
public abstract ClientCapabilities? ClientCapabilities { get; }
```

#### Property Value

[ClientCapabilities](ModelContextProtocol.Protocol.ClientCapabilities.html)

#### Remarks

These capabilities are established during the initialization handshake and indicate
which features the client supports, such as sampling, roots, and other
protocol-specific functionality.

Server implementations can check these capabilities to determine which features
are available when interacting with the client.

### ClientInfo

Gets the version and implementation information of the connected client.

```
public abstract Implementation? ClientInfo { get; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

This property contains identification information about the client that has connected to this server,
including its name and version. This information is provided by the client during initialization.

Server implementations can use this information for logging, tracking client versions,
or implementing client-specific behaviors.

### LoggingLevel

Gets the last logging level set by the client, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if it's never been set.

```
public abstract LoggingLevel? LoggingLevel { get; }
```

#### Property Value

[LoggingLevel](ModelContextProtocol.Protocol.LoggingLevel.html)?

### ServerOptions

Gets the options used to construct this server.

```
public abstract McpServerOptions ServerOptions { get; }
```

#### Property Value

[McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html)

#### Remarks

These options define the server's capabilities, protocol version, and other configuration
settings that were used to initialize the server.

### Services

Gets the service provider for the server.

```
public abstract IServiceProvider? Services { get; }
```

#### Property Value

[IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)

## Methods

### AsClientLoggerProvider()

Gets an [ILogger](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger) on which logged messages will be sent as notifications to the client.

```
public ILoggerProvider AsClientLoggerProvider()
```

#### Returns

[ILoggerProvider](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerprovider)
:   An [ILogger](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger) that can be used to log to the client.

### AsSamplingChatClient(JsonSerializerOptions?)

Creates an Microsoft.Extensions.AI.IChatClient wrapper that can be used to send sampling requests to the client.

```
public IChatClient AsSamplingChatClient(JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for serialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

IChatClient
:   The Microsoft.Extensions.AI.IChatClient that can be used to issue sampling requests to the client.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support sampling.

### CancelTaskAsync(string, CancellationToken)

Cancels a running task on the client.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> CancelTaskAsync(string taskId, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to cancel.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The updated state of the task after cancellation.

#### Remarks

Cancelling a task requests that the client stop execution. The client may not immediately cancel the task,
and may choose to allow the task to complete if it's close to finishing.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks or task cancellation.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### Create(ITransport, McpServerOptions, ILoggerFactory?, IServiceProvider?)

Creates a new instance of an [McpServer](ModelContextProtocol.Server.McpServer.html).

```
public static McpServer Create(ITransport transport, McpServerOptions serverOptions, ILoggerFactory? loggerFactory = null, IServiceProvider? serviceProvider = null)
```

#### Parameters

`transport` [ITransport](ModelContextProtocol.Protocol.ITransport.html)
:   The transport to use for the server representing an already-established MCP session.

`serverOptions` [McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html)
:   Configuration options for this server, including capabilities.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   Logger factory to use for logging. If null, logging will be disabled.

`serviceProvider` [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)
:   Optional service provider to create new instances of tools and other dependencies.

#### Returns

[McpServer](ModelContextProtocol.Server.McpServer.html)
:   An [McpServer](ModelContextProtocol.Server.McpServer.html) instance that should be disposed when no longer needed.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `transport` or `serverOptions` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ElicitAsTaskAsync(ElicitRequestParams, McpTaskMetadata, CancellationToken)

Requests additional information from the user via the client as a task, allowing the server to poll for completion.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> ElicitAsTaskAsync(ElicitRequestParams requestParams, McpTaskMetadata taskMetadata, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html)
:   The parameters for the elicitation request.

`taskMetadata` [McpTaskMetadata](ModelContextProtocol.Protocol.McpTaskMetadata.html)
:   The task metadata specifying TTL and other task-related options.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   An [McpTask](ModelContextProtocol.Protocol.McpTask.html) representing the created task on the client.

#### Remarks

Use [GetTaskAsync(string, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskAsync_System_String_System_Threading_CancellationToken_) to poll for task status and [GetTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskResultAsync__1_System_String_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)
(with [ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html)) to retrieve the final result when the task completes.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` or `taskMetadata` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support elicitation or task-augmented elicitation.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### ElicitAsync(ElicitRequestParams, CancellationToken)

Requests additional information from the user via the client, allowing the server to elicit structured data.

```
public ValueTask<ElicitResult> ElicitAsync(ElicitRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html)
:   The parameters for the elicitation request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html)>
:   A task containing the elicitation result.

#### Remarks

When called during task-augmented tool execution, this method automatically updates the task
status to [InputRequired](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_InputRequired) while waiting for user input,
then returns to [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working) when the response is received.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support elicitation.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### ElicitAsync<T>(string, RequestOptions?, CancellationToken)

Requests additional information from the user via the client, constructing a request schema from the
public serializable properties of `T` and deserializing the response into `T`.

```
public ValueTask<ElicitResult<T>> ElicitAsync<T>(string message, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message to present to the user.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ElicitResult](ModelContextProtocol.Protocol.ElicitResult-1.html)<T>>
:   An [ElicitResult<T>](ModelContextProtocol.Protocol.ElicitResult-1.html) with the user's response, if accepted.

#### Type Parameters

`T`
:   The type describing the expected input shape. Only primitive members are supported (string, number, boolean, enum).

#### Remarks

Elicitation uses a constrained subset of JSON Schema and only supports strings, numbers/integers, booleans and string enums.
Unsupported member types are ignored when constructing the schema.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `message` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `message` is empty or composed entirely of whitespace.

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support elicitation.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### GetTaskAsync(string, CancellationToken)

Retrieves the current state of a specific task from the client.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> GetTaskAsync(string taskId, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to retrieve.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The current state of the task.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### GetTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)

Retrieves the result of a completed task from the client, blocking until the task reaches a terminal state.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<TResult?> GetTaskResultAsync<TResult>(string taskId, JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task whose result to retrieve.

`jsonSerializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   Optional serializer options for deserializing the result.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<TResult>
:   The result of the task, deserialized into type `TResult`.

#### Type Parameters

`TResult`
:   The type to deserialize the task result into.

#### Remarks

This method sends a tasks/result request to the client, which will block until the task completes if it hasn't already.
The client handles all polling logic internally.

For sampling tasks, use [CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html) as `TResult`.
For elicitation tasks, use [ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html) as `TResult`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### ListTasksAsync(ListTasksRequestParams, CancellationToken)

Retrieves a list of tasks from the client.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<ListTasksResult> ListTasksAsync(ListTasksRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListTasksRequestParams](ModelContextProtocol.Protocol.ListTasksRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html)>
:   The result of the request as provided by the client.

#### Remarks

The [ListTasksAsync(CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_ListTasksAsync_System_Threading_CancellationToken_) overload retrieves all tasks by automatically handling pagination.
This overload works with the lower-level [ListTasksRequestParams](ModelContextProtocol.Protocol.ListTasksRequestParams.html) and [ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html), returning the raw result from the client.
Any pagination needs to be managed by the caller.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks or task listing.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### ListTasksAsync(CancellationToken)

Retrieves a list of all tasks from the client.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<IList<McpTask>> ListTasksAsync(CancellationToken cancellationToken = default)
```

#### Parameters

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>>
:   A list of all tasks.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks or task listing.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### NotifyTaskStatusAsync(McpTask, CancellationToken)

Sends a task status notification to the connected client.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public Task NotifyTaskStatusAsync(McpTask task, CancellationToken cancellationToken = default)
```

#### Parameters

`task` [McpTask](ModelContextProtocol.Protocol.McpTask.html)
:   The task whose status changed.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the asynchronous notification operation.

#### Remarks

This method sends an optional status notification to inform the client of task state changes.
According to the MCP specification, receivers MAY send this notification but are not required to.
Clients must not rely on receiving these notifications and should continue polling via tasks/get.

The notification is sent using the standard `notifications/tasks/status` method and includes
the full task state information.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `task` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The notification failed or the client returned an error response.

### PollTaskUntilCompleteAsync(string, CancellationToken)

Polls a task on the client until it reaches a terminal state.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> PollTaskUntilCompleteAsync(string taskId, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to poll.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The task in its terminal state.

#### Remarks

This method repeatedly calls [GetTaskAsync(string, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskAsync_System_String_System_Threading_CancellationToken_) until the task reaches a terminal status.
It respects the [PollInterval](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_PollInterval) returned by the client to determine how long
to wait between polling attempts.

For retrieving the actual result of a completed task, use [GetTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskResultAsync__1_System_String_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)
or [WaitForTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_WaitForTaskResultAsync__1_System_String_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### RequestRootsAsync(ListRootsRequestParams, CancellationToken)

Requests the client to list the roots it exposes.

```
public ValueTask<ListRootsResult> RequestRootsAsync(ListRootsRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListRootsRequestParams](ModelContextProtocol.Protocol.ListRootsRequestParams.html)
:   The parameters for the list roots request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListRootsResult](ModelContextProtocol.Protocol.ListRootsResult.html)>
:   A task containing the list of roots exposed by the client.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support roots.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### RunAsync(CancellationToken)

Runs the server, listening for and handling client requests.

```
public abstract Task RunAsync(CancellationToken cancellationToken = default)
```

#### Parameters

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### SampleAsTaskAsync(CreateMessageRequestParams, McpTaskMetadata, CancellationToken)

Requests to sample an LLM via the client as a task, allowing the server to poll for completion.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> SampleAsTaskAsync(CreateMessageRequestParams requestParams, McpTaskMetadata taskMetadata, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [CreateMessageRequestParams](ModelContextProtocol.Protocol.CreateMessageRequestParams.html)
:   The parameters for the sampling request.

`taskMetadata` [McpTaskMetadata](ModelContextProtocol.Protocol.McpTaskMetadata.html)
:   The task metadata specifying TTL and other task-related options.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   An [McpTask](ModelContextProtocol.Protocol.McpTask.html) representing the created task on the client.

#### Remarks

Use [GetTaskAsync(string, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskAsync_System_String_System_Threading_CancellationToken_) to poll for task status and [GetTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskResultAsync__1_System_String_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)
(with [CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html)) to retrieve the final result when the task completes.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` or `taskMetadata` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support sampling or task-augmented sampling.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### SampleAsync(CreateMessageRequestParams, CancellationToken)

Requests to sample an LLM via the client using the specified request parameters.

```
public ValueTask<CreateMessageResult> SampleAsync(CreateMessageRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [CreateMessageRequestParams](ModelContextProtocol.Protocol.CreateMessageRequestParams.html)
:   The parameters for the sampling request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html)>
:   A task containing the sampling result from the client.

#### Remarks

When called during task-augmented tool execution, this method automatically updates the task
status to [InputRequired](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_InputRequired) while waiting for the client response,
then returns to [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working) when the response is received.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support sampling.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### SampleAsync(IEnumerable<ChatMessage>, ChatOptions?, JsonSerializerOptions?, CancellationToken)

Requests to sample an LLM via the client using the provided chat messages and options.

```
public Task<ChatResponse> SampleAsync(IEnumerable<ChatMessage> messages, ChatOptions? chatOptions = null, JsonSerializerOptions? serializerOptions = null, CancellationToken cancellationToken = default)
```

#### Parameters

`messages` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<ChatMessage>
:   The messages to send as part of the request.

`chatOptions` ChatOptions
:   The options to use for the request, including model parameters and constraints.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for serializing user-provided objects. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<ChatResponse>
:   A task containing the chat response from the model.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `messages` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support sampling.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the client returned an error response.

### WaitForTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)

Waits for a task on the client to complete and retrieves its result.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<(McpTask Task, TResult? Result)> WaitForTaskResultAsync<TResult>(string taskId, JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task whose result to retrieve.

`jsonSerializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   Optional serializer options for deserializing the result.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<([McpTask](ModelContextProtocol.Protocol.McpTask.html) [Task](https://learn.microsoft.com/dotnet/api/system.valuetuple-modelcontextprotocol.protocol.mcptask%2C--0-.task), TResult [Result](https://learn.microsoft.com/dotnet/api/system.valuetuple-modelcontextprotocol.protocol.mcptask%2C--0-.result))>
:   A tuple containing the final task state and its result.

#### Type Parameters

`TResult`
:   The type to deserialize the task result into.

#### Remarks

This method combines [PollTaskUntilCompleteAsync(string, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_PollTaskUntilCompleteAsync_System_String_System_Threading_CancellationToken_) and [GetTaskResultAsync<TResult>(string, JsonSerializerOptions?, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_GetTaskResultAsync__1_System_String_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)
to provide a convenient way to wait for a task to complete and retrieve its result in a single call.

If the task completes with a status of [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed) or [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled),
an [McpException](ModelContextProtocol.McpException.html) is thrown.

For sampling tasks, use [CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html) as `TResult`.
For elicitation tasks, use [ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html) as `TResult`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client does not support tasks.

[McpException](ModelContextProtocol.McpException.html)
:   The task failed or was cancelled.




