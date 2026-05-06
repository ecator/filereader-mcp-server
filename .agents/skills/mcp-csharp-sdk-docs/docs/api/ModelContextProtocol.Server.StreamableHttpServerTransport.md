
##### Table of Contents

# Class StreamableHttpServerTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [ITransport](ModelContextProtocol.Protocol.ITransport.html) implementation using Server-Sent Events (SSE) for server-to-client communication.

```
public sealed class StreamableHttpServerTransport : ITransport, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    StreamableHttpServerTransport

Implements
:   [ITransport](ModelContextProtocol.Protocol.ITransport.html)

    [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This transport provides one-way communication from server to client using the SSE protocol over HTTP,
while receiving client messages through a separate mechanism. It writes messages as
SSE events to a response stream, typically associated with an HTTP response.

This transport is used in scenarios where the server needs to push messages to the client in real-time,
such as when streaming completion results or providing progress updates during long-running operations.

## Constructors

### StreamableHttpServerTransport(ILoggerFactory?)

Initializes a new instance of the [StreamableHttpServerTransport](ModelContextProtocol.Server.StreamableHttpServerTransport.html) class.

```
public StreamableHttpServerTransport(ILoggerFactory? loggerFactory = null)
```

#### Parameters

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   Optional logger factory used for logging employed by the transport.

## Fields

### UnsolicitedMessageStreamId

The stream ID used for unsolicited messages sent via the standalone GET SSE stream.

```
public static readonly string UnsolicitedMessageStreamId
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Properties

### EventStreamStore

Gets or sets the event store for resumability support.
When set, events are stored and can be replayed when clients reconnect with a Last-Event-ID header.

```
public ISseEventStreamStore? EventStreamStore { get; init; }
```

#### Property Value

[ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html)

### FlowExecutionContextFromRequests

