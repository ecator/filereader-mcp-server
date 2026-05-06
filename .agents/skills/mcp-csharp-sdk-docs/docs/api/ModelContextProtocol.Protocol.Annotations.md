
##### Table of Contents

# Class Annotations

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents annotations that can be attached to content, resources, and resource templates.

```
public sealed class Annotations
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Annotations

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Annotations enable filtering and prioritization of content for different audiences.
See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Audience

Gets or sets the intended audience for this content as an array of [Role](ModelContextProtocol.Protocol.Role.html) values.

```
[JsonPropertyName("audience")]
public IList<Role>? Audience { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Role](ModelContextProtocol.Protocol.Role.html)>

### LastModified

Gets or sets the moment the resource was last modified.

```
[JsonPropertyName("lastModified")]
public DateTimeOffset? LastModified { get; set; }
```

#### Property Value

[DateTimeOffset](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)?

#### Remarks

The corresponding JSON should be an ISO 8601 formatted string (for example, "2025-01-12T15:00:58Z").
Examples of when the resource was last modified include last activity in an open file or when the resource was attached.

### Priority

Gets or sets a value indicating how important this data is for operating the server.

```
[JsonPropertyName("priority")]
public float? Priority { get; set; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)?

#### Remarks

The value is a floating-point number between 0 and 1, where 0 represents the lowest priority
and 1 represents the highest priority.




