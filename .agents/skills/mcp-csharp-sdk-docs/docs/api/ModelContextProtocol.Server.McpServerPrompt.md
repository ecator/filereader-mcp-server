
##### Table of Contents

# Class McpServerPrompt

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an invocable prompt used by Model Context Protocol clients and servers.

```
public abstract class McpServerPrompt : IMcpServerPrimitive
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerPrompt

Implements
:   [IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

Derived
:   [DelegatingMcpServerPrompt](ModelContextProtocol.Server.DelegatingMcpServerPrompt.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) is an abstract base class that represents an MCP prompt for use in the server (as opposed
to [Prompt](ModelContextProtocol.Protocol.Prompt.html), which provides the protocol representation of a prompt, and [McpClientPrompt](ModelContextProtocol.Client.McpClientPrompt.html), which
provides a client-side representation of a prompt). Instances of [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) can be added into a
[IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) to be picked up automatically when [McpServer](ModelContextProtocol.Server.McpServer.html) is used to create
an [McpServer](ModelContextProtocol.Server.McpServer.html), or added into a [McpServerPrimitiveCollection<T>](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html).

Most commonly, [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances are created using the static McpServerPrompt.Create methods.
These methods enable creating an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) for a method, specified via a [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate) or
[MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo), and are what are used implicitly by WithPromptsFromAssembly and WithPrompts. The McpServerPrompt.Create methods
create [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances capable of working with a large variety of .NET method signatures, automatically handling
how parameters are marshaled into the method from the JSON received from the MCP client, and how the return value is marshaled back
into the [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) that's then serialized and sent back to the client.

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
  according to [IServiceProviderIsService](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice) will be resolved from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to
  [GetAsync(RequestContext<GetPromptRequestParams>, CancellationToken)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_GetAsync_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_GetPromptRequestParams__System_Threading_CancellationToken_) rather than from the argument collection.
* Any parameter attributed with [FromKeyedServicesAttribute](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.fromkeyedservicesattribute) will similarly be resolved from the
  [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to [GetAsync(RequestContext<GetPromptRequestParams>, CancellationToken)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_GetAsync_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_GetPromptRequestParams__System_Threading_CancellationToken_) rather than from the argument collection.

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
| [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) | Returned directly without modification. |

Other returned types will result in an [InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) being thrown.

Parameters of type [string](https://learn.microsoft.com/dotnet/api/system.string) that are decorated with `AllowedValuesAttribute`
will automatically have their allowed values surfaced as completions in response to `completion/complete` requests from clients,
without requiring a custom [CompleteHandler](ModelContextProtocol.Server.McpServerHandlers.html#ModelContextProtocol_Server_McpServerHandlers_CompleteHandler) to be configured.

## Constructors

### McpServerPrompt()

Initializes a new instance of the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) class.

```
protected McpServerPrompt()
```

## Properties

### Metadata

Gets the metadata for this prompt instance.

```
public abstract IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.

### ProtocolPrompt

Gets the protocol [Prompt](ModelContextProtocol.Protocol.Prompt.html) type for this instance.

```
public abstract Prompt ProtocolPrompt { get; }
```

#### Property Value

[Prompt](ModelContextProtocol.Protocol.Prompt.html)

#### Remarks

The ProtocolPrompt property represents the underlying prompt definition as defined in the
Model Context Protocol specification. It contains metadata like the prompt's name,
description, and acceptable arguments.

## Methods

### Create(AIFunction, McpServerPromptCreateOptions?)

Creates an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) that wraps the specified Microsoft.Extensions.AI.AIFunction.

```
public static McpServerPrompt Create(AIFunction function, McpServerPromptCreateOptions? options = null)
```

#### Parameters

`function` AIFunction
:   The function to wrap.

`options` [McpServerPromptCreateOptions](ModelContextProtocol.Server.McpServerPromptCreateOptions.html)
:   Optional options used in the creation of the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) to control its behavior.

#### Returns

[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)

#### Remarks

Unlike the other overloads of Create, the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) created by [Create(AIFunction, McpServerPromptCreateOptions?)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_Create_Microsoft_Extensions_AI_AIFunction_ModelContextProtocol_Server_McpServerPromptCreateOptions_)
does not provide all of the special parameter handling for MCP-specific concepts, like [McpServer](ModelContextProtocol.Server.McpServer.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `function` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(Delegate, McpServerPromptCreateOptions?)

Creates an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instance for a method, specified via a [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate) instance.

```
public static McpServerPrompt Create(Delegate method, McpServerPromptCreateOptions? options = null)
```

#### Parameters

`method` [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate)
:   The method to be represented via the created [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

`options` [McpServerPromptCreateOptions](ModelContextProtocol.Server.McpServerPromptCreateOptions.html)
:   Optional options used in the creation of the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) to control its behavior.

#### Returns

[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
:   The created [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(MethodInfo, Func<RequestContext<GetPromptRequestParams>, object>, McpServerPromptCreateOptions?)

Creates an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instance for a method, specified via a [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo) for
an instance method, along with a [Type](https://learn.microsoft.com/dotnet/api/system.type) representing the type of the target object to
instantiate each time the method is invoked.

```
public static McpServerPrompt Create(MethodInfo method, Func<RequestContext<GetPromptRequestParams>, object> createTargetFunc, McpServerPromptCreateOptions? options = null)
```

#### Parameters

`method` [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo)
:   The instance method to be represented via the created [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

`createTargetFunc` [Func](https://learn.microsoft.com/dotnet/api/system.func-2)<[RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html)>, [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   Callback used on each function invocation to create an instance of the type on which the instance method `method`
    will be invoked. If the returned instance is [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) or [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), it will
    be disposed of after method completes its invocation.

`options` [McpServerPromptCreateOptions](ModelContextProtocol.Server.McpServerPromptCreateOptions.html)
:   Optional options used in the creation of the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) to control its behavior.

#### Returns

[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
:   The created [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` or `createTargetFunc` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(MethodInfo, object?, McpServerPromptCreateOptions?)

Creates an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instance for a method, specified via a [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo) instance.

```
public static McpServerPrompt Create(MethodInfo method, object? target = null, McpServerPromptCreateOptions? options = null)
```

#### Parameters

`method` [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo)
:   The method to be represented via the created [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

`target` [object](https://learn.microsoft.com/dotnet/api/system.object)
:   The instance if `method` is an instance method; otherwise, [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

`options` [McpServerPromptCreateOptions](ModelContextProtocol.Server.McpServerPromptCreateOptions.html)
:   Optional options used in the creation of the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) to control its behavior.

#### Returns

[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
:   The created [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is an instance method but `target` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### GetAsync(RequestContext<GetPromptRequestParams>, CancellationToken)

Gets the prompt, rendering it with the provided request parameters and returning the prompt result.

```
public abstract ValueTask<GetPromptResult> GetAsync(RequestContext<GetPromptRequestParams> request, CancellationToken cancellationToken = default)
```

#### Parameters

`request` [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html)>
:   The request context containing information about the prompt invocation, including any arguments
    passed to the prompt. This object provides access to both the request parameters and the server context.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   A [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task) representing the asynchronous operation, containing a [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) with
    the prompt content and messages.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `request` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The prompt implementation returns [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) or an unsupported result type.

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




