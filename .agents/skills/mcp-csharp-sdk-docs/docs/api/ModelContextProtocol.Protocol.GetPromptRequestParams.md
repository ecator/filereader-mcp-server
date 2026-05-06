
##### Table of Contents

# Class GetPromptRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) request from a client to get a prompt provided by a server.

```
public sealed class GetPromptRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    GetPromptRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The server will respond with a [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) containing the resulting prompt.
See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Arguments

Gets or sets arguments to use for templating the prompt when retrieving it from the server.

```
[JsonPropertyName("arguments")]
public IDictionary<string, JsonElement>? Arguments { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)>

#### Remarks

Typically, these arguments are used to replace placeholders in prompt templates. The keys in this dictionary
should match the names defined in the prompt's [Arguments](ModelContextProtocol.Protocol.Prompt.html#ModelContextProtocol_Protocol_Prompt_Arguments) list. However, the server can
choose to use these arguments in any way it deems appropriate to generate the prompt.

### Name

Gets or sets the name of the prompt.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




