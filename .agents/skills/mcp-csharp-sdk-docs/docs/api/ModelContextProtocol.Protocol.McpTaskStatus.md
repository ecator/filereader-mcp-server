
##### Table of Contents

# Enum McpTaskStatus

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the status of an MCP task.

```
[JsonConverter(typeof(JsonStringEnumConverter<McpTaskStatus>))]
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public enum McpTaskStatus
```

## Fields

`[JsonStringEnumMemberName("cancelled")] Cancelled = 4`
:   The request was cancelled before completion.

    This is a terminal status. Tasks in this status cannot transition to any other status.

`[JsonStringEnumMemberName("completed")] Completed = 2`
:   The request completed successfully and results are available.

    This is a terminal status. Tasks in this status cannot transition to any other status.

`[JsonStringEnumMemberName("failed")] Failed = 3`
:   The associated request did not complete successfully.

    This is a terminal status. For tool calls specifically, this includes cases where
    the tool call result has isError set to true. Tasks in this status cannot transition
    to any other status.

`[JsonStringEnumMemberName("input_required")] InputRequired = 1`
:   The receiver needs input from the requestor.

    The requestor should call tasks/result to receive input requests, even though the task
    has not reached a terminal state. From [InputRequired](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_InputRequired), tasks may transition
    to [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working), [Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed), [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed), or [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled).

`[JsonStringEnumMemberName("working")] Working = 0`
:   The request is currently being processed.

    Tasks begin in this status when created. From [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working), tasks may transition
    to [InputRequired](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_InputRequired), [Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed), [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed), or [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled).

## Remarks

Tasks progress through a defined lifecycle:

* [Working](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Working): The request is currently being processed.
* [InputRequired](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_InputRequired): The receiver needs input from the requestor.
  The requestor should call tasks/result to receive input requests.
* [Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed): The request completed successfully and results are available.
* [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed): The request did not complete successfully.
* [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled): The request was cancelled before completion.

Terminal states are [Completed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Completed), [Failed](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Failed), and [Cancelled](ModelContextProtocol.Protocol.McpTaskStatus.html#ModelContextProtocol_Protocol_McpTaskStatus_Cancelled).
Once a task reaches a terminal state, it cannot transition to any other status.




