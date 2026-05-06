
##### Table of Contents

# Class ResourceUpdatedNotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [ResourceUpdatedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ResourceUpdatedNotification)
notification sent whenever a subscribed resource changes.

```
public sealed class ResourceUpdatedNotificationParams : NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [NotificationParams](ModelContextProtocol.Protocol.NotificationParams.html)

    ResourceUpdatedNotificationParams

Inherited Members
:   [NotificationParams.Meta](ModelContextProtocol.Protocol.NotificationParams.html#ModelContextProtocol_Protocol_NotificationParams_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

When a client subscribes to resource updates using [SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html), the server will
send notifications with this payload whenever the subscribed resource is modified. These notifications
allow clients to maintain synchronized state without needing to poll the server for changes.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Uri

Gets or sets the URI of the resource that was updated.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The URI can use any protocol; it is up to the server how to interpret it.




