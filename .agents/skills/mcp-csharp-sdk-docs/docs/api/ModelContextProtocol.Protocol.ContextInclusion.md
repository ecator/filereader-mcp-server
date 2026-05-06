
##### Table of Contents

# Enum ContextInclusion

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Specifies the context inclusion options for a request in the Model Context Protocol (MCP).

```
[JsonConverter(typeof(JsonStringEnumConverter<ContextInclusion>))]
public enum ContextInclusion
```

## Fields

`[JsonStringEnumMemberName("allServers")] AllServers = 2`
:   Context from all servers that the client is connected to should be included.

    This value is soft-deprecated. Servers should only use this value if the client
    declares ClientCapabilities.Sampling.Context.

`[JsonStringEnumMemberName("none")] None = 0`
:   No context should be included.

`[JsonStringEnumMemberName("thisServer")] ThisServer = 1`
:   Context from the server that sent the request should be included.

    This value is soft-deprecated. Servers should only use this value if the client
    declares ClientCapabilities.Sampling.Context.

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

[ContextInclusion](ModelContextProtocol.Protocol.ContextInclusion.html), and in particular [ThisServer](ModelContextProtocol.Protocol.ContextInclusion.html#ModelContextProtocol_Protocol_ContextInclusion_ThisServer) and [AllServers](ModelContextProtocol.Protocol.ContextInclusion.html#ModelContextProtocol_Protocol_ContextInclusion_AllServers), are deprecated.
Servers should only use these values if the client declares [Sampling](ModelContextProtocol.Protocol.ClientCapabilities.html#ModelContextProtocol_Protocol_ClientCapabilities_Sampling) with
[Context](ModelContextProtocol.Protocol.SamplingCapability.html#ModelContextProtocol_Protocol_SamplingCapability_Context) set. These values might be removed in future spec releases.




