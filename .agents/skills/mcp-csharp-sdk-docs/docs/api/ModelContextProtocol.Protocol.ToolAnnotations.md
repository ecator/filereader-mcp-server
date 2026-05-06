
##### Table of Contents

# Class ToolAnnotations

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents additional properties describing a [Tool](ModelContextProtocol.Protocol.Tool.html) to clients.

```
public sealed class ToolAnnotations
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ToolAnnotations

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

All properties in [ToolAnnotations](ModelContextProtocol.Protocol.ToolAnnotations.html) are hints.
They are not guaranteed to provide a faithful description of tool behavior (including descriptive properties like `title`).
Clients should never make tool use decisions based on [ToolAnnotations](ModelContextProtocol.Protocol.ToolAnnotations.html) received from untrusted servers.

## Properties

### DestructiveHint

Gets or sets a value that indicates whether the tool can perform destructive updates to its environment.

```
[JsonPropertyName("destructiveHint")]
public bool? DestructiveHint { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool can perform destructive updates to its environment;
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool performs only additive updates;
    [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unspecified, in which case clients should assume [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

This property is most relevant when the tool modifies its environment (ReadOnly = false).

### IdempotentHint

Gets or sets a value that indicates whether calling the tool repeatedly with the same arguments
has no additional effect on its environment.

```
[JsonPropertyName("idempotentHint")]
public bool? IdempotentHint { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if calling the tool repeatedly with the same arguments
    has no additional effect on the environment; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it does;
    [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unspecified, in which case clients should assume [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

This property is most relevant when the tool modifies its environment (ReadOnly = false).

### OpenWorldHint

Gets or sets a value that indicates whether this tool can interact with an "open world" of external entities.

```
[JsonPropertyName("openWorldHint")]
public bool? OpenWorldHint { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool can interact with an unpredictable or dynamic set of entities (like web search);
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool's domain of interaction is closed and well-defined (like memory access);
    [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unspecified, in which case clients should assume [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### ReadOnlyHint

Gets or sets a value that indicates whether this tool modifies its environment.

```
[JsonPropertyName("readOnlyHint")]
public bool? ReadOnlyHint { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool only performs read operations without changing state;
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool can make modifications to its environment;
    [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unspecified, in which case clients should assume [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

Read-only tools do not have side effects beyond computational resource usage.
They don't create, update, or delete data in any system.

### Title

Gets or sets a human-readable title for the tool that can be displayed to users.

```
[JsonPropertyName("title")]
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




