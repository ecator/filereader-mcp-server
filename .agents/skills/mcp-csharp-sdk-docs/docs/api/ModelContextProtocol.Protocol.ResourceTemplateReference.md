
##### Table of Contents

# Class ResourceTemplateReference

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a reference to a resource or resource template definition.

```
public sealed class ResourceTemplateReference : Reference
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Reference](ModelContextProtocol.Protocol.Reference.html)

    ResourceTemplateReference

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Properties

### Type

When overridden in a derived class, gets the type of content.

```
public override string Type { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   "ref/resource" or "ref/prompt".

### Uri

Gets or sets the URI or URI template of the resource.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string? Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




