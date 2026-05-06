
##### Table of Contents

# Class PromptsCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the server's capability to provide predefined prompt templates that clients can use.

```
public sealed class PromptsCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    PromptsCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The prompts capability allows a server to expose a collection of predefined prompt templates that clients
can discover and use. These prompts can be static (defined in the [PromptCollection](ModelContextProtocol.Server.McpServerOptions.html#ModelContextProtocol_Server_McpServerOptions_PromptCollection)) or
dynamically generated through handlers.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### ListChanged

Gets or sets a value that indicates whether this server supports notifications for changes to the prompt list.

```
[JsonPropertyName("listChanged")]
public bool? ListChanged { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?

#### Remarks

When set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), the server will send notifications using
[PromptListChangedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_PromptListChangedNotification) when prompts are added,
removed, or modified. Clients can register handlers for these notifications to
refresh their prompt cache. This capability enables clients to stay synchronized with server-side changes
to available prompts.




