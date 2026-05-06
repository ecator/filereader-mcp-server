
##### Table of Contents

# Class ElicitRequestParams.UntitledEnumItemsSchema

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the items schema for untitled multi-select enum arrays.

```
public sealed class ElicitRequestParams.UntitledEnumItemsSchema
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ElicitRequestParams.UntitledEnumItemsSchema

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Enum

Gets or sets the list of allowed string values.

```
[JsonPropertyName("enum")]
public required IList<string> Enum { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### Type

Gets or sets the type of the items.

```
[JsonPropertyName("type")]
public string Type { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




