
##### Table of Contents

# Class InitializeResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the result of a [Initialize](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_Initialize) request sent to the server during connection establishment.

```
public sealed class InitializeResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    InitializeResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [InitializeResult](ModelContextProtocol.Protocol.InitializeResult.html) is sent by the server in response to an [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html)
message from the client. It contains information about the server, its capabilities, and the protocol version
that will be used for the session.

After receiving this response, the client should send an [InitializedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_InitializedNotification)
notification to complete the handshake.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Capabilities

Gets or sets the server's capabilities.

```
[JsonPropertyName("capabilities")]
public required ServerCapabilities Capabilities { get; set; }
```

#### Property Value

[ServerCapabilities](ModelContextProtocol.Protocol.ServerCapabilities.html)

#### Remarks

This property defines the features the server supports, such as "tools", "prompts", "resources", or "logging",
and other protocol-specific functionality.

### Instructions

Gets or sets optional instructions for using the server and its features.

```
[JsonPropertyName("instructions")]
public string? Instructions { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

These instructions should focus on guidance that helps a model use the server effectively,
such as workflow tips, capability relationships, and server-specific conventions.
They should avoid repeating tool descriptions, prompt descriptions, or resource descriptions
that are already available through other protocol responses.

Client applications often use these instructions as system messages for LLM interactions
to provide context about available functionality.

### ProtocolVersion

Gets or sets the version of the Model Context Protocol that the server will use for this session.

```
[JsonPropertyName("protocolVersion")]
public required string ProtocolVersion { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This is the protocol version the server has agreed to use, which should match the client's
requested version. If there's a mismatch, the client should throw an exception to prevent
communication issues due to incompatible protocol versions.

The protocol uses a date-based versioning scheme in the format "YYYY-MM-DD".

See the [protocol specification](https://spec.modelcontextprotocol.io/specification/) for version details.

### ServerInfo

Gets or sets information about the server implementation, including its name and version.

```
[JsonPropertyName("serverInfo")]
public required Implementation ServerInfo { get; set; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

This information identifies the server during the initialization handshake.
Clients might use this information for logging, debugging, or compatibility checks.




