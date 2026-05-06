
##### Table of Contents

# Class SamplingMessage

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a message issued to or received from an LLM API within the Model Context Protocol.

```
public sealed class SamplingMessage
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    SamplingMessage

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

A [SamplingMessage](ModelContextProtocol.Protocol.SamplingMessage.html) encapsulates content sent to or received from AI models in the Model Context Protocol.
The message has a role ([User](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_User) or [Assistant](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_Assistant)) and content which can be text, images,
audio, tool uses, or tool results.

[SamplingMessage](ModelContextProtocol.Protocol.SamplingMessage.html) objects are typically used in collections within [CreateMessageRequestParams](ModelContextProtocol.Protocol.CreateMessageRequestParams.html)
to represent prompts or queries for LLM sampling. They form the core data structure for text generation requests
within the Model Context Protocol.

If content contains any [ToolResultContentBlock](ModelContextProtocol.Protocol.ToolResultContentBlock.html), then all content items
must be [ToolResultContentBlock](ModelContextProtocol.Protocol.ToolResultContentBlock.html). Tool results cannot be mixed with text, image, or
audio content in the same message.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Content

Gets or sets the content of the message.

```
[JsonPropertyName("content")]
[JsonConverter(typeof(SingleItemOrListConverter<ContentBlock>))]
public required IList<ContentBlock> Content { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)>

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

### Role

Gets or sets the role of the message sender.

```
[JsonPropertyName("role")]
public Role Role { get; set; }
```

#### Property Value

[Role](ModelContextProtocol.Protocol.Role.html)




