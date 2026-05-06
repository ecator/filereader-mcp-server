
##### Table of Contents

# Class DistributedCacheEventStreamStore

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.dll

An [ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html) implementation backed by [IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache).

```
public sealed class DistributedCacheEventStreamStore : ISseEventStreamStore
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    DistributedCacheEventStreamStore

Implements
:   [ISseEventStreamStore](ModelContextProtocol.Server.ISseEventStreamStore.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This implementation stores SSE events in a distributed cache, enabling resumability across
multiple server instances. Event IDs are encoded with session, stream, and sequence information
to allow efficient retrieval of events after a given point.

The writer maintains in-memory state for sequence number generation, as there is guaranteed
to be only one writer per stream. Readers may be created from separate processes.

## Constructors

### DistributedCacheEventStreamStore(IOptions<DistributedCacheEventStreamStoreOptions>, ILogger<DistributedCacheEventStreamStore>?)

Initializes a new instance of the [DistributedCacheEventStreamStore](ModelContextProtocol.Server.DistributedCacheEventStreamStore.html) class.

```
public DistributedCacheEventStreamStore(IOptions<DistributedCacheEventStreamStoreOptions> options, ILogger<DistributedCacheEventStreamStore>? logger = null)
```

#### Parameters

`options` [IOptions](https://learn.microsoft.com/dotnet/api/microsoft.extensions.options.ioptions-1)<[DistributedCacheEventStreamStoreOptions](ModelContextProtocol.Server.DistributedCacheEventStreamStoreOptions.html)>
:   Configuration options for the store, including the [IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache) to use.

`logger` [ILogger](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger-1)<[DistributedCacheEventStreamStore](ModelContextProtocol.Server.DistributedCacheEventStreamStore.html)>
:   Optional logger for diagnostic output.

## Methods

### CreateStreamAsync(SseEventStreamOptions, CancellationToken)

Creates a new SSE event stream with the specified options.

```
public ValueTask<ISseEventStreamWriter> CreateStreamAsync(SseEventStreamOptions options, CancellationToken cancellationToken = default)
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
public ValueTask<ISseEventStreamReader?> GetStreamReaderAsync(string lastEventId, CancellationToken cancellationToken = default)
```

#### Parameters

`lastEventId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The ID of the last event received by the client, used to resume from that point.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A token to cancel the operation.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ISseEventStreamReader](ModelContextProtocol.Server.ISseEventStreamReader.html)>
:   A reader for the event stream, or `null` if no matching stream is found.



