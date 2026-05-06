
##### Table of Contents

# Class TextResourceContents

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents text-based contents of a resource in the Model Context Protocol.

```
public sealed class TextResourceContents : ResourceContents
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html)

    TextResourceContents

Inherited Members
:   [ResourceContents.Uri](ModelContextProtocol.Protocol.ResourceContents.html#ModelContextProtocol_Protocol_ResourceContents_Uri)

    [ResourceContents.MimeType](ModelContextProtocol.Protocol.ResourceContents.html#ModelContextProtocol_Protocol_ResourceContents_MimeType)

    [ResourceContents.Meta](ModelContextProtocol.Protocol.ResourceContents.html#ModelContextProtocol_Protocol_ResourceContents_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

Extension Methods
:   [AIContentExtensions.ToAIContent(ResourceContents)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ResourceContents_)

## Remarks

[TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html) is used when textual data needs to be exchanged through
the Model Context Protocol. The text is stored directly in the [Text](ModelContextProtocol.Protocol.TextResourceContents.html#ModelContextProtocol_Protocol_TextResourceContents_Text) property.

This class inherits from [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html), which also has a sibling implementation
[BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) for binary resources. When working with resources, the
appropriate type is chosen based on the nature of the content.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for more details.

## Properties

### Text

Gets or sets the text of the item.

```
[JsonPropertyName("text")]
public required string Text { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




