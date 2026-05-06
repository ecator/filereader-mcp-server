
##### Table of Contents

# Class JsonRpcMessage

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents any JSON-RPC message used in the Model Context Protocol (MCP).

```
[JsonConverter(typeof(JsonRpcMessage.Converter))]
public abstract class JsonRpcMessage
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    JsonRpcMessage

Derived
:   [JsonRpcMessageWithId](ModelContextProtocol.Protocol.JsonRpcMessageWithId.html)

    [JsonRpcNotification](ModelContextProtocol.Protocol.JsonRpcNotification.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This interface serves as the foundation for all message types in the JSON-RPC 2.0 protocol
used by MCP, including requests, responses, notifications, and errors. JSON-RPC is a stateless,
lightweight remote procedure call (RPC) protocol that uses JSON as its data format.

## Properties

### Context

Gets or sets the contextual information for this JSON-RPC message.

```
[JsonIgnore]
public JsonRpcMessageContext? Context { get; set; }
```

#### Property Value

[JsonRpcMessageContext](ModelContextProtocol.Protocol.JsonRpcMessageContext.html)

#### Remarks

This property contains transport-specific and runtime context information that accompanies
JSON-RPC messages but is not serialized as part of the JSON-RPC payload. This includes
transport references, execution context, and authenticated user information.

This property should only be set when implementing a custom [ITransport](ModelContextProtocol.Protocol.ITransport.html)
that needs to pass additional per-message context or to pass a [User](ModelContextProtocol.Protocol.JsonRpcMessageContext.html#ModelContextProtocol_Protocol_JsonRpcMessageContext_User)
to [HandlePostRequestAsync(JsonRpcMessage, Stream, CancellationToken)](ModelContextProtocol.Server.StreamableHttpServerTransport.html#ModelContextProtocol_Server_StreamableHttpServerTransport_HandlePostRequestAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_IO_Stream_System_Threading_CancellationToken_)
or [OnMessageReceivedAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.Server.SseResponseStreamTransport.html#ModelContextProtocol_Server_SseResponseStreamTransport_OnMessageReceivedAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_).

### JsonRpc

Gets or sets the JSON-RPC protocol version used.

```
[JsonPropertyName("jsonrpc")]
public string JsonRpc { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




