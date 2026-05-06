
##### Table of Contents

# Class DistributedCacheEventStreamStoreOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.dll

Configuration options for [DistributedCacheEventStreamStore](ModelContextProtocol.Server.DistributedCacheEventStreamStore.html).

```
public sealed class DistributedCacheEventStreamStoreOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    DistributedCacheEventStreamStoreOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Cache

Gets or sets the [IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache) to use for event storage.

```
public IDistributedCache? Cache { get; set; }
```

#### Property Value

[IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache)

#### Remarks

When using dependency injection with `WithDistributedCacheEventStreamStore()`, this is
automatically populated from the [IDistributedCache](https://learn.microsoft.com/dotnet/api/microsoft.extensions.caching.distributed.idistributedcache) registered in DI.
Set this property explicitly to use a specific cache instance.

### EventAbsoluteExpiration

Gets or sets the absolute expiration for individual events in the cache.

```
public TimeSpan? EventAbsoluteExpiration { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?

#### Remarks

Events will be evicted from the cache after this time period, regardless of access.

### EventSlidingExpiration

Gets or sets the sliding expiration for individual events in the cache.

```
public TimeSpan? EventSlidingExpiration { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?

#### Remarks

Events are refreshed on each access. If an event is not accessed within this
time period, it may be evicted from the cache.

### MetadataAbsoluteExpiration

Gets or sets the absolute expiration for stream metadata in the cache.

```
public TimeSpan? MetadataAbsoluteExpiration { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?

#### Remarks

Stream metadata will be evicted from the cache after this time period, regardless of access.

### MetadataSlidingExpiration

Gets or sets the sliding expiration for stream metadata in the cache.

```
public TimeSpan? MetadataSlidingExpiration { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?

#### Remarks

Stream metadata includes mode and completion status. This should typically be
set to a longer duration than event expiration to allow for resumability.

### StreamReaderPollingInterval

Gets or sets the interval between polling attempts when a stream reader is waiting for new events
in the default [Streaming](ModelContextProtocol.Server.SseEventStreamMode.html#ModelContextProtocol_Server_SseEventStreamMode_Streaming) mode.

```
public TimeSpan StreamReaderPollingInterval { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)

#### Remarks

This only affects stream readers. A shorter interval provides lower latency for new events
but increases cache access frequency.




