
##### Table of Contents

# Class Tool

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a tool that the server is capable of calling.

```
public sealed class Tool : IBaseMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Tool

Implements
:   [IBaseMetadata](ModelContextProtocol.Protocol.IBaseMetadata.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Annotations

Gets or sets optional additional tool information and behavior hints.

```
[JsonPropertyName("annotations")]
public ToolAnnotations? Annotations { get; set; }
```

#### Property Value

[ToolAnnotations](ModelContextProtocol.Protocol.ToolAnnotations.html)

#### Remarks

These annotations provide metadata about the tool's behavior, such as whether it's read-only,
destructive, idempotent, or operates in an open world. They also can include a human-readable title.
Note that these are hints and should not be relied upon for security decisions.

### Description

Gets or sets a human-readable description of the tool.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description helps the AI model understand what the tool does and when to use it.
It should be clear, concise, and accurately describe the tool's purpose and functionality.

The description is typically presented to AI models to help them determine when
and how to use the tool based on user requests. A well-written description significantly
reduces incorrect tool invocations. Include information about what the tool does, any
constraints or prerequisites, and what it returns.

Similarly, individual parameter descriptions (provided via [DescriptionAttribute](https://learn.microsoft.com/dotnet/api/system.componentmodel.descriptionattribute)
on tool method parameters) are important for guiding the model to supply correct argument values.
Descriptions should document expected formats, valid value ranges, and any other constraints
the model should be aware of.

### Execution

Gets or sets execution-related metadata for this tool.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public ToolExecution? Execution { get; set; }
```

#### Property Value

[ToolExecution](ModelContextProtocol.Protocol.ToolExecution.html)

#### Remarks

This property provides hints about how the tool should be executed, particularly
regarding task augmentation support. See [ToolExecution](ModelContextProtocol.Protocol.ToolExecution.html) for details.

### Icons

Gets or sets an optional list of icons for this tool.

```
[JsonPropertyName("icons")]
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This can be used by clients to display the tool's icon in a user interface.

### InputSchema

Gets or sets a JSON Schema object defining the expected parameters for the tool.

```
[JsonPropertyName("inputSchema")]
public JsonElement InputSchema { get; set; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)

#### Remarks

The schema must be a valid JSON Schema object with the "type" property set to "object".
This is enforced by validation in the setter which will throw an [ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
if an invalid schema is provided.

The schema typically defines the properties (parameters) that the tool accepts,
their types, and which ones are required. This helps AI models understand
how to structure their calls to the tool.

If not explicitly set, a default minimal schema of `{"type":"object"}` is used.

#### Exceptions

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   The value is not a valid MCP tool JSON schema.

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
[JsonPropertyName("_meta")]
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

Implementations must not make assumptions about its contents.

### Name

Gets or sets the unique identifier for this item.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### OutputSchema

Gets or sets a JSON Schema object defining the expected structured outputs for the tool.

```
[JsonPropertyName("outputSchema")]
public JsonElement? OutputSchema { get; set; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)?

#### Remarks

The schema must be a valid JSON Schema object with the "type" property set to "object".
This is enforced by validation in the setter which will throw an [ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
if an invalid schema is provided.

The schema should describe the shape of the data as returned in [StructuredContent](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_StructuredContent).

#### Exceptions

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   The value is not a valid MCP tool JSON schema.

### Title

Gets or sets a title.

```
[JsonPropertyName("title")]
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This is intended for UI and end-user contexts. It is optimized to be human-readable and easily understood,
even by those unfamiliar with domain-specific terminology.
If not provided, [Name](ModelContextProtocol.Protocol.IBaseMetadata.html#ModelContextProtocol_Protocol_IBaseMetadata_Name) can be used for display (except for tools, where [Title](ModelContextProtocol.Protocol.ToolAnnotations.html#ModelContextProtocol_Protocol_ToolAnnotations_Title), if present,
should be given precedence over using [Name](ModelContextProtocol.Protocol.IBaseMetadata.html#ModelContextProtocol_Protocol_IBaseMetadata_Name)).




