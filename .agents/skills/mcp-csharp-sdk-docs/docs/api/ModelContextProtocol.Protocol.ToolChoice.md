
##### Table of Contents

# Class ToolChoice

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Controls tool selection behavior for sampling requests.

```
public sealed class ToolChoice
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ToolChoice

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Mode

Gets or sets the mode that controls which tools the model can call.

```
[JsonPropertyName("mode")]
public string? Mode { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

* "auto"Model decides whether to call tools (default)
* "required"Model must call at least one tool
* "none"Model must not call any tools




