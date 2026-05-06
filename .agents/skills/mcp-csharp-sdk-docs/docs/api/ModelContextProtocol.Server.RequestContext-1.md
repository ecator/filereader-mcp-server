
##### Table of Contents

# Class RequestContext<TParams>

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a context container that provides access to the client request parameters and resources for the request.

```
public sealed class RequestContext<TParams> : MessageContext
```

#### Type Parameters

`TParams`
:   Type of the request parameters specific to each MCP operation.

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [MessageContext](ModelContextProtocol.Server.MessageContext.html)

    RequestContext<TParams>

Inherited Members
:   [MessageContext.Server](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_Server)

    [MessageContext.Items](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_Items)

    [MessageContext.Services](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_Services)

    [MessageContext.User](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_User)

    [MessageContext.JsonRpcMessage](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_JsonRpcMessage)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) encapsulates all contextual information for handling an MCP request.
This type is typically received as a parameter in handler delegates registered with IMcpServerBuilder,
and can be injected as parameters into [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)s.

## Constructors

### RequestContext(McpServer, JsonRpcRequest)

Initializes a new instance of the [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) class with the specified server and JSON-RPC request.

```
[Obsolete("Use the constructor overload that accepts a parameters argument.", DiagnosticId = "MCP9003", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcp9003")]
public RequestContext(McpServer server, JsonRpcRequest jsonRpcRequest)
```

#### Parameters

`server` [McpServer](ModelContextProtocol.Server.McpServer.html)
:   The server with which this instance is associated.

`jsonRpcRequest` [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html)
:   The JSON-RPC request associated with this context.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `server` or `jsonRpcRequest` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### RequestContext(McpServer, JsonRpcRequest, TParams)

Initializes a new instance of the [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) class with the specified server, JSON-RPC request, and request parameters.

```
public RequestContext(McpServer server, JsonRpcRequest jsonRpcRequest, TParams parameters)
```

#### Parameters

`server` [McpServer](ModelContextProtocol.Server.McpServer.html)
:   The server with which this instance is associated.

`jsonRpcRequest` [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html)
:   The JSON-RPC request associated with this context.

`parameters` TParams
:   The parameters associated with this request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `server` or `jsonRpcRequest` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### JsonRpcRequest

Gets the JSON-RPC request associated with this context.

```
public JsonRpcRequest JsonRpcRequest { get; set; }
```

#### Property Value

[JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html)

#### Remarks

This property provides access to the complete JSON-RPC request that initiated this handler invocation,
including the method name, parameters, request ID, and associated transport and user information.

### MatchedPrimitive

Gets or sets the primitive that matched the request.

```
public IMcpServerPrimitive? MatchedPrimitive { get; set; }
```

#### Property Value

[IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

### Params

Gets or sets the parameters associated with this request.

```
public TParams Params { get; set; }
```

#### Property Value

TParams

## Methods

### EnablePollingAsync(TimeSpan, CancellationToken)

Ends the current response and enables polling for updates from the server.

```
public ValueTask EnablePollingAsync(TimeSpan retryInterval, CancellationToken cancellationToken = default)
```

#### Parameters

`retryInterval` [TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)
:   The interval at which the client should poll for updates.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The cancellation token.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask) that completes when polling has been enabled.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   Thrown when the transport does not support polling.