Gets or initializes a value indicating whether the execution context should flow from the calls to [HandlePostRequestAsync(JsonRpcMessage, Stream, CancellationToken)](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_HandlePostRequestAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_IO_Stream_System_Threading_CancellationToken_)
to the corresponding [ExecutionContext](ModelContextProtocol.Protocol.JsonRpcMessageContext.html#ModelContextProtocol_Protocol_JsonRpcMessageContext_ExecutionContext) property contained in the [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html) instances returned by the [MessageReader](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_MessageReader).

```
public bool FlowExecutionContextFromRequests { get; init; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### MessageReader

Gets a channel reader for receiving messages from the transport.

```
public ChannelReader<JsonRpcMessage> MessageReader { get; }
```

#### Property Value

[ChannelReader](https://learn.microsoft.com/dotnet/api/system.threading.channels.channelreader-1)<[JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)>

#### Remarks

The [MessageReader](ModelContextProtocol.Protocol.ITransport.html#ModelContextProtocol_Protocol_ITransport_MessageReader) provides access to incoming JSON-RPC messages received by the transport.
It returns a [ChannelReader<T>](https://learn.microsoft.com/dotnet/api/system.threading.channels.channelreader-1) which allows messages to be consumed in a thread-safe manner.

The reader will continue to provide messages as long as the transport is connected. When the transport
is disconnected or disposed, the channel will be completed and no more messages will be available after
any already transmitted messages are consumed.

### OnSessionInitialized

Gets or sets an optional callback invoked after the initialization handshake completes.

```
public Func<InitializeRequestParams, CancellationToken, ValueTask>? OnSessionInitialized { get; init; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>

#### Remarks

When set, this callback is invoked with the [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html) after a successful
initialization handshake. This can be used to persist session data for cross-instance migration.

### SessionId

Gets an identifier associated with the current MCP session.

```
public string? SessionId { get; init; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The identifier is typically populated in transports supporting multiple sessions, such as Streamable HTTP or SSE.
This property can return [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the session hasn't initialized or if the transport doesn't
support multiple sessions (as is the case with STDIO).

### Stateless

Gets or initializes a value that indicates whether the transport should be in stateless mode that does not require all requests for a given session
to arrive to the same ASP.NET Core application process. Unsolicited server-to-client messages are not supported in this mode,
so calling [HandleGetRequestAsync(Stream, CancellationToken)](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_HandleGetRequestAsync_System_IO_Stream_System_Threading_CancellationToken_) results in an [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception).
Server-to-client requests are also unsupported, because the responses might arrive at another ASP.NET Core application process.
Client sampling and roots capabilities are also disabled in stateless mode, because the server cannot make requests.

```
public bool Stateless { get; init; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

## Methods

### DisposeAsync()

Performs application-defined tasks associated with freeing, releasing, or
resetting unmanaged resources asynchronously.

```
public ValueTask DisposeAsync()
```

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A task that represents the asynchronous dispose operation.

### HandleGetRequestAsync(Stream, CancellationToken)

Handles an optional SSE GET request a client using the Streamable HTTP transport might make by
writing any unsolicited JSON-RPC messages sent via [SendMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_SendMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_)
to the SSE response stream until cancellation is requested or the transport is disposed.

```
public Task HandleGetRequestAsync(Stream sseResponseStream, CancellationToken cancellationToken = default)
```

#### Parameters

`sseResponseStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The response stream to write MCP JSON-RPC messages as SSE events to.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the send loop that writes JSON-RPC messages to the SSE response stream.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `sseResponseStream` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   [Stateless](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_Stateless) is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) and GET requests are not supported in stateless mode.

### HandleInitializeRequestAsync(InitializeRequestParams?)

Handles initialization by capturing the negotiated protocol version and optionally invoking
[OnSessionInitialized](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_OnSessionInitialized) so session data can be persisted.

```
public ValueTask HandleInitializeRequestAsync(InitializeRequestParams? initParams)
```

#### Parameters

`initParams` [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html)
:   The initialization parameters from the client, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unavailable.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)

#### Remarks

This is called automatically when an `initialize` request is processed via
[HandlePostRequestAsync(JsonRpcMessage, Stream, CancellationToken)](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_HandlePostRequestAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_IO_Stream_System_Threading_CancellationToken_). It can also be called
directly when restoring a migrated session with known [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html).

### HandlePostRequestAsync(JsonRpcMessage, Stream, CancellationToken)

Handles a Streamable HTTP POST request processing both the request body and response body ensuring that
[JsonRpcResponse](ModelContextProtocol.Protocol.JsonRpcResponse.html) and other correlated messages are sent back to the client directly in response
to the [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html) that initiated the message.

```
public Task<bool> HandlePostRequestAsync(JsonRpcMessage message, Stream responseStream, CancellationToken cancellationToken = default)
```

#### Parameters

`message` [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)
:   The JSON-RPC message received from the client via the POST request body.

`responseStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The POST response body to write MCP JSON-RPC messages to.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[bool](https://learn.microsoft.com/dotnet/api/system.boolean)>
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if data was written to the response body.
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if nothing was written because the request body did not contain any [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html) messages to respond to.
    The HTTP application should typically respond with an empty "202 Accepted" response in this scenario.

#### Remarks

If an authenticated [ClaimsPrincipal](https://learn.microsoft.com/dotnet/api/system.security.claims.claimsprincipal) sent the message, that can be included in the [Context](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_Context).
No other part of the context should be set.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `message` or `responseStream` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### SendMessageAsync(JsonRpcMessage, CancellationToken)

Sends a JSON-RPC message through the transport.

```
public Task SendMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
```

#### Parameters

`message` [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)
:   The JSON-RPC message to send.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous send operation.

#### Remarks

This method serializes and sends the provided JSON-RPC message through the transport connection.

This is a core method used by higher-level abstractions in the MCP protocol implementation.
Most client code should use the higher-level methods provided by [McpSession](ModelContextProtocol.McpSession.html),
[McpClient](ModelContextProtocol.Client.McpClient.html), or [McpServer](ModelContextProtocol.Server.McpServer.html),
rather than accessing this method directly.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The transport is not connected.




