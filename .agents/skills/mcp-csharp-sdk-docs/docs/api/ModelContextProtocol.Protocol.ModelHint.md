
##### Table of Contents

# Class ModelHint

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides hints to use for model selection.

```
public sealed class ModelHint
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ModelHint

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

When multiple hints are specified in [Hints](ModelContextProtocol.Protocol.ModelPreferences.html#ModelContextProtocol_Protocol_ModelPreferences_Hints), they are evaluated in order,
with the first match taking precedence. Clients should prioritize these hints over numeric priorities.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Name

Gets or sets a hint for a model name.

```
[JsonPropertyName("name")]
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The specified string can be a partial or full model name. Clients can also
map hints to equivalent models from different providers. Clients make the final model
selection based on these preferences and their available models.




