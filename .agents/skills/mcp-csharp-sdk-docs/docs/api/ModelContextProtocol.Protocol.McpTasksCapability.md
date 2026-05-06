
##### Table of Contents

# Class McpTasksCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the tasks capability configuration for servers and clients.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public sealed class McpTasksCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpTasksCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The tasks capability enables requestors (clients or servers) to augment their requests with
tasks for long-running operations. Tasks are durable state machines that carry information
about the underlying execution state of requests.

During initialization, both parties exchange their tasks capabilities to establish which
operations support task-based execution. Requestors should only augment requests with a
task if the corresponding capability has been declared by the receiver.

## Properties

### Cancel

Gets or sets whether this party supports the tasks/cancel operation.

```
[JsonPropertyName("cancel")]
public CancelMcpTasksCapability? Cancel { get; set; }
```

#### Property Value

[CancelMcpTasksCapability](ModelContextProtocol.Protocol.CancelMcpTasksCapability.html)

#### Remarks

When present, indicates support for cancelling tasks.

### List

Gets or sets whether this party supports the tasks/list operation.

```
[JsonPropertyName("list")]
public ListMcpTasksCapability? List { get; set; }
```

#### Property Value

[ListMcpTasksCapability](ModelContextProtocol.Protocol.ListMcpTasksCapability.html)

#### Remarks

When present, indicates support for listing all tasks.

### Requests

Gets or sets which request types support task augmentation.

```
[JsonPropertyName("requests")]
public RequestMcpTasksCapability? Requests { get; set; }
```

#### Property Value

[RequestMcpTasksCapability](ModelContextProtocol.Protocol.RequestMcpTasksCapability.html)

#### Remarks

The set of capabilities in this property is exhaustive. If a request type is not present,
it does not support task augmentation.

For servers, this typically includes tools/call. For clients, this typically includes
sampling/createMessage and elicitation/create.




