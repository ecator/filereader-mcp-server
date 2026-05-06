
##### Table of Contents

# Class NotificationMethods

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides constants with the names of common notification methods used in the MCP protocol.

```
public static class NotificationMethods
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    NotificationMethods

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Fields

### CancelledNotification

The name of the notification sent to indicate that a previously issued request should be canceled.

```
public const string CancelledNotification = "notifications/cancelled"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

From the issuer's perspective, the request should still be in-flight. However, due to communication latency,
it is always possible that this notification might arrive after the request has already finished.

This notification indicates that the result will be unused, so any associated processing SHOULD cease.

A client must not attempt to cancel its `initialize` request.

### ElicitationCompleteNotification

The name of the notification sent by the server when a URL-mode elicitation flow completes.

```
public const string ElicitationCompleteNotification = "notifications/elicitation/complete"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification references the original elicitation by ID, allowing clients to retry blocked requests
or update their UI state once the out-of-band interaction finishes.

### InitializedNotification

The name of the notification sent from the client to the server after initialization has finished.

```
public const string InitializedNotification = "notifications/initialized"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification is sent by the client after it has received and processed the server's response to the
[Initialize](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_Initialize) request. It signals that the client is ready to begin normal operation
and that the initialization phase is complete.

After receiving this notification, the server can begin sending notifications and processing
further requests from the client.

### LoggingMessageNotification

The name of the notification sent by the server when a log message is generated.

```
public const string LoggingMessageNotification = "notifications/message"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification is used by the server to send log messages to clients. Log messages can include
different severity levels, such as debug, info, warning, or error, and an optional logger name to
identify the source component.

The minimum logging level that triggers notifications can be controlled by clients using the
[LoggingSetLevel](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_LoggingSetLevel) request. If no level has been set by a client,
the server can determine which messages to send based on its own configuration.

### ProgressNotification

The name of the notification sent to inform the receiver of a progress update for a long-running request.

```
public const string ProgressNotification = "notifications/progress"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification provides updates on the progress of long-running operations. It includes
a progress token that associates the notification with a specific request, the current progress value,
and optionally, a total value and a descriptive message.

Progress notifications can be sent by either the client or the server, depending on the context.
Progress notifications enable clients to display progress indicators for operations that might take
significant time to complete, such as large file uploads, complex computations, or resource-intensive
processing tasks.

### PromptListChangedNotification

The name of the notification sent by the server when the list of available prompts changes.

```
public const string PromptListChangedNotification = "notifications/prompts/list_changed"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification informs clients that the set of available prompts has been modified.
Changes may include prompts being added, removed, or updated. Upon receiving this
notification, clients may refresh their prompt list by calling the appropriate
method to get the updated list of prompts.

### RelatedTaskMetaKey

The metadata key used to associate requests, responses, and notifications with a task.

```
public const string RelatedTaskMetaKey = "io.modelcontextprotocol/related-task"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This constant defines the key `"io.modelcontextprotocol/related-task"` used in the
`_meta` field to associate messages with their originating task across the entire
request lifecycle.

For example, an elicitation that a task-augmented tool call depends on must share the
same related task ID with that tool call's task.

For `tasks/get`, `tasks/list`, and `tasks/cancel` operations, this
metadata should not be included as the taskId is already present in the message structure.

### ResourceListChangedNotification

The name of the notification sent by the server when the list of available resources changes.

```
public const string ResourceListChangedNotification = "notifications/resources/list_changed"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification informs clients that the set of available resources has been modified.
Changes may include resources being added, removed, or updated. Upon receiving this
notification, clients may refresh their resource list by calling the appropriate
method to get the updated list of resources.

### ResourceUpdatedNotification

The name of the notification sent by the server when a resource is updated.

```
public const string ResourceUpdatedNotification = "notifications/resources/updated"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification is used to inform clients about changes to a specific resource they have subscribed to.
When a resource is updated, the server sends this notification to all clients that have subscribed to that resource.

### RootsListChangedNotification

The name of the notification sent by the client when roots have been updated.

```
public const string RootsListChangedNotification = "notifications/roots/list_changed"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification informs the server that the client's "roots" have changed.
Roots inform servers about the directories and files the client considers relevant,
so that servers can focus their operations accordingly. They are informational guidance
rather than an access-control mechanism; the protocol does not enforce that servers stay within roots.
Servers can request the list of roots from supporting clients and receive notifications when that list changes.

After receiving this notification, servers can refresh their knowledge of roots by calling the appropriate
method to get the updated list of roots from the client.

### TaskStatusNotification

The name of the notification sent when a task status changes.

```
public const string TaskStatusNotification = "notifications/tasks/status"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

When a task status changes, receivers may send this notification to inform the requestor
of the change. This notification includes the full task state.

Requestors must not rely on receiving this notification, as it is optional. Receivers
are not required to send status notifications and may choose to only send them for
certain status transitions. Requestors should continue to poll via tasks/get to ensure
they receive status updates.

### ToolListChangedNotification

The name of the notification sent by a server when the list of available tools changes.

```
public const string ToolListChangedNotification = "notifications/tools/list_changed"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This notification informs clients that the set of available tools has been modified.
Changes may include tools being added, removed, or updated. Upon receiving this
notification, clients may refresh their tool list by calling the appropriate
method to get the updated list of tools.




