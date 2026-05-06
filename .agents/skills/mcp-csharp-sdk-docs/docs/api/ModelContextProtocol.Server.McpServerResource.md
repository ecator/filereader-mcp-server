
##### Table of Contents

# Class McpServerResource

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an invocable resource used by Model Context Protocol clients and servers.

```
public abstract class McpServerResource : IMcpServerPrimitive
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerResource

Implements
:   [IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

Derived
:   [DelegatingMcpServerResource](ModelContextProtocol.Server.DelegatingMcpServerResource.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

[McpServerResource](ModelContextProtocol.Server.McpServerResource.html) is an abstract base class that represents an MCP resource for use in the server (as opposed
to [Resource](ModelContextProtocol.Protocol.Resource.html) or [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html), which provide the protocol representations of a resource). Instances of
[McpServerResource](ModelContextProtocol.Server.McpServerResource.html) can be added into a [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) to be picked up automatically when
[McpServer](ModelContextProtocol.Server.McpServer.html) is used to create an [McpServer](ModelContextProtocol.Server.McpServer.html), or added into a [McpServerPrimitiveCollection<T>](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html).

Most commonly, [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances are created using the static McpServerResource.Create methods.
These methods enable creating an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) for a method, specified via a [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate) or
[MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo), and are what are used implicitly by WithResourcesFromAssembly and
McpServerBuilderExtensions.WithResources. The McpServerResource.Create methods
create [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances capable of working with a large variety of .NET method signatures, automatically handling
how parameters are marshaled into the method from the URI received from the MCP client, and how the return value is marshaled back
into the [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html) that's then serialized and sent back to the client.

[McpServerResource](ModelContextProtocol.Server.McpServerResource.html) is used to represent both direct resources (for example,"resource://example") and templated
resources (for example,"resource://example/{id}").

Read resource requests do not contain separate arguments, only a URI. However, for templated resources, portions of that URI may be considered
as arguments and may be bound to parameters. Further, resource methods may accept parameters that will be bound to arguments based on their type.

* [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) parameters are automatically bound to a [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) provided by the
  [McpServer](ModelContextProtocol.Server.McpServer.html) and that respects any [CancelledNotificationParams](ModelContextProtocol.Protocol.CancelledNotificationParams.html)s sent by the client for this operation's
  [RequestId](ModelContextProtocol.Protocol.RequestId.html).
* [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) parameters are bound from the [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) for this request.
* [McpServer](ModelContextProtocol.Server.McpServer.html) parameters are bound directly to the [McpServer](ModelContextProtocol.Server.McpServer.html) instance associated
  with this request's [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html). Such parameters may be used to understand
  what server is being used to process the request, and to interact with the client issuing the request to that server.
* [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) parameters accepting [ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html) values
  are bound to an [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) instance manufactured to forward progress notifications
  from the resource to the client. If the client included a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html) in their request, progress reports issued
  to this instance will propagate to the client as [ProgressNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ProgressNotification) notifications with
  that token. If the client did not include a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html), the instance will ignore any progress reports issued to it.
* When the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) is constructed, it may be passed an [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) via
  [Services](ModelContextProtocol.Server.McpServerResourceCreateOptions.html#ModelContextProtocol_Server_McpServerResourceCreateOptions_Services). Any parameter that can be satisfied by that [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)
  according to [IServiceProviderIsService](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice) will be resolved from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to the
  resource invocation rather than from the argument collection.
* Any parameter attributed with [FromKeyedServicesAttribute](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.fromkeyedservicesattribute) will similarly be resolved from the
  [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to the resource invocation rather than from the argument collection.
* All other parameters are bound from the data in the URI.

Return values from a method are used to create the [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html) that is sent back to the client:

|  |  |
| --- | --- |
| [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) | Wrapped in a list containing the single [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html). |
| Microsoft.Extensions.AI.TextContent | Converted to a list containing a single [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html). |
| Microsoft.Extensions.AI.DataContent | Converted to a list containing a single [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html). |
| [string](https://learn.microsoft.com/dotnet/api/system.string) | Converted to a list containing a single [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) | Returned directly as a list of [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of Microsoft.Extensions.AI.AIContent | Converted to a list containing a [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html) for each [TextContentBlock](ModelContextProtocol.Protocol.TextContentBlock.html) and a [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) for each Microsoft.Extensions.AI.DataContent. |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [string](https://learn.microsoft.com/dotnet/api/system.string) | Converted to a list containing a [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html), one for each [string](https://learn.microsoft.com/dotnet/api/system.string). |
| [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html) | Returned directly without modification. |

Other returned types will result in an [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) being thrown.

Parameters of type [string](https://learn.microsoft.com/dotnet/api/system.string) that are decorated with `AllowedValuesAttribute`
will automatically have their allowed values surfaced as completions in response to `completion/complete` requests from clients,
without requiring a custom [CompleteHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_CompleteHandler) to be configured.

## Constructors

### McpServerResource()

Initializes a new instance of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) class.

```
protected McpServerResource()
```

## Properties

### IsTemplated

Gets a value that indicates whether this resource is a URI template with parameters as opposed to a direct resource.

```
public bool IsTemplated { get; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### Metadata

Gets the metadata for this resource instance.

```
public abstract IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.

### ProtocolResource

Gets the protocol [Resource](ModelContextProtocol.Protocol.Resource.html) type for this instance.

```
public virtual Resource? ProtocolResource { get; }
```

#### Property Value

[Resource](ModelContextProtocol.Protocol.Resource.html)

#### Remarks

The ProtocolResource property represents the underlying resource definition as defined in the
Model Context Protocol specification. It contains metadata like the resource template's URI template, name, and description.

### ProtocolResourceTemplate

Gets the protocol [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) type for this instance.

```
public abstract ResourceTemplate ProtocolResourceTemplate { get; }
```

#### Property Value

[ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html)

#### Remarks

The [ProtocolResourceTemplate](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ProtocolResourceTemplate) property represents the underlying resource template definition as defined in the
Model Context Protocol specification. It contains metadata like the resource template's URI template, name, and description.

Every valid resource URI is a valid resource URI template, and thus this property always returns an instance.
In contrast, the [ProtocolResource](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ProtocolResource) property might return [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if the resource template
contains a parameter, in which case the resource template URI is not a valid resource URI.

## Methods

### Create(AIFunction, McpServerResourceCreateOptions?)

Creates an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) that wraps the specified Microsoft.Extensions.AI.AIFunction.

```
public static McpServerResource Create(AIFunction function, McpServerResourceCreateOptions? options = null)
```

#### Parameters

`function` AIFunction
:   The function to wrap.

`options` [McpServerResourceCreateOptions](ModelContextProtocol.Server.McpServerResourceCreateOptions.html)
:   Optional options used in the creation of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) to control its behavior.

#### Returns

[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)

#### Remarks

Unlike the other overloads of Create, the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) created by [Create(AIFunction, McpServerResourceCreateOptions?)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_Create_Microsoft_Extensions_AI_AIFunction_ModelContextProtocol_Server_McpServerResourceCreateOptions_)
does not provide all of the special parameter handling for MCP-specific concepts, like [McpServer](ModelContextProtocol.Server.McpServer.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `function` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(Delegate, McpServerResourceCreateOptions?)

Creates an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instance for a method, specified via a [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate) instance.

```
public static McpServerResource Create(Delegate method, McpServerResourceCreateOptions? options = null)
```

#### Parameters

`method` [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate)
:   The method to be represented via the created [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

`options` [McpServerResourceCreateOptions](ModelContextProtocol.Server.McpServerResourceCreateOptions.html)
:   Optional options used in the creation of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) to control its behavior.

#### Returns

[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
:   The created [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(MethodInfo, Func<RequestContext<ReadResourceRequestParams>, object>, McpServerResourceCreateOptions?)

Creates an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instance for a method, specified via a [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo) for
an instance method, along with a [Type](https://learn.microsoft.com/dotnet/api/system.type) representing the type of the target object to
instantiate each time the method is invoked.

```
public static McpServerResource Create(MethodInfo method, Func<RequestContext<ReadResourceRequestParams>, object> createTargetFunc, McpServerResourceCreateOptions? options = null)
```

#### Parameters

`method` [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo)
:   The instance method to be represented via the created [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

`createTargetFunc` [Func](https://learn.microsoft.com/dotnet/api/system.func-2)<[RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html)>, [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   The callback used on each function invocation to create an instance of the type on which the instance method `method`
    will be invoked. If the returned instance is [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) or [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), it will
    be disposed of after method completes its invocation.

`options` [McpServerResourceCreateOptions](ModelContextProtocol.Server.McpServerResourceCreateOptions.html)
:   Optional options used in the creation of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) to control its behavior.

#### Returns

[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
:   The created [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` or `createTargetFunc` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(MethodInfo, object?, McpServerResourceCreateOptions?)

Creates an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instance for a method, specified via a [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo) instance.

```
public static McpServerResource Create(MethodInfo method, object? target = null, McpServerResourceCreateOptions? options = null)
```

#### Parameters

`method` [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo)
:   The method to be represented via the created [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

`target` [object](https://learn.microsoft.com/dotnet/api/system.object)
:   The instance if `method` is an instance method; otherwise, [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

`options` [McpServerResourceCreateOptions](ModelContextProtocol.Server.McpServerResourceCreateOptions.html)
:   Optional options used in the creation of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) to control its behavior.

#### Returns

[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
:   The created [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is an instance method but `target` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### IsMatch(string)

Evaluates whether the `uri` matches the [ProtocolResourceTemplate](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ProtocolResourceTemplate)
and can be used as the [Uri](ModelContextProtocol.Protocol.ReadResourceRequestParams.html#ModelContextProtocol_Protocol_ReadResourceRequestParams_Uri) passed to [ReadAsync(RequestContext<ReadResourceRequestParams>, CancellationToken)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ReadAsync_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_ReadResourceRequestParams__System_Threading_CancellationToken_).

```
public abstract bool IsMatch(string uri)
```

#### Parameters

`uri` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI being evaluated for this resource.

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the `uri` matches the [ProtocolResourceTemplate](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ProtocolResourceTemplate); otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ReadAsync(RequestContext<ReadResourceRequestParams>, CancellationToken)

Gets the resource, rendering it with the provided request parameters and returning the resource result.

```
public abstract ValueTask<ReadResourceResult> ReadAsync(RequestContext<ReadResourceRequestParams> request, CancellationToken cancellationToken = default)
```

#### Parameters

`request` [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html)>
:   The request context containing information about the resource invocation, including any arguments
    passed to the resource. This object provides access to both the request parameters and the server context.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>
:   A [ValueTask<TResult>](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1) representing the asynchronous operation, containing a [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html) with
    the resource content and messages.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `request` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The [Uri](ModelContextProtocol.Protocol.ReadResourceRequestParams.html#ModelContextProtocol_Protocol_ReadResourceRequestParams_Uri) did not match the [ProtocolResourceTemplate](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ProtocolResourceTemplate) for this resource,
    the resource implementation returned [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), or the resource implementation returned an unsupported result type.

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




