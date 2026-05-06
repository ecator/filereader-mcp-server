
##### Table of Contents

# Class PaginatedResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class for result payloads that support cursor-based pagination.

```
public abstract class PaginatedResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    PaginatedResult

Derived
:   [ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html)

    [ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html)

    [ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html)

    [ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html)

    [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html)

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Pagination allows API responses to be broken into smaller, manageable chunks when
there are potentially many results to return or when dynamically computed results
might incur measurable latency.

Classes that inherit from [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html) implement cursor-based pagination,
where the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor) property serves as an opaque token pointing to the next
set of results.

## Properties

### NextCursor

Gets or sets an opaque token representing the pagination position after the last returned result.

```
public string? NextCursor { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

When a paginated result has more data available, the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor)
property will contain a non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) token that can be used in subsequent requests
to fetch the next page. When there are no more results to return, the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor) property
will be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




