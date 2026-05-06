
##### Table of Contents

# Class ElicitRequestParams.PrimitiveSchemaDefinition

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a restricted subset of JSON Schema:
[ElicitRequestParams.StringSchema](ModelContextProtocol.Protocol.ElicitRequestParams.StringSchema.html), [ElicitRequestParams.NumberSchema](ModelContextProtocol.Protocol.ElicitRequestParams.NumberSchema.html), [ElicitRequestParams.BooleanSchema](ModelContextProtocol.Protocol.ElicitRequestParams.BooleanSchema.html),
[ElicitRequestParams.UntitledSingleSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.UntitledSingleSelectEnumSchema.html), [ElicitRequestParams.TitledSingleSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledSingleSelectEnumSchema.html),
[ElicitRequestParams.UntitledMultiSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.UntitledMultiSelectEnumSchema.html), [ElicitRequestParams.TitledMultiSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledMultiSelectEnumSchema.html),
or [ElicitRequestParams.LegacyTitledEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.LegacyTitledEnumSchema.html) (deprecated).

```
[JsonConverter(typeof(ElicitRequestParams.PrimitiveSchemaDefinition.Converter))]
public abstract class ElicitRequestParams.PrimitiveSchemaDefinition
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ElicitRequestParams.PrimitiveSchemaDefinition

Derived
:   [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[BooleanSchema](ModelContextProtocol.Protocol.ElicitRequestParams.BooleanSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[LegacyTitledEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.LegacyTitledEnumSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[NumberSchema](ModelContextProtocol.Protocol.ElicitRequestParams.NumberSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[StringSchema](ModelContextProtocol.Protocol.ElicitRequestParams.StringSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[TitledMultiSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledMultiSelectEnumSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[TitledSingleSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledSingleSelectEnumSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[UntitledMultiSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.UntitledMultiSelectEnumSchema.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[UntitledSingleSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.UntitledSingleSelectEnumSchema.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Description

Gets or sets a description for the schema.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Title

Gets or sets a title for the schema.

```
[JsonPropertyName("title")]
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Type

Gets or sets the type of the schema.

```
[JsonPropertyName("type")]
public abstract string Type { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




