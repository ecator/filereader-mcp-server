
##### Table of Contents

# Class CancelledNotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a notification indicating that a request has been cancelled by the client,
and that any associated processing should cease immediately.

```
public sealed class CancelledNotificationParams : NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [NotificationParams](ModelContextProtocol.Protocol.NotificationParams.html)

    CancelledNotificationParams

Inherited Members
:   [NotificationParams.Meta](ModelContextProtocol.Protocol.NotificationParams.html#ModelContextProtocol_Protocol_NotificationParams_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class is typically used in conjunction with the [CancelledNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_CancelledNotification)
method identifier. When a client sends this notification, the server should attempt to
cancel any ongoing operations associated with the specified request ID.

## Properties

### Reason

Gets or sets an optional string describing the reason for the cancellation request.

```
[JsonPropertyName("reason")]
public string? Reason { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### RequestId

Gets or sets the ID of the request to cancel.

```
[JsonPropertyName("requestId")]
public required RequestId RequestId { get; set; }
```

#### Property Value

[RequestId](ModelContextProtocol.Protocol.RequestId.html)

#### Remarks

This value must match the ID of an in-flight request that the sender wishes to cancel.




