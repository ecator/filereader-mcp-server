
##### Table of Contents

# Class ProgressNotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an out-of-band notification used to inform the receiver of a progress update for a long-running request.

```
[JsonConverter(typeof(ProgressNotificationParams.Converter))]
public sealed class ProgressNotificationParams : NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [NotificationParams](ModelContextProtocol.Protocol.NotificationParams.html)

    ProgressNotificationParams

Inherited Members
:   [NotificationParams.Meta](ModelContextProtocol.Protocol.NotificationParams.html#ModelContextProtocol_Protocol_NotificationParams_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for more details.

## Properties

### Progress

Gets or sets the progress thus far.

```
public required ProgressNotificationValue Progress { get; set; }
```

#### Property Value

[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)

#### Remarks

This value should increase for each notification issued as part of the same request, even if the total is unknown.

### ProgressToken

Gets or sets the progress token that was given in the initial request that's used to associate this notification with
the corresponding request.

```
public required ProgressToken ProgressToken { get; set; }
```

#### Property Value

[ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)

#### Remarks

This token acts as a correlation identifier that links progress updates to their corresponding request.

When an endpoint initiates a request with a [ProgressToken](ModelContextProtocol.Protocol.ProgressNotificationParams.html#ModelContextProtocol_Protocol_ProgressNotificationParams_ProgressToken) in its metadata,
the receiver can send progress notifications using this same token. This allows both sides to
correlate the notifications with the original request.




