
##### Table of Contents

# Class CreateMessageRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [SamplingCreateMessage](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_SamplingCreateMessage)
request from a server to sample an LLM via the client.

```
public sealed class CreateMessageRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    CreateMessageRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### IncludeContext

Gets or sets an indication as to which server contexts should be included in the prompt.

```
[JsonPropertyName("includeContext")]
public ContextInclusion? IncludeContext { get; set; }
```

#### Property Value

[ContextInclusion](ModelContextProtocol.Protocol.ContextInclusion.html)?

#### Remarks

The client might ignore this request.

[ContextInclusion](ModelContextProtocol.Protocol.ContextInclusion.html), and in particular [ThisServer](ModelContextProtocol.Protocol.ContextInclusion.html#ModelContextProtocol_Protocol_ContextInclusion_ThisServer) and
[AllServers](ModelContextProtocol.Protocol.ContextInclusion.html#ModelContextProtocol_Protocol_ContextInclusion_AllServers), are deprecated. Servers should only use these values if the client
declares [Sampling](ModelContextProtocol.Protocol.ClientCapabilities.html#ModelContextProtocol_Protocol_ClientCapabilities_Sampling) with [Context](ModelContextProtocol.Protocol.SamplingCapability.html#ModelContextProtocol_Protocol_SamplingCapability_Context) set.
These values might be removed in future spec releases.

### MaxTokens

Gets or sets the maximum number of tokens to generate in the LLM response, as requested by the server.

```
[JsonPropertyName("maxTokens")]
public required int MaxTokens { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)

#### Remarks

A token is generally a word or part of a word in the text. Setting this value helps control
response length and computation time. The client can choose to sample fewer tokens than requested.

The client must respect the [MaxTokens](ModelContextProtocol.Protocol.CreateMessageRequestParams.html#ModelContextProtocol_Protocol_CreateMessageRequestParams_MaxTokens) parameter.

### Messages

Gets or sets the messages requested by the server to be included in the prompt.

```
[JsonPropertyName("messages")]
public IList<SamplingMessage> Messages { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[SamplingMessage](ModelContextProtocol.Protocol.SamplingMessage.html)>

#### Remarks

The list of messages in a sampling request should not be retained between separate requests.

### Metadata

Gets or sets optional metadata to pass through to the LLM provider.

```
[JsonPropertyName("metadata")]
public JsonObject? Metadata { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

The format of this metadata is provider-specific and can include model-specific settings or
configuration that isn't covered by standard parameters. This allows for passing custom parameters
that are specific to certain AI models or providers.

The client may modify or ignore metadata.

### ModelPreferences

Gets or sets the server's preferences for which model to select.

```
[JsonPropertyName("modelPreferences")]
public ModelPreferences? ModelPreferences { get; set; }
```

#### Property Value

[ModelPreferences](ModelContextProtocol.Protocol.ModelPreferences.html)

#### Remarks

The client might ignore these preferences.

These preferences help the client make an appropriate model selection based on the server's priorities
for cost, speed, intelligence, and specific model hints.

When multiple dimensions are specified (cost, speed, intelligence), the client should balance these
based on their relative values. If specific model hints are provided, the client should evaluate them
in order and prioritize them over numeric priorities.

### StopSequences

Gets or sets optional sequences of characters that signal the LLM to stop generating text when encountered.

```
[JsonPropertyName("stopSequences")]
public IList<string>? StopSequences { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

When the model generates any of these sequences during sampling, text generation stops immediately,
even if the maximum token limit hasn't been reached. This behavior is useful for controlling generation
endings or preventing the model from continuing beyond certain points.

Stop sequences are typically case-sensitive, and the LLM will only stop generation when a produced
sequence exactly matches one of the provided sequences. Common uses include ending markers like "END", punctuation
like ".", or special delimiter sequences like "###".

The client may modify or ignore stop sequences.

### SystemPrompt

Gets or sets an optional system prompt the server wants to use for sampling.

```
[JsonPropertyName("systemPrompt")]
public string? SystemPrompt { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The client might modify or omit this prompt.

### Task

Gets or sets optional task metadata to augment this request with task execution.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public McpTaskMetadata? Task { get; set; }
```

#### Property Value

[McpTaskMetadata](ModelContextProtocol.Protocol.McpTaskMetadata.html)

#### Remarks

When present, indicates that the requestor wants this operation executed as a task.
The receiver must support task augmentation for this specific request type.

### Temperature

Gets or sets the temperature to use for sampling, as requested by the server.

```
[JsonPropertyName("temperature")]
public float? Temperature { get; set; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)?

#### Remarks

Temperature controls randomness in model responses. Higher values produce higher randomness,
and lower values produce more stable output. The valid range depends on the model provider.

The client may modify or ignore this value.

### ToolChoice

Gets or sets controls for how the model uses tools.

```
[JsonPropertyName("toolChoice")]
public ToolChoice? ToolChoice { get; set; }
```

#### Property Value

[ToolChoice](ModelContextProtocol.Protocol.ToolChoice.html)

#### Remarks

This controls whether and how the model uses the request-scoped [Tools](ModelContextProtocol.Protocol.CreateMessageRequestParams.html#ModelContextProtocol_Protocol_CreateMessageRequestParams_Tools) during sampling.

### Tools

Gets or sets tools that the model can use during generation.

```
[JsonPropertyName("tools")]
public IList<Tool>? Tools { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Tool](ModelContextProtocol.Protocol.Tool.html)>

#### Remarks

The tool definitions in this array are scoped to this sampling request.
They do not need to correspond to tools registered on the server via [ToolsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsList).




