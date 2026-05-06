
##### Table of Contents

# Class SamplingMcpTasksCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents task support for sampling-related requests.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class SamplingMcpTasksCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    SamplingMcpTasksCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### CreateMessage

Gets or sets whether sampling/createMessage requests support task augmentation.

```
[JsonPropertyName("createMessage")]
public CreateMessageMcpTasksCapability? CreateMessage { get; set; }
```

#### Property Value

[CreateMessageMcpTasksCapability](ModelContextProtocol.Protocol.CreateMessageMcpTasksCapability.html)

#### Remarks

When present, indicates that the client supports task-augmented sampling/createMessage requests.




