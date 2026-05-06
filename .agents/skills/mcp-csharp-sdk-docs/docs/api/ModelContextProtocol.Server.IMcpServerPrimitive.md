
##### Table of Contents

# Interface IMcpServerPrimitive

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an MCP server primitive, like a tool or a prompt.

```
public interface IMcpServerPrimitive
```

## Properties

### Id

Gets the unique identifier of the primitive.

```
string Id { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Metadata

Gets the metadata for this primitive instance.

```
IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.




