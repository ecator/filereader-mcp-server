
##### Table of Contents

# Class Resource

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a known resource that the server is capable of reading.

```
public sealed class Resource : IBaseMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Resource

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

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Annotations

Gets or sets optional annotations for the resource.

```
[JsonPropertyName("annotations")]
public Annotations? Annotations { get; set; }
```

#### Property Value

[Annotations](ModelContextProtocol.Protocol.Annotations.html)

#### Remarks

These annotations can be used to specify the intended audience ([User](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_User), [Assistant](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_Assistant), or both)
and the priority level of the resource. Clients can use this information to filter or prioritize resources for different roles.

### Description

Gets or sets a description of what this resource represents.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This can be used by clients to improve the LLM's understanding of available resources. It can be thought of like a \"hint\" to the model.

The description should provide clear context about the resource's content, format, and purpose.
This helps AI models make better decisions about when to access or reference the resource.

Client applications can also use this description for display purposes in user interfaces
or to help users understand the available resources.

### Icons

Gets or sets an optional list of icons for this resource.

```
[JsonPropertyName("icons")]
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This can be used by clients to display the resource's icon in a user interface.

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
[JsonPropertyName("_meta")]
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

Implementations must not make assumptions about its contents.

### MimeType

Gets or sets the MIME type of this resource.

```
[JsonPropertyName("mimeType")]
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

[MimeType](ModelContextProtocol.Protocol.Resource.html#ModelContextProtocol_Protocol_Resource_MimeType) specifies the format of the resource content, helping clients to properly interpret and display the data.
Common MIME types include "text/plain" for plain text, "application/pdf" for PDF documents,
"image/png" for PNG images, and "application/json" for JSON data.

This property can be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the MIME type is unknown or not applicable for the resource.

### Name

Gets or sets the unique identifier for this item.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Size

Gets or sets the size of the raw resource content (before base64 encoding), in bytes, if known.

```
[JsonPropertyName("size")]
public long? Size { get; set; }
```

#### Property Value

[long](https://learn.microsoft.com/dotnet/api/system.int64)?

#### Remarks

This can be used by applications to display file sizes and estimate context window usage.

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

### Uri

Gets or sets the URI of this resource.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




