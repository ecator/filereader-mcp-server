
##### Table of Contents

# Class McpServerOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides configuration options for the MCP server.

```
public sealed class McpServerOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Capabilities

Gets or sets server capabilities to advertise to the client.

```
public ServerCapabilities? Capabilities { get; set; }
```

#### Property Value

[ServerCapabilities](ModelContextProtocol.Protocol.ServerCapabilities.html)

#### Remarks

These determine which features will be available when a client connects.
Capabilities can include "tools", "prompts", "resources", "logging", and other
protocol-specific functionality.

### Filters

Gets or sets the filter collections for MCP server handlers.

```
public McpServerFilters Filters { get; set; }
```

#### Property Value

[McpServerFilters](ModelContextProtocol.Server.McpServerFilters.html)

#### Remarks

This property provides access to filter collections that can be used to modify the behavior
of various MCP server handlers. The first filter added is the outermost (first to execute),
and each subsequent filter wraps closer to the handler.

### Handlers

Gets or sets the container of handlers used by the server for processing protocol messages.

```
public McpServerHandlers Handlers { get; set; }
```

#### Property Value

[McpServerHandlers](ModelContextProtocol.Server.McpServerHandlers.html)

### InitializationTimeout

Gets or sets a timeout used for the client-server initialization handshake sequence.

```
public TimeSpan InitializationTimeout { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)

#### Remarks

This timeout determines how long the server will wait for client responses during
the initialization protocol handshake. If the client doesn't respond within this timeframe,
the initialization process will be aborted.

### KnownClientCapabilities

Gets or sets preexisting knowledge about the client's capabilities to support session migration
scenarios where the client will not re-send the initialize request.

```
public ClientCapabilities? KnownClientCapabilities { get; set; }
```

#### Property Value

[ClientCapabilities](ModelContextProtocol.Protocol.ClientCapabilities.html)

#### Remarks

When not specified, this information is sourced from the client's initialize request.
This is typically set during session migration in conjunction with [KnownClientInfo](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_KnownClientInfo).

### KnownClientInfo

Gets or sets preexisting knowledge about the client including its name and version to help support
stateless Streamable HTTP servers that encode this knowledge in the mcp-session-id header.

```
public Implementation? KnownClientInfo { get; set; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

When not specified, this information is sourced from the client's initialize request.

### MaxSamplingOutputTokens

Gets or sets the default maximum number of tokens to use for sampling requests when not explicitly specified.

```
public int MaxSamplingOutputTokens { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)
:   The default maximum number of tokens to use for sampling requests. The default value is 1000 tokens.

#### Remarks

