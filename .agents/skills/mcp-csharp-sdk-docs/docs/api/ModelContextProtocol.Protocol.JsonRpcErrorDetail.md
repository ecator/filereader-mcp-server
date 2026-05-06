
##### Table of Contents

# Class JsonRpcErrorDetail

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents detailed error information for JSON-RPC error responses.

```
public sealed class JsonRpcErrorDetail
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    JsonRpcErrorDetail

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class is used as part of the [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html) message to provide structured
error information when a request cannot be fulfilled. The JSON-RPC 2.0 specification defines
a standard format for error responses that includes a numeric code, a human-readable message,
and optional additional data.

## Properties

### Code

Gets or sets an integer error code according to the JSON-RPC specification.

```
[JsonPropertyName("code")]
public required int Code { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)

### Data

Gets or sets optional additional error data.

```
[JsonPropertyName("data")]
public object? Data { get; set; }
```

#### Property Value

[object](https://learn.microsoft.com/dotnet/api/system.object)

#### Remarks

This property can contain any additional information that might help the client
understand or resolve the error. Common examples include validation errors,
stack traces (in development environments), or contextual information about
the error condition.

### Message

Gets or sets a short description of the error.

```
[JsonPropertyName("message")]
public required string Message { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description is expected to be a brief, human-readable explanation of what went wrong.
For standard error codes, it's recommended to use the descriptions defined
in the JSON-RPC 2.0 specification.




