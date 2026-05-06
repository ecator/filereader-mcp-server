
##### Table of Contents

# Class ElicitResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the client's response to an elicitation request.

```
public sealed class ElicitResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    ElicitResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Action

Gets or sets the user action in response to the elicitation.

```
[JsonPropertyName("action")]
public string Action { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   Defaults to "cancel" if not explicitly set.

#### Remarks

* "accept"User submitted the form/confirmed the action
* "decline"User explicitly declined the action
* "cancel"User dismissed without making an explicit choice (default)

### Content

Gets or sets the submitted form data.

```
[JsonPropertyName("content")]
public IDictionary<string, JsonElement>? Content { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)>

#### Remarks

This value is typically omitted if the action is "cancel" or "decline".

Values in the dictionary should be of types [String](https://learn.microsoft.com/dotnet/api/system.text.json.jsonvaluekind#system-text-json-jsonvaluekind-string), [Number](https://learn.microsoft.com/dotnet/api/system.text.json.jsonvaluekind#system-text-json-jsonvaluekind-number),
[True](https://learn.microsoft.com/dotnet/api/system.text.json.jsonvaluekind#system-text-json-jsonvaluekind-true), [False](https://learn.microsoft.com/dotnet/api/system.text.json.jsonvaluekind#system-text-json-jsonvaluekind-false), or [Array](https://learn.microsoft.com/dotnet/api/system.text.json.jsonvaluekind#system-text-json-jsonvaluekind-array) (for multi-select enums).

### IsAccepted

Gets a value that indicates whether the elicitation was accepted by the user.

```
[JsonIgnore]
public bool IsAccepted { get; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

#### Remarks

If [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), it indicates that the elicitation request completed successfully and the value of [Content](ModelContextProtocol.Protocol.ElicitResult.html#ModelContextProtocol_Protocol_ElicitResult_Content) has been populated with a value.




