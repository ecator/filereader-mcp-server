
##### Table of Contents

# Class SseEventStreamOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Configuration options for creating an SSE event stream.

```
public sealed class SseEventStreamOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    SseEventStreamOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Mode

Gets or sets the mode of the event stream. Defaults to [Streaming](ModelContextProtocol.Server.SseEventStreamMode.html#ModelContextProtocol_Server_SseEventStreamMode_Streaming).

```
public SseEventStreamMode Mode { get; set; }
```

#### Property Value

[SseEventStreamMode](ModelContextProtocol.Server.SseEventStreamMode.html)

### SessionId

Gets or sets the session ID associated with the event stream.

```
public required string SessionId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### StreamId

Gets or sets the stream ID that uniquely identifies this stream within a session.

```
public required string StreamId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




