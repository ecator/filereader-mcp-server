
##### Table of Contents

# Class ReadResourceRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [ResourcesRead](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesRead) request from a client to get a resource provided by a server.

```
public sealed class ReadResourceRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    ReadResourceRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

The server will respond with a [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html) containing the resulting resource data.

Alternatively, if the resource URI uses the `https://` scheme, clients may fetch the resource
directly from the web instead of using [ResourcesRead](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesRead).
Servers should only use the `https://` scheme when the client is able to fetch and load the
resource directly on its own.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Uri

Gets or sets the URI of the resource to read. The URI can use any protocol; it is up to the server how to interpret it.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




