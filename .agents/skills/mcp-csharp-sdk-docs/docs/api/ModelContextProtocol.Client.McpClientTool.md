
##### Table of Contents

# Class McpClientTool

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an Microsoft.Extensions.AI.AIFunction that calls a tool via an [McpClient](ModelContextProtocol.Client.McpClient.html).

```
public sealed class McpClientTool : AIFunction
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    AITool

    AIFunctionDeclaration

    AIFunction

    McpClientTool

Inherited Members
:   [AIFunction.InvokeAsync(AIFunctionArguments, CancellationToken)](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)

    AIFunction.AsDeclarationOnly()

    AIFunction.UnderlyingMethod

    AITool.ToString()

    [AITool.GetService(Type, object)](https://learn.microsoft.com/dotnet/api/system.type)

    [AITool.GetService<TService>(object)](https://learn.microsoft.com/dotnet/api/system.object)

    AITool.AdditionalProperties

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

The [McpClientTool](ModelContextProtocol.Client.McpClientTool.html) class encapsulates an [McpClient](ModelContextProtocol.Client.McpClient.html) along with a description of
a tool available via that client, allowing it to be invoked as an Microsoft.Extensions.AI.AIFunction. This enables integration
with AI models that support function calling capabilities.

Tools retrieved from an MCP server can be customized for model presentation using methods like
[WithName(string)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithName_System_String_) and [WithDescription(string)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithDescription_System_String_) without changing the underlying tool functionality.

Typically, you would get instances of this class by calling the [ListToolsAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListToolsAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_)
method on an [McpClient](ModelContextProtocol.Client.McpClient.html) instance.

## Constructors

### McpClientTool(McpClient, Tool, JsonSerializerOptions?)

Initializes a new instance of the [McpClientTool](ModelContextProtocol.Client.McpClientTool.html) class.

```
public McpClientTool(McpClient client, Tool tool, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`client` [McpClient](ModelContextProtocol.Client.McpClient.html)
:   The [McpClient](ModelContextProtocol.Client.McpClient.html) instance to use for invoking the tool.

`tool` [Tool](ModelContextProtocol.Protocol.Tool.html)
:   The protocol [Tool](ModelContextProtocol.Protocol.Tool.html) definition describing the tool's metadata and schema.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The JSON serialization options governing argument serialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null),
    [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Remarks

This constructor enables reusing cached tool definitions across different [McpClient](ModelContextProtocol.Client.McpClient.html) instances
without needing to call [ListToolsAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListToolsAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) on every reconnect.
This is particularly useful in scenarios where tool definitions are stable and network round-trips should be minimized.

The provided `tool` must represent a tool that is actually available on the server
associated with the `client`. Attempting to invoke a tool that doesn't exist on the
server will result in an [McpException](ModelContextProtocol.McpException.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `client` or `tool` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Description

Gets a description of the tool, suitable for use in describing the purpose to a model.

```
public override string Description { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### JsonSchema

Gets a JSON Schema describing the function and its input parameters.

```
public override JsonElement JsonSchema { get; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)

#### Remarks

When specified, declares a self-contained JSON schema document that describes the function and its input parameters.
A simple example of a JSON schema for a function that adds two numbers together is shown below:

```
{
  "type": "object",
  "properties": {
    "a" : { "type": "number" },
    "b" : { "type": ["number","null"], "default": 1 }
  },
  "required" : ["a"]
}
```

The metadata present in the schema document plays an important role in guiding AI function invocation.

When an Microsoft.Extensions.AI.AIFunction is created via Microsoft.Extensions.AI.AIFunctionFactory, this schema is automatically derived from the
method's parameters using the configured [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) and Microsoft.Extensions.AI.AIJsonSchemaCreateOptions.

When no schema is specified, consuming chat clients should assume the "{}" or "true" schema, indicating that any JSON input is admissible.

### JsonSerializerOptions

Gets a Microsoft.Extensions.AI.AIFunction.JsonSerializerOptions that can be used to marshal function parameters.

```
public override JsonSerializerOptions JsonSerializerOptions { get; }
```

#### Property Value

[JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)

### Name

Gets the name of the tool.

```
public override string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ProtocolTool

Gets the protocol [Tool](ModelContextProtocol.Protocol.Tool.html) type for this instance.

```
public Tool ProtocolTool { get; }
```

#### Property Value

[Tool](ModelContextProtocol.Protocol.Tool.html)

#### Remarks

This property provides direct access to the underlying protocol representation of the tool,
which can be useful for advanced scenarios or when implementing custom MCP client extensions.
It contains the original metadata about the tool as provided by the server, including its
name, description, and schema information before any customizations applied through methods
like [WithName(string)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithName_System_String_) or [WithDescription(string)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithDescription_System_String_).

### ReturnJsonSchema

Gets a JSON Schema describing the function's return value.

```
public override JsonElement? ReturnJsonSchema { get; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)?

#### Remarks

When an Microsoft.Extensions.AI.AIFunction is created via Microsoft.Extensions.AI.AIFunctionFactory, this schema is automatically derived from the
method's return type using the configured [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) and Microsoft.Extensions.AI.AIJsonSchemaCreateOptions.
For methods returning [Task<TResult>](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1) or [ValueTask<TResult>](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1), the schema is based on the
unwrapped result type. Return schema generation can be excluded by setting
Microsoft.Extensions.AI.AIFunctionFactoryOptions.ExcludeResultSchema to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

A [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) value typically reflects a function that doesn't specify a return schema,
a function that returns [void](https://learn.microsoft.com/dotnet/api/system.void), [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task), or [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask),
or a function for which Microsoft.Extensions.AI.AIFunctionFactoryOptions.ExcludeResultSchema was set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### Title

Gets the tool's title.

```
public string? Title { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### CallAsync(IReadOnlyDictionary<string, object?>?, IProgress<ProgressNotificationValue>?, RequestOptions?, CancellationToken)

Invokes the tool on the server.

```
public ValueTask<CallToolResult> CallAsync(IReadOnlyDictionary<string, object?>? arguments = null, IProgress<ProgressNotificationValue>? progress = null, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`arguments` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   An optional dictionary of arguments to pass to the tool. Each key represents a parameter name,
    and its associated value represents the argument value.

`progress` [IProgress](https://learn.microsoft.com/dotnet/api/system.iprogress-1)<[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)>
:   An optional [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) to have progress notifications reported to it. Setting this to a non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null)
    value will result in a progress token being included in the call, and any resulting progress notifications during the operation
    routed to this instance.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   A task containing the [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) from the tool execution. The response includes
    the tool's output content, which can be structured data, text, or an error message.

#### Examples

```
var result = await tool.CallAsync(
    new Dictionary<string, object?>
    {
        ["message"] = "Hello MCP!"
    });
```

#### Remarks

The base [InvokeAsync(AIFunctionArguments, CancellationToken)](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) method is overridden to invoke this [CallAsync(IReadOnlyDictionary<string, object?>?, IProgress<ProgressNotificationValue>?, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_CallAsync_System_Collections_Generic_IReadOnlyDictionary_System_String_System_Object__System_IProgress_ModelContextProtocol_ProgressNotificationValue__ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) method.
The only difference in behavior is that [InvokeAsync(AIFunctionArguments, CancellationToken)](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) serializes the resulting [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)
such that the [object](https://learn.microsoft.com/dotnet/api/system.object) returned is a [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement) containing the serialized [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html).
This [CallAsync(IReadOnlyDictionary<string, object?>?, IProgress<ProgressNotificationValue>?, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_CallAsync_System_Collections_Generic_IReadOnlyDictionary_System_String_System_Object__System_IProgress_ModelContextProtocol_ProgressNotificationValue__ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) method is intended to be called directly by user code, whereas the base [InvokeAsync(AIFunctionArguments, CancellationToken)](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
is intended to be used polymorphically via the base class, typically as part of an Microsoft.Extensions.AI.IChatClient operation.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The server could not find the requested tool, or the server encountered an error while processing the request.

### InvokeCoreAsync(AIFunctionArguments, CancellationToken)

Invokes the Microsoft.Extensions.AI.AIFunction and returns its result.

```
protected override ValueTask<object?> InvokeCoreAsync(AIFunctionArguments arguments, CancellationToken cancellationToken)
```

#### Parameters

`arguments` AIFunctionArguments
:   The arguments to pass to the function's invocation.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests.

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>
:   The result of the function's execution.

### WithDescription(string)

Creates a new instance of the tool but modified to return the specified description from its [Description](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_Description) property.

```
public McpClientTool WithDescription(string description)
```

#### Parameters

`description` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The description to give the tool.

#### Returns

[McpClientTool](ModelContextProtocol.Client.McpClientTool.html)
:   A new instance of [McpClientTool](ModelContextProtocol.Client.McpClientTool.html) with the provided description.

#### Remarks

Changing the description can help the model better understand the tool's purpose or provide more
context about how the tool should be used. This is particularly useful when:

* The original description is too technical or lacks clarity for the model.
* You want to add example usage scenarios to improve the model's understanding.
* You need to tailor the tool's description for specific model requirements.

When invoking [InvokeAsync(AIFunctionArguments, CancellationToken)](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), the MCP server will still be called with
the original tool description, so no mapping is required on the server side. This new description only affects
the value returned from this instance's Microsoft.Extensions.AI.AITool.Description.

### WithMeta(JsonObject?)

Creates a new instance of the tool but modified to include the specified metadata in tool call requests.

```
public McpClientTool WithMeta(JsonObject? meta)
```

#### Parameters

`meta` [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)
:   The metadata to include in tool call requests. This will be serialized as the `_meta` field
    in the JSON-RPC request parameters.

#### Returns

[McpClientTool](ModelContextProtocol.Client.McpClientTool.html)
:   A new instance of [McpClientTool](ModelContextProtocol.Client.McpClientTool.html), configured with the provided metadata.

#### Remarks

Adding metadata to the tool allows you to pass additional protocol-level information with each tool call.
This can be useful for tracing, logging, or passing context information to the server.

Only one metadata object can be specified at a time. Calling [WithMeta(JsonObject?)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithMeta_System_Text_Json_Nodes_JsonObject_) again
will overwrite any previously specified metadata object. If passed [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null),
any previously supplied metadata will be removed.

The metadata is passed through to the server as-is, merged with any protocol-level metadata
such as progress tokens when [WithProgress(IProgress<ProgressNotificationValue>)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithProgress_System_IProgress_ModelContextProtocol_ProgressNotificationValue__) is also used. If a [RequestOptions](ModelContextProtocol.RequestOptions.html)
is passed to [CallAsync(IReadOnlyDictionary<string, object?>?, IProgress<ProgressNotificationValue>?, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_CallAsync_System_Collections_Generic_IReadOnlyDictionary_System_String_System_Object__System_IProgress_ModelContextProtocol_ProgressNotificationValue__ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_), the metadata from both `meta` and its
[RequestOptions](ModelContextProtocol.RequestOptions.html) will be merged, preferring values from the [RequestOptions](ModelContextProtocol.RequestOptions.html) in
case of conflicts.

### WithName(string)

Creates a new instance of the tool but modified to return the specified name from its [Name](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_Name) property.

```
public McpClientTool WithName(string name)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The model-facing name to give the tool.

#### Returns

[McpClientTool](ModelContextProtocol.Client.McpClientTool.html)
:   A new instance of [McpClientTool](ModelContextProtocol.Client.McpClientTool.html) with the provided name.

#### Remarks

This method is useful for optimizing the tool name for specific models or for prefixing the tool name
with a namespace to avoid conflicts.

Changing the name can help with:

* Making the tool name more intuitive for the model.
* Preventing name collisions when using tools from multiple sources.
* Creating specialized versions of a general tool for specific contexts.

When invoking [InvokeAsync(AIFunctionArguments, CancellationToken)](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), the MCP server will still be called with
the original tool name, so no mapping is required on the server side. This new name only affects
the value returned from this instance's Microsoft.Extensions.AI.AITool.Name.

### WithProgress(IProgress<ProgressNotificationValue>)

Creates a new instance of the tool but modified to report progress via the specified [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1).

```
public McpClientTool WithProgress(IProgress<ProgressNotificationValue> progress)
```

#### Parameters

`progress` [IProgress](https://learn.microsoft.com/dotnet/api/system.iprogress-1)<[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)>
:   The [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) to which progress notifications should be reported.

#### Returns

[McpClientTool](ModelContextProtocol.Client.McpClientTool.html)
:   A new instance of [McpClientTool](ModelContextProtocol.Client.McpClientTool.html), configured with the provided progress instance.

#### Remarks

Adding an [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) to the tool does not impact how it is reported to any AI model.
Rather, when the tool is invoked, the request to the MCP server will include a unique progress token,
and any progress notifications issued by the server with that progress token while the operation is in
flight will be reported to the `progress` instance.

Only one [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1) can be specified at a time. Calling [WithProgress(IProgress<ProgressNotificationValue>)](ModelContextProtocol.Client.McpClientTool.html#ModelContextProtocol_Client_McpClientTool_WithProgress_System_IProgress_ModelContextProtocol_ProgressNotificationValue__) again
overwrites any previously specified progress instance.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `progress` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




