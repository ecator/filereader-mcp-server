
##### Table of Contents

# Class ResourceLinkBlock

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a resource that the server is capable of reading, included in a prompt or tool call result.

```
public sealed class ResourceLinkBlock : ContentBlock
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)

    ResourceLinkBlock

Inherited Members
:   [ContentBlock.Annotations](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Annotations)

    [ContentBlock.Meta](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToAIContent(ContentBlock, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ContentBlock_System_Text_Json_JsonSerializerOptions_)

## Remarks

Resource links returned by tools are not guaranteed to appear in the results of `resources/list` requests.

## Properties

### Description

Gets or sets a description of what this resource represents.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description can be used by clients to improve the LLM's understanding of available resources. It can be thought of like a \"hint\" to the model.

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

### MimeType

Gets or sets the MIME type of this resource.

```
[JsonPropertyName("mimeType")]
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

[MimeType](ModelContextProtocol.Protocol.ResourceLinkBlock.html#ModelContextProtocol_Protocol_ResourceLinkBlock_MimeType) specifies the format of the resource content, helping clients to properly interpret and display the data.
Common MIME types include "text/plain" for plain text, "application/pdf" for PDF documents,
"image/png" for PNG images, and "application/json" for JSON data.

This property can be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the MIME type is unknown or not applicable for the resource.

### Name

Gets or sets a human-readable name for this resource.

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

This value can be used by applications to display file sizes and estimate context window usage.

### Title

Gets or sets a title for this resource.

```
[JsonPropertyName("title")]
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This is intended for UI and end-user contexts. It is optimized to be human-readable and easily understood,
even by those unfamiliar with domain-specific terminology.
If not provided, [Name](ModelContextProtocol.Protocol.ResourceLinkBlock.html#ModelContextProtocol_Protocol_ResourceLinkBlock_Name) can be used for display.

### Type

When overridden in a derived class, gets the type of content.

```
public override string Type { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The type of content. Valid values include "image", "audio", "text", "resource", "resource\_link", "tool\_use", and "tool\_result".

#### Remarks

This value determines the structure of the content object.

### Uri

Gets or sets the URI of this resource.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




