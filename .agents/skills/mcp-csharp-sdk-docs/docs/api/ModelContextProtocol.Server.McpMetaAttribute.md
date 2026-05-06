
##### Table of Contents

# Class McpMetaAttribute

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Specifies metadata for an MCP server primitive (tool, prompt, or resource).

```
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class McpMetaAttribute : Attribute
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Attribute](https://learn.microsoft.com/dotnet/api/system.attribute)

    McpMetaAttribute

Inherited Members
:   [Attribute.Equals(object)](https://learn.microsoft.com/dotnet/api/system.attribute.equals)

    [Attribute.GetCustomAttribute(Assembly, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-assembly-system-type))

    [Attribute.GetCustomAttribute(Assembly, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-assembly-system-type-system-boolean))

    [Attribute.GetCustomAttribute(MemberInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-memberinfo-system-type))

    [Attribute.GetCustomAttribute(MemberInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-memberinfo-system-type-system-boolean))

    [Attribute.GetCustomAttribute(Module, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-module-system-type))

    [Attribute.GetCustomAttribute(Module, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-module-system-type-system-boolean))

    [Attribute.GetCustomAttribute(ParameterInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-parameterinfo-system-type))

    [Attribute.GetCustomAttribute(ParameterInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-parameterinfo-system-type-system-boolean))

    [Attribute.GetCustomAttributes(Assembly)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly))

    [Attribute.GetCustomAttributes(Assembly, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly-system-boolean))

    [Attribute.GetCustomAttributes(Assembly, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly-system-type))

    [Attribute.GetCustomAttributes(Assembly, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly-system-type-system-boolean))

    [Attribute.GetCustomAttributes(MemberInfo)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo))

    [Attribute.GetCustomAttributes(MemberInfo, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo-system-boolean))

    [Attribute.GetCustomAttributes(MemberInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo-system-type))

    [Attribute.GetCustomAttributes(MemberInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo-system-type-system-boolean))

    [Attribute.GetCustomAttributes(Module)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module))

    [Attribute.GetCustomAttributes(Module, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module-system-boolean))

    [Attribute.GetCustomAttributes(Module, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module-system-type))

    [Attribute.GetCustomAttributes(Module, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module-system-type-system-boolean))

    [Attribute.GetCustomAttributes(ParameterInfo)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo))

    [Attribute.GetCustomAttributes(ParameterInfo, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo-system-boolean))

    [Attribute.GetCustomAttributes(ParameterInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo-system-type))

    [Attribute.GetCustomAttributes(ParameterInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo-system-type-system-boolean))

    [Attribute.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.attribute.gethashcode)

    [Attribute.IsDefaultAttribute()](https://learn.microsoft.com/dotnet/api/system.attribute.isdefaultattribute)

    [Attribute.IsDefined(Assembly, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-assembly-system-type))

    [Attribute.IsDefined(Assembly, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-assembly-system-type-system-boolean))

    [Attribute.IsDefined(MemberInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-memberinfo-system-type))

    [Attribute.IsDefined(MemberInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-memberinfo-system-type-system-boolean))

    [Attribute.IsDefined(Module, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-module-system-type))

    [Attribute.IsDefined(Module, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-module-system-type-system-boolean))

    [Attribute.IsDefined(ParameterInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-parameterinfo-system-type))

    [Attribute.IsDefined(ParameterInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-parameterinfo-system-type-system-boolean))

    [Attribute.Match(object)](https://learn.microsoft.com/dotnet/api/system.attribute.match)

    [Attribute.TypeId](https://learn.microsoft.com/dotnet/api/system.attribute.typeid)

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Examples

```
[McpServerTool]
[McpMeta("model", "gpt-4o")]
[McpMeta("version", "1.0")]
[McpMeta("priority", 5.0)]
[McpMeta("isBeta", true)]
[McpMeta("tags", JsonValue = """["a","b"]""")]
public string MyTool(string input) => $"Processed: {input}";
```

## Remarks

The metadata is used to populate the [Meta](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_Meta), [Meta](ModelContextProtocol.Protocol.Prompt.html#ModelContextProtocol_Protocol_Prompt_Meta),
or [Meta](ModelContextProtocol.Protocol.Resource.html#ModelContextProtocol_Protocol_Resource_Meta) property of the corresponding primitive. This metadata is
included in the responses to listing operations (`tools/list`, `prompts/list`,
`resources/list`).

This metadata is **not** propagated to the results of invocation operations such as
`tools/call`, `prompts/get`, or `resources/read`. To include metadata in
those results, set the `Meta` property on the [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html),
[GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html), or [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html) directly in your method implementation.

This attribute can be applied multiple times to a method to specify multiple key/value pairs
of metadata. However, the same key should not be used more than once; doing so will result
in undefined behavior.

Metadata can be used to attach additional information to primitives, such as model preferences,
version information, or other custom data that should be communicated to MCP clients.

## Constructors

### McpMetaAttribute(string, bool)

Initializes a new instance of the [McpMetaAttribute](ModelContextProtocol.Server.McpMetaAttribute.html) class with a Boolean value.

```
public McpMetaAttribute(string name, bool value)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name (key) of the metadata entry.

`value` [bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   The Boolean value of the metadata entry.

### McpMetaAttribute(string, double)

Initializes a new instance of the [McpMetaAttribute](ModelContextProtocol.Server.McpMetaAttribute.html) class with a double value.

```
public McpMetaAttribute(string name, double value)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name (key) of the metadata entry.

`value` [double](https://learn.microsoft.com/dotnet/api/system.double)
:   The double value of the metadata entry.

### McpMetaAttribute(string, string?)

Initializes a new instance of the [McpMetaAttribute](ModelContextProtocol.Server.McpMetaAttribute.html) class with a string value.

```
public McpMetaAttribute(string name, string? value = null)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name (key) of the metadata entry.

`value` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The string value of the metadata entry. If null, the value will be serialized as JSON null.

## Properties

### JsonValue

Gets or sets the value of the metadata entry as a JSON string.

```
[StringSyntax("Json")]
public string JsonValue { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value must be well-formed JSON. It will be parsed and added to the metadata [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject).
Simple values can be represented as JSON literals like `"\"my-string\""`, `"123"`,
or `"true"`. Complex structures can be represented as JSON objects or arrays.

Setting this property overrides any value provided via the constructor.

For programmatic scenarios where you want to construct complex metadata without dealing with
JSON strings, use the [Meta](ModelContextProtocol.Server.McpServerToolCreateOptions.html#ModelContextProtocol_Server_McpServerToolCreateOptions_Meta),
[Meta](ModelContextProtocol.Server.McpServerPromptCreateOptions.html#ModelContextProtocol_Server_McpServerPromptCreateOptions_Meta), or [Meta](ModelContextProtocol.Server.McpServerResourceCreateOptions.html#ModelContextProtocol_Server_McpServerResourceCreateOptions_Meta)
property to provide a JsonObject directly.

### Name

Gets the name (key) of the metadata entry.

```
public string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value is used as the key in the metadata object. It should be a unique identifier
for this piece of metadata within the context of the primitive.




