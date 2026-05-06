
##### Table of Contents

# Class StdioServerTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [ITransport](ModelContextProtocol.Protocol.ITransport.html) implemented via "stdio" (standard input/output).

```
public sealed class StdioServerTransport : StreamServerTransport, ITransport, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [TransportBase](ModelContextProtocol.Protocol.TransportBase.html)

    [StreamServerTransport](ModelContextProtocol.Server.StreamServerTransport.html)

    StdioServerTransport

Implements
:   [ITransport](ModelContextProtocol.Protocol.ITransport.html)

    [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Inherited Members
:   [StreamServerTransport.SendMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.StreamServerTransport.html#ModelContextProtocol_Server_StreamServerTransport_SendMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_)

    [StreamServerTransport.DisposeAsync()](ModelContextProtocol.Server.StreamServerTransport.html#ModelContextProtocol_Server_StreamServerTransport_DisposeAsync)

    [TransportBase.SessionId](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_SessionId)

    [TransportBase.IsConnected](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_IsConnected)

    [TransportBase.MessageReader](ModelContextProtocol.Protocol.TransportBase.html#ModelContextProtocol_Protocol_TransportBase_MessageReader)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### StdioServerTransport(McpServerOptions, ILoggerFactory?)

Initializes a new instance of the [StdioServerTransport](ModelContextProtocol.Server.StdioServerTransport.html) class.

```
public StdioServerTransport(McpServerOptions serverOptions, ILoggerFactory? loggerFactory = null)
```

#### Parameters

`serverOptions` [McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html)
:   The server options.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   Optional logger factory used for logging employed by the transport.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `serverOptions` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) or contains a null name.

### StdioServerTransport(string, ILoggerFactory?)

Initializes a new instance of the [StdioServerTransport](ModelContextProtocol.Server.StdioServerTransport.html) class.

```
public StdioServerTransport(string serverName, ILoggerFactory? loggerFactory = null)
```

#### Parameters

`serverName` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the server.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   Optional logger factory used for logging employed by the transport.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `serverName` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




