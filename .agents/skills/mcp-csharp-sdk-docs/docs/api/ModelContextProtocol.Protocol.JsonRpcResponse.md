
##### Table of Contents

# Class JsonRpcResponse

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a successful response message in the JSON-RPC protocol.

```
public sealed class JsonRpcResponse : JsonRpcMessageWithId
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)

    [JsonRpcMessageWithId](ModelContextProtocol.Protocol.JsonRpcMessageWithId.html)

    JsonRpcResponse

Inherited Members
:   [JsonRpcMessageWithId.Id](ModelContextProtocol.Protocol.JsonRpcMessageWithId.html#ModelContextProtocol_Protocol_JsonRpcMessageWithId_Id)

    [JsonRpcMessage.JsonRpc](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_JsonRpc)

    [JsonRpcMessage.Context](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_Context)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Response messages are sent in reply to a request message and contain the result of the method execution.
Each response includes the same ID as the original request, allowing the sender to match responses
with their corresponding requests.

This class represents a successful response with a result. For error responses, see [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html).

## Properties

### Result

Gets or sets the result of the method invocation.

```
[JsonPropertyName("result")]
public required JsonNode? Result { get; set; }
```

#### Property Value

[JsonNode](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonnode)

#### Remarks

This property contains the result data returned by the server in response to the JSON-RPC method request.




