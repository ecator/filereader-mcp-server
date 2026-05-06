
##### Table of Contents

# Class McpServerTool

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an invocable tool used by Model Context Protocol clients and servers.

```
public abstract class McpServerTool : IMcpServerPrimitive
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerTool

Implements
:   [IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

Derived
:   [DelegatingMcpServerTool](ModelContextProtocol.Server.DelegatingMcpServerTool.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

[McpServerTool](ModelContextProtocol.Server.McpServerTool.html) is an abstract base class that represents an MCP tool for use in the server (as opposed
to [Tool](ModelContextProtocol.Protocol.Tool.html), which provides the protocol representation of a tool, and [McpClientTool](ModelContextProtocol.Client.McpClientTool.html), which
provides a client-side representation of a tool). Instances of [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) can be added into a
[IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) to be picked up automatically when [McpServer](ModelContextProtocol.Server.McpServer.html) is used to create
an [McpServer](ModelContextProtocol.Server.McpServer.html), or added into a [McpServerPrimitiveCollection<T>](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html).

Most commonly, [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances are created using the static McpServerTool.Create methods.
These methods enable creating an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) for a method, specified via a [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate) or
[MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo), and are what are used implicitly by WithToolsFromAssembly and WithTools. The McpServerTool.Create methods
create [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances capable of working with a large variety of .NET method signatures, automatically handling
how parameters are marshaled into the method from the JSON received from the MCP client, and how the return value is marshaled back
into the [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) that's then serialized and sent back to the client.

By default, parameters are sourced from the [Arguments](ModelContextProtocol.Protocol.CallToolRequestParams.html#ModelContextProtocol_Protocol_CallToolRequestParams_Arguments) dictionary, which is a collection
of key/value pairs, and are represented in the JSON schema for the function, as exposed in the returned [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)'s
[ProtocolTool](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_ProtocolTool)'s [InputSchema](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_InputSchema). Those parameters are deserialized from the
[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement) values in that collection. There are a few exceptions to this:

* [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) parameters are automatically bound to a [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) provided by the
  [McpServer](ModelContextProtocol.Server.McpServer.html) and that respects any [CancelledNotificationParams](ModelContextProtocol.Protocol.CancelledNotificationParams.html)s sent by the client for this operation's
  [RequestId](ModelContextProtocol.Protocol.RequestId.html). The parameter is not included in the generated JSON schema.
* [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) parameters are bound from the [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html) for this request,
  and are not included in the JSON schema.
* [McpServer](ModelContextProtocol.Server.McpServer.html) parameters are not included in the JSON schema and are bound directly to the [McpServer](ModelContextProtocol.Server.McpServer.html)
  instance associated with this request's [RequestContext<TParams>](ModelContextProtocol.Server.RequestContext-1.html). Such parameters may be used to understand
  what server is being used to process the request, and to interact with the client issuing the request to that server.
* [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) parameters accepting [ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html) values
  are not included in the JSON schema and are bound to an [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) instance manufactured
  to forward progress notifications from the tool to the client. If the client included a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html) in their request,
  progress reports issued to this instance will propagate to the client as [ProgressNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ProgressNotification) notifications with
  that token. If the client did not include a [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html), the instance will ignore any progress reports issued to it.
* When the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) is constructed, it may be passed an [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) via
  [Services](ModelContextProtocol.Server.McpServerToolCreateOptions.html#ModelContextProtocol_Server_McpServerToolCreateOptions_Services). Any parameter that can be satisfied by that [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)
  according to [IServiceProviderIsService](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice) will not be included in the generated JSON schema and will be resolved
  from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to [InvokeAsync(RequestContext<CallToolRequestParams>, CancellationToken)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_InvokeAsync_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_CallToolRequestParams__System_Threading_CancellationToken_) rather than from the argument collection.
* Any parameter attributed with [FromKeyedServicesAttribute](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.fromkeyedservicesattribute) will similarly be resolved from the
  [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided to [InvokeAsync(RequestContext<CallToolRequestParams>, CancellationToken)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_InvokeAsync_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_CallToolRequestParams__System_Threading_CancellationToken_) rather than from the argument
  collection, and will not be included in the generated JSON schema.

All other parameters are deserialized from the [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)s in the [Arguments](ModelContextProtocol.Protocol.CallToolRequestParams.html#ModelContextProtocol_Protocol_CallToolRequestParams_Arguments) dictionary,
using the [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) supplied in [SerializerOptions](ModelContextProtocol.Server.McpServerToolCreateOptions.html#ModelContextProtocol_Server_McpServerToolCreateOptions_SerializerOptions), or if none was provided,
using [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions).

In general, the data supplied via the [Arguments](ModelContextProtocol.Protocol.CallToolRequestParams.html#ModelContextProtocol_Protocol_CallToolRequestParams_Arguments)'s dictionary is passed along from the caller and
should thus be considered unvalidated and untrusted. To provide validated and trusted data to the invocation of the tool, consider having
the tool be an instance method, referring to data stored in the instance, or using an instance or parameters resolved from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)
to provide data to the method.

The tool method is responsible for validating its own input arguments (e.g., checking required fields, value ranges, string lengths, or
any other business rules). Data annotations such as `RequiredAttribute` and
`MaxLengthAttribute` on parameter types influence the generated JSON schema exposed
to clients, but they are not enforced at runtime by the SDK. Validation should be performed explicitly within the tool method.

To signal an error (including validation failures) back to the client, either throw an [McpException](ModelContextProtocol.McpException.html)
or return a [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) with [IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError) set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).
When a tool throws an [McpException](ModelContextProtocol.McpException.html), its [Message](https://learn.microsoft.com/dotnet/api/system.exception.message) is included in the error result
sent to the client. Throwing any other exception type also results in an error [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html), but with
a generic error message (to avoid leaking sensitive information). Alternatively, a tool can declare a return type of
[CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) to have full control over both success and error responses.

It is important to provide clear [DescriptionAttribute](https://learn.microsoft.com/dotnet/api/system.componentmodel.descriptionattribute) values on tool methods and their parameters.
These descriptions are surfaced to AI models and help them determine when and how to use the tool, what values to pass for each parameter,
and what constraints the parameters have. Well-written descriptions reduce incorrect tool invocations and improve the quality of
model interactions.

Return values from a method are used to create the [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) that is sent back to the client:

|  |  |
| --- | --- |
| [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) | Returns an empty [Content](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_Content) list. |
| Microsoft.Extensions.AI.AIContent | Converted to a single [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object using [ToContentBlock(AIContent, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToContentBlock_Microsoft_Extensions_AI_AIContent_System_Text_Json_JsonSerializerOptions_). |
| [string](https://learn.microsoft.com/dotnet/api/system.string) | Converted to a single [TextContentBlock](ModelContextProtocol.Protocol.TextContentBlock.html) object with its text set to the string value. |
| [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) | Returned as a single-item [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) list. |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of Microsoft.Extensions.AI.AIContent | Each Microsoft.Extensions.AI.AIContent is converted to a [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object using [ToContentBlock(AIContent, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToContentBlock_Microsoft_Extensions_AI_AIContent_System_Text_Json_JsonSerializerOptions_). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) | Returned as the [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) list. |
| [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) | Returned directly without modification. |
| Other types | Serialized to JSON and returned as a single [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object with [Type](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Type) set to "text". |

## Constructors

### McpServerTool()

Initializes a new instance of the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) class.

```
protected McpServerTool()
```

## Properties

### Metadata

Gets the metadata for this tool instance.

```
public abstract IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.

