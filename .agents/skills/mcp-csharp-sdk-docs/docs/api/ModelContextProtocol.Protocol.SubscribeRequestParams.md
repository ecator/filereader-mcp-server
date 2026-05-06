
##### Table of Contents

# Class SubscribeRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [ResourcesSubscribe](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesSubscribe) request from a client
to request real-time notifications from the server whenever a particular resource changes.

```
public sealed class SubscribeRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    SubscribeRequestParams

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

The subscription mechanism allows clients to be notified about changes to specific resources
identified by their URI. When a subscribed resource changes, the server sends a notification
to the client with the updated resource information.

Subscriptions remain active until explicitly canceled using [UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html)
or until the connection is terminated.

The server might refuse or limit subscriptions based on its capabilities or resource constraints.

## Properties

### Uri

Gets or sets the URI of the resource to subscribe to.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The URI can use any protocol; it is up to the server how to interpret it.




