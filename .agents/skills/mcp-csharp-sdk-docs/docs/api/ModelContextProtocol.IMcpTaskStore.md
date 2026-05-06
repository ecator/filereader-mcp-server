
##### Table of Contents

# Interface IMcpTaskStore

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an interface for pluggable task storage implementations in MCP servers.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public interface IMcpTaskStore
```

## Remarks

The task store is responsible for managing the lifecycle of tasks, including creation,
status updates, result storage, and retrieval. Implementations must be thread-safe and
may support session-based isolation for multi-session scenarios.

TTL (Time To Live) Management: Implementations may override the requested TTL value in
[TimeToLive](ModelContextProtocol.Protocol.McpTaskMetadata.html#ModelContextProtocol_Protocol_McpTaskMetadata_TimeToLive) to enforce resource limits. The actual TTL
used is returned in the [TimeToLive](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_TimeToLive) property. A null TTL indicates
unlimited lifetime. Tasks may be deleted after their TTL expires, regardless of status.

## Methods

### CancelTaskAsync(string, string?, CancellationToken)

Attempts to cancel a task, transitioning it to [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled) status.

```
Task<McpTask> CancelTaskAsync(string taskId, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to cancel.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for access control.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The updated [McpTask](ModelContextProtocol.Protocol.McpTask.html). If the task is already in a terminal state
    ([Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed), [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed), or
    [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled)), the task is returned unchanged.

#### Remarks

This method must be idempotent. If called on a task that is already in a terminal state,
it returns the current task without error. This behavior differs from the MCP specification
but ensures idempotency and avoids race conditions between cancellation and task completion.

For tasks not in a terminal state, the implementation should attempt to stop the underlying
operation and transition the task to [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled) status before returning.

### CreateTaskAsync(McpTaskMetadata, RequestId, JsonRpcRequest, string?, CancellationToken)

Creates a new task for tracking an asynchronous operation.

```
Task<McpTask> CreateTaskAsync(McpTaskMetadata taskParams, RequestId requestId, JsonRpcRequest request, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskParams` [McpTaskMetadata](ModelContextProtocol.Protocol.McpTaskMetadata.html)
:   Metadata for the task, including requested TTL.

`requestId` [RequestId](ModelContextProtocol.Protocol.RequestId.html)
:   The JSON-RPC request ID that initiated this task.

`request` [JsonRpcRequest](ModelContextProtocol.Protocol.JsonRpcRequest.html)
:   The original JSON-RPC request that triggered task creation.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for multi-session isolation.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   A new [McpTask](ModelContextProtocol.Protocol.McpTask.html) with a unique task ID, initial status of [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working),
    and the actual TTL that will be used (which may differ from the requested TTL).

#### Remarks

Implementations must generate a unique task ID and set the [CreatedAt](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_CreatedAt)
and [LastUpdatedAt](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_LastUpdatedAt) timestamps. The implementation may override the
requested TTL to enforce storage limits.

### GetTaskAsync(string, string?, CancellationToken)

Retrieves a task by its unique identifier.

```
Task<McpTask?> GetTaskAsync(string taskId, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to retrieve.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for access control.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The [McpTask](ModelContextProtocol.Protocol.McpTask.html) if found and accessible, otherwise [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

#### Remarks

Returns null if the task does not exist or if session-based access control denies access.

### GetTaskResultAsync(string, string?, CancellationToken)

Retrieves the stored result of a completed or failed task.

```
Task<JsonElement> GetTaskResultAsync(string taskId, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for access control.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)>
:   The stored operation result as a JSON element.

#### Remarks

This method should only be called on tasks in terminal states ([Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed)
or [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed)). The result contains the JSON representation of the
original operation result (e.g., [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) for tools/call).

### ListTasksAsync(string?, string?, CancellationToken)

Lists tasks with pagination support.

```
Task<ListTasksResult> ListTasksAsync(string? cursor = null, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`cursor` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional cursor for pagination, from a previous call's nextCursor value.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for filtering tasks by session.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html)>
:   A [ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html) containing the tasks and an optional cursor for the next page.

#### Remarks

When `sessionId` is provided, implementations should filter to only return
tasks associated with that session. The cursor format is implementation-specific.

### StoreTaskResultAsync(string, McpTaskStatus, JsonElement, string?, CancellationToken)

Stores the final result of a task that has reached a terminal status.

```
Task<McpTask> StoreTaskResultAsync(string taskId, McpTaskStatus status, JsonElement result, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task.

`status` [McpTaskStatus](ModelContextProtocol.Protocol.McpTaskStatus.html)
:   The terminal status: [Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed) or [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed).

`result` [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)
:   The operation result to store as a JSON element.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for access control.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The updated [McpTask](ModelContextProtocol.Protocol.McpTask.html) with the new status and result stored.

#### Remarks

The `status` must be either [Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed) or
[Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed). This method updates the task status and stores
the result for later retrieval via [GetTaskResultAsync(string, string?, CancellationToken)](ModelContextProtocol.IMcpTaskStore.html#ModelContextProtocol_IMcpTaskStore_GetTaskResultAsync_System_String_System_String_System_Threading_CancellationToken_).

Implementations should throw [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) if called on a task
that is already in a terminal state, to prevent result overwrites.

### UpdateTaskStatusAsync(string, McpTaskStatus, string?, string?, CancellationToken)

Updates the status and optional status message of a task.

```
Task<McpTask> UpdateTaskStatusAsync(string taskId, McpTaskStatus status, string? statusMessage, string? sessionId = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task.

`status` [McpTaskStatus](ModelContextProtocol.Protocol.McpTaskStatus.html)
:   The new status to set.

`statusMessage` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional diagnostic message describing the status change.

`sessionId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional session identifier for access control.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   Cancellation token for the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The updated [McpTask](ModelContextProtocol.Protocol.McpTask.html) with the new status applied.

#### Remarks

This method updates the task's [Status](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_Status), [StatusMessage](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_StatusMessage),
and [LastUpdatedAt](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_LastUpdatedAt) properties. Common uses include transitioning to
[Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled), [InputRequired](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_InputRequired), or updating
progress messages while in [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working) status.




