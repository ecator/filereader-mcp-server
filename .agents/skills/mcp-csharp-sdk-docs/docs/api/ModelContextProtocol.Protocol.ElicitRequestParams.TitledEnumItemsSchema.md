
##### Table of Contents

# Class ElicitRequestParams.TitledEnumItemsSchema

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the items schema for titled multi-select enum arrays.

```
public sealed class ElicitRequestParams.TitledEnumItemsSchema
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ElicitRequestParams.TitledEnumItemsSchema

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### AnyOf

Gets or sets the list of enum options with constant values and display titles.

```
[JsonPropertyName("anyOf")]
public required IList<ElicitRequestParams.EnumSchemaOption> AnyOf { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[EnumSchemaOption](ModelContextProtocol.Protocol.ElicitRequestParams.EnumSchemaOption.html)>




