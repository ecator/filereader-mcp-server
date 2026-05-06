
##### Table of Contents

# Class ElicitRequestParams.EnumSchemaOption

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a single option in a titled enum schema with a constant value and display title.

```
public sealed class ElicitRequestParams.EnumSchemaOption
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ElicitRequestParams.EnumSchemaOption

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Const

Gets or sets the constant value for this option.

```
[JsonPropertyName("const")]
public required string Const { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Title

Gets or sets the display title for this option.

```
[JsonPropertyName("title")]
public required string Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




