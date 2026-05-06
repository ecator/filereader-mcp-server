
##### Table of Contents

# Class McpClientResourceTemplate

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a named resource template that can be retrieved from an MCP server.

```
public sealed class McpClientResourceTemplate
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpClientResourceTemplate

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class provides a client-side wrapper around a resource template defined on an MCP server. It allows
retrieving the resource template's content by sending a request to the server with the resource's URI.
Instances of this class are typically obtained by calling [ListResourceTemplatesAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListResourceTemplatesAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_).

## Constructors

### McpClientResourceTemplate(McpClient, ResourceTemplate)

Initializes a new instance of the [McpClientResourceTemplate](ModelContextProtocol.Client.McpClientResourceTemplate.html) class.

```
public McpClientResourceTemplate(McpClient client, ResourceTemplate resourceTemplate)
```

#### Parameters

`client` [McpClient](ModelContextProtocol.Client.McpClient.html)
:   The [McpClient](ModelContextProtocol.Client.McpClient.html) instance to use for reading the resource template.

`resourceTemplate` [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html)
:   The protocol [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) definition describing the resource template's metadata.

#### Remarks

This constructor enables reusing cached resource template definitions across different [McpClient](ModelContextProtocol.Client.McpClient.html) instances
without needing to call [ListResourceTemplatesAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListResourceTemplatesAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) on every reconnect. This is particularly useful
in scenarios where resource template definitions are stable and network round-trips should be minimized.

The provided `resourceTemplate` must represent a resource template that is actually available on the server
associated with the `client`. Attempting to read a resource template that doesn't exist on the
server will result in an [McpException](ModelContextProtocol.McpException.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `client` or `resourceTemplate` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Description

Gets the description of the resource template.

```
public string? Description { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### MimeType

Gets the media (MIME) type of the resource template.

```
public string? MimeType { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Name

Gets the name of the resource template.

```
public string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ProtocolResourceTemplate

Gets the underlying protocol [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) type for this instance.

```
public ResourceTemplate ProtocolResourceTemplate { get; }
```

#### Property Value

[ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html)

#### Remarks

This property provides direct access to the underlying protocol representation of the resource template,
which can be useful for advanced scenarios or when implementing custom MCP client extensions.

For most common use cases, you can use the more convenient [UriTemplate](ModelContextProtocol.Client.McpClientResourceTemplate.html#ModelContextProtocol_Client_McpClientResourceTemplate_UriTemplate) and
[Description](ModelContextProtocol.Client.McpClientResourceTemplate.html#ModelContextProtocol_Client_McpClientResourceTemplate_Description) properties instead of accessing the [ProtocolResourceTemplate](ModelContextProtocol.Client.McpClientResourceTemplate.html#ModelContextProtocol_Client_McpClientResourceTemplate_ProtocolResourceTemplate) directly.

### Title

Gets the title of the resource template.

```
public string? Title { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### UriTemplate

Gets the URI template of the resource template.

```
public string UriTemplate { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### ReadAsync(IReadOnlyDictionary<string, object?>, RequestOptions?, CancellationToken)

Gets this resource template's content by formatting a URI from the template and supplied arguments
and sending a request to the server.

```
public ValueTask<ReadResourceResult> ReadAsync(IReadOnlyDictionary<string, object?> arguments, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`arguments` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   A dictionary of arguments to pass to the tool. Each key represents a parameter name,
    and its associated value represents the argument value.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>
:   A [ValueTask<TResult>](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1) containing the resource template's result with content and messages.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.




