
##### Table of Contents

# Class PromptReference

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a reference to a prompt, identified by its name.

```
public sealed class PromptReference : Reference, IBaseMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Reference](ModelContextProtocol.Protocol.Reference.html)

    PromptReference

Implements
:   [IBaseMetadata](ModelContextProtocol.Protocol.IBaseMetadata.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Properties

### Name

Gets or sets the unique identifier for this item.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

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

### Type

When overridden in a derived class, gets the type of content.

```
public override string Type { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   "ref/resource" or "ref/prompt".

## Methods

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




