
##### Table of Contents

# Class ServerCapabilities

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the capabilities that a server supports.

```
public sealed class ServerCapabilities
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ServerCapabilities

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Server capabilities define the features and functionality available when clients connect.
These capabilities are advertised to clients during the initialize handshake.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Completions

Gets or sets a server's completions capability for supporting argument auto-completion suggestions.

```
[JsonPropertyName("completions")]
public CompletionsCapability? Completions { get; set; }
```

#### Property Value

[CompletionsCapability](ModelContextProtocol.Protocol.CompletionsCapability.html)

### Experimental

Gets or sets experimental, non-standard capabilities that the server supports.

```
[JsonPropertyName("experimental")]
public IDictionary<string, object>? Experimental { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

The [Experimental](ModelContextProtocol.Protocol.ServerCapabilities.html#ModelContextProtocol_Protocol_ServerCapabilities_Experimental) dictionary allows servers to advertise support for features that are not yet
standardized in the Model Context Protocol specification. This extension mechanism enables
future protocol enhancements while maintaining backward compatibility.

Values in this dictionary are implementation-specific and should be coordinated between client
and server implementations. Clients should not assume the presence of any experimental capability
without checking for it first.

### Extensions

Gets or sets optional MCP extensions that the server supports.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public IDictionary<string, object>? Extensions { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Keys are extension identifiers in reverse domain notation with an extension name
(e.g., `"io.modelcontextprotocol/apps"`), and values are per-extension settings
objects. An empty object indicates support with no additional settings.

Extensions provide a framework for extending the Model Context Protocol while maintaining
interoperability. Servers advertise extension support via this field during the initialization handshake.

### Logging

Gets or sets a server's logging capability for sending log messages to the client.

```
[JsonPropertyName("logging")]
public LoggingCapability? Logging { get; set; }
```

#### Property Value

[LoggingCapability](ModelContextProtocol.Protocol.LoggingCapability.html)

### Prompts

Gets or sets a server's prompts capability for serving predefined prompt templates that clients can discover and use.

```
[JsonPropertyName("prompts")]
public PromptsCapability? Prompts { get; set; }
```

#### Property Value

[PromptsCapability](ModelContextProtocol.Protocol.PromptsCapability.html)

### Resources

Gets or sets a server's resources capability for serving predefined resources that clients can discover and use.

```
[JsonPropertyName("resources")]
public ResourcesCapability? Resources { get; set; }
```

#### Property Value

[ResourcesCapability](ModelContextProtocol.Protocol.ResourcesCapability.html)

### Tasks

Gets or sets a server's tasks capability for supporting task-augmented requests.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public McpTasksCapability? Tasks { get; set; }
```

#### Property Value

[McpTasksCapability](ModelContextProtocol.Protocol.McpTasksCapability.html)

#### Remarks

The tasks capability enables clients to augment their requests with tasks for long-running
operations. When present, clients can request that certain operations (like tool calls)
execute asynchronously, with the ability to poll for status and retrieve results later.

See [McpTasksCapability](ModelContextProtocol.Protocol.McpTasksCapability.html) for details on configuring which operations support tasks.

### Tools

Gets or sets a server's tools capability for listing tools that a client is able to invoke.

```
[JsonPropertyName("tools")]
public ToolsCapability? Tools { get; set; }
```

#### Property Value

[ToolsCapability](ModelContextProtocol.Protocol.ToolsCapability.html)




