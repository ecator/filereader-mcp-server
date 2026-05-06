
##### Table of Contents

# Class McpMessageFilters

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides grouped message filter collections.

```
public sealed class McpMessageFilters
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpMessageFilters

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### IncomingFilters

Gets or sets the filters for all incoming JSON-RPC messages.

```
public IList<McpMessageFilter> IncomingFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpMessageFilter](ModelContextProtocol.Server.McpMessageFilter.html)>

#### Remarks

These filters intercept all incoming JSON-RPC messages before they are processed by the server,
including requests, notifications, responses, and errors. The filters can perform logging,
authentication, rate limiting, or other cross-cutting concerns that apply to all message types.

Message filters are applied before request-specific filters. If a message filter does not call
the next handler in the pipeline, the default handlers will not be executed.

### OutgoingFilters

Gets or sets the filters for all outgoing JSON-RPC messages.

```
public IList<McpMessageFilter> OutgoingFilters { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpMessageFilter](ModelContextProtocol.Server.McpMessageFilter.html)>

#### Remarks

These filters intercept all outgoing JSON-RPC messages before they are sent to the client,
including responses, notifications, and errors. The filters can perform logging,
redaction, auditing, or other cross-cutting concerns that apply to all message types.

If a message filter does not call the next handler in the pipeline, the message will not be sent.
Filters may also call the next handler multiple times with different messages to emit additional
server-to-client messages.




