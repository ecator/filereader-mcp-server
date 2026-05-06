
##### Table of Contents

# Class RequestParamsMetadata

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides metadata related to the request that provides additional protocol-level information.

```
public sealed class RequestParamsMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    RequestParamsMetadata

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class contains properties that are used by the Model Context Protocol
for features like progress tracking and other protocol-specific capabilities.

## Properties

### ProgressToken

Gets or sets an opaque token that will be attached to any subsequent progress notifications.

```
[JsonPropertyName("progressToken")]
public ProgressToken? ProgressToken { get; set; }
```

#### Property Value

[ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)?

#### Remarks

The receiver is not obligated to provide these notifications.




