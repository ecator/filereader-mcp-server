
##### Table of Contents

# Class ClientCapabilities

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the capabilities that a client supports.

```
public sealed class ClientCapabilities
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ClientCapabilities

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Capabilities define the features and functionality that a client can handle when communicating with an MCP server.
These are advertised to the server during the initialize handshake.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Elicitation

Gets or sets the client's elicitation capability, which indicates whether the client
supports elicitation of additional information from the user on behalf of the server.

```
[JsonPropertyName("elicitation")]
public ElicitationCapability? Elicitation { get; set; }
```

#### Property Value

[ElicitationCapability](ModelContextProtocol.Protocol.ElicitationCapability.html)

### Experimental

Gets or sets experimental, non-standard capabilities that the client supports.

```
[JsonPropertyName("experimental")]
public IDictionary<string, object>? Experimental { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

The [Experimental](ModelContextProtocol.Protocol.ClientCapabilities.html#ModelContextProtocol_Protocol_ClientCapabilities_Experimental) dictionary allows clients to advertise support for features that are not yet
standardized in the Model Context Protocol specification. This extension mechanism enables
future protocol enhancements while maintaining backward compatibility.

Values in this dictionary are implementation-specific and should be coordinated between client
and server implementations. Servers should not assume the presence of any experimental capability
without checking for it first.

### Extensions

Gets or sets optional MCP extensions that the client supports.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public IDictionary<string, object>? Extensions { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Keys are extension identifiers in reverse domain notation with an extension name
(e.g., `"io.modelcontextprotocol/oauth-client-credentials"`), and values are
per-extension settings objects. An empty object indicates support with no additional settings.

Extensions provide a framework for extending the Model Context Protocol while maintaining
interoperability. Clients advertise extension support via this field during the initialization handshake.

### Roots

Gets or sets the client's roots capability, which are entry points for resource navigation.

```
[JsonPropertyName("roots")]
public RootsCapability? Roots { get; set; }
```

#### Property Value

[RootsCapability](ModelContextProtocol.Protocol.RootsCapability.html)

#### Remarks

When [Roots](ModelContextProtocol.Protocol.ClientCapabilities.html#ModelContextProtocol_Protocol_ClientCapabilities_Roots) is non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the client indicates that it can respond to
server requests for listing root URIs. Root URIs serve as entry points for resource navigation in the protocol.

The server can use [RequestRootsAsync(ListRootsRequestParams, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_RequestRootsAsync_ModelContextProtocol_Protocol_ListRootsRequestParams_System_Threading_CancellationToken_) to request the list of
available roots from the client, which will trigger the client's [RootsHandler](ModelContextProtocol.Client.McpClientHandlers.html#ModelContextProtocol_Client_McpClientHandlers_RootsHandler).

### Sampling

Gets or sets the client's sampling capability, which indicates whether the client
supports issuing requests to an LLM on behalf of the server.

```
[JsonPropertyName("sampling")]
public SamplingCapability? Sampling { get; set; }
```

#### Property Value

[SamplingCapability](ModelContextProtocol.Protocol.SamplingCapability.html)

### Tasks

Gets or sets the client's tasks capability for supporting task-augmented requests.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public McpTasksCapability? Tasks { get; set; }
```

#### Property Value

[McpTasksCapability](ModelContextProtocol.Protocol.McpTasksCapability.html)

#### Remarks

The tasks capability enables servers to augment their requests with tasks for long-running
operations. When present, servers can request that certain operations (like sampling or
elicitation) execute asynchronously, with the ability to poll for status and retrieve results later.

See [McpTasksCapability](ModelContextProtocol.Protocol.McpTasksCapability.html) for details on configuring which operations support tasks.




