
##### Table of Contents

# Class ElicitRequestParams.TitledMultiSelectEnumSchema

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a schema for multiple-selection enumeration with display titles for each option.

```
public sealed class ElicitRequestParams.TitledMultiSelectEnumSchema : ElicitRequestParams.PrimitiveSchemaDefinition
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[PrimitiveSchemaDefinition](ModelContextProtocol.Protocol.ElicitRequestParams.PrimitiveSchemaDefinition.html)

    ElicitRequestParams.TitledMultiSelectEnumSchema

Inherited Members
:   [ElicitRequestParams.PrimitiveSchemaDefinition.Title](ModelContextProtocol.Protocol.ElicitRequestParams.PrimitiveSchemaDefinition.html#ModelContextProtocol_Protocol_ElicitRequestParams_PrimitiveSchemaDefinition_Title)

    [ElicitRequestParams.PrimitiveSchemaDefinition.Description](ModelContextProtocol.Protocol.ElicitRequestParams.PrimitiveSchemaDefinition.html#ModelContextProtocol_Protocol_ElicitRequestParams_PrimitiveSchemaDefinition_Description)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Default

Gets or sets the default values for the enum.

```
[JsonPropertyName("default")]
public IList<string>? Default { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### Items

Gets or sets the schema for items in the array.

```
[JsonPropertyName("items")]
public required ElicitRequestParams.TitledEnumItemsSchema Items { get; set; }
```

#### Property Value

[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[TitledEnumItemsSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledEnumItemsSchema.html)

### MaxItems

Gets or sets the maximum number of items that can be selected.

```
[JsonPropertyName("maxItems")]
public int? MaxItems { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

### MinItems

Gets or sets the minimum number of items that can be selected.

```
[JsonPropertyName("minItems")]
public int? MinItems { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

### Type

Gets or sets the type of the schema.

```
[JsonPropertyName("type")]
public override string Type { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




