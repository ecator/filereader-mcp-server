
##### Table of Contents

# Interface IBaseMetadata

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base interface for metadata with name (identifier) and title (display name) properties.

```
public interface IBaseMetadata
```

## Properties

### Name

Gets or sets the unique identifier for this item.

```
[JsonPropertyName("name")]
string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Title

Gets or sets a title.

```
[JsonPropertyName("title")]
string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This is intended for UI and end-user contexts. It is optimized to be human-readable and easily understood,
even by those unfamiliar with domain-specific terminology.
If not provided, [Name](ModelContextProtocol.Protocol.IBaseMetadata.html#ModelContextProtocol_Protocol_IBaseMetadata_Name) can be used for display (except for tools, where [Title](ModelContextProtocol.Protocol.ToolAnnotations.html#ModelContextProtocol_Protocol_ToolAnnotations_Title), if present,
should be given precedence over using [Name](ModelContextProtocol.Protocol.IBaseMetadata.html#ModelContextProtocol_Protocol_IBaseMetadata_Name)).




