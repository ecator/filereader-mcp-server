
##### Table of Contents

# Class ElicitRequestParams.NumberSchema

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a schema for a number or integer type.

```
public sealed class ElicitRequestParams.NumberSchema : ElicitRequestParams.PrimitiveSchemaDefinition
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[PrimitiveSchemaDefinition](ModelContextProtocol.Protocol.ElicitRequestParams.PrimitiveSchemaDefinition.html)

    ElicitRequestParams.NumberSchema

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

Gets or sets the default value for the number.

```
[JsonPropertyName("default")]
public double? Default { get; set; }
```

#### Property Value

[double](https://learn.microsoft.com/dotnet/api/system.double)?

### Maximum

Gets or sets the maximum allowed value.

```
[JsonPropertyName("maximum")]
public double? Maximum { get; set; }
```

#### Property Value

[double](https://learn.microsoft.com/dotnet/api/system.double)?

### Minimum

Gets or sets the minimum allowed value.

```
[JsonPropertyName("minimum")]
public double? Minimum { get; set; }
```

#### Property Value

[double](https://learn.microsoft.com/dotnet/api/system.double)?

### Type

Gets or sets the type of the schema.

```
public override string Type { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




