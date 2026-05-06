
##### Table of Contents

# Class McpServerPromptAttribute

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Used to indicate that a method should be considered an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
[AttributeUsage(AttributeTargets.Method)]
public sealed class McpServerPromptAttribute : Attribute
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Attribute](https://learn.microsoft.com/dotnet/api/system.attribute)

    McpServerPromptAttribute

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

This attribute is applied to methods that should be exposed as prompts in the Model Context Protocol. When a class
containing methods marked with this attribute is registered with McpServerBuilderExtensions,
these methods become available as prompts that can be called by MCP clients.

When methods are provided directly to McpServerPrompt.Create, the attribute is not required.

By default, parameters are sourced from the [Arguments](ModelContextProtocol.Protocol.GetPromptRequestParams.html#ModelContextProtocol_Protocol_GetPromptRequestParams_Arguments) dictionary, which is a collection
of key/value pairs. Those parameters are deserialized from the
[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement) values in that collection. There are a few exceptions to this:

* [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) parameters are automatically bound to a [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) provided by the
  [McpServer](ModelContextProtocol.Server.McpServer.html) and that respects any [CancelledNotificationParams](ModelContextProtocol.Protocol.CancelledNotificationParams.html)s sent by the client for this operation's
  [RequestId](ModelContextProtocol.Protocol.RequestId.html).
* [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) parameters are bound from the [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) for this request.
* [McpServer](ModelContextProtocol.Server.McpServer.html) parameters are bound directly to the [McpServer](ModelContextProtocol.Server.McpServer.html) instance associated
  with this request's [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html). Such parameters may be used to understand
  what server is being used to process the request, and to interact with the client issuing the request to that server.
* [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) parameters accepting [ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html) values
  are bound to an [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) instance manufactured to forward progress notifications
  from the prompt to the client. If the client included a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html) in their request, progress reports issued
  to this instance will propagate to the client as [ProgressNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ProgressNotification) notifications with
  that token. If the client did not include a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html), the instance will ignore any progress reports issued to it.
* When the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) is constructed, it may be passed an [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) via
  [Services](ModelContextProtocol.Server.McpServerPromptCreateOptions.html#ModelContextProtocol_Server_McpServerPromptCreateOptions_Services). Any parameter that can be satisfied by that [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)
  according to [IServiceProviderIsService](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice) will be resolved from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to the
  prompt invocation rather than from the argument collection.
* Any parameter attributed with [FromKeyedServicesAttribute](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.fromkeyedservicesattribute) will similarly be resolved from the
  [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to the prompt invocation rather than from the argument collection.

All other parameters are deserialized from the [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)s in the [Arguments](ModelContextProtocol.Protocol.GetPromptRequestParams.html#ModelContextProtocol_Protocol_GetPromptRequestParams_Arguments) dictionary.

In general, the data supplied via the [Arguments](ModelContextProtocol.Protocol.GetPromptRequestParams.html#ModelContextProtocol_Protocol_GetPromptRequestParams_Arguments)'s dictionary is passed along from the caller and
should thus be considered unvalidated and untrusted. To provide validated and trusted data to the invocation of the prompt, consider having
the prompt be an instance method, referring to data stored in the instance, or using an instance or parameters resolved from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)
to provide data to the method.

Return values from a method are used to create the [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) that is sent back to the client:

|  |  |
| --- | --- |
| [string](https://learn.microsoft.com/dotnet/api/system.string) | Converted to a list containing a single [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) with its [Content](ModelContextProtocol.Protocol.PromptMessage.html#ModelContextProtocol_Protocol_PromptMessage_Content) set to contain the [string](https://learn.microsoft.com/dotnet/api/system.string). |
| [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) | Converted to a list containing the single [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) | Converted to a list containing all of the returned [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) instances. |
| Microsoft.Extensions.AI.ChatMessage | Converted to a list of [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) instances derived from the Microsoft.Extensions.AI.ChatMessage with [ToPromptMessages(ChatMessage)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToPromptMessages_Microsoft_Extensions_AI_ChatMessage_). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of Microsoft.Extensions.AI.ChatMessage | Converted to a list of [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) instances derived from all of the Microsoft.Extensions.AI.ChatMessage instances with [ToPromptMessages(ChatMessage)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToPromptMessages_Microsoft_Extensions_AI_ChatMessage_). |

Other returned types will result in an [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) being thrown.

Parameters of type [string](https://learn.microsoft.com/dotnet/api/system.string) that are decorated with `AllowedValuesAttribute`
will automatically have their allowed values surfaced as completions in response to `completion/complete` requests from clients,
without requiring a custom [CompleteHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_CompleteHandler) to be configured.

## Constructors

### McpServerPromptAttribute()

Initializes a new instance of the [McpServerPromptAttribute](ModelContextProtocol.Server.McpServerPromptAttribute.html) class.

```
public McpServerPromptAttribute()
```

## Properties

### IconSource

Gets or sets the source URI for the prompt's icon.

```
public string? IconSource { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value can be an HTTP/HTTPS URL pointing to an image file or a data URI with base64-encoded image data.
When specified, a single icon will be added to the prompt.

For more advanced icon configuration (multiple icons, MIME type specification, size characteristics),
use [Icons](ModelContextProtocol.Server.McpServerPromptCreateOptions.html#ModelContextProtocol_Server_McpServerPromptCreateOptions_Icons) when creating the prompt programmatically.

### Name

Gets or sets the name of the prompt.

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the method name is used.

### Title

Gets or sets the title of the prompt.

```
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




