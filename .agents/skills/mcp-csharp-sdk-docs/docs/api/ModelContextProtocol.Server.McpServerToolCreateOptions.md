
##### Table of Contents

# Class McpServerToolCreateOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides options for controlling the creation of an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public sealed class McpServerToolCreateOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerToolCreateOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

These options allow for customizing the behavior and metadata of tools created with
McpServerTool.Create. They provide control over naming, description,
tool properties, and dependency injection integration.

When creating tools programmatically rather than using attributes, these options
provide the same level of configuration flexibility.

## Properties

### Description

Gets or sets the description to use for the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but a [DescriptionAttribute](https://learn.microsoft.com/dotnet/api/system.componentmodel.descriptionattribute) is applied to the method,
the description from that attribute is used.

### Destructive

Gets or sets a value that indicates whether the tool might perform destructive updates to its environment.

```
public bool? Destructive { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool might perform destructive updates to its environment.
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool performs only additive updates.
    The default is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

This property is most relevant when the tool modifies its environment (ReadOnly = false).

### Execution

Gets or sets the execution hints for this tool.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ToolExecution? Execution { get; set; }
```

#### Property Value

[ToolExecution](ModelContextProtocol.Protocol.ToolExecution.html)

#### Remarks

Execution hints provide information about how the tool should be invoked, including
task support level ([ToolTaskSupport](ModelContextProtocol.Protocol.ToolTaskSupport.html)).

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the tool's execution settings are determined automatically based on
the method signature (async methods get [Optional](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Optional); sync methods
get [Forbidden](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Forbidden)).

### Icons

Gets or sets the icons for this tool.

```
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This property can be used by clients to display the tool's icon in a user interface.

### Idempotent

Gets or sets a value that indicates whether calling the tool repeatedly with the same arguments
has no additional effect on its environment.

```
public bool? Idempotent { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if calling the tool repeatedly with the same arguments
    has no additional effect on the environment; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it does.
    The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

This property is most relevant when the tool modifies its environment (ReadOnly = false).

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

This [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) is used to seed the [Meta](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_Meta) property. Any metadata from
[McpMetaAttribute](ModelContextProtocol.Server.McpMetaAttribute.html) instances on the method will be added to this object, but
properties already present in this [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) will not be overwritten.

Implementations must not make assumptions about its contents.

### Metadata

Gets or sets the metadata associated with the tool.

```
public IReadOnlyList<object>? Metadata { get; set; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Metadata includes information such as attributes extracted from the method and its declaring class.
If not provided, metadata will be automatically generated for methods created via reflection.

### Name

Gets or sets the name to use for the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but an [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html) is applied to the method,
the name from the attribute is used. If that's not present, a name based on the method's name is used.

### OpenWorld

Gets or sets a value that indicates whether this tool can interact with an "open world" of external entities.

```
public bool? OpenWorld { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool can interact with an unpredictable or dynamic set of entities (like web search).
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool's domain of interaction is closed and well-defined (like memory access).
    The default is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### OutputSchema

Gets or sets an explicit JSON schema to use as the tool's output schema.

```
public JsonElement? OutputSchema { get; set; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)?
:   The default is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), which means the output schema is inferred from the return type.

#### Remarks

When set, this schema is used as the [OutputSchema](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_OutputSchema) instead of the schema
inferred from the tool method's return type. This is particularly useful when a tool method
returns [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) directly (to control properties like [Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta),
[IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError), or [StructuredContent](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_StructuredContent)) but still
needs to advertise a meaningful output schema to clients.

[UseStructuredContent](ModelContextProtocol.Server.McpServerToolCreateOptions.html#ModelContextProtocol_Server_McpServerToolCreateOptions_UseStructuredContent) must also be set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) for this property to take effect.

### ReadOnly

Gets or sets a value that indicates whether this tool does not modify its environment.

```
public bool? ReadOnly { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   If [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the tool only performs read operations without changing state.
    If [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the tool might make modifications to its environment.
    The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

Read-only tools do not have side effects beyond computational resource usage.
They don't create, update, or delete data in any system.

### SchemaCreateOptions

Gets or sets the JSON schema options when creating an Microsoft.Extensions.AI.AIFunction from a method.

```
public AIJsonSchemaCreateOptions? SchemaCreateOptions { get; set; }
```

#### Property Value

AIJsonSchemaCreateOptions
:   The default is Microsoft.Extensions.AI.AIJsonSchemaCreateOptions.Default.

### SerializerOptions

Gets or sets the JSON serializer options to use when marshalling data to/from JSON.

```
public JsonSerializerOptions? SerializerOptions { get; set; }
```

#### Property Value

[JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The default is [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions).

### Services

Gets or sets optional services used in the construction of the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public IServiceProvider? Services { get; set; }
```

#### Property Value

[IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)

#### Remarks

These services will be used to determine which parameters should be satisfied from dependency injection. As such,
what services are satisfied via this provider should match what's satisfied via the provider passed in at invocation time.

### Title

Gets or sets a human-readable title for the tool that can be displayed to users.

```
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The title provides a more descriptive, user-friendly name for the tool than the tool's
programmatic name. It is intended for display purposes and to help users understand
the tool's purpose at a glance.

Unlike the tool name (which follows programmatic naming conventions), the title can
include spaces, special characters, and be phrased in a more natural language style.

### UseStructuredContent

Gets or sets a value that indicates whether the tool should report an output schema for structured content.

```
public bool UseStructuredContent { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

When enabled, the tool will attempt to populate the [OutputSchema](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_OutputSchema)
and provide structured content in the [StructuredContent](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_StructuredContent) property.




