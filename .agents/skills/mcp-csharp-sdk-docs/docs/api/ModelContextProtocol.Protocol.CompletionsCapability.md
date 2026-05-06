
##### Table of Contents

# Class CompletionsCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the completions capability for providing auto-completion suggestions
for prompt arguments and resource references.

```
public sealed class CompletionsCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    CompletionsCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

When enabled, this capability allows a Model Context Protocol server to provide
auto-completion suggestions. This capability is advertised to clients during the initialize handshake.

The primary function of this capability is to improve the user experience by offering
contextual suggestions for argument values or resource identifiers based on partial input.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

This class is intentionally empty as the Model Context Protocol specification does not
currently define additional properties for completions capabilities. Future versions of the
specification might extend this capability with additional configuration options.




