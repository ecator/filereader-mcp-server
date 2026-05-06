
##### Table of Contents

# Class RequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class for all request parameters.

```
public abstract class RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    RequestParams

Derived
:   [CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html)

    [CancelMcpTaskRequestParams](ModelContextProtocol.Protocol.CancelMcpTaskRequestParams.html)

    [CompleteRequestParams](ModelContextProtocol.Protocol.CompleteRequestParams.html)

    [CreateMessageRequestParams](ModelContextProtocol.Protocol.CreateMessageRequestParams.html)

    [ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html)

    [GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html)

    [GetTaskPayloadRequestParams](ModelContextProtocol.Protocol.GetTaskPayloadRequestParams.html)

    [GetTaskRequestParams](ModelContextProtocol.Protocol.GetTaskRequestParams.html)

    [InitializeRequestParams](ModelContextProtocol.Protocol.InitializeRequestParams.html)

    [ListRootsRequestParams](ModelContextProtocol.Protocol.ListRootsRequestParams.html)

    [PaginatedRequestParams](ModelContextProtocol.Protocol.PaginatedRequestParams.html)

    [PingRequestParams](ModelContextProtocol.Protocol.PingRequestParams.html)

    [ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html)

    [SetLevelRequestParams](ModelContextProtocol.Protocol.SetLevelRequestParams.html)

    [SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html)

    [UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

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

### ProgressToken

Gets the opaque token that will be attached to any subsequent progress notifications.

```
[JsonIgnore]
public ProgressToken? ProgressToken { get; }
```

#### Property Value

[ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)?




