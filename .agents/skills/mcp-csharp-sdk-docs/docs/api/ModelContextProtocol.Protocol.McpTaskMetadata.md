
##### Table of Contents

# Class McpTaskMetadata

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents metadata for augmenting a request with task execution.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class McpTaskMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpTaskMetadata

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

When included in a request's params, this metadata signals that the requestor
wants the receiver to execute the request as a task rather than synchronously.
The receiver will return a [Result](ModelContextProtocol.Protocol.Result.html) containing task data
instead of the actual operation result.

Requestors can specify a desired TTL (time-to-live) duration for the task,
though receivers may override this value based on their resource management policies.

## Properties

### TimeToLive

Gets or sets the requested time to live (retention duration) to retain the task from creation.

```
[JsonPropertyName("ttl")]
[JsonConverter(typeof(TimeSpanMillisecondsConverter))]
public TimeSpan? TimeToLive { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)?

#### Remarks

This is a hint to the receiver about how long the requestor expects to need access
to the task data. Receivers may override this value based on their resource constraints
and policies.

A null value indicates no specific retention requirement. The actual TTL used by the
receiver will be returned in the [TimeToLive](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_TimeToLive) property.




