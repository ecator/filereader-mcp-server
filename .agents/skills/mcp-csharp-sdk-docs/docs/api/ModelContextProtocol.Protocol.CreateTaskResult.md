
##### Table of Contents

# Class CreateTaskResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the response to a task-augmented request.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class CreateTaskResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    CreateTaskResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

When a client sends a request with a `task` parameter, the server immediately returns
a [CreateTaskResult](ModelContextProtocol.Protocol.CreateTaskResult.html) containing the created task information instead of the
normal result type. The actual result can be retrieved later via `tasks/result`.

This type is returned for any task-augmented request including `tools/call`,
`sampling/createMessage`, and `elicitation/create`.

## Properties

### Task

Gets or sets the task data for the newly created task.

```
[JsonPropertyName("task")]
public McpTask Task { get; set; }
```

#### Property Value

[McpTask](ModelContextProtocol.Protocol.McpTask.html)




