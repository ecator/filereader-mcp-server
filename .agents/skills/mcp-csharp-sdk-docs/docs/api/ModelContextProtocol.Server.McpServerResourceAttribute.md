
##### Table of Contents

# Class McpServerResourceAttribute

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Indicates that a method or property should be considered an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
[AttributeUsage(AttributeTargets.Method)]
public sealed class McpServerResourceAttribute : Attribute
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Attribute](https://learn.microsoft.com/dotnet/api/system.attribute)

    McpServerResourceAttribute

Inherited Members
:   [Attribute.Equals(object)](https://learn.microsoft.com/dotnet/api/system.attribute.equals)

    [Attribute.GetCustomAttribute(Assembly, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-assembly-system-type))

    [Attribute.GetCustomAttribute(Assembly, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-assembly-system-type-system-boolean))

    [Attribute.GetCustomAttribute(MemberInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-memberinfo-system-type))

    [Attribute.GetCustomAttribute(MemberInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-memberinfo-system-type-system-boolean))

    [Attribute.GetCustomAttribute(Module, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-module-system-type))

    [Attribute.GetCustomAttribute(Module, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-module-system-type-system-boolean))

    [Attribute.GetCustomAttribute(ParameterInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-parameterinfo-system-type))

    [Attribute.GetCustomAttribute(ParameterInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattribute#system-attribute-getcustomattribute(system-reflection-parameterinfo-system-type-system-boolean))

    [Attribute.GetCustomAttributes(Assembly)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly))

    [Attribute.GetCustomAttributes(Assembly, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly-system-boolean))

    [Attribute.GetCustomAttributes(Assembly, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly-system-type))

    [Attribute.GetCustomAttributes(Assembly, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-assembly-system-type-system-boolean))

    [Attribute.GetCustomAttributes(MemberInfo)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo))

    [Attribute.GetCustomAttributes(MemberInfo, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo-system-boolean))

    [Attribute.GetCustomAttributes(MemberInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo-system-type))

    [Attribute.GetCustomAttributes(MemberInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-memberinfo-system-type-system-boolean))

    [Attribute.GetCustomAttributes(Module)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module))

    [Attribute.GetCustomAttributes(Module, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module-system-boolean))

    [Attribute.GetCustomAttributes(Module, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module-system-type))

    [Attribute.GetCustomAttributes(Module, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-module-system-type-system-boolean))

    [Attribute.GetCustomAttributes(ParameterInfo)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo))

    [Attribute.GetCustomAttributes(ParameterInfo, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo-system-boolean))

    [Attribute.GetCustomAttributes(ParameterInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo-system-type))

    [Attribute.GetCustomAttributes(ParameterInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.getcustomattributes#system-attribute-getcustomattributes(system-reflection-parameterinfo-system-type-system-boolean))

    [Attribute.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.attribute.gethashcode)

    [Attribute.IsDefaultAttribute()](https://learn.microsoft.com/dotnet/api/system.attribute.isdefaultattribute)

    [Attribute.IsDefined(Assembly, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-assembly-system-type))

    [Attribute.IsDefined(Assembly, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-assembly-system-type-system-boolean))

    [Attribute.IsDefined(MemberInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-memberinfo-system-type))

    [Attribute.IsDefined(MemberInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-memberinfo-system-type-system-boolean))

    [Attribute.IsDefined(Module, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-module-system-type))

    [Attribute.IsDefined(Module, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-module-system-type-system-boolean))

    [Attribute.IsDefined(ParameterInfo, Type)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-parameterinfo-system-type))

    [Attribute.IsDefined(ParameterInfo, Type, bool)](https://learn.microsoft.com/dotnet/api/system.attribute.isdefined#system-attribute-isdefined(system-reflection-parameterinfo-system-type-system-boolean))

    [Attribute.Match(object)](https://learn.microsoft.com/dotnet/api/system.attribute.match)

    [Attribute.TypeId](https://learn.microsoft.com/dotnet/api/system.attribute.typeid)

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This attribute is applied to methods or properties that should be exposed as resources in the Model Context Protocol. When a class
containing methods marked with this attribute is registered with McpServerBuilderExtensions,
these methods or properties become available as resources that can be called by MCP clients.

When methods are provided directly to McpServerResource.Create, the attribute is not required.

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
| [TextContentBlock](ModelContextProtocol.Protocol.TextContentBlock.html) | Converted to a list containing a single [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html). |
| Microsoft.Extensions.AI.DataContent | Converted to a list containing a single [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html). |
| [string](https://learn.microsoft.com/dotnet/api/system.string) | Converted to a list containing a single [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) | Returned directly as a list of [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of Microsoft.Extensions.AI.AIContent | Converted to a list containing a [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html) for each [TextContentBlock](ModelContextProtocol.Protocol.TextContentBlock.html) and a [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) for each Microsoft.Extensions.AI.DataContent. |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [string](https://learn.microsoft.com/dotnet/api/system.string) | Converted to a list containing a [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html), one for each [string](https://learn.microsoft.com/dotnet/api/system.string). |

Other returned types will result in an [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) being thrown.

Parameters of type [string](https://learn.microsoft.com/dotnet/api/system.string) that are decorated with `AllowedValuesAttribute`
will automatically have their allowed values surfaced as completions in response to `completion/complete` requests from clients,
without requiring a custom [CompleteHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_CompleteHandler) to be configured.

## Constructors

### McpServerResourceAttribute()

Initializes a new instance of the [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html) class.

```
public McpServerResourceAttribute()
```

## Properties

### IconSource

Gets or sets the source URI for the resource's icon.

```
public string? IconSource { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This can be an HTTP/HTTPS URL pointing to an image file or a data URI with base64-encoded image data.
When specified, a single icon will be added to the resource.

For more advanced icon configuration (multiple icons, MIME type specification, size characteristics),
use [Icons](ModelContextProtocol.Server.McpServerResourceCreateOptions.html#ModelContextProtocol_Server_McpServerResourceCreateOptions_Icons) when creating the resource programmatically.

### MimeType

Gets or sets the MIME (media) type of the resource.

```
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Name

Gets or sets the name of the resource.

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the method name is used.

### Title

Gets or sets the title of the resource.

```
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### UriTemplate

Gets or sets the URI template of the resource.

```
public string? UriTemplate { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), a URI will be derived from [Name](ModelContextProtocol.Server.McpServerResourceAttribute.html#ModelContextProtocol_Server_McpServerResourceAttribute_Name) and the method's parameter names.
This template can, but doesn't have to, include parameters; if it does, this [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
is considered a "resource template", and if it doesn't, it is considered a "direct resource".
The former will be listed with [ResourcesTemplatesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesTemplatesList) requests and the latter
with [ResourcesList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ResourcesList) requests.




