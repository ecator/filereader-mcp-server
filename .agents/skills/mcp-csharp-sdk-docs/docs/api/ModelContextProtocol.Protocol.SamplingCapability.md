
##### Table of Contents

# Class SamplingCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the capability for a client to generate text or other content using an AI model.

```
public sealed class SamplingCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    SamplingCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This capability enables the MCP client to respond to sampling requests from an MCP server.

When this capability is enabled, an MCP server can request the client to generate content
using an AI model. The client must set a [SamplingHandler](ModelContextProtocol.Client.McpClientHandlers.html#ModelContextProtocol_Client_McpClientHandlers_SamplingHandler) to process these requests.

## Properties

### Context

Gets or sets whether the client supports context inclusion via includeContext parameter.

```
[JsonPropertyName("context")]
public SamplingContextCapability? Context { get; set; }
```

#### Property Value

[SamplingContextCapability](ModelContextProtocol.Protocol.SamplingContextCapability.html)

#### Remarks

If not declared, servers should only use includeContext: "none".

### Tools

Gets or sets whether the client supports tool use via tools and toolChoice parameters.

```
[JsonPropertyName("tools")]
public SamplingToolsCapability? Tools { get; set; }
```

#### Property Value

[SamplingToolsCapability](ModelContextProtocol.Protocol.SamplingToolsCapability.html)




