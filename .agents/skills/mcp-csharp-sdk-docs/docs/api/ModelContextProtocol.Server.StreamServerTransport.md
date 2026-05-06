
##### Table of Contents

# Class StreamServerTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [ITransport](ModelContextProtocol.Protocol.ITransport.html) implemented using a pair of input and output streams.

```
public class StreamServerTransport : TransportBase, ITransport, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [TransportBase](ModelContextProtocol.Protocol.TransportBase.html)

    StreamServerTransport

Implements
:   [ITransport](ModelContextProtocol.Protocol.ITransport.html)

    [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Derived
:   [StdioServerTransport](ModelContextProtocol.Server.StdioServerTransport.html)

Inherited Members
:   [TransportBase.SessionId](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_SessionId)

    [TransportBase.Name](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_Name)

    [TransportBase.IsConnected](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_IsConnected)

    [TransportBase.MessageReader](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_MessageReader)

    [TransportBase.WriteMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_WriteMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_)

    [TransportBase.SetConnected()](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_SetConnected)

    [TransportBase.SetDisconnected(Exception)](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_SetDisconnected_System_Exception_)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [StreamServerTransport](ModelContextProtocol.Server.StreamServerTransport.html) class implements bidirectional JSON-RPC messaging over arbitrary
streams, allowing MCP communication with clients through various I/O channels such as network sockets,
memory streams, or pipes.

## Constructors

### StreamServerTransport(Stream, Stream, string?, ILoggerFactory?)

Initializes a new instance of the [StreamServerTransport](ModelContextProtocol.Server.StreamServerTransport.html) class with explicit input/output streams.

```
public StreamServerTransport(Stream inputStream, Stream outputStream, string? serverName = null, ILoggerFactory? loggerFactory = null)
```

#### Parameters

`inputStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The input [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream) to use as standard input.

`outputStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The output [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream) to use as standard output.

`serverName` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional name of the server, used for diagnostic purposes, like logging.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   Optional logger factory used for logging employed by the transport.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `inputStream` or `outputStream` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Methods

### DisposeAsync()

Performs application-defined tasks associated with freeing, releasing, or
resetting unmanaged resources asynchronously.

```
public override ValueTask DisposeAsync()
```

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A task that represents the asynchronous dispose operation.

### SendMessageAsync(JsonRpcMessage, CancellationToken)

Sends a JSON-RPC message through the transport.

```
public override Task SendMessageAsync(JsonRpcMessage message, CancellationToken cancellationToken = default)
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




