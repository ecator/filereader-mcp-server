
##### Table of Contents

# Class RequestMcpTasksCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents task support for tool-specific requests.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class RequestMcpTasksCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    RequestMcpTasksCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Elicitation

Gets or sets task support for elicitation-related requests.

```
[JsonPropertyName("elicitation")]
public ElicitationMcpTasksCapability? Elicitation { get; set; }
```

#### Property Value

[ElicitationMcpTasksCapability](ModelContextProtocol.Protocol.ElicitationMcpTasksCapability.html)

### Sampling

Gets or sets task support for sampling-related requests.

```
[JsonPropertyName("sampling")]
public SamplingMcpTasksCapability? Sampling { get; set; }
```

#### Property Value

[SamplingMcpTasksCapability](ModelContextProtocol.Protocol.SamplingMcpTasksCapability.html)

### Tools

Gets or sets task support for tool-related requests.

```
[JsonPropertyName("tools")]
public ToolsMcpTasksCapability? Tools { get; set; }
```

#### Property Value

[ToolsMcpTasksCapability](ModelContextProtocol.Protocol.ToolsMcpTasksCapability.html)




