
##### Table of Contents

# Class NotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class for notification parameters.

```
public abstract class NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    NotificationParams

Derived
:   [CancelledNotificationParams](ModelContextProtocol.Protocol.CancelledNotificationParams.html)

    [ElicitationCompleteNotificationParams](ModelContextProtocol.Protocol.ElicitationCompleteNotificationParams.html)

    [InitializedNotificationParams](ModelContextProtocol.Protocol.InitializedNotificationParams.html)

    [LoggingMessageNotificationParams](ModelContextProtocol.Protocol.LoggingMessageNotificationParams.html)

    [McpTaskStatusNotificationParams](ModelContextProtocol.Protocol.McpTaskStatusNotificationParams.html)

    [ProgressNotificationParams](ModelContextProtocol.Protocol.ProgressNotificationParams.html)

    [PromptListChangedNotificationParams](ModelContextProtocol.Protocol.PromptListChangedNotificationParams.html)

    [ResourceListChangedNotificationParams](ModelContextProtocol.Protocol.ResourceListChangedNotificationParams.html)

    [ResourceUpdatedNotificationParams](ModelContextProtocol.Protocol.ResourceUpdatedNotificationParams.html)

    [RootsListChangedNotificationParams](ModelContextProtocol.Protocol.RootsListChangedNotificationParams.html)

    [ToolListChangedNotificationParams](ModelContextProtocol.Protocol.ToolListChangedNotificationParams.html)

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




