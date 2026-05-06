
##### Table of Contents

# Class SseResponseStreamTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [ITransport](ModelContextProtocol.Protocol.ITransport.html) implementation using Server-Sent Events (SSE) for server-to-client communication.

```
public sealed class SseResponseStreamTransport : ITransport, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    SseResponseStreamTransport

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

**Backpressure consideration:** The SSE transport separates request and response channels — the client POSTs
messages to a separate endpoint while responses flow over the SSE stream. If the HTTP handler for incoming
messages returns immediately (e.g., `202 Accepted`) after calling [OnMessageReceivedAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_OnMessageReceivedAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_),
there is no HTTP-level backpressure on handler concurrency. The ASP.NET Core integration disables legacy SSE
endpoints by default for this reason. If you are using this type directly, consider holding the POST response
open until the handler completes, or applying rate-limiting at the HTTP layer.

## Constructors

### SseResponseStreamTransport(Stream, string?, string?)

Provides an [ITransport](ModelContextProtocol.Protocol.ITransport.html) implementation using Server-Sent Events (SSE) for server-to-client communication.

```
public SseResponseStreamTransport(Stream sseResponseStream, string? messageEndpoint = "/message", string? sessionId = null)
```

#### Parameters

`sseResponseStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The response stream to write MCP JSON-RPC messages as SSE events to.

`messageEndpoint` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The relative or absolute URI the client should use to post MCP JSON-RPC messages for this session.
    These messages should be passed to [OnMessageReceivedAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_OnMessageReceivedAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_).
    Defaults to "/message".

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The identifier corresponding to the current MCP session.

#### Remarks

This transport provides one-way communication from server to client using the SSE protocol over HTTP,
while receiving client messages through a separate mechanism. It writes messages as
SSE events to a response stream, typically associated with an HTTP response.

This transport is used in scenarios where the server needs to push messages to the client in real-time,
such as when streaming completion results or providing progress updates during long-running operations.

**Backpressure consideration:** The SSE transport separates request and response channels — the client POSTs
messages to a separate endpoint while responses flow over the SSE stream. If the HTTP handler for incoming
messages returns immediately (e.g., `202 Accepted`) after calling [OnMessageReceivedAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_OnMessageReceivedAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_),
there is no HTTP-level backpressure on handler concurrency. The ASP.NET Core integration disables legacy SSE
endpoints by default for this reason. If you are using this type directly, consider holding the POST response
open until the handler completes, or applying rate-limiting at the HTTP layer.

## Properties

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

### SessionId

Gets an identifier associated with the current MCP session.

```
public string? SessionId { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The identifier is typically populated in transports supporting multiple sessions, such as Streamable HTTP or SSE.
This property can return [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the session hasn't initialized or if the transport doesn't
support multiple sessions (as is the case with STDIO).

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

### OnMessageReceivedAsync(JsonRpcMessage, CancellationToken)

Handles incoming JSON-RPC messages received on the /message endpoint.

```
public Task OnMessageReceivedAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
```

#### Parameters

`message` [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)
:   The JSON-RPC message received from the client.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the asynchronous operation to buffer the JSON-RPC message for processing.

#### Remarks

This method is the entry point for processing client-to-server communication in the SSE transport model.
While the SSE protocol itself is unidirectional (server to client), this method allows bidirectional
communication by handling HTTP POST requests sent to the message endpoint.

When a client sends a JSON-RPC message to the /message endpoint, the server calls this method to
process the message and make it available to the MCP server via the [MessageReader](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_MessageReader) channel.

If an authenticated [ClaimsPrincipal](https://learn.microsoft.com/dotnet/api/system.security.claims.claimsprincipal) sent the message, that can be included in the [Context](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_Context).
No other part of the context should be set.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `message` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   There is an attempt to process a message before calling [RunAsync(CancellationToken)](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_RunAsync_System_Threading_CancellationToken_).

### RunAsync(CancellationToken)

Starts the transport and writes the JSON-RPC messages sent via [SendMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_SendMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_)
to the SSE response stream until cancellation is requested or the transport is disposed.

```
public Task RunAsync(CancellationToken cancellationToken = default)
```

#### Parameters

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the send loop that writes JSON-RPC messages to the SSE response stream.

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




