
##### Table of Contents

# Class HttpClientTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [IClientTransport](ModelContextProtocol.Client.IClientTransport.html) over HTTP using the Server-Sent Events (SSE) or Streamable HTTP protocol.

```
public sealed class HttpClientTransport : IClientTransport, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    HttpClientTransport

Implements
:   [IClientTransport](ModelContextProtocol.Client.IClientTransport.html)

    [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This transport connects to an MCP server over HTTP using SSE or Streamable HTTP,
allowing for real-time server-to-client communication with standard HTTP requests.
Unlike the [StdioClientTransport](ModelContextProtocol.Client.StdioClientTransport.html), this transport connects to an existing server
rather than launching a new process.

## Constructors

### HttpClientTransport(HttpClientTransportOptions, ILoggerFactory?)

Initializes a new instance of the [HttpClientTransport](ModelContextProtocol.Client.HttpClientTransport.html) class.

```
public HttpClientTransport(HttpClientTransportOptions transportOptions, ILoggerFactory? loggerFactory = null)
```

#### Parameters

`transportOptions` [HttpClientTransportOptions](ModelContextProtocol.Client.HttpClientTransportOptions.html)
:   The configuration options for the transport.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   The logger factory for creating loggers used for diagnostic output during transport operations.

### HttpClientTransport(HttpClientTransportOptions, HttpClient, ILoggerFactory?, bool)

Initializes a new instance of the [HttpClientTransport](ModelContextProtocol.Client.HttpClientTransport.html) class with a provided HTTP client.

```
public HttpClientTransport(HttpClientTransportOptions transportOptions, HttpClient httpClient, ILoggerFactory? loggerFactory = null, bool ownsHttpClient = false)
```

#### Parameters

`transportOptions` [HttpClientTransportOptions](ModelContextProtocol.Client.HttpClientTransportOptions.html)
:   The configuration options for the transport.

`httpClient` [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient)
:   The HTTP client instance used for requests.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   The logger factory for creating loggers used for diagnostic output during transport operations.

`ownsHttpClient` [bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to dispose of `httpClient` when the transport is disposed;
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the caller is retaining ownership of the `httpClient`'s lifetime.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `transportOptions` or `httpClient` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

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

### DisposeAsync()

Performs application-defined tasks associated with freeing, releasing, or
resetting unmanaged resources asynchronously.

```
public ValueTask DisposeAsync()
```

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A task that represents the asynchronous dispose operation.




