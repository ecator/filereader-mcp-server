
##### Table of Contents

# Class ResourcesCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the resources capability configuration.

```
public sealed class ResourcesCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ResourcesCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### ListChanged

Gets or sets a value that indicates whether this server supports notifications for changes to the resource list.

```
[JsonPropertyName("listChanged")]
public bool? ListChanged { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?

#### Remarks

When set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the server sends notifications using
[ResourceListChangedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ResourceListChangedNotification) when resources are added,
removed, or modified. Clients can register handlers for these notifications to
refresh their resource cache.

### Subscribe

Gets or sets a value that indicates whether this server supports subscribing to resource updates.

```
[JsonPropertyName("subscribe")]
public bool? Subscribe { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?




