
##### Table of Contents

# Class GetTaskResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the result of a tasks/get request.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class GetTaskResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    GetTaskResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The result contains the current state of the task, including its status, timestamps,
and any status message.

## Properties

### CreatedAt

Gets or sets the ISO 8601 timestamp when the task was created.

```
[JsonPropertyName("createdAt")]
public required DateTimeOffset CreatedAt { get; set; }
```

#### Property Value

[DateTimeOffset](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

### LastUpdatedAt

Gets or sets the ISO 8601 timestamp when the task status was last updated.

```
[JsonPropertyName("lastUpdatedAt")]
public required DateTimeOffset LastUpdatedAt { get; set; }
```

#### Property Value

[DateTimeOffset](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

### PollInterval

Gets or sets the suggested time between status checks.

```
[JsonPropertyName("pollInterval")]
[JsonConverter(typeof(TimeSpanMillisecondsConverter))]
public TimeSpan? PollInterval { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?

### Status

Gets or sets the current status of the task.

```
[JsonPropertyName("status")]
public required McpTaskStatus Status { get; set; }
```

#### Property Value

[McpTaskStatus](ModelContextProtocol.Protocol.McpTaskStatus.html)

### StatusMessage

Gets or sets an optional human-readable message describing the current state.

```
[JsonPropertyName("statusMessage")]
public string? StatusMessage { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### TaskId

Gets or sets the task ID.

```
[JsonPropertyName("taskId")]
public required string TaskId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### TimeToLive

Gets or sets the time to live (retention duration) from creation before the task may be deleted.

```
[JsonPropertyName("ttl")]
[JsonConverter(typeof(TimeSpanMillisecondsConverter))]
public TimeSpan? TimeToLive { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?




