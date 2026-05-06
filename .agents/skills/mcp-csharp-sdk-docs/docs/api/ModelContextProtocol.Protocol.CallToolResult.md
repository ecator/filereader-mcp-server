
##### Table of Contents

# Class CallToolResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the result of a [ToolsCall](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsCall) request from a client to invoke a tool provided by the server.

```
public sealed class CallToolResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    CallToolResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToChatMessage(CallToolResult, string, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToChatMessage_ModelContextProtocol_Protocol_CallToolResult_System_String_System_Text_Json_JsonSerializerOptions_)

## Remarks

Tool execution errors (including input validation errors, API failures, and business logic errors)
should be reported inside the result object with [IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError) set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool),
rather than as a [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html). This allows language models to see error details
and potentially self-correct in subsequent requests.

To return a validation or business-logic error from a tool method, either throw an [McpException](ModelContextProtocol.McpException.html)
(whose [Message](https://learn.microsoft.com/dotnet/api/system.exception.message) will be included in the error result), or declare the tool's return type
as [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) so it can be returned directly with [IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError) set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool)
and details in [Content](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_Content). Using [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) as the return type gives the tool full control
over both success and error responses.

Protocol-level errors (such as unknown tool names, malformed requests that fail schema validation,
or server errors) should be reported as MCP protocol error responses using [McpErrorCode](ModelContextProtocol.McpErrorCode.html).

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Content

Gets or sets the response content from the tool call.

```
[JsonPropertyName("content")]
public IList<ContentBlock> Content { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)>

### IsError

Gets or sets a value that indicates whether the tool call was unsuccessful.

```
[JsonPropertyName("isError")]
public bool? IsError { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) to signify that the tool execution failed; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it was successful.

#### Remarks

Tool execution errors (including input validation errors, API failures, and business logic errors)
are reported with this property set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) and details in the [Content](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_Content)
property, rather than as protocol-level errors.

This design allows language models to receive detailed error feedback and potentially self-correct
in subsequent requests. For example, if a date parameter is in the wrong format or out of range,
the error message in [Content](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_Content) can explain the issue, enabling the model to retry
with corrected parameters.

### StructuredContent

Gets or sets an optional JSON object representing the structured result of the tool call.

```
[JsonPropertyName("structuredContent")]
public JsonElement? StructuredContent { get; set; }
```

#### Property Value

[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)?

### Task

Gets or sets the task data for the newly created task.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
[JsonIgnore]
public McpTask? Task { get; set; }
```

#### Property Value

[McpTask](ModelContextProtocol.Protocol.McpTask.html)

#### Remarks

This property is populated only for task-augmented tool calls. When present, the other properties
([Content](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_Content), [StructuredContent](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_StructuredContent), [IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError)) may not be populated.
The actual tool result can be retrieved later via `tasks/result`.




