
##### Table of Contents

# Class McpServerFilters

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides filter collections for MCP server handlers.

```
public sealed class McpServerFilters
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerFilters

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class contains collections of filters that can be applied to various MCP server handlers.
This allows for middleware-style composition where filters can perform actions before and after the inner handler.

## Properties

### Message

Gets or sets the filters for incoming and outgoing JSON-RPC messages.

```
public McpMessageFilters Message { get; set; }
```

#### Property Value

[McpMessageFilters](ModelContextProtocol.Server.McpMessageFilters.html)

### Request

Gets or sets the filters for request-specific MCP handler pipelines.

```
public McpRequestFilters Request { get; set; }
```

#### Property Value

[McpRequestFilters](ModelContextProtocol.Server.McpRequestFilters.html)




