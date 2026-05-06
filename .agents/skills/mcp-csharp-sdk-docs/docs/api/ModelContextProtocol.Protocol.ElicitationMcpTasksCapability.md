
##### Table of Contents

# Class ElicitationMcpTasksCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents task support for elicitation-related requests.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class ElicitationMcpTasksCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ElicitationMcpTasksCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Create

Gets or sets whether elicitation/create requests support task augmentation.

```
[JsonPropertyName("create")]
public CreateElicitationMcpTasksCapability? Create { get; set; }
```

#### Property Value

[CreateElicitationMcpTasksCapability](ModelContextProtocol.Protocol.CreateElicitationMcpTasksCapability.html)

#### Remarks

When present, indicates that the client supports task-augmented elicitation/create requests.




