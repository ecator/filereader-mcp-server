
##### Table of Contents

# Class LoggingMessageNotificationParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [LoggingMessageNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_LoggingMessageNotification)
notification sent whenever a log message is generated.

```
public sealed class LoggingMessageNotificationParams : NotificationParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [NotificationParams](ModelContextProtocol.Protocol.NotificationParams.html)

    LoggingMessageNotificationParams

Inherited Members
:   [NotificationParams.Meta](ModelContextProtocol.Protocol.NotificationParams.html#ModelContextProtocol_Protocol_NotificationParams_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Logging notifications allow servers to communicate diagnostic information to clients with varying severity levels.
Clients can filter these messages based on the [Level](ModelContextProtocol.Protocol.LoggingMessageNotificationParams.html#ModelContextProtocol_Protocol_LoggingMessageNotificationParams_Level) and [Logger](ModelContextProtocol.Protocol.LoggingMessageNotificationParams.html#ModelContextProtocol_Protocol_LoggingMessageNotificationParams_Logger) properties.

If no [LoggingSetLevel](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_LoggingSetLevel) request has been sent from the client, the server can decide which
messages to send automatically.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Data

Gets or sets the data to be logged, such as a string message or an object.
Any JSON serializable type is allowed here.

```
[JsonPropertyName("data")]
public required JsonElement Data { get; set; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)

### Level

Gets or sets the severity of this log message.

```
[JsonPropertyName("level")]
public required LoggingLevel Level { get; set; }
```

#### Property Value

[LoggingLevel](ModelContextProtocol.Protocol.LoggingLevel.html)

### Logger

Gets or sets an optional name of the logger issuing this message.

```
[JsonPropertyName("logger")]
public string? Logger { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

[Logger](ModelContextProtocol.Protocol.LoggingMessageNotificationParams.html#ModelContextProtocol_Protocol_LoggingMessageNotificationParams_Logger) typically represents a category or component in the server's logging system.
The logger name is useful for filtering and routing log messages in client applications.

When implementing custom servers, choose clear, hierarchical logger names to help
clients understand the source of log messages.




