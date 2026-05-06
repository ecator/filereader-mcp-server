
##### Table of Contents

# Class McpClientOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides configuration options for creating [McpClient](ModelContextProtocol.Client.McpClient.html) instances.

```
public sealed class McpClientOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpClientOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

These options are typically passed to [CreateAsync(IClientTransport, McpClientOptions?, ILoggerFactory?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_CreateAsync_ModelContextProtocol_Client_IClientTransport_ModelContextProtocol_Client_McpClientOptions_Microsoft_Extensions_Logging_ILoggerFactory_System_Threading_CancellationToken_) when creating a client.
They define client capabilities, protocol version, and other client-specific settings.

## Properties

### Capabilities

Gets or sets the client capabilities to advertise to the server.

```
public ClientCapabilities? Capabilities { get; set; }
```

#### Property Value

[ClientCapabilities](ModelContextProtocol.Protocol.ClientCapabilities.html)

### ClientInfo

Gets or sets information about this client implementation, including its name and version.

```
public Implementation? ClientInfo { get; set; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

This information is sent to the server during initialization to identify the client.
It's often displayed in server logs and can be used for debugging and compatibility checks.

When not specified, information sourced from the current process is used.

### Handlers

Gets or sets the container of handlers used by the client for processing protocol messages.

```
public McpClientHandlers Handlers { get; set; }
```

#### Property Value

[McpClientHandlers](ModelContextProtocol.Client.McpClientHandlers.html)

### InitializationTimeout

Gets or sets a timeout for the client-server initialization handshake sequence.

```
public TimeSpan InitializationTimeout { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)
:   The timeout for the client-server initialization handshake sequence. The default value is 60 seconds.

#### Remarks

This timeout determines how long the client will wait for the server to respond during
the initialization protocol handshake. If the server doesn't respond within this timeframe,
an exception is thrown.

Setting an appropriate timeout prevents the client from hanging indefinitely when
connecting to unresponsive servers.

### ProtocolVersion

Gets or sets the protocol version to request from the server, using a date-based versioning scheme.

```
public string? ProtocolVersion { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The protocol version is a key part of the initialization handshake. The client and server must
agree on a compatible protocol version to communicate successfully.

If non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), this version will be sent to the server, and the handshake
will fail if the version in the server's response does not match this version.
If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the client will request the latest version supported by the server
but will allow any supported version that the server advertises in its response.

### SendTaskStatusNotifications

Gets or sets a value indicating whether the client should send task status notifications to the server.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public bool SendTaskStatusNotifications { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to send task status notifications; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) otherwise.
    The default is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

When enabled and a [TaskStore](ModelContextProtocol.Client.McpClientOptions.html#ModelContextProtocol_Client_McpClientOptions_TaskStore) is configured, the client will send optional
`notifications/tasks/status` notifications to inform the server of task state changes.
Servers MUST NOT rely on receiving these notifications and should continue polling via `tasks/get`.

### TaskStore

Gets or sets the task store for managing client-side tasks.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public IMcpTaskStore? TaskStore { get; set; }
```

#### Property Value

[IMcpTaskStore](ModelContextProtocol.IMcpTaskStore.html)

#### Remarks

When a task store is configured, the client will support task-augmented requests from the server.
This allows the server to request sampling or elicitation as tasks, which the client executes
asynchronously and allows the server to poll for status and results.

If not set, task-augmented requests will not be supported, and the client will not advertise
task capabilities to the server.




