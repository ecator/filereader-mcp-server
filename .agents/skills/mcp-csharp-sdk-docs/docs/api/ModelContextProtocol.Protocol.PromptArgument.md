
##### Table of Contents

# Class PromptArgument

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an argument that a prompt can accept for templating and customization.

```
public sealed class PromptArgument : IBaseMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    PromptArgument

Implements
:   [IBaseMetadata](ModelContextProtocol.Protocol.IBaseMetadata.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The [PromptArgument](ModelContextProtocol.Protocol.PromptArgument.html) class defines metadata for arguments that can be provided
to a prompt. These arguments are used to customize or parameterize prompts when they are
retrieved using [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) requests.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Description

Gets or sets a human-readable description of the argument's purpose and expected values.

```
[JsonPropertyName("description")]
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This description helps developers understand what information should be provided
for this argument and how it will affect the generated prompt.

### Name

Gets or sets the unique identifier for this item.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Required

Gets or sets a value that indicates whether this argument must be provided when requesting the prompt.

```
[JsonPropertyName("required")]
public bool? Required { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?

#### Remarks

When set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the client must include this argument when making a [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) request.
If a required argument is missing, the server should respond with an error.

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




