
##### Table of Contents

# Class ElicitRequestParams.StringSchema

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a schema for a string type.

```
public sealed class ElicitRequestParams.StringSchema : ElicitRequestParams.PrimitiveSchemaDefinition
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[PrimitiveSchemaDefinition](ModelContextProtocol.Protocol.ElicitRequestParams.PrimitiveSchemaDefinition.html)

    ElicitRequestParams.StringSchema

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

Gets or sets the default value for the string.

```
[JsonPropertyName("default")]
public string? Default { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Format

Gets or sets a specific format for the string ("email", "uri", "date", or "date-time").

```
[JsonPropertyName("format")]
public string? Format { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### MaxLength

Gets or sets the maximum length for the string.

```
[JsonPropertyName("maxLength")]
public int? MaxLength { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

### MinLength

Gets or sets the minimum length for the string.

```
[JsonPropertyName("minLength")]
public int? MinLength { get; set; }
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




