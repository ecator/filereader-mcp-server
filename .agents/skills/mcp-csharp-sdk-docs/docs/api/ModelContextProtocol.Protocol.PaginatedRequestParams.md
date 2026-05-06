
##### Table of Contents

# Class PaginatedRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class for paginated requests.

```
public abstract class PaginatedRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    PaginatedRequestParams

Derived
:   [ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html)

    [ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html)

    [ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html)

    [ListTasksRequestParams](ModelContextProtocol.Protocol.ListTasksRequestParams.html)

    [ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html)

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

[See the schema for details](https://github.com/modelcontextprotocol/specification/blob/main/schema/)

## Properties

### Cursor

Gets or sets an opaque token representing the current pagination position.

```
[JsonPropertyName("cursor")]
public string? Cursor { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If provided, the server should return results starting after this cursor.
This value should be obtained from the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor)
property of a previous request's response.




