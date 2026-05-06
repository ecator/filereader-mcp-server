
##### Table of Contents

# Class RequestMethods

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides constants with the names of common request methods used in the MCP protocol.

```
public static class RequestMethods
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    RequestMethods

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Fields

### CompletionComplete

The name of the request method sent from the client to the server to ask for completion suggestions.

```
public const string CompletionComplete = "completion/complete"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This is used to provide autocompletion-like functionality for arguments in a resource reference or a prompt template.
The client provides a reference (resource or prompt), argument name, and partial value, and the server
responds with matching completion options.

### ElicitationCreate

The name of the request method sent from the server to elicit additional information from the user via the client.

```
public const string ElicitationCreate = "elicitation/create"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This request is used when the server needs more information from the client to proceed with a task or interaction.
Servers can request structured data from users, with optional JSON schemas to validate responses (form mode),
or request URL mode (out-of-band) user interaction via navigation for sensitive operations.

Two modes are supported:

* **form**: In-band elicitation where structured data is collected and returned to the server
* **url**: URL mode (out-of-band) elicitation for sensitive operations like OAuth or payments

### Initialize

The name of the request method sent from the client to the server when it first connects, asking it to initialize.

```
public const string Initialize = "initialize"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The initialize request is the first request sent by the client to the server. It provides client information
and capabilities to the server during connection establishment. The server responds with its own capabilities
and information, establishing the protocol version and available features for the session.

### LoggingSetLevel

The name of the request method sent from the client to the server to adjust the logging level.

```
public const string LoggingSetLevel = "logging/setLevel"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This request allows clients to control which log messages they receive from the server
by setting a minimum severity threshold. After processing this request, the server will
send log messages with severity at or above the specified level to the client as
[LoggingMessageNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_LoggingMessageNotification) notifications.

### Ping

The name of the request method sent by either endpoint to check that the connected endpoint is still alive.

```
public const string Ping = "ping"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### PromptsGet

The name of the request method sent by the client to get a prompt provided by the server.

```
public const string PromptsGet = "prompts/get"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### PromptsList

The name of the request method sent from the client to request a list of the server's prompts.

```
public const string PromptsList = "prompts/list"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ResourcesList

The name of the request method sent from the client to request a list of the server's resources.

```
public const string ResourcesList = "resources/list"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ResourcesRead

The name of the request method sent from the client to read a specific server resource.

```
public const string ResourcesRead = "resources/read"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ResourcesSubscribe

The name of the request method sent from the client to request [ResourceUpdatedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ResourceUpdatedNotification)
notifications from the server whenever a particular resource changes.

```
public const string ResourcesSubscribe = "resources/subscribe"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ResourcesTemplatesList

The name of the request method sent from the client to request a list of the server's resource templates.

```
public const string ResourcesTemplatesList = "resources/templates/list"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ResourcesUnsubscribe

The name of the request method sent from the client to request unsubscribing from [ResourceUpdatedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ResourceUpdatedNotification)
notifications from the server.

```
public const string ResourcesUnsubscribe = "resources/unsubscribe"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### RootsList

The name of the request method sent from the server to request a list of the client's roots.

```
public const string RootsList = "roots/list"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### SamplingCreateMessage

The name of the request method sent from the server to sample a large language model (LLM) via the client.

```
public const string SamplingCreateMessage = "sampling/createMessage"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This request allows servers to utilize an LLM available on the client side to generate text or image responses
based on provided messages. It is part of the sampling capability in the Model Context Protocol and enables servers to access
client-side AI models without needing direct API access to those models.

### TasksCancel

The name of the request method to explicitly cancel a task.

```
public const string TasksCancel = "tasks/cancel"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### TasksGet

The name of the request method to retrieve task status.

```
public const string TasksGet = "tasks/get"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Requestors poll for task completion by sending tasks/get requests. They should respect
the pollInterval provided in responses when determining polling frequency.

### TasksList

The name of the request method to retrieve a list of tasks with pagination support.

```
public const string TasksList = "tasks/list"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### TasksResult

The name of the request method to retrieve the result of a completed task.

```
public const string TasksResult = "tasks/result"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This request blocks until the task reaches a terminal status (completed, failed, or cancelled).
The result structure matches the original request type (e.g., CallToolResult for tools/call).

### ToolsCall

The name of the request method sent from the client to request that the server invoke a specific tool.

```
public const string ToolsCall = "tools/call"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ToolsList

The name of the request method sent from the client to request a list of the server's tools.

```
public const string ToolsList = "tools/list"
```

#### Field Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




