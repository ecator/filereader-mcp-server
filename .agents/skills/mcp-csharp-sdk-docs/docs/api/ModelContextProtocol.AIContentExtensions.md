
##### Table of Contents

# Class AIContentExtensions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides extension methods for converting between Model Context Protocol (MCP) types and Microsoft.Extensions.AI types.

```
public static class AIContentExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    AIContentExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This class serves as an adapter layer between Model Context Protocol (MCP) types and the Microsoft.Extensions.AI.AIContent model types
from the Microsoft.Extensions.AI namespace.

## Methods

### CreateSamplingHandler(IChatClient, JsonSerializerOptions?)

Creates a sampling handler for use with [SamplingHandler](ModelContextProtocol.Client.McpClientHandlers.html#ModelContextProtocol_Client_McpClientHandlers_SamplingHandler) that will
satisfy sampling requests using the specified Microsoft.Extensions.AI.IChatClient.

```
public static Func<CreateMessageRequestParams?, IProgress<ProgressNotificationValue>, CancellationToken, ValueTask<CreateMessageResult>> CreateSamplingHandler(this IChatClient chatClient, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`chatClient` IChatClient
:   The Microsoft.Extensions.AI.IChatClient with which to satisfy sampling requests.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for serializing user-provided objects. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

[Func](https://learn.microsoft.com/dotnet/api/system.func-4)<[CreateMessageRequestParams](ModelContextProtocol.Protocol.CreateMessageRequestParams.html), [IProgress](https://learn.microsoft.com/dotnet/api/system.iprogress-1)<[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)>, [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CreateMessageResult](ModelContextProtocol.Protocol.CreateMessageResult.html)>>
:   The created handler delegate that can be assigned to [SamplingHandler](ModelContextProtocol.Client.McpClientHandlers.html#ModelContextProtocol_Client_McpClientHandlers_SamplingHandler).

#### Remarks

This method creates a function that converts MCP message requests into chat client calls, enabling
an MCP client to generate text or other content using an actual AI model via the provided chat client.

The handler can process text messages, image messages, resource messages, and tool use/results as defined in the
Model Context Protocol.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `chatClient` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToAIContent(ContentBlock, JsonSerializerOptions?)

Creates a new Microsoft.Extensions.AI.AIContent from the content of a [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html).

```
public static AIContent? ToAIContent(this ContentBlock content, JsonSerializerOptions? options = null)
```

#### Parameters

`content` [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)
:   The [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) to convert.

`options` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for deserialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

AIContent
:   The created Microsoft.Extensions.AI.AIContent. If the content can't be converted (such as when it's a resource link), [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) is returned.

#### Remarks

This method converts Model Context Protocol content types to the equivalent Microsoft.Extensions.AI
content types, enabling seamless integration between the protocol and AI client libraries.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `content` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToAIContent(ResourceContents)

Creates a new Microsoft.Extensions.AI.AIContent from the content of a [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html).

```
public static AIContent ToAIContent(this ResourceContents content)
```

#### Parameters

`content` [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html)
:   The [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) to convert.

#### Returns

AIContent
:   The created Microsoft.Extensions.AI.AIContent.

#### Remarks

This method converts Model Context Protocol resource types to the equivalent Microsoft.Extensions.AI
content types, enabling seamless integration between the protocol and AI client libraries.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `content` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[NotSupportedException](https://learn.microsoft.com/dotnet/api/system.notsupportedexception)
:   The resource type is not supported.

### ToAIContents(IEnumerable<ContentBlock>, JsonSerializerOptions?)

Creates a list of Microsoft.Extensions.AI.AIContent from a sequence of [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html).

```
public static IList<AIContent> ToAIContents(this IEnumerable<ContentBlock> contents, JsonSerializerOptions? options = null)
```

#### Parameters

`contents` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)>
:   The [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) instances to convert.

`options` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for deserialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<AIContent>
:   The created Microsoft.Extensions.AI.AIContent instances.

#### Remarks

This method converts a collection of Model Context Protocol content objects into a collection of
Microsoft.Extensions.AI content objects. It's useful when working with multiple content items, such as
when processing the contents of a message or response.

Each [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object is converted using [ToAIContent(ContentBlock, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ContentBlock_System_Text_Json_JsonSerializerOptions_),
preserving the type-specific conversion logic for text, images, audio, and resources.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `contents` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToAIContents(IEnumerable<ResourceContents>)

Creates a list of Microsoft.Extensions.AI.AIContent from a sequence of [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html).

```
public static IList<AIContent> ToAIContents(this IEnumerable<ResourceContents> contents)
```

#### Parameters

`contents` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html)>
:   The [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) instances to convert.

#### Returns

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<AIContent>
:   A list of Microsoft.Extensions.AI.AIContent objects created from the resource contents.

#### Remarks

This method converts a collection of Model Context Protocol resource objects into a collection of
Microsoft.Extensions.AI content objects. It's useful when working with multiple resources, such as
when processing the contents of a [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html).

Each [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) object is converted using [ToAIContent(ResourceContents)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ResourceContents_),
preserving the type-specific conversion logic: text resources become Microsoft.Extensions.AI.TextContent objects and
binary resources become Microsoft.Extensions.AI.DataContent objects.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `contents` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToChatMessage(CallToolResult, string, JsonSerializerOptions?)

Converts a [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) to a Microsoft.Extensions.AI.ChatMessage object.

```
public static ChatMessage ToChatMessage(this CallToolResult result, string callId, JsonSerializerOptions? options = null)
```

#### Parameters

`result` [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)
:   The tool result to convert.

`callId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The identifier for the function call request that triggered the tool invocation.

`options` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for serialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

ChatMessage
:   A Microsoft.Extensions.AI.ChatMessage object created from the tool result.

#### Remarks

This method transforms a protocol-specific [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) from the Model Context Protocol
into a standard Microsoft.Extensions.AI.ChatMessage object that can be used with AI client libraries. It produces a
Microsoft.Extensions.AI.ChatRole.Tool message containing a Microsoft.Extensions.AI.FunctionResultContent with result as a
serialized [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `result` or `callId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToChatMessage(PromptMessage, JsonSerializerOptions?)

Converts a [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) to a Microsoft.Extensions.AI.ChatMessage object.

```
public static ChatMessage ToChatMessage(this PromptMessage promptMessage, JsonSerializerOptions? options = null)
```

#### Parameters

`promptMessage` [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html)
:   The prompt message to convert.

`options` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for deserialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

ChatMessage
:   A Microsoft.Extensions.AI.ChatMessage object created from the prompt message.

#### Remarks

This method transforms a protocol-specific [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) from the Model Context Protocol
into a standard Microsoft.Extensions.AI.ChatMessage object that can be used with AI client libraries.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `promptMessage` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToChatMessages(GetPromptResult)

Converts a [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) to a list of Microsoft.Extensions.AI.ChatMessage objects.

```
public static IList<ChatMessage> ToChatMessages(this GetPromptResult promptResult)
```

#### Parameters

`promptResult` [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)
:   The prompt result containing messages to convert.

#### Returns

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<ChatMessage>
:   A list of Microsoft.Extensions.AI.ChatMessage objects created from the prompt messages.

#### Remarks

This method transforms protocol-specific [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) objects from a Model Context Protocol
prompt result into standard Microsoft.Extensions.AI.ChatMessage objects that can be used with AI client libraries.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `promptResult` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToContentBlock(AIContent, JsonSerializerOptions?)

Creates a new [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) from the content of an Microsoft.Extensions.AI.AIContent.

```
public static ContentBlock ToContentBlock(this AIContent content, JsonSerializerOptions? options = null)
```

#### Parameters

`content` AIContent
:   The Microsoft.Extensions.AI.AIContent to convert.

`options` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to use for serialization. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) is used.

#### Returns

[ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)
:   The created [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `content` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToPromptMessages(ChatMessage)

Converts a Microsoft.Extensions.AI.ChatMessage to a list of [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) objects.

```
public static IList<PromptMessage> ToPromptMessages(this ChatMessage chatMessage)
```

#### Parameters

`chatMessage` ChatMessage
:   The chat message to convert.

#### Returns

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html)>
:   A list of [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) objects created from the chat message's contents.

#### Remarks

This method transforms standard Microsoft.Extensions.AI.ChatMessage objects used with AI client libraries into
protocol-specific [PromptMessage](ModelContextProtocol.Protocol.PromptMessage.html) objects for the Model Context Protocol system.
Only representable content items are processed.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `chatMessage` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




