
##### Table of Contents

# Class UnsubscribeRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a message sent from the client to cancel resource update notifications from the server for a specific resource.

```
public sealed class UnsubscribeRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    UnsubscribeRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

After a client has subscribed to resource updates using [SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html),
this message can be sent to stop receiving notifications for a specific resource.
This action is useful for conserving resources and network bandwidth when
the client no longer needs to track changes to a particular resource.

The unsubscribe operation is idempotent, meaning it can be called multiple times
for the same resource without causing errors, even if there is no active subscription.

## Properties

### Uri

Gets or sets the URI of the resource to unsubscribe from. The URI can use any protocol; it is up to the server how to interpret it.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




