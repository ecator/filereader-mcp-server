
##### Table of Contents

# Class EmbeddedResourceBlock

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the contents of a resource, embedded into a prompt or tool call result.

```
public sealed class EmbeddedResourceBlock : ContentBlock
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)

    EmbeddedResourceBlock

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

It is up to the client how best to render embedded resources for the benefit of the LLM and/or the user.

## Properties

### Resource

Gets or sets the resource content of the message when [Type](ModelContextProtocol.Protocol.EmbeddedResourceBlock.html#ModelContextProtocol_Protocol_EmbeddedResourceBlock_Type) is "resource".

```
[JsonPropertyName("resource")]
public required ResourceContents Resource { get; set; }
```

#### Property Value

[ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html)

#### Remarks

Resources can be either text-based ([TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html)) or
binary ([BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html)), allowing for flexible data representation.
Each resource has a URI that can be used for identification and retrieval.

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




