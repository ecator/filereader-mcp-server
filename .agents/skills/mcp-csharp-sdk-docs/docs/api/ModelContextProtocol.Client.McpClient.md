
##### Table of Contents

# Class McpClient

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an instance of a Model Context Protocol (MCP) client session that connects to and communicates with an MCP server.

```
public abstract class McpClient : McpSession, IAsyncDisposable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [McpSession](ModelContextProtocol.McpSession.html)

    McpClient

Implements
:   [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)

Inherited Members
:   [McpSession.SessionId](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SessionId)

    [McpSession.NegotiatedProtocolVersion](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_NegotiatedProtocolVersion)

    [McpSession.SendRequestAsync(JsonRpcRequest, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendRequestAsync_ModelContextProtocol_Protocol_JsonRpcRequest_System_Threading_CancellationToken_)

    [McpSession.SendMessageAsync(JsonRpcMessage, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendMessageAsync_ModelContextProtocol_Protocol_JsonRpcMessage_System_Threading_CancellationToken_)

    [McpSession.RegisterNotificationHandler(string, Func<JsonRpcNotification, CancellationToken, ValueTask>)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_RegisterNotificationHandler_System_String_System_Func_ModelContextProtocol_Protocol_JsonRpcNotification_System_Threading_CancellationToken_System_Threading_Tasks_ValueTask__)

    [McpSession.DisposeAsync()](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_DisposeAsync)

    [McpSession.SendRequestAsync<TParameters, TResult>(string, TParameters, JsonSerializerOptions, RequestId, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendRequestAsync__2_System_String___0_System_Text_Json_JsonSerializerOptions_ModelContextProtocol_Protocol_RequestId_System_Threading_CancellationToken_)

    [McpSession.SendNotificationAsync(string, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendNotificationAsync_System_String_System_Threading_CancellationToken_)

    [McpSession.SendNotificationAsync<TParameters>(string, TParameters, JsonSerializerOptions, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_SendNotificationAsync__1_System_String___0_System_Text_Json_JsonSerializerOptions_System_Threading_CancellationToken_)

    [McpSession.NotifyProgressAsync(ProgressToken, ProgressNotificationValue, RequestOptions, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_NotifyProgressAsync_ModelContextProtocol_Protocol_ProgressToken_ModelContextProtocol_ProgressNotificationValue_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_)

    [McpSession.NotifyProgressAsync(ProgressNotificationParams, CancellationToken)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_NotifyProgressAsync_ModelContextProtocol_Protocol_ProgressNotificationParams_System_Threading_CancellationToken_)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### McpClient()

Initializes a new instance of the [McpClient](ModelContextProtocol.Client.McpClient.html) class.

```
[Experimental("MCPEXP002", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp002")]
protected McpClient()
```

## Properties

### Completion

Gets a [Task<TResult>](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1) that completes when the client session has completed.

```
public abstract Task<ClientCompletionDetails> Completion { get; }
```

#### Property Value

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[ClientCompletionDetails](ModelContextProtocol.Client.ClientCompletionDetails.html)>

#### Remarks

The task always completes successfully. The result provides details about why the session
completed. Transport implementations may return derived types with additional strongly-typed
information, such as [StdioClientCompletionDetails](ModelContextProtocol.Client.StdioClientCompletionDetails.html).

For graceful closure (e.g., explicit disposal), [Exception](ModelContextProtocol.Client.ClientCompletionDetails.html#ModelContextProtocol_Client_ClientCompletionDetails_Exception)
will be [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null). For unexpected closure (e.g., process crash, network failure),
it may contain an exception that caused or that represents the failure.

### ServerCapabilities

Gets the capabilities supported by the connected server.

```
public abstract ServerCapabilities ServerCapabilities { get; }
```

#### Property Value

[ServerCapabilities](ModelContextProtocol.Protocol.ServerCapabilities.html)

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client is not connected.

### ServerInfo

Gets the implementation information of the connected server.

```
public abstract Implementation ServerInfo { get; }
```

#### Property Value

[Implementation](ModelContextProtocol.Protocol.Implementation.html)

#### Remarks

This property provides identification details about the connected server, including its name and version.
It is populated during the initialization handshake and is available after a successful connection.

This information can be useful for logging, debugging, compatibility checks, and displaying server
information to users.

#### Exceptions

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The client is not connected.

### ServerInstructions

Gets any instructions describing how to use the connected server and its features.

```
public abstract string? ServerInstructions { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This property contains instructions provided by the server during initialization that explain
how to effectively use its capabilities. They should focus on guidance that helps a model
use the server effectively and should avoid duplicating tool, prompt, or resource descriptions.

This can be used by clients to improve an LLM's understanding of how to use the server.
It can be thought of like a "hint" to the model and can be added to a system prompt.

## Methods

### CallToolAsTaskAsync(string, IReadOnlyDictionary<string, object?>?, McpTaskMetadata?, IProgress<ProgressNotificationValue>?, RequestOptions?, CancellationToken)

Invokes a tool on the server as a task for long-running operations.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> CallToolAsTaskAsync(string toolName, IReadOnlyDictionary<string, object?>? arguments = null, McpTaskMetadata? taskMetadata = null, IProgress<ProgressNotificationValue>? progress = null, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`toolName` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the tool to call on the server.

`arguments` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   An optional dictionary of arguments to pass to the tool.

`taskMetadata` [McpTaskMetadata](ModelContextProtocol.Protocol.McpTaskMetadata.html)
:   Metadata for task augmentation, including optional TTL. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), an empty metadata is used.

`progress` [IProgress](https://learn.microsoft.com/dotnet/api/system.iprogress-1)<[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)>
:   An optional progress reporter for server notifications.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   An [McpTask](ModelContextProtocol.Protocol.McpTask.html) representing the created task. Use [GetTaskAsync(string, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_GetTaskAsync_System_String_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) to poll for status updates
    and [GetTaskResultAsync(string, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_GetTaskResultAsync_System_String_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) to retrieve the final result.

#### Remarks

Task-augmented tool calls allow long-running operations to be executed asynchronously. Instead of blocking
until the tool completes, the server immediately returns a task identifier that can be used to poll for
status updates and retrieve the final result.

The server must advertise task support via `capabilities.tasks.requests.tools.call` and the tool
must have `execution.taskSupport` set to `"optional"` or `"required"`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `toolName` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### CallToolAsync(CallToolRequestParams, CancellationToken)

Invokes a tool on the server.

```
public ValueTask<CallToolResult> CallToolAsync(CallToolRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   The result of the request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### CallToolAsync(string, IReadOnlyDictionary<string, object?>?, IProgress<ProgressNotificationValue>?, RequestOptions?, CancellationToken)

Invokes a tool on the server.

```
public ValueTask<CallToolResult> CallToolAsync(string toolName, IReadOnlyDictionary<string, object?>? arguments = null, IProgress<ProgressNotificationValue>? progress = null, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`toolName` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the tool to call on the server.

`arguments` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   An optional dictionary of arguments to pass to the tool.

`progress` [IProgress](https://learn.microsoft.com/dotnet/api/system.iprogress-1)<[ProgressNotificationValue](ModelContextProtocol.ProgressNotificationValue.html)>
:   An optional progress reporter for server notifications.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   The [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) from the tool execution.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `toolName` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### CancelTaskAsync(string, RequestOptions?, CancellationToken)

Cancels a running task on the server.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> CancelTaskAsync(string taskId, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to cancel.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The updated state of the task after cancellation.

#### Remarks

Cancelling a task requests that the server stop execution. The server may not immediately cancel the task,
and may choose to allow the task to complete if it's close to finishing.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### CompleteAsync(CompleteRequestParams, CancellationToken)

Requests completion suggestions for a prompt argument or resource reference.

```
public ValueTask<CompleteResult> CompleteAsync(CompleteRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [CompleteRequestParams](ModelContextProtocol.Protocol.CompleteRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)>
:   The result of the request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### CompleteAsync(Reference, string, string, RequestOptions?, CancellationToken)

Requests completion suggestions for a prompt argument or resource reference.

```
public ValueTask<CompleteResult> CompleteAsync(Reference reference, string argumentName, string argumentValue, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`reference` [Reference](ModelContextProtocol.Protocol.Reference.html)
:   The reference object specifying the type and optional URI or name.

`argumentName` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the argument for which completions are requested.

`argumentValue` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The current value of the argument, used to filter relevant completions.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)>
:   A [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html) containing completion suggestions.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `reference` or `argumentName` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `argumentName` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### CreateAsync(IClientTransport, McpClientOptions?, ILoggerFactory?, CancellationToken)

Creates an [McpClient](ModelContextProtocol.Client.McpClient.html), connecting it to the specified server.

```
public static Task<McpClient> CreateAsync(IClientTransport clientTransport, McpClientOptions? clientOptions = null, ILoggerFactory? loggerFactory = null, CancellationToken cancellationToken = default)
```

#### Parameters

`clientTransport` [IClientTransport](ModelContextProtocol.Client.IClientTransport.html)
:   The transport instance used to communicate with the server.

`clientOptions` [McpClientOptions](ModelContextProtocol.Client.McpClientOptions.html)
:   A client configuration object that specifies client capabilities and protocol version.
    If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), details based on the current process are used.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   A logger factory for creating loggers for clients.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpClient](ModelContextProtocol.Client.McpClient.html)>
:   An [McpClient](ModelContextProtocol.Client.McpClient.html) that's connected to the specified server.

#### Remarks

When using an HTTP-based transport (such as [HttpClientTransport](ModelContextProtocol.Client.HttpClientTransport.html)), this method may throw
[HttpRequestException](https://learn.microsoft.com/dotnet/api/system.net.http.httprequestexception) if there is a problem establishing the connection to the MCP server.

If the server requires authentication and credentials are not provided or are invalid, an
[HttpRequestException](https://learn.microsoft.com/dotnet/api/system.net.http.httprequestexception) with an HTTP 401 Unauthorized status code will be thrown.
To authenticate with a protected server, configure the [OAuth](ModelContextProtocol.Client.HttpClientTransportOptions.html#ModelContextProtocol_Client_HttpClientTransportOptions_OAuth)
property of the transport with appropriate credentials before calling this method.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `clientTransport` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[HttpRequestException](https://learn.microsoft.com/dotnet/api/system.net.http.httprequestexception)
:   An error occurred while connecting to the server over HTTP.

[McpException](ModelContextProtocol.McpException.html)
:   The server returned an error response during initialization.

### GetPromptAsync(GetPromptRequestParams, CancellationToken)

Retrieves a specific prompt from the MCP server.

```
public ValueTask<GetPromptResult> GetPromptAsync(GetPromptRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   The result of the request as provided by the server.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### GetPromptAsync(string, IReadOnlyDictionary<string, object?>?, RequestOptions?, CancellationToken)

Retrieves a specific prompt from the MCP server.

```
public ValueTask<GetPromptResult> GetPromptAsync(string name, IReadOnlyDictionary<string, object?>? arguments = null, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the prompt to retrieve.

`arguments` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   Optional arguments for the prompt. The dictionary keys are parameter names, and the values are the argument values.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   A task containing the prompt's result with content and messages.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `name` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `name` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### GetTaskAsync(string, RequestOptions?, CancellationToken)

Retrieves the current state of a specific task from the server.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> GetTaskAsync(string taskId, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to retrieve.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The current state of the task.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### GetTaskResultAsync(string, RequestOptions?, CancellationToken)

Retrieves the result of a completed task, blocking until the task reaches a terminal state.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<JsonElement> GetTaskResultAsync(string taskId, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task whose result to retrieve.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)>
:   The raw JSON result of the task.

#### Remarks

This method sends a tasks/result request to the server, which will block until the task completes if it hasn't already.
The server handles all polling logic internally.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListPromptsAsync(ListPromptsRequestParams, CancellationToken)

Retrieves a list of available prompts from the server.

```
public ValueTask<ListPromptsResult> ListPromptsAsync(ListPromptsRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html)>
:   The result of the request as provided by the server.

#### Remarks

The [ListPromptsAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListPromptsAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) overload retrieves all prompts by automatically handling pagination.
This overload works with the lower-level [ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html) and [ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html), returning the raw result from the server.
Any pagination needs to be managed by the caller.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListPromptsAsync(RequestOptions?, CancellationToken)

Retrieves a list of available prompts from the server.

```
public ValueTask<IList<McpClientPrompt>> ListPromptsAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpClientPrompt](ModelContextProtocol.Client.McpClientPrompt.html)>>
:   A list of all available prompts as [McpClientPrompt](ModelContextProtocol.Client.McpClientPrompt.html) instances.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListResourceTemplatesAsync(ListResourceTemplatesRequestParams, CancellationToken)

Retrieves a list of available resource templates from the server.

```
public ValueTask<ListResourceTemplatesResult> ListResourceTemplatesAsync(ListResourceTemplatesRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html)>
:   The result of the request as provided by the server.

#### Remarks

The [ListResourceTemplatesAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListResourceTemplatesAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) overload retrieves all resource templates by automatically handling pagination.
This overload works with the lower-level [ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html) and [ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html), returning the raw result from the server.
Any pagination needs to be managed by the caller.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListResourceTemplatesAsync(RequestOptions?, CancellationToken)

Retrieves a list of available resource templates from the server.

```
public ValueTask<IList<McpClientResourceTemplate>> ListResourceTemplatesAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpClientResourceTemplate](ModelContextProtocol.Client.McpClientResourceTemplate.html)>>
:   A list of all available resource templates as [ResourceTemplate](ModelContextProtocol.Protocol.ResourceTemplate.html) instances.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListResourcesAsync(ListResourcesRequestParams, CancellationToken)

Retrieves a list of available resources from the server.

```
public ValueTask<ListResourcesResult> ListResourcesAsync(ListResourcesRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html)>
:   The result of the request as provided by the server.

#### Remarks

The [ListResourcesAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListResourcesAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) overload retrieves all resources by automatically handling pagination.
This overload works with the lower-level [ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html) and [ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html), returning the raw result from the server.
Any pagination needs to be managed by the caller.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListResourcesAsync(RequestOptions?, CancellationToken)

Retrieves a list of available resources from the server.

```
public ValueTask<IList<McpClientResource>> ListResourcesAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpClientResource](ModelContextProtocol.Client.McpClientResource.html)>>
:   A list of all available resources as [Resource](ModelContextProtocol.Protocol.Resource.html) instances.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListTasksAsync(ListTasksRequestParams, CancellationToken)

Retrieves a list of tasks from the server.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<ListTasksResult> ListTasksAsync(ListTasksRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListTasksRequestParams](ModelContextProtocol.Protocol.ListTasksRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html)>
:   The result of the request as provided by the server.

#### Remarks

The [ListTasksAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListTasksAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) overload retrieves all tasks by automatically handling pagination.
This overload works with the lower-level [ListTasksRequestParams](ModelContextProtocol.Protocol.ListTasksRequestParams.html) and [ListTasksResult](ModelContextProtocol.Protocol.ListTasksResult.html), returning the raw result from the server.
Any pagination needs to be managed by the caller.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListTasksAsync(RequestOptions?, CancellationToken)

Retrieves a list of all tasks from the server.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<IList<McpTask>> ListTasksAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>>
:   A list of all tasks.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListToolsAsync(ListToolsRequestParams, CancellationToken)

Retrieves a list of available tools from the server.

```
public ValueTask<ListToolsResult> ListToolsAsync(ListToolsRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html)>
:   The result of the request as provided by the server.

#### Remarks

The [ListToolsAsync(RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ListToolsAsync_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) overload retrieves all tools by automatically handling pagination.
This overload works with the lower-level [ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html) and [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html), returning the raw result from the server.
Any pagination needs to be managed by the caller.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ListToolsAsync(RequestOptions?, CancellationToken)

Retrieves a list of available tools from the server.

```
public ValueTask<IList<McpClientTool>> ListToolsAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[McpClientTool](ModelContextProtocol.Client.McpClientTool.html)>>
:   A list of all available tools as [McpClientTool](ModelContextProtocol.Client.McpClientTool.html) instances.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### PingAsync(PingRequestParams, CancellationToken)

Sends a ping request to verify server connectivity.

```
public ValueTask<PingResult> PingAsync(PingRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [PingRequestParams](ModelContextProtocol.Protocol.PingRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[PingResult](ModelContextProtocol.Protocol.PingResult.html)>
:   A task containing the ping result.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The server cannot be reached or returned an error response.

### PingAsync(RequestOptions?, CancellationToken)

Sends a ping request to verify server connectivity.

```
public ValueTask<PingResult> PingAsync(RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[PingResult](ModelContextProtocol.Protocol.PingResult.html)>
:   A task containing the ping result.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The server cannot be reached or returned an error response.

### PollTaskUntilCompleteAsync(string, RequestOptions?, CancellationToken)

Polls a task until it reaches a terminal status (completed, failed, or cancelled).

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ValueTask<McpTask> PollTaskUntilCompleteAsync(string taskId, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`taskId` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The unique identifier of the task to poll.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[McpTask](ModelContextProtocol.Protocol.McpTask.html)>
:   The task in its terminal state.

#### Remarks

This method repeatedly calls [GetTaskAsync(string, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_GetTaskAsync_System_String_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_) until the task reaches a terminal status.
It respects the [PollInterval](ModelContextProtocol.Protocol.McpTask.html#ModelContextProtocol_Protocol_McpTask_PollInterval) returned by the server to determine how long
to wait between polling attempts.

For retrieving the actual result of a completed task, use [GetTaskResultAsync(string, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_GetTaskResultAsync_System_String_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `taskId` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `taskId` is empty or composed entirely of whitespace.

### ReadResourceAsync(ReadResourceRequestParams, CancellationToken)

Reads a resource from the server.

```
public ValueTask<ReadResourceResult> ReadResourceAsync(ReadResourceRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>
:   The result of the request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ReadResourceAsync(string, RequestOptions?, CancellationToken)

Reads a resource from the server.

```
public ValueTask<ReadResourceResult> ReadResourceAsync(string uri, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI of the resource.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `uri` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ReadResourceAsync(string, IReadOnlyDictionary<string, object?>, RequestOptions?, CancellationToken)

Reads a resource from the server.

```
public ValueTask<ReadResourceResult> ReadResourceAsync(string uriTemplate, IReadOnlyDictionary<string, object?> arguments, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uriTemplate` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI template of the resource.

`arguments` [IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [object](https://learn.microsoft.com/dotnet/api/system.object)>
:   Arguments to use to format `uriTemplate`.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uriTemplate` or `arguments` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `uriTemplate` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ReadResourceAsync(Uri, RequestOptions?, CancellationToken)

Reads a resource from the server.

```
public ValueTask<ReadResourceResult> ReadResourceAsync(Uri uri, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [Uri](https://learn.microsoft.com/dotnet/api/system.uri)
:   The URI of the resource.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### ResumeSessionAsync(IClientTransport, ResumeClientSessionOptions, McpClientOptions?, ILoggerFactory?, CancellationToken)

Recreates an [McpClient](ModelContextProtocol.Client.McpClient.html) using an existing transport session without sending a new initialize request.

```
public static Task<McpClient> ResumeSessionAsync(IClientTransport clientTransport, ResumeClientSessionOptions resumeOptions, McpClientOptions? clientOptions = null, ILoggerFactory? loggerFactory = null, CancellationToken cancellationToken = default)
```

#### Parameters

`clientTransport` [IClientTransport](ModelContextProtocol.Client.IClientTransport.html)
:   The transport instance already configured to connect to the target server.

`resumeOptions` [ResumeClientSessionOptions](ModelContextProtocol.Client.ResumeClientSessionOptions.html)
:   The metadata captured from the original session that should be applied when resuming.

`clientOptions` [McpClientOptions](ModelContextProtocol.Client.McpClientOptions.html)
:   Optional client settings that should mirror those used to create the original session.

`loggerFactory` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)
:   An optional logger factory for diagnostics.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[McpClient](ModelContextProtocol.Client.McpClient.html)>
:   An [McpClient](ModelContextProtocol.Client.McpClient.html) bound to the resumed session.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `clientTransport`, `resumeOptions`, [ServerCapabilities](ModelContextProtocol.Client.ResumeClientSessionOptions.html#ModelContextProtocol_Client_ResumeClientSessionOptions_ServerCapabilities), or [ServerInfo](ModelContextProtocol.Client.ResumeClientSessionOptions.html#ModelContextProtocol_Client_ResumeClientSessionOptions_ServerInfo) is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### SetLoggingLevelAsync(LogLevel, RequestOptions?, CancellationToken)

Sets the logging level for the server to control which log messages are sent to the client.

```
public Task SetLoggingLevelAsync(LogLevel level, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`level` [LogLevel](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.loglevel)
:   The minimum severity level of log messages to receive from the server.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the asynchronous operation.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SetLoggingLevelAsync(LoggingLevel, RequestOptions?, CancellationToken)

Sets the logging level for the server to control which log messages are sent to the client.

```
public Task SetLoggingLevelAsync(LoggingLevel level, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`level` [LoggingLevel](ModelContextProtocol.Protocol.LoggingLevel.html)
:   The minimum severity level of log messages to receive from the server.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the asynchronous operation.

#### Exceptions

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SetLoggingLevelAsync(SetLevelRequestParams, CancellationToken)

Sets the logging level for the server to control which log messages are sent to the client.

```
public Task SetLoggingLevelAsync(SetLevelRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [SetLevelRequestParams](ModelContextProtocol.Protocol.SetLevelRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   The result of the request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SubscribeToResourceAsync(SubscribeRequestParams, CancellationToken)

Subscribes to a resource on the server to receive notifications when it changes.

```
public Task SubscribeToResourceAsync(SubscribeRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   The result of the request.

#### Remarks

This method subscribes to resource update notifications but does not register a handler.
To receive notifications, you must separately call [RegisterNotificationHandler(string, Func<JsonRpcNotification, CancellationToken, ValueTask>)](ModelContextProtocol.McpSession.html#ModelContextProtocol_McpSession_RegisterNotificationHandler_System_String_System_Func_ModelContextProtocol_Protocol_JsonRpcNotification_System_Threading_CancellationToken_System_Threading_Tasks_ValueTask__)
with [ResourceUpdatedNotification](ModelContextProtocol.Protocol.NotificationMethods.html#ModelContextProtocol_Protocol_NotificationMethods_ResourceUpdatedNotification) and filter for the specific resource URI.
To unsubscribe, call [UnsubscribeFromResourceAsync(UnsubscribeRequestParams, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_UnsubscribeFromResourceAsync_ModelContextProtocol_Protocol_UnsubscribeRequestParams_System_Threading_CancellationToken_) and dispose the handler registration.

For a simpler API that handles both subscription and notification registration in a single call,
use [SubscribeToResourceAsync(Uri, Func<ResourceUpdatedNotificationParams, CancellationToken, ValueTask>, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_SubscribeToResourceAsync_System_Uri_System_Func_ModelContextProtocol_Protocol_ResourceUpdatedNotificationParams_System_Threading_CancellationToken_System_Threading_Tasks_ValueTask__ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SubscribeToResourceAsync(string, RequestOptions?, CancellationToken)

Subscribes to a resource on the server to receive notifications when it changes.

```
public Task SubscribeToResourceAsync(string uri, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI of the resource to which to subscribe.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous operation.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `uri` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SubscribeToResourceAsync(string, Func<ResourceUpdatedNotificationParams, CancellationToken, ValueTask>, RequestOptions?, CancellationToken)

Subscribes to a resource on the server and registers a handler for notifications when it changes.

```
public Task<IAsyncDisposable> SubscribeToResourceAsync(string uri, Func<ResourceUpdatedNotificationParams, CancellationToken, ValueTask> handler, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI of the resource to which to subscribe.

`handler` [Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[ResourceUpdatedNotificationParams](ModelContextProtocol.Protocol.ResourceUpdatedNotificationParams.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>
:   The handler to invoke when the resource is updated. It receives [ResourceUpdatedNotificationParams](ModelContextProtocol.Protocol.ResourceUpdatedNotificationParams.html) for the subscribed resource.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)>
:   A task that completes with an [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) that, when disposed, unsubscribes from the resource
    and removes the notification handler.

#### Remarks

This method provides a convenient way to subscribe to resource updates and handle notifications in a single call.
The returned [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) manages both the subscription and the notification handler registration.
When disposed, it automatically unsubscribes from the resource and removes the handler.

The handler will only be invoked for notifications related to the specified resource URI.
Notifications for other resources are filtered out automatically.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` or `handler` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `uri` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SubscribeToResourceAsync(Uri, RequestOptions?, CancellationToken)

Subscribes to a resource on the server to receive notifications when it changes.

```
public Task SubscribeToResourceAsync(Uri uri, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [Uri](https://learn.microsoft.com/dotnet/api/system.uri)
:   The URI of the resource to subscribe to.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous operation.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### SubscribeToResourceAsync(Uri, Func<ResourceUpdatedNotificationParams, CancellationToken, ValueTask>, RequestOptions?, CancellationToken)

Subscribes to a resource on the server and registers a handler for notifications when it changes.

```
public Task<IAsyncDisposable> SubscribeToResourceAsync(Uri uri, Func<ResourceUpdatedNotificationParams, CancellationToken, ValueTask> handler, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [Uri](https://learn.microsoft.com/dotnet/api/system.uri)
:   The URI of the resource to which to subscribe.

`handler` [Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[ResourceUpdatedNotificationParams](ModelContextProtocol.Protocol.ResourceUpdatedNotificationParams.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)>
:   The handler to invoke when the resource is updated. It receives [ResourceUpdatedNotificationParams](ModelContextProtocol.Protocol.ResourceUpdatedNotificationParams.html) for the subscribed resource.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable)>
:   A task that completes with an [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) that, when disposed, unsubscribes from the resource
    and removes the notification handler.

#### Remarks

This method provides a convenient way to subscribe to resource updates and handle notifications in a single call.
The returned [IAsyncDisposable](https://learn.microsoft.com/dotnet/api/system.iasyncdisposable) manages both the subscription and the notification handler registration.
When disposed, it automatically unsubscribes from the resource and removes the handler.

The handler will only be invoked for notifications related to the specified resource URI.
Notifications for other resources are filtered out automatically.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` or `handler` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### UnsubscribeFromResourceAsync(UnsubscribeRequestParams, CancellationToken)

Unsubscribes from a resource on the server to stop receiving notifications about its changes.

```
public Task UnsubscribeFromResourceAsync(UnsubscribeRequestParams requestParams, CancellationToken cancellationToken = default)
```

#### Parameters

`requestParams` [UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html)
:   The request parameters to send in the request.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   The result of the request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `requestParams` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### UnsubscribeFromResourceAsync(string, RequestOptions?, CancellationToken)

Unsubscribes from a resource on the server to stop receiving notifications about its changes.

```
public Task UnsubscribeFromResourceAsync(string uri, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI of the resource to unsubscribe from.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous operation.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `uri` is empty or composed entirely of whitespace.

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.

### UnsubscribeFromResourceAsync(Uri, RequestOptions?, CancellationToken)

Unsubscribes from a resource on the server to stop receiving notifications about its changes.

```
public Task UnsubscribeFromResourceAsync(Uri uri, RequestOptions? options = null, CancellationToken cancellationToken = default)
```

#### Parameters

`uri` [Uri](https://learn.microsoft.com/dotnet/api/system.uri)
:   The URI of the resource to unsubscribe from.

`options` [RequestOptions](ModelContextProtocol.RequestOptions.html)
:   Optional request options including metadata, serialization settings, and progress tracking.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task that represents the asynchronous operation.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `uri` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[McpException](ModelContextProtocol.McpException.html)
:   The request failed or the server returned an error response.




