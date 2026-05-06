
##### Table of Contents

# Class MessageContext

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a context container that provides access to the server and resources for processing a JSON-RPC message.

```
public class MessageContext
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    MessageContext

Derived
:   [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<TParams>

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [MessageContext](ModelContextProtocol.Server.MessageContext.html) encapsulates contextual information for handling any JSON-RPC message,
including requests, responses, notifications, and errors. This is the base class for
[RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html), which adds request-specific properties.

This type is typically received as a parameter in message filter delegates registered via
[Message](ModelContextProtocol.Server.McpServerFilters.html#ModelContextProtocol_Server_McpServerFilters_Message)'s [IncomingFilters](ModelContextProtocol.Server.McpMessageFilters.html#ModelContextProtocol_Server_McpMessageFilters_IncomingFilters) or
[OutgoingFilters](ModelContextProtocol.Server.McpMessageFilters.html#ModelContextProtocol_Server_McpMessageFilters_OutgoingFilters) collections.

## Constructors

### MessageContext(McpServer, JsonRpcMessage)

Initializes a new instance of the [MessageContext](ModelContextProtocol.Server.MessageContext.html) class with the specified server and JSON-RPC message.

```
public MessageContext(McpServer server, JsonRpcMessage jsonRpcMessage)
```

#### Parameters

`server` [McpServer](ModelContextProtocol.Server.McpServer.html)
:   The server with which this instance is associated.

`jsonRpcMessage` [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)
:   The JSON-RPC message associated with this context.

## Properties

### Items

Gets or sets a key/value collection that can be used to share data within the scope of this message.

```
public IDictionary<string, object?> Items { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

This dictionary is shared with the [Items](ModelContextProtocol.Protocol.JsonRpcMessageContext.html#ModelContextProtocol_Protocol_JsonRpcMessageContext_Items) property
on the underlying [JsonRpcMessage](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_JsonRpcMessage), ensuring that data set in message filters
flows through to request-specific filters and handlers.

### JsonRpcMessage

Gets the JSON-RPC message associated with this context.

```
public JsonRpcMessage JsonRpcMessage { get; set; }
```

#### Property Value

[JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)

#### Remarks

This property provides access to the complete JSON-RPC message,
including the method name (for requests/notifications), request ID (for requests/responses),
and associated transport and user information.

### Server

Gets or sets the server with which this instance is associated.

```
public McpServer Server { get; set; }
```

#### Property Value

[McpServer](ModelContextProtocol.Server.McpServer.html)

### Services

Gets or sets the services associated with this message.

```
public IServiceProvider? Services { get; set; }
```

#### Property Value

[IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)

#### Remarks

This provider might not be the same instance stored in [Services](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_Services)
if [ScopeRequests](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ScopeRequests) was true, in which case this
might be a scoped [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) derived from the server's
[Services](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_Services).

### User

Gets or sets the user associated with this message.

```
public ClaimsPrincipal? User { get; set; }
```

#### Property Value

[ClaimsPrincipal](https://learn.microsoft.com/dotnet/api/system.security.claims.claimsprincipal)

#### Remarks

This property is backed by the [User](ModelContextProtocol.Protocol.JsonRpcMessageContext.html#ModelContextProtocol_Protocol_JsonRpcMessageContext_User) property
on the underlying [JsonRpcMessage](ModelContextProtocol.Server.MessageContext.html#ModelContextProtocol_Server_MessageContext_JsonRpcMessage), ensuring that user information set in message filters
flows through to request-specific filters and handlers.




