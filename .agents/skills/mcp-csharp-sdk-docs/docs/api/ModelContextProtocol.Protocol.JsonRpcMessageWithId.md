
##### Table of Contents

# Class JsonRpcMessageWithId

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a JSON-RPC message used in the Model Context Protocol (MCP) and that includes an ID.

```
public abstract class JsonRpcMessageWithId : JsonRpcMessage
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)

    JsonRpcMessageWithId

Derived
:   [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html)

    [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html)

    [JsonRpcResponse](ModelContextProtocol.Protocol.JsonRpcResponse.html)

Inherited Members
:   [JsonRpcMessage.JsonRpc](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_JsonRpc)

    [JsonRpcMessage.Context](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_Context)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

In the JSON-RPC protocol, messages with an ID require a response from the receiver.
This includes request messages (which expect a matching response) and response messages
(which include the ID of the original request they're responding to).
The ID is used to correlate requests with their responses, allowing asynchronous
communication where multiple requests can be sent without waiting for responses.

## Properties

### Id

Gets or sets the message identifier.

```
[JsonPropertyName("id")]
public RequestId Id { get; set; }
```

#### Property Value

[RequestId](ModelContextProtocol.Protocol.RequestId.html)

#### Remarks

Each ID is expected to be unique within the context of a given session.




