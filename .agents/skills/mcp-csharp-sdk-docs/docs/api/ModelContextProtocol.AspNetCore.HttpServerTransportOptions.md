
##### Table of Contents

# Class HttpServerTransportOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[AspNetCore](ModelContextProtocol.AspNetCore.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Represents configuration options for McpEndpointRouteBuilderExtensions.MapMcp,
which implements the Streamable HTTP transport for the Model Context Protocol.
See the protocol specification for details on the Streamable HTTP transport. <https://modelcontextprotocol.io/specification/2025-11-25/basic/transports#streamable-http>

```
public class HttpServerTransportOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    HttpServerTransportOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

For details on the Streamable HTTP transport, see the [protocol specification](https://modelcontextprotocol.io/specification/2025-11-25/basic/transports#streamable-http).

## Properties

### ConfigureSessionOptions

Gets or sets an optional asynchronous callback to configure per-session [McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html)
with access to the [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) of the request that initiated the session.

```
public Func<HttpContext, McpServerOptions, CancellationToken, Task>? ConfigureSessionOptions { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-4)<[HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext), [McpServerOptions](ModelContextProtocol.Server.McpServerOptions.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)>

#### Remarks

In stateful mode (the default), this callback is invoked once per session when the client sends the
`initialize` request. In [Stateless](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_Stateless) mode, it is invoked on **every HTTP request**
because each request creates a fresh server context.

### EnableLegacySse

Gets or sets a value that indicates whether the server maps legacy SSE endpoints (`/sse` and `/message`)
for backward compatibility with clients that do not support the Streamable HTTP transport.

```
[Obsolete("Legacy SSE transport has no built-in request backpressure and should only be used with completely trusted clients in isolated processes. Use Streamable HTTP instead.", DiagnosticId = "MCP9004", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#obsolete-apis")]
public bool EnableLegacySse { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to map the legacy SSE endpoints; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to disable them. The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

The legacy SSE transport separates request and response channels: clients POST JSON-RPC messages
to `/message` and receive responses through a long-lived GET SSE stream on `/sse`.
Because the POST endpoint returns `202 Accepted` immediately, there is no HTTP-level
backpressure on handler concurrency — unlike Streamable HTTP, where each POST is held open
until the handler responds.

Use Streamable HTTP instead whenever possible. If you must support legacy SSE clients,
enable this property only for completely trusted clients in isolated processes, and apply
HTTP rate-limiting middleware and reverse proxy limits to compensate for the lack of
built-in backpressure.

Setting this to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) while [Stateless](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_Stateless) is also [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool)
throws an [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) at startup, because SSE requires in-memory session state.

This property can also be enabled via the `ModelContextProtocol.AspNetCore.EnableLegacySse`
[AppContext](https://learn.microsoft.com/dotnet/api/system.appcontext) switch.

### EventStreamStore

Gets or sets the event store for resumability support.
When set, events are stored and can be replayed when clients reconnect with a Last-Event-ID header.

```
public ISseEventStreamStore? EventStreamStore { get; set; }
```

#### Property Value

[ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html)

#### Remarks

When configured, the server will:

* Generate unique event IDs for each SSE message
* Store events for later replay
* Replay missed events when a client reconnects with a Last-Event-ID header
* Send priming events to establish resumability before any actual messages

This can be set directly, or an [ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html) can be registered in DI.
If this property is not set, the server will attempt to resolve an [ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html) from DI.

### IdleTimeout

Gets or sets the duration of time the server will wait between any active requests before timing out an MCP session.

```
public TimeSpan IdleTimeout { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)
:   The amount of time the server waits between any active requests before timing out an MCP session. The default is 2 hours.

#### Remarks

This value is checked in the background every 5 seconds. A client trying to resume a session will receive a 404 status code
and should restart their session. A client can keep their session open by keeping a GET request open.

Legacy SSE sessions (when [EnableLegacySse](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_EnableLegacySse) is enabled) are not subject to this timeout — their lifetime is
tied to the open GET `/sse` request, and they are removed immediately when the client disconnects.

### MaxIdleSessionCount

Gets or sets the maximum number of idle sessions to track in memory. This value is used to limit the number of sessions that can be idle at once.

