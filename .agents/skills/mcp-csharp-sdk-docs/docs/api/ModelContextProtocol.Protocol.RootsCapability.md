
##### Table of Contents

# Class RootsCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a client capability that enables root resource discovery in the Model Context Protocol.

```
public sealed class RootsCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    RootsCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

When present in [ClientCapabilities](ModelContextProtocol.Protocol.ClientCapabilities.html), it indicates that the client supports listing
root URIs that serve as entry points for resource navigation.

The roots capability establishes a mechanism for servers to discover the directories and files
the client considers relevant. Root URIs represent top-level entry points that inform the server
about the working context, providing informational guidance rather than enforcing access control.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### ListChanged

Gets or sets a value that indicates whether the client supports notifications for changes to the roots list.

```
[JsonPropertyName("listChanged")]
public bool? ListChanged { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?

#### Remarks

When set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the client can notify servers when roots are added,
removed, or modified, allowing servers to refresh their roots cache accordingly.
This enables servers to stay synchronized with client-side changes to available roots.




