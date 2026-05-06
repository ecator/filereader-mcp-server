
##### Table of Contents

# Class McpJsonUtilities

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a collection of utility methods for working with JSON data in the context of MCP.

```
public static class McpJsonUtilities
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpJsonUtilities

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### DefaultOptions

Gets the [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) singleton used as the default in JSON serialization operations.

```
public static JsonSerializerOptions DefaultOptions { get; }
```

#### Property Value

[JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)

#### Remarks

For Native AOT or applications disabling [IsReflectionEnabledByDefault](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializer.isreflectionenabledbydefault), this instance
includes source generated contracts for all common exchange types contained in the ModelContextProtocol library.

It additionally turns on the following settings:

1. Enables [Web](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializerdefaults#system-text-json-jsonserializerdefaults-web) defaults.
2. Enables [WhenWritingNull](https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonignorecondition#system-text-json-serialization-jsonignorecondition-whenwritingnull) as the default ignore condition for properties.
3. Enables [AllowReadingFromString](https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling#system-text-json-serialization-jsonnumberhandling-allowreadingfromstring) as the default number handling for number types.



