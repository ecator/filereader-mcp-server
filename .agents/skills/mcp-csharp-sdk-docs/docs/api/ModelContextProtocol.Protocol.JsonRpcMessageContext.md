
##### Table of Contents

# Class JsonRpcMessageContext

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Contains contextual information for JSON-RPC messages that is not part of the JSON-RPC protocol specification.

```
public sealed class JsonRpcMessageContext
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    JsonRpcMessageContext

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class holds transport-specific and runtime context information that accompanies JSON-RPC messages
but is not serialized as part of the JSON-RPC payload. This includes transport references, execution context,
and authenticated user information.

## Properties

### ExecutionContext

Gets or sets the [ExecutionContext](ModelContextProtocol.Protocol.JsonRpcMessageContext.html#ModelContextProtocol_Protocol_JsonRpcMessageContext_ExecutionContext) that should be used to run any handlers.

```
public ExecutionContext? ExecutionContext { get; set; }
```

#### Property Value

[ExecutionContext](https://learn.microsoft.com/dotnet/api/system.threading.executioncontext)

#### Remarks

This property is used to support the Streamable HTTP transport in its default stateful mode. In this mode,
the [McpServer](ModelContextProtocol.Server.McpServer.html) outlives the initial HTTP request context it was created on, and new
JSON-RPC messages can originate from future HTTP requests. This behavior allows the transport to flow the
context with the JSON-RPC message. This is particularly useful for enabling IHttpContextAccessor
in tool calls.

### Items

Gets or sets a key/value collection that can be used to share data within the scope of this message.

```
public IDictionary<string, object?>? Items { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

This property allows data to be flowed throughout the message processing pipeline,
including from incoming message filters to request-specific filters and handlers.

When creating a [MessageContext](ModelContextProtocol.Server.MessageContext.html) or [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) for server-side
processing, the Items dictionary from this context will be used, ensuring data set in message filters
is available in request filters and handlers.

### RelatedTransport

Gets or sets the transport the [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html) was received on or should be sent over.

```
public ITransport? RelatedTransport { get; set; }
```

#### Property Value

[ITransport](ModelContextProtocol.Protocol.ITransport.html)

#### Remarks

This property is used to support the Streamable HTTP transport where the specification states that the server
SHOULD include JSON-RPC responses in the HTTP response body for the POST request containing
the corresponding JSON-RPC request. It can be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) for other transports.

### User

Gets or sets the authenticated user associated with this JSON-RPC message.

```
public ClaimsPrincipal? User { get; set; }
```

#### Property Value

[ClaimsPrincipal](https://learn.microsoft.com/dotnet/api/system.security.claims.claimsprincipal)

#### Remarks

This property contains the [ClaimsPrincipal](https://learn.microsoft.com/dotnet/api/system.security.claims.claimsprincipal) representing the authenticated user
who initiated this JSON-RPC message. This enables request handlers to access user identity
and authorization information without requiring dependency on HTTP context accessors
or other HTTP-specific abstractions.

The user information is automatically populated by the transport layer when processing
incoming HTTP requests in ASP.NET Core scenarios. For other transport types or scenarios
where user authentication is not applicable, this property can be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

This property is particularly useful in the Streamable HTTP transport where JSON-RPC messages
might outlive the original HTTP request context, allowing user identity to be preserved
throughout the message processing pipeline.




