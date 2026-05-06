
##### Table of Contents

# Class ListTasksResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the result of a tasks/list request.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class ListTasksResult : PaginatedResult
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html)

    ListTasksResult

Inherited Members
:   [PaginatedResult.NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor)

    [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The result contains an array of task objects and an optional cursor for pagination.
If [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor) is present, more tasks are available.

## Properties

### Tasks

Gets or sets the list of tasks.

```
[JsonPropertyName("tasks")]
public required IList<McpTask> Tasks { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>




