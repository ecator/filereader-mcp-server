
##### Table of Contents

# Class ElicitationCompleteNotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [ElicitationCompleteNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ElicitationCompleteNotification)
notification emitted after a URL-mode elicitation finishes out-of-band.

```
public sealed class ElicitationCompleteNotificationParams : NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [NotificationParams](ModelContextProtocol.Protocol.NotificationParams.html)

    ElicitationCompleteNotificationParams

Inherited Members
:   [NotificationParams.Meta](ModelContextProtocol.Protocol.NotificationParams.html#ModelContextProtocol_Protocol_NotificationParams_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The payload references the original elicitation by ID so that clients can resume deferred
requests or update pending UI once the external flow completes.

## Properties

### ElicitationId

Gets or sets the unique identifier of the elicitation that completed.

```
[JsonPropertyName("elicitationId")]
public required string ElicitationId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This matches [ElicitationId](ModelContextProtocol.Protocol.ElicitRequestParams.html#ModelContextProtocol_Protocol_ElicitRequestParams_ElicitationId) from the originating request and allows
clients to correlate the completion notification with previously issued prompts.