This value is used in [SampleAsync(IEnumerable<ChatMessage>, ChatOptions?, JsonSerializerOptions?, CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_SampleAsync_System_Collections_Generic_IEnumerable_Microsoft_Extensions_AI_ChatMessage__Microsoft_Extensions_AI_ChatOptions_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)
when Microsoft.Extensions.AI.ChatOptions.MaxOutputTokens is not set in the request options.

### PromptCollection

Gets or sets a collection of prompts that will be served by the server.

```
public McpServerPrimitiveCollection<McpServerPrompt>? PromptCollection { get; set; }
```

#### Property Value

[McpServerPrimitiveCollection](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html)<[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)>

#### Remarks

The [PromptCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_PromptCollection) contains the predefined prompts that clients can request from the server.
This collection works in conjunction with [ListPromptsHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ListPromptsHandler) and [GetPromptHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_GetPromptHandler)
when those are provided:

- For [PromptsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsList) requests: The server returns all prompts from this collection
plus any additional prompts provided by the [ListPromptsHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ListPromptsHandler) if it's set.

- For [PromptsGet](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsGet) requests: The server first checks this collection for the requested prompt.
If not found, it will invoke the [GetPromptHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_GetPromptHandler) as a fallback if one is set.

### ProtocolVersion

Gets or sets the protocol version supported by this server, using a date-based versioning scheme.

```
public string? ProtocolVersion { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The protocol version defines which features and message formats this server supports.
This uses a date-based versioning scheme in the format "YYYY-MM-DD".
If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the server will advertise to the client the version requested
by the client if that version is known to be supported, and otherwise will advertise the latest
version supported by the server.

### ResourceCollection

Gets or sets a collection of resources served by the server.

```
public McpServerResourceCollection? ResourceCollection { get; set; }
```

#### Property Value

[McpServerResourceCollection](ModelContextProtocol.Server.McpServerResourceCollection.html)

#### Remarks

Resources specified via [ResourceCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ResourceCollection) augment the [ListResourcesHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ListResourcesHandler), [ListResourceTemplatesHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ListResourceTemplatesHandler)
and [ReadResourceHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ReadResourceHandler) handlers, if provided. Resources with template expressions in their URI templates are considered resource templates
and are listed via ListResourceTemplate, whereas resources without template parameters are considered static resources and are listed with ListResources.

ReadResource requests will first check the [ResourceCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ResourceCollection) for the exact resource being requested. If no match is found, they'll proceed to
try to match the resource against each resource template in [ResourceCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ResourceCollection). If no match is still found, the request will fall back to
any handler registered for [ReadResourceHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ReadResourceHandler).

### ScopeRequests

Gets or sets a value that indicates whether to create a new service provider scope for each handled request.

```
public bool ScopeRequests { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if each invocation of a request handler is invoked within a new service scope.
    The default is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### SendTaskStatusNotifications

Gets or sets whether to send task status notifications to clients.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public bool SendTaskStatusNotifications { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to send optional `notifications/tasks/status` notifications when task status changes;
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to not send notifications. The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

When enabled, the server will send `notifications/tasks/status` notifications to inform clients
of task state changes. According to the MCP specification, these notifications are optional and
receivers MAY send them but are not required to.

Clients must not rely on receiving these notifications and should continue polling via `tasks/get`
requests to ensure they receive status updates.

Even when this is set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), notifications are only sent when [TaskStore](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_TaskStore)
is configured, as task-augmented requests require a task store.

### ServerInfo

Gets or sets information about this server implementation, including its name and version.

```
public Implementation? ServerInfo { get; set; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

This information is sent to the client during initialization to identify the server.
It's displayed in client logs and can be used for debugging and compatibility checks.

### ServerInstructions

Gets or sets optional server instructions to send to clients.

```
public string? ServerInstructions { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

These instructions are sent to clients during the initialization handshake and provide
guidance on how to effectively use the server's capabilities. They should focus on
information that helps models use the server effectively and should not duplicate
tool, prompt, or resource descriptions already exposed elsewhere.
Client applications typically use these instructions as system messages for LLM interactions
to provide context about available functionality.

### TaskStore

Gets or sets the task store for managing asynchronous task execution.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public IMcpTaskStore? TaskStore { get; set; }
```

#### Property Value

[IMcpTaskStore](ModelContextProtocol.IMcpTaskStore.html)

#### Remarks

When non-null, enables explicit task support with persistence, allowing clients to:

* Execute operations asynchronously by augmenting requests with task metadata
* Poll for task status via tasks/get requests
* Retrieve task results via tasks/result requests
* List all tasks via tasks/list requests
* Cancel tasks via tasks/cancel requests

When null, implicit task support may still be available for async methods (returning [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task) or
[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)), but tasks will be ephemeral and not persisted. Use [InMemoryMcpTaskStore](ModelContextProtocol.InMemoryMcpTaskStore.html)
for development/testing or implement [IMcpTaskStore](ModelContextProtocol.IMcpTaskStore.html) for production scenarios.

The server will automatically advertise task capabilities based on the presence of a task store
and the detection of async server primitives (tools, prompts, resources).

### ToolCollection

Gets or sets a collection of tools served by the server.

```
public McpServerPrimitiveCollection<McpServerTool>? ToolCollection { get; set; }
```

#### Property Value

[McpServerPrimitiveCollection](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html)<[McpServerTool](ModelContextProtocol.Server.McpServerTool.html)>

#### Remarks

Tools specified via [ToolCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ToolCollection) augment the [ListToolsHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ListToolsHandler) and
[CallToolHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_CallToolHandler), if provided. ListTools requests will output information about every tool
in [ToolCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ToolCollection) and then also any tools output by [ListToolsHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_ListToolsHandler), if it's
non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null). CallTool requests will first check [ToolCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ToolCollection) for the tool
being requested, and if the tool is not found in the [ToolCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_ToolCollection), any specified [CallToolHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_CallToolHandler)
will be invoked as a fallback.




