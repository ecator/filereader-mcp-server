
##### Table of Contents

# Class GetPromptResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a server's response to a [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) request from the client.

```
public sealed class GetPromptResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    GetPromptResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToChatMessages(GetPromptResult)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToChatMessages_ModelContextProtocol_Protocol_GetPromptResult_)

## Remarks

For integration with AI client libraries, [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) can be converted to
a collection of Microsoft.Extensions.AI.ChatMessage objects using the [ToChatMessages(GetPromptResult)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToChatMessages_ModelContextProtocol_Protocol_GetPromptResult_) extension method.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Description

Gets or sets an optional description for the prompt.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description provides contextual information about the prompt's purpose and use cases.
It helps developers understand what the prompt is designed for and how it should be used.

When returned from a server in response to a [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) request,
this description can be used by client applications to provide context about the prompt or to
display in user interfaces.

### Messages

Gets or sets the prompt that the server offers.

```
[JsonPropertyName("messages")]
public IList<PromptMessage> Messages { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html)>




