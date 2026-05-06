
##### Table of Contents

# Class ListResourceTemplatesResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a server's response to a [ResourcesTemplatesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesTemplatesList) request from the client,
containing available resource templates.

```
public sealed class ListResourceTemplatesResult : PaginatedResult
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html)

    ListResourceTemplatesResult

Inherited Members
:   [PaginatedResult.NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor)

    [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This result is returned when a client sends a [ResourcesTemplatesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesTemplatesList) request to discover
available resource templates on the server.

It inherits from [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html), allowing for paginated responses when there are many resource templates.
The server can provide the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor) property to indicate there are more
resource templates available beyond what was returned in the current response.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### ResourceTemplates

Gets or sets a list of resource templates that the server offers.

```
[JsonPropertyName("resourceTemplates")]
public IList<ResourceTemplate> ResourceTemplates { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html)>

#### Remarks

This collection contains all the resource templates returned in the current page of results.
Each [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) provides metadata about resources available on the server,
including URI templates, names, descriptions, and MIME types.




