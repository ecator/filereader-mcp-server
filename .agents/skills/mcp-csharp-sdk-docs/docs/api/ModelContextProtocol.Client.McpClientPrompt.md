
##### Table of Contents

# Class McpClientPrompt

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a named prompt that can be retrieved from an MCP server and invoked with arguments.

```
public sealed class McpClientPrompt
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpClientPrompt

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class provides a client-side wrapper around a prompt defined on an MCP server. It allows
retrieving the prompt's content by sending a request to the server with optional arguments.
Instances of this class are typically obtained by calling [ListPromptsAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListPromptsAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_).

Each prompt has a name and optionally a description, and it can be invoked with arguments
to produce customized prompt content from the server.

## Constructors

### McpClientPrompt(McpClient, Prompt)

Initializes a new instance of the [McpClientPrompt](ModelContextProtocol.Client.McpClientPrompt.html) class.

```
public McpClientPrompt(McpClient client, Prompt prompt)
```

#### Parameters

`client` [McpClient](ModelContextProtocol.Client.McpClient.html)
:   The [McpClient](ModelContextProtocol.Client.McpClient.html) instance to use for invoking the prompt.

`prompt` [Prompt](ModelContextProtocol.Protocol.Prompt.html)
:   The protocol [Prompt](ModelContextProtocol.Protocol.Prompt.html) definition describing the prompt's metadata.

#### Remarks

This constructor enables reusing cached prompt definitions across different [McpClient](ModelContextProtocol.Client.McpClient.html) instances
without needing to call [ListPromptsAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListPromptsAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) on every reconnect. This is particularly useful
in scenarios where prompt definitions are stable and network round-trips should be minimized.

The provided `prompt` must represent a prompt that is actually available on the server
associated with the `client`. Attempting to invoke a prompt that doesn't exist on the
server will result in an [McpException](ModelContextProtocol.McpException.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `client` or `prompt` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Description

Gets the description of the prompt.

```
public string? Description { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Name

Gets the name of the prompt.

```
public string Name { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ProtocolPrompt

Gets the underlying protocol [Prompt](ModelContextProtocol.Protocol.Prompt.html) type for this instance.

```
public Prompt ProtocolPrompt { get; }
```

#### Property Value

[Prompt](ModelContextProtocol.Protocol.Prompt.html)

#### Remarks

This property provides direct access to the underlying protocol representation of the prompt,
which can be useful for advanced scenarios or when implementing custom MCP client extensions.

For most common use cases, you can use the more convenient [Name](ModelContextProtocol.Client.McpClientPrompt.html#ModelContextProtocol_Client_McpClientPrompt_Name) and
[Description](ModelContextProtocol.Client.McpClientPrompt.html#ModelContextProtocol_Client_McpClientPrompt_Description) properties instead of accessing the [ProtocolPrompt](ModelContextProtocol.Client.McpClientPrompt.html#ModelContextProtocol_Client_McpClientPrompt_ProtocolPrompt) directly.

### Title

Gets the title of the prompt.

```
public string? Title { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### GetAsync(IEnumerable<KeyValuePair<string, object?>>?, RequestOptions?, CancellationToken)

Gets this prompt's content by sending a request to the server with optional arguments.

```
public ValueTask<GetPromptResult> GetAsync(IEnumerable<KeyValuePair<string, object?>>? arguments = null, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`arguments` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[KeyValuePair](https://learn.microsoft.com/dotnet/api/system.collections.generic.keyvaluepair-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>>
:   Optional arguments to pass to the prompt. Keys are parameter names, and values are the argument values.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   A [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask) containing the prompt's result with content and messages.

#### Remarks

This method sends a request to the MCP server to execute this prompt with the provided arguments.
The server will process the request and return a result containing messages or other content.

This is a convenience method that internally calls
[GetPromptAsync(string, IReadOnlyDictionary<string, object?>?, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_GetPromptAsync_System_String_System_Collections_Generic_IReadOnlyDictionary_System_String_System_Object__ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_)
with this prompt's name and arguments.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.




