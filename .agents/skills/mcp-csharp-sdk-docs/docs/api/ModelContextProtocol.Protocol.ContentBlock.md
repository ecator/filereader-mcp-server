
##### Table of Contents

# Class ContentBlock

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents content within the Model Context Protocol (MCP).

```
[JsonConverter(typeof(ContentBlock.Converter))]
public abstract class ContentBlock
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ContentBlock

Derived
:   [AudioContentBlock](ModelContextProtocol.Protocol.AudioContentBlock.html)

    [EmbeddedResourceBlock](ModelContextProtocol.Protocol.EmbeddedResourceBlock.html)

    [ImageContentBlock](ModelContextProtocol.Protocol.ImageContentBlock.html)

    [ResourceLinkBlock](ModelContextProtocol.Protocol.ResourceLinkBlock.html)

    [TextContentBlock](ModelContextProtocol.Protocol.TextContentBlock.html)

    [ToolResultContentBlock](ModelContextProtocol.Protocol.ToolResultContentBlock.html)

    [ToolUseContentBlock](ModelContextProtocol.Protocol.ToolUseContentBlock.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToAIContent(ContentBlock, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ContentBlock_System_Text_Json_JsonSerializerOptions_)

## Remarks

The [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) class is a fundamental type in the MCP that can represent different forms of content
based on the [Type](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Type) property. Derived types like [TextContentBlock](ModelContextProtocol.Protocol.TextContentBlock.html), [ImageContentBlock](ModelContextProtocol.Protocol.ImageContentBlock.html),
and [EmbeddedResourceBlock](ModelContextProtocol.Protocol.EmbeddedResourceBlock.html) provide the type-specific content.

This class is used throughout the MCP for representing content in messages, tool responses,
and other communication between clients and servers.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for more details.

## Properties

### Annotations

Gets or sets optional annotations for the content.

```
[JsonPropertyName("annotations")]
public Annotations? Annotations { get; set; }
```

#### Property Value

[Annotations](ModelContextProtocol.Protocol.Annotations.html)

#### Remarks

These annotations can be used to specify the intended audience ([User](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_User), [Assistant](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_Assistant), or both)
and the priority level of the content. Clients can use this information to filter or prioritize content for different roles.

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

### Type

When overridden in a derived class, gets the type of content.

```
[JsonPropertyName("type")]
public abstract string Type { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The type of content. Valid values include "image", "audio", "text", "resource", "resource\_link", "tool\_use", and "tool\_result".

#### Remarks

This value determines the structure of the content object.




