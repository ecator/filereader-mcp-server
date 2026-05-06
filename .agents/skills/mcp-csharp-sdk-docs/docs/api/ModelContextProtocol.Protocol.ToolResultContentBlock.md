
##### Table of Contents

# Class ToolResultContentBlock

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the result of a tool use, provided by the user back to the assistant.

```
public sealed class ToolResultContentBlock : ContentBlock
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)

    ToolResultContentBlock

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

## Properties

### Content

Gets or sets the unstructured result content of the tool use.

```
[JsonPropertyName("content")]
public required IList<ContentBlock> Content { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)>

#### Remarks

This value has the same format as CallToolResult.Content and can include text, images,
audio, resource links, and embedded resources.

### IsError

Gets or sets a value that indicates whether the tool use resulted in an error.

```
[JsonPropertyName("isError")]
public bool? IsError { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool use resulted in an error; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it succeeded. The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

If [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the content typically describes the error that occurred.

### StructuredContent

Gets or sets an optional structured result object.

```
[JsonPropertyName("structuredContent")]
public JsonElement? StructuredContent { get; set; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)?

#### Remarks

If the tool defined an outputSchema, this object should conform to that schema.

### ToolUseId

Gets or sets the ID of the tool use this result corresponds to.

```
[JsonPropertyName("toolUseId")]
public required string ToolUseId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value must match the ID from a previous [ToolUseContentBlock](ModelContextProtocol.Protocol.ToolUseContentBlock.html).

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




