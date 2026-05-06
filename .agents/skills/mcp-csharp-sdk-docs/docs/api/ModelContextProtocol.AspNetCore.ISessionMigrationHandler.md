
##### Table of Contents

# Interface ISessionMigrationHandler

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[AspNetCore](ModelContextProtocol.AspNetCore.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Provides hooks for persisting and restoring MCP session initialization data,
enabling session migration across server instances.

```
public interface ISessionMigrationHandler
```

## Remarks

When an MCP server is horizontally scaled, stateful sessions are bound to a single process.
If that process restarts or scales down, the session is lost. By implementing this interface
and registering it with DI, you can persist the initialization handshake data and restore it
when a client reconnects to a different server instance with its existing `Mcp-Session-Id`.

This does **not** solve the session-affinity problem for in-flight server-to-client
requests (such as sampling or elicitation). Responses to those requests must still be routed to
the process that created the request. This interface only enables migration of idle sessions
by persisting the data established during the initialization handshake.

## Methods

### AllowSessionMigrationAsync(HttpContext, string, CancellationToken)

Called when a request arrives with an `Mcp-Session-Id` that the current server doesn't recognize.

```
ValueTask<InitializeRequestParams?> AllowSessionMigrationAsync(HttpContext context, string sessionId, CancellationToken cancellationToken)
```

#### Parameters

`context` [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext)
:   The [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) for the request with the unrecognized session ID.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The session ID from the request that was not found on this server.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A cancellation token.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html)>
:   The original [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html) if migration is allowed,
    or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) to reject the request.

#### Remarks

Return the original [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html) to allow the session to be migrated
to this server instance, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) to reject the request (returning a 404 to the client).

Implementations should validate that the request is authorized, for example by checking
[User](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext.user), to ensure the caller is permitted to migrate the session.

### OnSessionInitializedAsync(HttpContext, string, InitializeRequestParams, CancellationToken)

Called after a session has been successfully initialized via the MCP initialization handshake.

```
ValueTask OnSessionInitializedAsync(HttpContext context, string sessionId, InitializeRequestParams initializeParams, CancellationToken cancellationToken)
```

#### Parameters

`context` [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext)
:   The [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) for the initialization request.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier for the session.

`initializeParams` [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html)
:   The initialization parameters sent by the client during the handshake.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A cancellation token.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask) representing the asynchronous operation.

#### Remarks

Use this to persist the `initializeParams` (which includes client capabilities,
client info, and protocol version) to an external store so the session can be migrated to
another server instance later via [AllowSessionMigrationAsync(HttpContext, string, CancellationToken)](ModelContextProtocol.AspNetCore.ISessionMigrationHandler.html#ModelContextProtocol_AspNetCore_ISessionMigrationHandler_AllowSessionMigrationAsync_Microsoft_AspNetCore_Http_HttpContext_System_String_System_Threading_CancellationToken_).