```
public int MaxIdleSessionCount { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)
:   The maximum number of idle sessions to track in memory. The default is 10,000 sessions.

#### Remarks

Past this limit, the server logs a critical error and terminates the oldest idle sessions, even if they have not reached
their [IdleTimeout](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_IdleTimeout), until the idle session count is below this limit. Sessions with any active HTTP request
are not considered idle and don't count towards this limit.

Legacy SSE sessions (when [EnableLegacySse](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_EnableLegacySse) is enabled) are never considered idle because their lifetime is
tied to the open GET `/sse` request. They are not subject to [IdleTimeout](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_IdleTimeout) or this limit — they exist
exactly as long as the SSE connection is open.

### PerSessionExecutionContext

Gets or sets a value that indicates whether the server uses a single execution context for the entire session.

```
public bool PerSessionExecutionContext { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the server uses a single execution context for the entire session; otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool). The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

If [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), handlers like tools get called with the [ExecutionContext](https://learn.microsoft.com/dotnet/api/system.threading.executioncontext)
belonging to the corresponding HTTP request, which can change throughout the MCP session.
If [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), handlers will get called with the same [ExecutionContext](https://learn.microsoft.com/dotnet/api/system.threading.executioncontext)
used to call [ConfigureSessionOptions](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_ConfigureSessionOptions) and [RunSessionHandler](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_RunSessionHandler).
Enabling a per-session [ExecutionContext](https://learn.microsoft.com/dotnet/api/system.threading.executioncontext) can be useful for setting [AsyncLocal<T>](https://learn.microsoft.com/dotnet/api/system.threading.asynclocal-1) variables
that persist for the entire session, but it prevents you from using IHttpContextAccessor in handlers.

### RunSessionHandler

Gets or sets an optional asynchronous callback for running new MCP sessions manually.

```
[Experimental("MCPEXP002", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp002")]
public Func<HttpContext, McpServer, CancellationToken, Task>? RunSessionHandler { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-4)<[HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext), [McpServer](ModelContextProtocol.Server.McpServer.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)>

#### Remarks

This callback is useful for running logic before a session starts and after it completes.

The [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) parameter comes from the request that initiated the session (e.g., the
initialize request) and may not be usable after [RunAsync(CancellationToken)](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_RunAsync_System_Threading_CancellationToken_) starts, since that
request will have already completed.

Consider using [ConfigureSessionOptions](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_ConfigureSessionOptions) instead, which provides access to the
[HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) of the initializing request with fewer known issues.

This API is experimental and may be removed or change signatures in a future release.

### SessionMigrationHandler

Gets or sets the session migration handler for cross-instance session migration.

```
public ISessionMigrationHandler? SessionMigrationHandler { get; set; }
```

#### Property Value

[ISessionMigrationHandler](ModelContextProtocol.AspNetCore.ISessionMigrationHandler.html)

#### Remarks

When configured, the server will support session migration between instances.
If a request arrives with a session ID that is not found locally, the handler
is consulted to determine if the session can be migrated from another instance.

This can be set directly, or an [ISessionMigrationHandler](ModelContextProtocol.AspNetCore.ISessionMigrationHandler.html) can be registered in DI.
If this property is not set, the server will attempt to resolve an [ISessionMigrationHandler](ModelContextProtocol.AspNetCore.ISessionMigrationHandler.html) from DI.

### Stateless

Gets or sets a value that indicates whether the server runs in a stateless mode that doesn't track state between requests,
allowing for load balancing without session affinity.

```
public bool Stateless { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the server runs in a stateless mode; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the server tracks state between requests. The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

If [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), [SessionId](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SessionId) will be null, and the "MCP-Session-Id" header will not be used,
the [RunSessionHandler](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_RunSessionHandler) will be called once for each request, and the "/sse" endpoint will be disabled.
Unsolicited server-to-client messages and all server-to-client requests are also unsupported, because any responses
might arrive at another ASP.NET Core application process.
Client sampling, elicitation, and roots capabilities are also disabled in stateless mode, because the server cannot make requests.

### TimeProvider

Gets or sets the time provider that's used for testing the [IdleTimeout](ModelContextProtocol.AspNetCore.HttpServerTransportOptions.html#ModelContextProtocol_AspNetCore_HttpServerTransportOptions_IdleTimeout).

```
public TimeProvider TimeProvider { get; set; }
```

#### Property Value

[TimeProvider](https://learn.microsoft.com/dotnet/api/system.timeprovider)




