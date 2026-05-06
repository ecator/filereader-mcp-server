
##### Table of Contents

# Class TransportBase

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class for implementing [ITransport](ModelContextProtocol.Protocol.ITransport.html).

```
public abstract class TransportBase : ITransport, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    TransportBase

Implements
:   [ITransport](ModelContextProtocol.Protocol.ITransport.html)

    [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Derived
:   [StreamServerTransport](ModelContextProtocol.Server.StreamServerTransport.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [TransportBase](ModelContextProtocol.Protocol.TransportBase.html) class provides core functionality required by most [ITransport](ModelContextProtocol.Protocol.ITransport.html)
implementations, including message channel management, connection state tracking, and logging support.

Custom transport implementations should inherit from this class and implement the abstract
[SendMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_SendMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_) and [DisposeAsync()](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_DisposeAsync) methods
to handle the specific transport mechanism being used.

## Constructors

### TransportBase(string, ILoggerFactory?)

Initializes a new instance of the [TransportBase](ModelContextProtocol.Protocol.TransportBase.html) class.

```
protected TransportBase(string name, ILoggerFactory? loggerFactory)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)

## Properties

### IsConnected

```
public bool IsConnected { get; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

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

### Name

Gets the name that identifies this transport endpoint in logs.

```
protected string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This name is used in log messages to identify the source of transport-related events.

### SessionId

Gets an identifier associated with the current MCP session.

```
public virtual string? SessionId { get; protected set; }
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
public abstract ValueTask DisposeAsync()
```

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A task that represents the asynchronous dispose operation.

### SendMessageAsync(JsonRpcMessage, CancellationToken)

Sends a JSON-RPC message through the transport.

```
public abstract Task SendMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
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

### SetConnected()

Sets the transport to a connected state.

```
protected void SetConnected()
```

### SetDisconnected(Exception?)

Sets the transport to a disconnected state.

```
protected void SetDisconnected(Exception? error = null)
```

#### Parameters

`error` [Exception](https://learn.microsoft.com/dotnet/api/system.exception)
:   Optional error information associated with the transport disconnecting. Should be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the disconnect was graceful and expected.

### WriteMessageAsync(JsonRpcMessage, CancellationToken)

Writes a message to the message channel.

```
protected Task WriteMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
```

#### Parameters

`message` [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)
:   The message to write.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)



