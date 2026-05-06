
##### Table of Contents

# Interface ISseEventStreamStore

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides storage and retrieval of SSE event streams, enabling resumability and redelivery of events.

```
public interface ISseEventStreamStore
```

## Methods

### CreateStreamAsync(SseEventStreamOptions, CancellationToken)

Creates a new SSE event stream with the specified options.

```
ValueTask<ISseEventStreamWriter> CreateStreamAsync(SseEventStreamOptions options, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [SseEventStreamOptions](ModelContextProtocol.Server.SseEventStreamOptions.html)
:   The configuration options for the new stream.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A token to cancel the operation.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ISseEventStreamWriter](ModelContextProtocol.Server.ISseEventStreamWriter.html)>
:   A writer for the newly created event stream.

### GetStreamReaderAsync(string, CancellationToken)

Gets a reader for an existing event stream based on the last event ID.

```
ValueTask<ISseEventStreamReader?> GetStreamReaderAsync(string lastEventId, CancellationToken cancellationToken = default)
```

#### Parameters

`lastEventId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The ID of the last event received by the client, used to resume from that point.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A token to cancel the operation.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ISseEventStreamReader](ModelContextProtocol.Server.ISseEventStreamReader.html)>
:   A reader for the event stream, or `null` if no matching stream is found.




