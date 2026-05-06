
##### Table of Contents

# Class Argument

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an argument used in completion requests to provide context for auto-completion functionality.

```
public sealed class Argument
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Argument

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class is used when requesting completion suggestions for a particular field or parameter.
See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Name

Gets or sets the name of the argument being completed.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Value

Gets or sets the current partial text value for which completion suggestions are requested.

```
[JsonPropertyName("value")]
public required string Value { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This property represents the text that has been entered so far and for which completion
options should be generated.




