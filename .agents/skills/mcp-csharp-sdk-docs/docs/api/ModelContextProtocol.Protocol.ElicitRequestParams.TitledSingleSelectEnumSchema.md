
##### Table of Contents

# Class ElicitRequestParams.TitledSingleSelectEnumSchema

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a schema for single-selection enumeration with display titles for each option.

```
public sealed class ElicitRequestParams.TitledSingleSelectEnumSchema : ElicitRequestParams.PrimitiveSchemaDefinition
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[PrimitiveSchemaDefinition](ModelContextProtocol.Protocol.ElicitRequestParams.PrimitiveSchemaDefinition.html)

    ElicitRequestParams.TitledSingleSelectEnumSchema

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

Gets or sets the default value for the enum.

```
[JsonPropertyName("default")]
public string? Default { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### OneOf

Gets or sets the list of enum options with their constant values and display titles.

```
[JsonPropertyName("oneOf")]
public IList<ElicitRequestParams.EnumSchemaOption> OneOf { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[EnumSchemaOption](ModelContextProtocol.Protocol.ElicitRequestParams.EnumSchemaOption.html)>

### Type

Gets or sets the type of the schema.

```
[JsonPropertyName("type")]
public override string Type { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




