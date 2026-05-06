
##### Table of Contents

# Class UrlElicitationCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the capability for URL mode (out-of-band) elicitation.

```
public sealed class UrlElicitationCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    UrlElicitationCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This capability enables secure out-of-band interactions where the user is directed to a URL
(typically opened in a browser) to complete sensitive operations like OAuth authorization,
payments, or credential entry.

Unlike form mode, sensitive data in URL mode is never exposed to the MCP client, providing
better security for sensitive interactions.




