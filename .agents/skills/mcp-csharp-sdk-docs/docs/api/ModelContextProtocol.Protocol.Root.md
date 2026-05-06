
##### Table of Contents

# Class Root

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a root URI and its metadata in the Model Context Protocol.

```
public sealed class Root
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Root

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Root URIs serve as entry points for resource navigation, typically representing
top-level directories or container resources that are relevant to the current session.
Roots inform servers which locations the client considers important, providing informational
guidance rather than an access-control mechanism. Each root has a URI that uniquely identifies
it and optional metadata like a human-readable name.

## Properties

### Meta

Gets or sets additional metadata for the root.

```
[JsonPropertyName("_meta")]
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

This is reserved by the protocol for future use.

### Name

Gets or sets a human-readable name for the root.

```
[JsonPropertyName("name")]
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Uri

Gets or sets the URI of the root.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




