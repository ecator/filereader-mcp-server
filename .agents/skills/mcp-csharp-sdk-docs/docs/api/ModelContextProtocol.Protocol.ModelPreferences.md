
##### Table of Contents

# Class ModelPreferences

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a server's preferences for model selection, requested of the client during sampling.

```
public sealed class ModelPreferences
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ModelPreferences

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Because LLMs can vary along multiple dimensions, choosing the "best" model is
rarely straightforward. Different models excel in different areas—some are
faster but less capable, others are more capable but more expensive, and so
on. This class allows servers to express their priorities across multiple
dimensions to help clients make an appropriate selection for their use case.

These preferences are always advisory. The client may ignore them. It is also
up to the client to decide how to interpret these preferences and how to
balance them against other considerations.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### CostPriority

Gets or sets a value that indicates how much to prioritize cost when selecting a model.

```
[JsonPropertyName("costPriority")]
public float? CostPriority { get; set; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)?

#### Remarks

A value of 0 means cost is not important, while a value of 1 means cost is the most important factor.

### Hints

Gets or sets optional hints to use for model selection.

```
[JsonPropertyName("hints")]
public IList<ModelHint>? Hints { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ModelHint](ModelContextProtocol.Protocol.ModelHint.html)>

### IntelligencePriority

Gets or sets a value that indicates how much to prioritize intelligence and capabilities when selecting a model.

```
[JsonPropertyName("intelligencePriority")]
public float? IntelligencePriority { get; set; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)?

#### Remarks

A value of 0 means intelligence is not important, while a value of 1 means intelligence is the most important factor.

### SpeedPriority

Gets or sets a value that indicates how much to prioritize sampling speed (latency) when selecting a model.

```
[JsonPropertyName("speedPriority")]
public float? SpeedPriority { get; set; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)?

#### Remarks

A value of 0 means speed is not important, while a value of 1 means speed is the most important factor.




