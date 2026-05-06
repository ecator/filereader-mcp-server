
##### Table of Contents

# Class StreamClientTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [IClientTransport](ModelContextProtocol.Client.IClientTransport.html) implemented around a pair of input/output streams.

```
public sealed class StreamClientTransport : IClientTransport
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    StreamClientTransport

Implements
:   [IClientTransport](ModelContextProtocol.Client.IClientTransport.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This transport is useful for scenarios where you already have established streams for communication,
such as custom network protocols, pipe connections, or for testing purposes. It works with any
readable and writable streams.

## Constructors

### StreamClientTransport(Stream, Stream, ILoggerFactory?)

Initializes a new instance of the [StreamClientTransport](ModelContextProtocol.Protocol.StreamClientTransport.html) class.

```
public StreamClientTransport(Stream serverInput, Stream serverOutput, ILoggerFactory? loggerFactory = null)
```

#### Parameters

`serverInput` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The stream representing the connected server's input.
    Writes to this stream will be sent to the server.

`serverOutput` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The stream representing the connected server's output.
    Reads from this stream will receive messages from the server.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   A logger factory for creating loggers.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `serverInput` or `serverOutput` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Name

Gets a transport identifier, used for logging purposes.

```
public string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### ConnectAsync(CancellationToken)

Asynchronously establishes a transport session with an MCP server and returns a transport for the duplex message stream.

```
public Task<ITransport> ConnectAsync(CancellationToken cancellationToken = default)
```

#### Parameters

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[ITransport](ModelContextProtocol.Protocol.ITransport.html)>
:   An interface for the duplex message stream.

#### Remarks

This method is responsible for initializing the connection to the server using the specific transport
mechanism implemented by the derived class. The returned [ITransport](ModelContextProtocol.Protocol.ITransport.html) interface
provides methods to send and receive messages over the established connection.

The lifetime of the returned [ITransport](ModelContextProtocol.Protocol.ITransport.html) instance is typically managed by the
[McpClient](ModelContextProtocol.Client.McpClient.html) that uses this transport. When the client is disposed, it will dispose
the transport session as well.

This method is used by [McpClient](ModelContextProtocol.Client.McpClient.html) to initialize the connection.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The transport connection could not be established.




