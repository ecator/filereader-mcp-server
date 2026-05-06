
##### Table of Contents

# Class RequestOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a bag of optional parameters for use with MCP requests.

```
public sealed class RequestOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    RequestOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### RequestOptions()

Initializes a new instance of the [RequestOptions](ModelContextProtocol.RequestOptions.html) class.

```
public RequestOptions()
```

## Properties

### JsonSerializerOptions

Gets or sets a [JsonSerializerOptions](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_JsonSerializerOptions) to use for any serialization of arguments or results in the request.

```
public JsonSerializerOptions? JsonSerializerOptions { get; set; }
```

#### Property Value

[JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

### Meta

Gets or sets optional metadata to include as the "\_meta" property in a request.

```
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

Although progress tokens are propagated in MCP "\_meta" objects, the [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken)
property and the [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) property do not interact (setting [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta)
does not affect [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken), and the object returned from [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta)
is not impacted by the value of [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken)). To get the actual [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)
that contains state from both [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) and [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken), use the
[GetMetaForRequest()](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_GetMetaForRequest) method.

### ProgressToken

Gets or sets an optional progress token to use for tracking long-running operations.

```
public ProgressToken? ProgressToken { get; set; }
```

#### Property Value

[ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)?

#### Remarks

Although progress tokens are propagated in MCP "\_meta" objects, the [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken)
property and the [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) property do not interact (setting [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken)
does not affect [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta), and getting [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken) does not read from
[Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta)). To get the actual [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) that contains state from both
[Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) and [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken), use the [GetMetaForRequest()](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_GetMetaForRequest) method.

## Methods

### GetMetaForRequest()

Gets a [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) to use in requests for the "\_meta" property.

```
public JsonObject? GetMetaForRequest()
```

#### Returns

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)
:   A [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) suitable for use in requests for the "\_meta" property.

#### Remarks

Progress tokens are part of MCP's \_meta property. As such, if [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken)
is non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) but [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [GetMetaForRequest()](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_GetMetaForRequest) will
manufacture and return a new [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) instance containing the token. If both [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken)
and [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) are non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), a new clone of [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta) will be created and its
"progressToken" property overwritten with [ProgressToken](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_ProgressToken). Otherwise, [GetMetaForRequest()](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_GetMetaForRequest)
will just return [Meta](ModelContextProtocol.RequestOptions.html#ModelContextProtocol_RequestOptions_Meta).




