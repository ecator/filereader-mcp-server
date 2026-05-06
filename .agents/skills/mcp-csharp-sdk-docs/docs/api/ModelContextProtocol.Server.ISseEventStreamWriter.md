
##### Table of Contents

# Interface ISseEventStreamWriter

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides write access to an SSE event stream, allowing events to be written and tracked with unique IDs.

```
public interface ISseEventStreamWriter : IAsyncDisposable
```

Inherited Members
:   [IAsyncDisposable.DisposeAsync()](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable.disposeasync)

## Methods

### SetModeAsync(SseEventStreamMode, CancellationToken)

Sets the mode of the event stream.

```
ValueTask SetModeAsync(SseEventStreamMode mode, CancellationToken cancellationToken = default)
```

#### Parameters

`mode` [SseEventStreamMode](ModelContextProtocol.Server.SseEventStreamMode.html)
:   The new mode to set for the event stream.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A token to cancel the operation.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)
:   A task that represents the asynchronous operation.

### WriteEventAsync(SseItem<JsonRpcMessage?>, CancellationToken)

Writes an event to the stream.

```
ValueTask<SseItem<JsonRpcMessage?>> WriteEventAsync(SseItem<JsonRpcMessage?> sseItem, CancellationToken cancellationToken = default)
```

#### Parameters

`sseItem` SseItem<[JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)>
:   The original System.Net.ServerSentEvents.SseItem<T>.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A token to cancel the operation.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<SseItem<[JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)>>
:   A new System.Net.ServerSentEvents.SseItem<T> with a populated event ID.

#### Remarks

If the provided `sseItem` already has an event ID, this method skips writing the event.
Otherwise, an event ID unique to all sessions and streams is generated and assigned to the event.




