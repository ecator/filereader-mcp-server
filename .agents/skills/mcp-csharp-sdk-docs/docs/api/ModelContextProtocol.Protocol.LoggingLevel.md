
##### Table of Contents

# Enum LoggingLevel

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Indicates the severity of a log message.

```
[JsonConverter(typeof(JsonStringEnumConverter<LoggingLevel>))]
public enum LoggingLevel
```

## Fields

`[JsonStringEnumMemberName("alert")] Alert = 6`
:   Action must be taken immediately to address the condition.

`[JsonStringEnumMemberName("critical")] Critical = 5`
:   Critical conditions that require immediate attention.

`[JsonStringEnumMemberName("debug")] Debug = 0`
:   Detailed debug information, typically only valuable to developers.

`[JsonStringEnumMemberName("emergency")] Emergency = 7`
:   System is unusable and requires immediate attention.

`[JsonStringEnumMemberName("error")] Error = 4`
:   Error conditions that should be addressed but don't require immediate action.

`[JsonStringEnumMemberName("info")] Info = 1`
:   Normal operational messages that require no action.

`[JsonStringEnumMemberName("notice")] Notice = 2`
:   Normal but significant events that might deserve attention.

`[JsonStringEnumMemberName("warning")] Warning = 3`
:   Warning conditions that don't represent an error but indicate potential issues.

## Remarks

These values map to syslog message severities, as specified in [RFC-5424](https://datatracker.ietf.org/doc/html/rfc5424#section-6.2.1).




