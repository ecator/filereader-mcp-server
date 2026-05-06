
##### Table of Contents

# Class Result

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class for result payloads.

```
public abstract class Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Result

Derived
:   [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)

    [CancelMcpTaskResult](ModelContextProtocol.Protocol.CancelMcpTaskResult.html)

    [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)

    [CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html)

    [CreateTaskResult](ModelContextProtocol.Protocol.CreateTaskResult.html)

    [ElicitResult](ModelContextProtocol.Protocol.ElicitResult.html)

    [ElicitResult<T>](ModelContextProtocol.Protocol.ElicitResult-1.html)

    [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)

    [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)

    [GetTaskResult](ModelContextProtocol.Protocol.GetTaskResult.html)

    [InitializeResult](ModelContextProtocol.Protocol.InitializeResult.html)

    [ListRootsResult](ModelContextProtocol.Protocol.ListRootsResult.html)

    [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html)

    [PingResult](ModelContextProtocol.Protocol.PingResult.html)

    [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
[JsonPropertyName("_meta")]
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

Implementations must not make assumptions about its contents.




