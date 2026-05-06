
##### Table of Contents

# Class ToolExecution

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents execution-related metadata for a tool.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class ToolExecution
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ToolExecution

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This type provides hints about how a tool should be executed, particularly
regarding task augmentation support.

## Properties

### TaskSupport

Gets or sets the level of task augmentation support for this tool.

```
[JsonPropertyName("taskSupport")]
public ToolTaskSupport? TaskSupport { get; set; }
```

#### Property Value

[ToolTaskSupport](ModelContextProtocol.Protocol.ToolTaskSupport.html)?

#### Remarks

This property declares whether a tool supports task-augmented execution:

* [Forbidden](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Forbidden): Clients must not attempt to invoke
  the tool as a task. This is the default behavior.
* [Optional](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Optional): Clients may invoke the tool as a task
  or as a normal request.
* [Required](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Required): Clients must invoke the tool as a task.

This is a fine-grained layer in addition to server capabilities. Even if a server's capabilities
include tasks.requests.tools.call, this property controls whether each specific tool supports tasks.




