
##### Table of Contents

# Class JsonRpcRequest

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a request message in the JSON-RPC protocol.

```
public sealed class JsonRpcRequest : JsonRpcMessageWithId
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)

    [JsonRpcMessageWithId](ModelContextProtocol.Protocol.JsonRpcMessageWithId.html)

    JsonRpcRequest

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

Requests are messages that require a response from the receiver. Each request includes a unique ID
that will be included in the corresponding response message (either a success response or an error).

The receiver of a request message is expected to execute the specified method with the provided parameters
and return either a [JsonRpcResponse](ModelContextProtocol.Protocol.JsonRpcResponse.html) with the result, or a [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html)
if the method execution fails.

## Properties

### Method

Gets or sets the name of the method to invoke.

```
[JsonPropertyName("method")]
public required string Method { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Params

Gets or sets optional parameters for the method.

```
[JsonPropertyName("params")]
public JsonNode? Params { get; set; }
```

#### Property Value

[JsonNode](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonnode)




