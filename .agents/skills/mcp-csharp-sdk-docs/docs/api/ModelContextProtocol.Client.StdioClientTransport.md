
##### Table of Contents

# Class StdioClientTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a [IClientTransport](ModelContextProtocol.Client.IClientTransport.html) implemented via "stdio" (standard input/output).

```
public sealed class StdioClientTransport : IClientTransport
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    StdioClientTransport

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

This transport launches an external process and communicates with it through standard input and output streams.
It's used to connect to MCP servers launched and hosted in child processes.

The transport manages the entire lifecycle of the process: starting it with specified command-line arguments
and environment variables, handling output, and properly terminating the process when the transport is closed.

## Constructors

### StdioClientTransport(StdioClientTransportOptions, ILoggerFactory?)

Initializes a new instance of the [StdioClientTransport](ModelContextProtocol.Client.StdioClientTransport.html) class.

```
public StdioClientTransport(StdioClientTransportOptions options, ILoggerFactory? loggerFactory = null)
```

#### Parameters

`options` [StdioClientTransportOptions](ModelContextProtocol.Client.StdioClientTransportOptions.html)
:   Configuration options for the transport, including the command to execute, arguments, working directory, and environment variables.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   A logger factory for creating loggers used for diagnostic output during transport operations.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `options` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

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



