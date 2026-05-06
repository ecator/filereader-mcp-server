
##### Table of Contents

# Interface ISseEventStreamReader

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides read access to an SSE event stream, allowing events to be consumed asynchronously.

```
public interface ISseEventStreamReader
```

## Properties

### SessionId

Gets the session ID associated with the stream being read.

```
string SessionId { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### StreamId

Gets the ID of the stream.

```
string StreamId { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value is guaranteed to be unique on a per-session basis.

## Methods

### ReadEventsAsync(CancellationToken)

Gets the messages from the stream as an [IAsyncEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.iasyncenumerable-1).

```
IAsyncEnumerable<SseItem<JsonRpcMessage?>> ReadEventsAsync(CancellationToken cancellationToken = default)
```

#### Parameters

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A token to cancel the operation.

#### Returns

[IAsyncEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.iasyncenumerable-1)<SseItem<[JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)>>
:   An [IAsyncEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.iasyncenumerable-1) of System.Net.ServerSentEvents.SseItem<T> containing JSON-RPC messages.

#### Remarks

If the stream's mode is set to [Polling](ModelContextProtocol.Server.SseEventStreamMode.html#ModelContextProtocol_Server_SseEventStreamMode_Polling), the returned
messages will only include the currently-available events starting at the last event ID specified
when the reader was created. Otherwise, the returned messages will continue until the associated
[ISseEventStreamWriter](ModelContextProtocol.Server.ISseEventStreamWriter.html) is disposed.




