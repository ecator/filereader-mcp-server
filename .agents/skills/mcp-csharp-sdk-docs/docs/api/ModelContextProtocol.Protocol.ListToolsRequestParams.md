
##### Table of Contents

# Class ListToolsRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [ToolsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsList) request from a client to request
a list of tools available from the server.

```
public sealed class ListToolsRequestParams : PaginatedRequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    [PaginatedRequestParams](ModelContextProtocol.Protocol.PaginatedRequestParams.html)

    ListToolsRequestParams

Inherited Members
:   [PaginatedRequestParams.Cursor](ModelContextProtocol.Protocol.PaginatedRequestParams.html#ModelContextProtocol_Protocol_PaginatedRequestParams_Cursor)

    [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The server responds with a [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html) containing the available tools.
See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.




