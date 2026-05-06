
##### Table of Contents

# Class JsonRpcError

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an error response message in the JSON-RPC protocol.

```
public sealed class JsonRpcError : JsonRpcMessageWithId
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)

    [JsonRpcMessageWithId](ModelContextProtocol.Protocol.JsonRpcMessageWithId.html)

    JsonRpcError

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

Error responses are sent when a request cannot be fulfilled or encounters an error during processing.
Like successful responses, error messages include the same ID as the original request, allowing the
sender to match errors with their corresponding requests.

Each error response contains a structured error detail object with a numeric code, descriptive message,
and optional additional data to provide more context about the error.

## Properties

### Error

Gets or sets detailed error information for the failed request, containing an error code,
message, and optional additional data.

```
[JsonPropertyName("error")]
public required JsonRpcErrorDetail Error { get; set; }
```

#### Property Value

[JsonRpcErrorDetail](ModelContextProtocol.Protocol.JsonRpcErrorDetail.html)




