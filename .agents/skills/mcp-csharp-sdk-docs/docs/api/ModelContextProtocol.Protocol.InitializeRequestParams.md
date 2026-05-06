
##### Table of Contents

# Class InitializeRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [Initialize](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_Initialize) request sent by a client to a server during the protocol handshake.

```
public sealed class InitializeRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    InitializeRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html) is the first message sent in the Model Context Protocol
communication flow. It establishes the connection between client and server, negotiates the protocol
version, and declares the client's capabilities.

After sending this request, the client should wait for an [InitializeResult](ModelContextProtocol.Protocol.InitializeResult.html) response
before sending an [InitializedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_InitializedNotification) notification to complete the handshake.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Capabilities

Gets or sets the client's capabilities.

```
[JsonPropertyName("capabilities")]
public required ClientCapabilities Capabilities { get; set; }
```

#### Property Value

[ClientCapabilities](ModelContextProtocol.Protocol.ClientCapabilities.html)

#### Remarks

Capabilities define the features the client supports, such as "sampling" or "roots".

### ClientInfo

Gets or sets information about the client implementation, including its name and version.

```
[JsonPropertyName("clientInfo")]
public required Implementation ClientInfo { get; set; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

This information is required during the initialization handshake to identify the client.
Servers might use this information for logging, debugging, or compatibility checks.

### ProtocolVersion

Gets or sets the version of the Model Context Protocol that the client wants to use.

```
[JsonPropertyName("protocolVersion")]
public required string ProtocolVersion { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Protocol version is specified using a date-based versioning scheme in the format "YYYY-MM-DD".
The client and server must agree on a protocol version to communicate successfully.

During initialization, the server will check if it supports this requested version. If there's a
mismatch, the server will reject the connection with a version mismatch error.

See the [protocol specification](https://spec.modelcontextprotocol.io/specification/) for version details.




