
##### Table of Contents

# Class ListResourcesResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a server's response to a [ResourcesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesList) request from the client, containing available resources.

```
public sealed class ListResourcesResult : PaginatedResult
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html)

    ListResourcesResult

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

This result is returned when a client sends a [ResourcesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesList) request to discover available resources on the server.

It inherits from [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html), allowing for paginated responses when there are many resources.
The server can provide the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor) property to indicate there are more
resources available beyond what was returned in the current response.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Resources

Gets or sets a list of resources that the server offers.

```
[JsonPropertyName("resources")]
public IList<Resource> Resources { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Resource](ModelContextProtocol.Protocol.Resource.html)>




