
##### Table of Contents

# Class ResumeClientSessionOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides the metadata captured from a previous MCP client session that is required to resume it.

```
public sealed class ResumeClientSessionOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ResumeClientSessionOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### NegotiatedProtocolVersion

Gets or sets the protocol version that was negotiated with the server.

```
public string? NegotiatedProtocolVersion { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ServerCapabilities

Gets or sets the server capabilities that were negotiated during the original session initialization.

```
public required ServerCapabilities ServerCapabilities { get; set; }
```

#### Property Value

[ServerCapabilities](ModelContextProtocol.Protocol.ServerCapabilities.html)

### ServerInfo

Gets or sets the server implementation metadata that identifies the connected MCP server.

```
public required Implementation ServerInfo { get; set; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

### ServerInstructions

Gets or sets any instructions previously supplied by the server.

```
public string? ServerInstructions { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




