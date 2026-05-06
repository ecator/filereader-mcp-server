
##### Table of Contents

# Class ToolsMcpTasksCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents task support for tool-related requests.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class ToolsMcpTasksCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ToolsMcpTasksCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Call

Gets or sets whether tools/call requests support task augmentation.

```
[JsonPropertyName("call")]
public CallToolMcpTasksCapability? Call { get; set; }
```

#### Property Value

[CallToolMcpTasksCapability](ModelContextProtocol.Protocol.CallToolMcpTasksCapability.html)

#### Remarks

When present, indicates that the server supports task-augmented tools/call requests.




