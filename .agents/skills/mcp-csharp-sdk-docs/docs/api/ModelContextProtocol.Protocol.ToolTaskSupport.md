
##### Table of Contents

# Enum ToolTaskSupport

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the level of task augmentation support for a tool.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonConverter(typeof(JsonStringEnumConverter<ToolTaskSupport>))]
public enum ToolTaskSupport
```

## Fields

`[JsonStringEnumMemberName("forbidden")] Forbidden = 0`
:   Clients must not attempt to invoke the tool as a task.

    This is the default behavior. Servers should return a -32601 (Method not found) error
    if a client attempts to invoke the tool as a task when this is set.

`[JsonStringEnumMemberName("optional")] Optional = 1`
:   Clients may invoke the tool as a task or as a normal request.

    When this is set, clients can choose whether to use task augmentation based on their needs.

`[JsonStringEnumMemberName("required")] Required = 2`
:   Clients must invoke the tool as a task.

    Servers must return a -32601 (Method not found) error if a client does not attempt
    to invoke the tool as a task when this is set.

## Remarks

This enum defines how a tool interacts with the task augmentation system:

* [Forbidden](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Forbidden): Task augmentation is not allowed (default)
* [Optional](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Optional): Task augmentation is supported but not required
* [Required](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Required): Task augmentation is mandatory




