
##### Table of Contents

# Class ReadResourceResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a server's response to a [ResourcesRead](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesRead) request from the client.

```
public sealed class ReadResourceResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    ReadResourceResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Contents

Gets or sets a list of [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) objects that this resource contains.

```
[JsonPropertyName("contents")]
public IList<ResourceContents> Contents { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html)>

#### Remarks

This property contains the actual content of the requested resource, which can be
either text-based ([TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html)) or binary ([BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html)).
The type of content included depends on the resource being accessed.




