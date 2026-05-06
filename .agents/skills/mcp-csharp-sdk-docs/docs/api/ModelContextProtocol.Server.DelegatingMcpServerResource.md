
##### Table of Contents

# Class DelegatingMcpServerResource

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) that delegates all operations to an inner [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public abstract class DelegatingMcpServerResource : McpServerResource, IMcpServerPrimitive
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)

    DelegatingMcpServerResource

Implements
:   [IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

Inherited Members
:   [McpServerResource.IsTemplated](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_IsTemplated)

    [McpServerResource.Create(Delegate, McpServerResourceCreateOptions)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_Create_System_Delegate_ModelContextProtocol_Server_McpServerResourceCreateOptions_)

    [McpServerResource.Create(MethodInfo, object, McpServerResourceCreateOptions)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_Create_System_Reflection_MethodInfo_System_Object_ModelContextProtocol_Server_McpServerResourceCreateOptions_)

    [McpServerResource.Create(MethodInfo, Func<RequestContext<ReadResourceRequestParams>, object>, McpServerResourceCreateOptions)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_Create_System_Reflection_MethodInfo_System_Func_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_ReadResourceRequestParams__System_Object__ModelContextProtocol_Server_McpServerResourceCreateOptions_)

    [McpServerResource.Create(AIFunction, McpServerResourceCreateOptions)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_Create_Microsoft_Extensions_AI_AIFunction_ModelContextProtocol_Server_McpServerResourceCreateOptions_)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

This is recommended as a base type when building resources that can be chained around an underlying [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).
The default implementation simply passes each call to the inner resource instance.

## Constructors

### DelegatingMcpServerResource(McpServerResource)

Initializes a new instance of the [DelegatingMcpServerResource](ModelContextProtocol.Server.DelegatingMcpServerResource.html) class around the specified `innerResource`.

```
protected DelegatingMcpServerResource(McpServerResource innerResource)
```

#### Parameters

`innerResource` [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
:   The inner resource wrapped by this delegating resource.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `innerResource` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Metadata

Gets the metadata for this resource instance.

```
public override IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.

### ProtocolResource

Gets the protocol [Resource](ModelContextProtocol.Protocol.Resource.html) type for this instance.

```
public override Resource? ProtocolResource { get; }
```

#### Property Value

[Resource](ModelContextProtocol.Protocol.Resource.html)

#### Remarks

The ProtocolResource property represents the underlying resource definition as defined in the
Model Context Protocol specification. It contains metadata like the resource template's URI template, name, and description.

### ProtocolResourceTemplate

Gets the protocol [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) type for this instance.

```
public override ResourceTemplate ProtocolResourceTemplate { get; }
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

### IsMatch(string)

Evaluates whether the `uri` matches the [ProtocolResourceTemplate](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ProtocolResourceTemplate)
and can be used as the [Uri](ModelContextProtocol.Protocol.ReadResourceRequestParams.html#ModelContextProtocol_Protocol_ReadResourceRequestParams_Uri) passed to [ReadAsync(RequestContext<ReadResourceRequestParams>, CancellationToken)](ModelContextProtocol.Server.McpServerResource.html#ModelContextProtocol_Server_McpServerResource_ReadAsync_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_ReadResourceRequestParams__System_Threading_CancellationToken_).

```
public override bool IsMatch(string uri)
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
public override ValueTask<ReadResourceResult> ReadAsync(RequestContext<ReadResourceRequestParams> request, CancellationToken cancellationToken = default)
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