### ProtocolTool

Gets the protocol [Tool](ModelContextProtocol.Protocol.Tool.html) type for this instance.

```
public abstract Tool ProtocolTool { get; }
```

#### Property Value

[Tool](ModelContextProtocol.Protocol.Tool.html)

## Methods

### Create(AIFunction, McpServerToolCreateOptions?)

Creates an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) that wraps the specified Microsoft.Extensions.AI.AIFunction.

```
public static McpServerTool Create(AIFunction function, McpServerToolCreateOptions? options = null)
```

#### Parameters

`function` AIFunction
:   The function to wrap.

`options` [McpServerToolCreateOptions](ModelContextProtocol.Server.McpServerToolCreateOptions.html)
:   Optional options used in the creation of the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) to control its behavior.

#### Returns

[McpServerTool](ModelContextProtocol.Server.McpServerTool.html)

#### Remarks

Unlike the other overloads of Create, the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) created by [Create(AIFunction, McpServerToolCreateOptions?)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_Create_Microsoft_Extensions_AI_AIFunction_ModelContextProtocol_Server_McpServerToolCreateOptions_)
does not provide all of the special parameter handling for MCP-specific concepts, like [McpServer](ModelContextProtocol.Server.McpServer.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `function` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(Delegate, McpServerToolCreateOptions?)

Creates an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instance for a method, specified via a [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate) instance.

```
public static McpServerTool Create(Delegate method, McpServerToolCreateOptions? options = null)
```

#### Parameters

`method` [Delegate](https://learn.microsoft.com/dotnet/api/system.delegate)
:   The method to be represented via the created [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

`options` [McpServerToolCreateOptions](ModelContextProtocol.Server.McpServerToolCreateOptions.html)
:   Optional options used in the creation of the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) to control its behavior.

#### Returns

[McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
:   The created [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(MethodInfo, Func<RequestContext<CallToolRequestParams>, object>, McpServerToolCreateOptions?)

Creates an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instance for a method, specified via a [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo) for
an instance method, along with a [Type](https://learn.microsoft.com/dotnet/api/system.type) representing the type of the target object to
instantiate each time the method is invoked.

```
public static McpServerTool Create(MethodInfo method, Func<RequestContext<CallToolRequestParams>, object> createTargetFunc, McpServerToolCreateOptions? options = null)
```

#### Parameters

`method` [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo)
:   The instance method to be represented via the created [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

`createTargetFunc` [Func](https://learn.microsoft.com/dotnet/api/system.func-2)<[RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html)>, [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   Callback used on each function invocation to create an instance of the type on which the instance method `method`
    will be invoked. If the returned instance is [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) or [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), it will
    be disposed of after method completes its invocation.

`options` [McpServerToolCreateOptions](ModelContextProtocol.Server.McpServerToolCreateOptions.html)
:   Optional options used in the creation of the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) to control its behavior.

#### Returns

[McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
:   The created [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` or `createTargetFunc` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### Create(MethodInfo, object?, McpServerToolCreateOptions?)

Creates an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instance for a method, specified via a [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo) instance.

```
public static McpServerTool Create(MethodInfo method, object? target = null, McpServerToolCreateOptions? options = null)
```

#### Parameters

`method` [MethodInfo](https://learn.microsoft.com/dotnet/api/system.reflection.methodinfo)
:   The method to be represented via the created [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

`target` [object](https://learn.microsoft.com/dotnet/api/system.object)
:   The instance if `method` is an instance method; otherwise, [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

`options` [McpServerToolCreateOptions](ModelContextProtocol.Server.McpServerToolCreateOptions.html)
:   Optional options used in the creation of the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) to control its behavior.

#### Returns

[McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
:   The created [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) for invoking `method`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `method` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `method` is an instance method but `target` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### InvokeAsync(RequestContext<CallToolRequestParams>, CancellationToken)

Invokes the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public abstract ValueTask<CallToolResult> InvokeAsync(RequestContext<CallToolRequestParams> request, CancellationToken cancellationToken = default)
```

#### Parameters

`request` [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html)>
:   The request information resulting in the invocation of this tool.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   The call response from invoking the tool.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `request` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




