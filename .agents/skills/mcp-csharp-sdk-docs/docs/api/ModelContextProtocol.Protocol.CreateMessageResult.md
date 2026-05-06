
##### Table of Contents

# Class CreateMessageResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a client's response to a [SamplingCreateMessage](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_SamplingCreateMessage) from the server.

```
public sealed class CreateMessageResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    CreateMessageResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Content

Gets or sets the content of the assistant's response.

```
[JsonPropertyName("content")]
[JsonConverter(typeof(SingleItemOrListConverter<ContentBlock>))]
public required IList<ContentBlock> Content { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)>

#### Remarks

In the corresponding JSON, this might be a single content block or an array of content blocks.

### Model

Gets or sets the name of the model that generated the message.

```
[JsonPropertyName("model")]
public required string Model { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value should contain the specific model identifier such as "claude-3-5-sonnet-20241022" or "o3-mini".

This property allows the server to know which model was used to generate the response,
enabling appropriate handling based on the model's capabilities and characteristics.

### Role

Gets or sets the role of the user who generated the message.

```
[JsonPropertyName("role")]
public Role Role { get; set; }
```

#### Property Value

[Role](ModelContextProtocol.Protocol.Role.html)
:   The role of the user who generated the message. The default is [Assistant](ModelContextProtocol.Protocol.Role.html#ModelContextProtocol_Protocol_Role_Assistant).

### StopReason

Gets or sets the reason why message generation (sampling) stopped, if known.

```
[JsonPropertyName("stopReason")]
public string? StopReason { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Standard values include:

* endTurnThe participant is yielding the conversation to the other party.
* maxTokensThe response was truncated due to reaching token limits.
* stopSequenceA specific stop sequence was encountered during generation.
* toolUseThe model wants to use one or more tools.

This field is an open string to allow for provider-specific stop reasons.




