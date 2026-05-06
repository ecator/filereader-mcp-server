
##### Table of Contents

# Class UrlElicitationRequiredErrorData

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the payload for the `URL_ELICITATION_REQUIRED` JSON-RPC error.

```
public sealed class UrlElicitationRequiredErrorData
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    UrlElicitationRequiredErrorData

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Elicitations

Gets or sets the elicitations that must be completed before retrying the original request.

```
[JsonPropertyName("elicitations")]
public required IList<ElicitRequestParams> Elicitations { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html)>




