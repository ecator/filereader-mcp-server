
##### Table of Contents

# Interface IClientTransport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a transport mechanism for Model Context Protocol (MCP) client-to-server communication.

```
public interface IClientTransport
```

## Remarks

The [IClientTransport](ModelContextProtocol.Client.IClientTransport.html) interface abstracts the communication layer between MCP clients
and servers, allowing different transport protocols to be used interchangeably.

When creating an [McpClient](ModelContextProtocol.Client.McpClient.html), [CreateAsync(IClientTransport, McpClientOptions?, ILoggerFactory?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_CreateAsync_ModelContextProtocol_Client_IClientTransport_ModelContextProtocol_Client_McpClientOptions_Microsoft_Extensions_Logging_ILoggerFactory_System_Threading_CancellationToken_) is typically used, and is
provided with the [IClientTransport](ModelContextProtocol.Client.IClientTransport.html) based on expected server configuration.

## Properties

### Name

Gets a transport identifier, used for logging purposes.

```
string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### ConnectAsync(CancellationToken)

Asynchronously establishes a transport session with an MCP server and returns a transport for the duplex message stream.

```
Task<ITransport> ConnectAsync(CancellationToken cancellationToken = default)
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




