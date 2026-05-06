
##### Table of Contents

# Class PromptListChangedNotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [PromptListChangedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_PromptListChangedNotification)
notification from the server to the client, informing it that the list of prompts it offers has changed.

```
public sealed class PromptListChangedNotificationParams : NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [NotificationParams](ModelContextProtocol.Protocol.NotificationParams.html)

    PromptListChangedNotificationParams

Inherited Members
:   [NotificationParams.Meta](ModelContextProtocol.Protocol.NotificationParams.html#ModelContextProtocol_Protocol_NotificationParams_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This notification can be issued by servers without any previous subscription from the client.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.




