
##### Table of Contents

# Class InMemoryMcpTaskStore

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an in-memory implementation of [IMcpTaskStore](ModelContextProtocol.IMcpTaskStore.html) for development and testing.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class InMemoryMcpTaskStore : IMcpTaskStore, IDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    InMemoryMcpTaskStore

Implements
:   [IMcpTaskStore](ModelContextProtocol.IMcpTaskStore.html)

    [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This implementation uses thread-safe concurrent collections and is suitable for single-server
scenarios and testing. It is not recommended for production multi-server deployments as tasks
are stored only in memory and are lost on server restart.

Features:

* Thread-safe operations using [ConcurrentDictionary<TKey, TValue>](https://learn.microsoft.com/dotnet/api/system.collections.concurrent.concurrentdictionary-2)
* Automatic TTL-based cleanup via background task
* Session-based isolation when sessionId is provided
* Configurable default TTL and maximum TTL limits

## Constructors

### InMemoryMcpTaskStore(TimeSpan?, TimeSpan?, TimeSpan?, TimeSpan?, int, int?, int?)

Initializes a new instance of the [InMemoryMcpTaskStore](ModelContextProtocol.InMemoryMcpTaskStore.html) class.

```
public InMemoryMcpTaskStore(TimeSpan? defaultTtl = null, TimeSpan? maxTtl = null, TimeSpan? pollInterval = null, TimeSpan? cleanupInterval = null, int pageSize = 100, int? maxTasks = null, int? maxTasksPerSession = null)
```

#### Parameters

`defaultTtl` [TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?
:   Default TTL to use when task creation does not specify a TTL. Null means unlimited.

`maxTtl` [TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?
:   Maximum TTL allowed. If a task requests a longer TTL, it will be capped to this value.
    Null means no maximum limit.

`pollInterval` [TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?
:   Advertised polling interval for tasks. Default is 1 second.
    This value is used when creating new tasks to indicate how frequently clients should poll for updates.

`cleanupInterval` [TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?
:   Interval for running background cleanup of expired tasks. Default is 1 minute.
    Pass [InfiniteTimeSpan](https://learn.microsoft.com/dotnet/api/system.threading.timeout.infinitetimespan) to disable automatic cleanup.

`pageSize` [int](https://learn.microsoft.com/dotnet/api/system.int32)
:   Maximum number of tasks to return per page in [ListTasksAsync(string?, string?, CancellationToken)](ModelContextProtocol.InMemoryMcpTaskStore.html#ModelContextProtocol_InMemoryMcpTaskStore_ListTasksAsync_System_String_System_String_System_Threading_CancellationToken_). Default is 100.

`maxTasks` [int](https://learn.microsoft.com/dotnet/api/system.int32)?
:   Maximum number of tasks allowed in the store globally. Null means unlimited.
    When the limit is reached, [CreateTaskAsync(McpTaskMetadata, RequestId, JsonRpcRequest, string?, CancellationToken)](ModelContextProtocol.InMemoryMcpTaskStore.html#ModelContextProtocol_InMemoryMcpTaskStore_CreateTaskAsync_ModelContextProtocol_Protocol_McpTaskMetadata_ModelContextProtocol_Protocol_RequestId_ModelContextProtocol_Protocol_JsonRpcRequest_System_String_System_Threading_CancellationToken_) will throw [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception).

`maxTasksPerSession` [int](https://learn.microsoft.com/dotnet/api/system.int32)?
:   Maximum number of tasks allowed per session. Null means unlimited.
    When the limit is reached for a session, [CreateTaskAsync(McpTaskMetadata, RequestId, JsonRpcRequest, string?, CancellationToken)](ModelContextProtocol.InMemoryMcpTaskStore.html#ModelContextProtocol_InMemoryMcpTaskStore_CreateTaskAsync_ModelContextProtocol_Protocol_McpTaskMetadata_ModelContextProtocol_Protocol_RequestId_ModelContextProtocol_Protocol_JsonRpcRequest_System_String_System_Threading_CancellationToken_) will throw [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception).

## Methods

### CancelTaskAsync(string, string?, CancellationToken)

Attempts to cancel a task, transitioning it to [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled) status.

```
public Task<McpTask> CancelTaskAsync(string taskId, string? sessionId = null, CancellationToken cancellationToken = default)
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
public Task<McpTask> CreateTaskAsync(McpTaskMetadata taskParams, RequestId requestId, JsonRpcRequest request, string? sessionId = null, CancellationToken cancellationToken = default)
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

### Dispose()

Disposes the task store and stops background cleanup.

```
public void Dispose()
```

### GetTaskAsync(string, string?, CancellationToken)

Retrieves a task by its unique identifier.

```
public Task<McpTask?> GetTaskAsync(string taskId, string? sessionId = null, CancellationToken cancellationToken = default)
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
public Task<JsonElement> GetTaskResultAsync(string taskId, string? sessionId = null, CancellationToken cancellationToken = default)
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
public Task<ListTasksResult> ListTasksAsync(string? cursor = null, string? sessionId = null, CancellationToken cancellationToken = default)
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
public Task<McpTask> StoreTaskResultAsync(string taskId, McpTaskStatus status, JsonElement result, string? sessionId = null, CancellationToken cancellationToken = default)
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
public Task<McpTask> UpdateTaskStatusAsync(string taskId, McpTaskStatus status, string? statusMessage, string? sessionId = null, CancellationToken cancellationToken = default)
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




