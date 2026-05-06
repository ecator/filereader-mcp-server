
##### Table of Contents

# Class Implementation

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides the name and version of an MCP implementation.

```
public sealed class Implementation : IBaseMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Implementation

Implements
:   [IBaseMetadata](ModelContextProtocol.Protocol.IBaseMetadata.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [Implementation](ModelContextProtocol.Protocol.Implementation.html) class is used to identify MCP clients and servers during the initialization handshake.
It provides version and name information that can be used for compatibility checks, logging, and debugging.

Both clients and servers provide this information during connection establishment.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Description

Gets or sets an optional description of the implementation.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description helps users and developers understand what the implementation provides
and its purpose. It should clearly explain the functionality and capabilities offered.

The description is typically used in documentation, UI displays, and for providing context
to users about the server or client they are interacting with.

### Icons

Gets or sets an optional list of icons for this implementation.

```
[JsonPropertyName("icons")]
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This value can be used by clients to display the implementation's icon in a user interface.

### Name

Gets or sets the unique identifier for this item.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Title

Gets or sets a title.

```
[JsonPropertyName("title")]
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This is intended for UI and end-user contexts. It is optimized to be human-readable and easily understood,
even by those unfamiliar with domain-specific terminology.
If not provided, [Name](ModelContextProtocol.Protocol.IBaseMetadata.html#ModelContextProtocol_Protocol_IBaseMetadata_Name) can be used for display (except for tools, where [Title](ModelContextProtocol.Protocol.ToolAnnotations.html#ModelContextProtocol_Protocol_ToolAnnotations_Title), if present,
should be given precedence over using [Name](ModelContextProtocol.Protocol.IBaseMetadata.html#ModelContextProtocol_Protocol_IBaseMetadata_Name)).

### Version

Gets or sets the version of the implementation.

```
[JsonPropertyName("version")]
public required string Version { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The version is used during client-server handshake to identify implementation versions,
which can be important for troubleshooting compatibility issues or when reporting bugs.

### WebsiteUrl

Gets or sets an optional URL of the website for this implementation.

```
[JsonPropertyName("websiteUrl")]
public string? WebsiteUrl { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This URL can be used by clients to link to documentation or more information about the implementation.

Consumers SHOULD take steps to ensure URLs are from the same domain as the client/server
or a trusted domain to prevent security issues.




