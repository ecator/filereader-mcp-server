
##### Table of Contents

# Class McpSession

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a client or server Model Context Protocol (MCP) session.

```
public abstract class McpSession : IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpSession

Implements
:   [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Derived
:   [McpClient](ModelContextProtocol.Client.McpClient.html)

    [McpServer](ModelContextProtocol.Server.McpServer.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The MCP session provides the core communication functionality used by both clients and servers:

* Sending JSON-RPC requests and receiving responses.
* Sending notifications to the connected session.
* Registering handlers for receiving notifications.

[McpSession](ModelContextProtocol.McpSession.html) serves as the base class for both [McpClient](ModelContextProtocol.Client.McpClient.html) and
[McpServer](ModelContextProtocol.Server.McpServer.html), providing the common functionality needed for MCP protocol
communication. Most applications will use these more specific interfaces rather than working with
[McpSession](ModelContextProtocol.McpSession.html) directly.

All MCP sessions should be properly disposed after use as they implement [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable).

## Properties

### NegotiatedProtocolVersion

Gets the negotiated protocol version for the current MCP session.

```
public abstract string? NegotiatedProtocolVersion { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Returns the protocol version negotiated during session initialization,
or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if initialization hasn't yet occurred.

### SessionId

Gets an identifier associated with the current MCP session.

```
public abstract string? SessionId { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Typically populated in transports supporting multiple sessions, such as Streamable HTTP or SSE.
Can return [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the session hasn't initialized or if the transport doesn't
support multiple sessions (as is the case with STDIO).

## Methods

### DisposeAsync()

Performs application-defined tasks associated with freeing, releasing, or
resetting unmanaged resources asynchronously.

```
public abstract ValueTask DisposeAsync()
```

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A task that represents the asynchronous dispose operation.

### NotifyProgressAsync(ProgressNotificationParams, CancellationToken)

Notifies the connected session of progress for a long-running operation.

```
public Task NotifyProgressAsync(ProgressNotificationParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ProgressNotificationParams](ModelContextProtocol.Protocol.ProgressNotificationParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the completion of the notification operation (not the operation being tracked).

#### Remarks

This method sends a progress notification to the connected session using the Model Context Protocol's
standardized progress notification format. Progress updates are identified by a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)
that allows the recipient to correlate multiple updates with a specific long-running operation.

Progress notifications are sent asynchronously and don't block the operation from continuing.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### NotifyProgressAsync(ProgressToken, ProgressNotificationValue, RequestOptions?, CancellationToken)

Notifies the connected session of progress for a long-running operation.

```
public Task NotifyProgressAsync(ProgressToken progressToken, ProgressNotificationValue progress, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`progressToken` [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)
:   The token that identifies the operation for which progress is being reported.

`progress` [ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)
:   The progress update to send, containing information such as percentage complete or status message.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the completion of the notification operation (not the operation being tracked).

#### Remarks

This method sends a progress notification to the connected session using the Model Context Protocol's
standardized progress notification format. Progress updates are identified by a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)
that allows the recipient to correlate multiple updates with a specific long-running operation.

Progress notifications are sent asynchronously and don't block the operation from continuing.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `progress` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### RegisterNotificationHandler(string, Func<JsonRpcNotification, CancellationToken, ValueTask>)

Registers a handler to be invoked when a notification for the specified method is received.

```
public abstract IAsyncDisposable RegisterNotificationHandler(string method, Func<JsonRpcNotification, CancellationToken, ValueTask> handler)
```

#### Parameters

`method` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The notification method.

`handler` [Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[JsonRpcNotification](ModelContextProtocol.Protocol.JsonRpcNotification.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>
:   The handler to be invoked.

#### Returns

[IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)
:   An [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) that will remove the registered handler when disposed.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` or `handler` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is empty or composed entirely of whitespace.

### SendMessageAsync(JsonRpcMessage, CancellationToken)

Sends a JSON-RPC message to the connected session.

```
public abstract Task SendMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
```

#### Parameters

`message` [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)
:   The JSON-RPC message to send. This can be any type that implements JsonRpcMessage, such as
    JsonRpcRequest, JsonRpcResponse, JsonRpcNotification, or JsonRpcError.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous send operation.

#### Remarks

This method provides low-level access to send any JSON-RPC message. For specific message types,
consider using the higher-level methods such as [SendRequestAsync(JsonRpcRequest, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendRequestAsync_ModelContextProtocol_Protocol_JsonRpcRequest_System_Threading_CancellationToken_) or methods
on this class that provide a simpler API.

The method serializes the message and transmits it using the underlying transport mechanism.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The transport is not connected.

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `message` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### SendNotificationAsync(string, CancellationToken)

Sends a parameterless notification to the connected session.

```
public Task SendNotificationAsync(string method, CancellationToken cancellationToken = default)
```

#### Parameters

`method` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The notification method name.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous send operation.

#### Remarks

This method sends a notification without any parameters. Notifications are one-way messages
that don't expect a response. They are commonly used for events, status updates, or to signal
changes in state.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is empty or composed entirely of whitespace.

### SendNotificationAsync<TParameters>(string, TParameters, JsonSerializerOptions?, CancellationToken)

Sends a notification with parameters to the connected session.

```
public Task SendNotificationAsync<TParameters>(string method, TParameters parameters, JsonSerializerOptions? serializerOptions = null, CancellationToken cancellationToken = default)
```

#### Parameters

`method` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The JSON-RPC method name for the notification.

`parameters` TParameters
:   The notification parameters.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The options governing parameter serialization. If null, default options are used.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous send operation.

#### Type Parameters

`TParameters`
:   The type of the notification parameters to serialize.

#### Remarks

This method sends a notification with parameters to the connected session. Notifications are one-way
messages that don't expect a response, commonly used for events, status updates, or signaling changes.

The parameters object is serialized to JSON according to the provided serializer options or the default
options if none are specified.

The Model Context Protocol defines several standard notification methods in [NotificationMethods](ModelContextProtocol.Protocol.NotificationMethods.html),
but custom methods can also be used for application-specific notifications.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is empty or composed entirely of whitespace.

### SendRequestAsync(JsonRpcRequest, CancellationToken)

Sends a JSON-RPC request to the connected session and waits for a response.

```
public abstract Task<JsonRpcResponse> SendRequestAsync(JsonRpcRequest request, CancellationToken cancellationToken = default)
```

#### Parameters

`request` [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html)
:   The JSON-RPC request to send.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[JsonRpcResponse](ModelContextProtocol.Protocol.JsonRpcResponse.html)>
:   A task containing the session's response.

#### Remarks

This method provides low-level access to send raw JSON-RPC requests. For most use cases,
consider using the strongly-typed methods that provide a more convenient API.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The transport is not connected, or another error occurred during request processing.

[McpException](ModelContextProtocol.McpException.html)
:   An error occurred during request processing.

### SendRequestAsync<TParameters, TResult>(string, TParameters, JsonSerializerOptions?, RequestId, CancellationToken)

Sends a JSON-RPC request and attempts to deserialize the result to `TResult`.

```
public ValueTask<TResult> SendRequestAsync<TParameters, TResult>(string method, TParameters parameters, JsonSerializerOptions? serializerOptions = null, RequestId requestId = default, CancellationToken cancellationToken = default) where TResult : notnull
```

#### Parameters

`method` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The JSON-RPC method name to invoke.

`parameters` TParameters
:   The request parameters.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The options governing request serialization.

`requestId` [RequestId](ModelContextProtocol.Protocol.RequestId.html)
:   The request ID for the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<TResult>
:   A task that represents the asynchronous operation. The task result contains the deserialized result.

#### Type Parameters

`TParameters`
:   The type of the request parameters to serialize from.

`TResult`
:   The type of the result to deserialize to.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.




