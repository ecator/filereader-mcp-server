
##### Table of Contents

# Interface ITransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a transport mechanism for MCP (Model Context Protocol) communication between clients and servers.

```
public interface ITransport : IAsyncDisposable
```

Inherited Members
:   [IAsyncDisposable.DisposeAsync()](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable.disposeasync)

## Remarks

The [ITransport](ModelContextProtocol.Protocol.ITransport.html) interface is the core abstraction for bidirectional communication.
It provides methods for sending and receiving messages, abstracting away the underlying transport mechanism,
and allowing protocol implementations to be decoupled from communication details.

Implementations of [ITransport](ModelContextProtocol.Protocol.ITransport.html) handle the serialization, transmission, and reception of
messages over various channels like standard input/output streams and HTTP (Server-Sent Events).

While [IClientTransport](ModelContextProtocol.Client.IClientTransport.html) is responsible for establishing a client's connection,
[ITransport](ModelContextProtocol.Protocol.ITransport.html) represents an established session. Client implementations typically obtain an
[ITransport](ModelContextProtocol.Protocol.ITransport.html) instance by calling [ConnectAsync(CancellationToken)](ModelContextProtocol.Client.IClientTransport.html#ModelContextProtocol_Client_IClientTransport_ConnectAsync_System_Threading_CancellationToken_).

## Properties

### MessageReader

Gets a channel reader for receiving messages from the transport.

```
ChannelReader<JsonRpcMessage> MessageReader { get; }
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
string? SessionId { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The identifier is typically populated in transports supporting multiple sessions, such as Streamable HTTP or SSE.
This property can return [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the session hasn't initialized or if the transport doesn't
support multiple sessions (as is the case with STDIO).

## Methods

### SendMessageAsync(JsonRpcMessage, CancellationToken)

Sends a JSON-RPC message through the transport.

```
Task SendMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
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




