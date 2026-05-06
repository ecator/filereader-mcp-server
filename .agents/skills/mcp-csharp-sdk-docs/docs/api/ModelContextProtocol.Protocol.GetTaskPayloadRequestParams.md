
##### Table of Contents

# Class GetTaskPayloadRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters for a tasks/result request to retrieve the result of a completed task.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class GetTaskPayloadRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    GetTaskPayloadRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This request blocks until the task reaches a terminal status ([Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed),
[Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed), or [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled)).

The result structure matches the original request type (e.g., [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) for tools/call).
This is distinct from the initial [Result](ModelContextProtocol.Protocol.Result.html) response, which contains only task data.

## Properties

### TaskId

Gets or sets the unique identifier of the task whose result to retrieve.

```
[JsonPropertyName("taskId")]
public required string TaskId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




