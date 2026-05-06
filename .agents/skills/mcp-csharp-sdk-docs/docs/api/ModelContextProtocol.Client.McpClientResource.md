
##### Table of Contents

# Class McpClientResource

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a named resource that can be retrieved from an MCP server.

```
public sealed class McpClientResource
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpClientResource

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class provides a client-side wrapper around a resource defined on an MCP server. It allows
retrieving the resource's content by sending a request to the server with the resource's URI.
Instances of this class are typically obtained by calling [ListResourcesAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListResourcesAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_).

## Constructors

### McpClientResource(McpClient, Resource)

Initializes a new instance of the [McpClientResource](ModelContextProtocol.Client.McpClientResource.html) class.

```
public McpClientResource(McpClient client, Resource resource)
```

#### Parameters

`client` [McpClient](ModelContextProtocol.Client.McpClient.html)
:   The [McpClient](ModelContextProtocol.Client.McpClient.html) instance to use for reading the resource.

`resource` [Resource](ModelContextProtocol.Protocol.Resource.html)
:   The protocol [Resource](ModelContextProtocol.Protocol.Resource.html) definition describing the resource's metadata.

#### Remarks

This constructor enables reusing cached resource definitions across different [McpClient](ModelContextProtocol.Client.McpClient.html) instances
without needing to call [ListResourcesAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListResourcesAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) on every reconnect. This is particularly useful
in scenarios where resource definitions are stable and network round-trips should be minimized.

The provided `resource` must represent a resource that is actually available on the server
associated with the `client`. Attempting to read a resource that doesn't exist on the
server will result in an [McpException](ModelContextProtocol.McpException.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `client` or `resource` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Description

Gets the description of the resource.

```
public string? Description { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### MimeType

Gets the media (MIME) type of the resource.

```
public string? MimeType { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Name

Gets the name of the resource.

```
public string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ProtocolResource

Gets the underlying protocol [Resource](ModelContextProtocol.Protocol.Resource.html) type for this instance.

```
public Resource ProtocolResource { get; }
```

#### Property Value

[Resource](ModelContextProtocol.Protocol.Resource.html)

#### Remarks

This property provides direct access to the underlying protocol representation of the resource,
which can be useful for advanced scenarios or when implementing custom MCP client extensions.

For most common use cases, you can use the more convenient [Name](ModelContextProtocol.Client.McpClientResource.html#ModelContextProtocol_Client_McpClientResource_Name) and
[Description](ModelContextProtocol.Client.McpClientResource.html#ModelContextProtocol_Client_McpClientResource_Description) properties instead of accessing the [ProtocolResource](ModelContextProtocol.Client.McpClientResource.html#ModelContextProtocol_Client_McpClientResource_ProtocolResource) directly.

### Title

Gets the title of the resource.

```
public string? Title { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Uri

Gets the URI of the resource.

```
public string Uri { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### ReadAsync(RequestOptions?, CancellationToken)

Gets this resource's content by sending a request to the server.

```
public ValueTask<ReadResourceResult> ReadAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>
:   A [ValueTask<TResult>](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1) containing the resource's result with content and messages.

#### Remarks

This is a convenience method that internally calls [ReadResourceAsync(string, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ReadResourceAsync_System_String_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_).

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.




