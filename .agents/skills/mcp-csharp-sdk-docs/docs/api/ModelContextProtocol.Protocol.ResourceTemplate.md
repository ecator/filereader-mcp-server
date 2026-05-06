
##### Table of Contents

# Class ResourceTemplate

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a known resource template that the server is capable of reading.

```
public sealed class ResourceTemplate : IBaseMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ResourceTemplate

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

Resource templates provide metadata about resources available on the server,
including how to construct URIs for those resources.

## Properties

### Annotations

Gets or sets optional annotations for the resource template.

```
[JsonPropertyName("annotations")]
public Annotations? Annotations { get; set; }
```

#### Property Value

[Annotations](ModelContextProtocol.Protocol.Annotations.html)

#### Remarks

These annotations can be used to specify the intended audience ([User](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_User), [Assistant](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_Assistant), or both)
and the priority level of the resource template. Clients can use this information to filter
or prioritize resource templates for different roles.

### Description

Gets or sets a description of what this resource template represents.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description helps clients understand the purpose and content of resources
that can be generated from this template. It can be used by client applications
to provide context about available resource types or to display in user interfaces.

For AI models, this description can serve as a hint about when and how to use
the resource template, enhancing the model's ability to generate appropriate URIs.

### Icons

Gets or sets an optional list of icons for this resource template.

```
[JsonPropertyName("icons")]
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This value can be used by clients to display the resource template's icon in a user interface.

### IsTemplated

Gets a value that indicates whether [UriTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html#ModelContextProtocol_Protocol_ResourceTemplate_UriTemplate) contains any template expressions.

```
[JsonIgnore]
public bool IsTemplated { get; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

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

Gets or sets the MIME type of this resource template, if known.

```
[JsonPropertyName("mimeType")]
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Specifies the expected format of resources that can be generated from this template.
This helps clients understand what type of content to expect when accessing resources
created using this template.

Common MIME types include "text/plain" for plain text, "application/pdf" for PDF documents,
"image/png" for PNG images, or "application/json" for JSON data.

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

### UriTemplate

Gets or sets the URI template (according to RFC 6570) that can be used to construct resource URIs.

```
[JsonPropertyName("uriTemplate")]
public required string UriTemplate { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### AsResource()

Converts the [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) into a [Resource](ModelContextProtocol.Protocol.Resource.html).

```
public Resource? AsResource()
```

#### Returns

[Resource](ModelContextProtocol.Protocol.Resource.html)
:   A [Resource](ModelContextProtocol.Protocol.Resource.html) if [IsTemplated](ModelContextProtocol.Protocol.ResourceTemplate.html#ModelContextProtocol_Protocol_ResourceTemplate_IsTemplated) is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool); otherwise, [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




