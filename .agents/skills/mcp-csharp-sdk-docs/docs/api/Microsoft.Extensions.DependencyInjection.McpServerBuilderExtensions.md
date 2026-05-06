
##### Table of Contents

# Class McpServerBuilderExtensions

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.dll

Provides methods for configuring MCP servers via dependency injection.

```
public static class McpServerBuilderExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerBuilderExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### WithCallToolHandler(IMcpServerBuilder, McpRequestHandler<CallToolRequestParams, CallToolResult>)

Configures a handler for calling tools available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithCallToolHandler(this IMcpServerBuilder builder, McpRequestHandler<CallToolRequestParams, CallToolResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html), [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   The handler function that processes tool calls.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

The call tool handler is responsible for executing custom tools and returning their results to clients.
This method is typically paired with [WithListToolsHandler(IMcpServerBuilder, McpRequestHandler<ListToolsRequestParams, ListToolsResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithListToolsHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ListToolsRequestParams_ModelContextProtocol_Protocol_ListToolsResult__) to provide a complete tools implementation,
where [WithListToolsHandler(IMcpServerBuilder, McpRequestHandler<ListToolsRequestParams, ListToolsResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithListToolsHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ListToolsRequestParams_ModelContextProtocol_Protocol_ListToolsResult__) advertises available tools and this handler executes them.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithCompleteHandler(IMcpServerBuilder, McpRequestHandler<CompleteRequestParams, CompleteResult>)

Configures a handler for auto-completion suggestions for prompt arguments or resource references available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithCompleteHandler(this IMcpServerBuilder builder, McpRequestHandler<CompleteRequestParams, CompleteResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[CompleteRequestParams](ModelContextProtocol.Protocol.CompleteRequestParams.html), [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html)>
:   The handler function that processes completion requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

The completion handler is invoked when clients request suggestions for argument values.
This enables auto-complete functionality for both prompt arguments and resource references.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithGetPromptHandler(IMcpServerBuilder, McpRequestHandler<GetPromptRequestParams, GetPromptResult>)

Configures a handler for getting a prompt available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithGetPromptHandler(this IMcpServerBuilder builder, McpRequestHandler<GetPromptRequestParams, GetPromptResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html), [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   The handler function that processes prompt requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithListPromptsHandler(IMcpServerBuilder, McpRequestHandler<ListPromptsRequestParams, ListPromptsResult>)

Configures a handler for listing prompts available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithListPromptsHandler(this IMcpServerBuilder builder, McpRequestHandler<ListPromptsRequestParams, ListPromptsResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListPromptsRequestParams](ModelContextProtocol.Protocol.ListPromptsRequestParams.html), [ListPromptsResult](ModelContextProtocol.Protocol.ListPromptsResult.html)>
:   The handler that processes list prompts requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This handler is called when a client requests a list of available prompts. It should return all prompts
that can be invoked through the server, including their names, descriptions, and parameter specifications.
The handler can optionally support pagination via the cursor mechanism for large or dynamically-generated
prompt collections.

When prompts are also defined using [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) collection, both sets of prompts
will be combined in the response to clients. This allows for a mix of programmatically defined
prompts and dynamically generated prompts.

This method is typically paired with [WithGetPromptHandler(IMcpServerBuilder, McpRequestHandler<GetPromptRequestParams, GetPromptResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithGetPromptHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_GetPromptRequestParams_ModelContextProtocol_Protocol_GetPromptResult__) to provide a complete prompts implementation,
where [WithListPromptsHandler(IMcpServerBuilder, McpRequestHandler<ListPromptsRequestParams, ListPromptsResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithListPromptsHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ListPromptsRequestParams_ModelContextProtocol_Protocol_ListPromptsResult__) advertises available prompts and [WithGetPromptHandler(IMcpServerBuilder, McpRequestHandler<GetPromptRequestParams, GetPromptResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithGetPromptHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_GetPromptRequestParams_ModelContextProtocol_Protocol_GetPromptResult__)
produces them when invoked by clients.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithListResourceTemplatesHandler(IMcpServerBuilder, McpRequestHandler<ListResourceTemplatesRequestParams, ListResourceTemplatesResult>)

Configures a handler for listing resource templates available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithListResourceTemplatesHandler(this IMcpServerBuilder builder, McpRequestHandler<ListResourceTemplatesRequestParams, ListResourceTemplatesResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListResourceTemplatesRequestParams](ModelContextProtocol.Protocol.ListResourceTemplatesRequestParams.html), [ListResourceTemplatesResult](ModelContextProtocol.Protocol.ListResourceTemplatesResult.html)>
:   The handler function that processes resource template list requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This handler is responsible for providing clients with information about available resource templates
that can be used to construct resource URIs.

Resource templates describe the structure of resource URIs that the server can handle. They include
URI templates (according to RFC 6570) that clients can use to construct valid resource URIs.

This handler is typically paired with [WithReadResourceHandler(IMcpServerBuilder, McpRequestHandler<ReadResourceRequestParams, ReadResourceResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithReadResourceHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ReadResourceRequestParams_ModelContextProtocol_Protocol_ReadResourceResult__) to provide a complete
resource system where templates define the URI patterns and the read handler provides the actual content.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithListResourcesHandler(IMcpServerBuilder, McpRequestHandler<ListResourcesRequestParams, ListResourcesResult>)

Configures a handler for listing resources available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithListResourcesHandler(this IMcpServerBuilder builder, McpRequestHandler<ListResourcesRequestParams, ListResourcesResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListResourcesRequestParams](ModelContextProtocol.Protocol.ListResourcesRequestParams.html), [ListResourcesResult](ModelContextProtocol.Protocol.ListResourcesResult.html)>
:   The handler function that processes resource list requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This handler is typically paired with [WithReadResourceHandler(IMcpServerBuilder, McpRequestHandler<ReadResourceRequestParams, ReadResourceResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithReadResourceHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ReadResourceRequestParams_ModelContextProtocol_Protocol_ReadResourceResult__) to provide a complete resources implementation,
where this handler advertises available resources and the read handler provides their content when requested.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithListToolsHandler(IMcpServerBuilder, McpRequestHandler<ListToolsRequestParams, ListToolsResult>)

Configures a handler for listing tools available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithListToolsHandler(this IMcpServerBuilder builder, McpRequestHandler<ListToolsRequestParams, ListToolsResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ListToolsRequestParams](ModelContextProtocol.Protocol.ListToolsRequestParams.html), [ListToolsResult](ModelContextProtocol.Protocol.ListToolsResult.html)>
:   The handler that processes list tools requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This handler is called when a client requests a list of available tools. It should return all tools
that can be invoked through the server, including their names, descriptions, and parameter specifications.
The handler can optionally support pagination via the cursor mechanism for large or dynamically generated
tool collections.

When tools are also defined using [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) collection, both sets of tools
will be combined in the response to clients. This allows for a mix of programmatically defined
tools and dynamically generated tools.

This method is typically paired with [WithCallToolHandler(IMcpServerBuilder, McpRequestHandler<CallToolRequestParams, CallToolResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithCallToolHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_CallToolRequestParams_ModelContextProtocol_Protocol_CallToolResult__) to provide a complete tools implementation,
where [WithListToolsHandler(IMcpServerBuilder, McpRequestHandler<ListToolsRequestParams, ListToolsResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithListToolsHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ListToolsRequestParams_ModelContextProtocol_Protocol_ListToolsResult__) advertises available tools and [WithCallToolHandler(IMcpServerBuilder, McpRequestHandler<CallToolRequestParams, CallToolResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithCallToolHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_CallToolRequestParams_ModelContextProtocol_Protocol_CallToolResult__)
executes them when invoked by clients.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithMessageFilters(IMcpServerBuilder, Action<IMcpMessageFilterBuilder>)

Configures message-level filters for the MCP server.

```
public static IMcpServerBuilder WithMessageFilters(this IMcpServerBuilder builder, Action<IMcpMessageFilterBuilder> configure)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`configure` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[IMcpMessageFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpMessageFilterBuilder.html)>
:   A callback used to register message filters.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `configure` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithPrompts(IMcpServerBuilder, IEnumerable<McpServerPrompt>)

Adds [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithPrompts(this IMcpServerBuilder builder, IEnumerable<McpServerPrompt> prompts)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`prompts` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)>
:   The [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances to add to the server.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `prompts` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithPrompts(IMcpServerBuilder, IEnumerable<Type>, JsonSerializerOptions?)

Adds [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances to the service collection backing `builder`.

```
[RequiresUnreferencedCode("The non-generic WithPrompts and WithPromptsFromAssembly methods require dynamic lookup of method metadata and might not work in Native AOT. Use the generic WithPrompts method instead.")]
public static IMcpServerBuilder WithPrompts(this IMcpServerBuilder builder, IEnumerable<Type> promptTypes, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`promptTypes` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[Type](https://learn.microsoft.com/dotnet/api/system.type)>
:   Types with marked methods to add as prompts to the server.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing prompt parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method discovers all instance and static methods (public and non-public) on the specified `promptTypes`
types, where the methods are attributed as [McpServerPromptAttribute](ModelContextProtocol.Server.McpServerPromptAttribute.html), and adds an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
instance for each. For instance methods, an instance is constructed for each invocation of the prompt.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `promptTypes` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithPromptsFromAssembly(IMcpServerBuilder, Assembly?, JsonSerializerOptions?)

Adds types marked with the [McpServerPromptTypeAttribute](ModelContextProtocol.Server.McpServerPromptTypeAttribute.html) attribute from the given assembly as prompts to the server.

```
[RequiresUnreferencedCode("The non-generic WithPrompts and WithPromptsFromAssembly methods require dynamic lookup of method metadata and might not work in Native AOT. Use the generic WithPrompts method instead.")]
public static IMcpServerBuilder WithPromptsFromAssembly(this IMcpServerBuilder builder, Assembly? promptAssembly = null, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`promptAssembly` [Assembly](https://learn.microsoft.com/dotnet/api/system.reflection.assembly)
:   The assembly to load the types from. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the calling assembly is used.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing prompt parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method scans the specified assembly (or the calling assembly if none is provided) for classes
marked with the [McpServerPromptTypeAttribute](ModelContextProtocol.Server.McpServerPromptTypeAttribute.html). It then discovers all methods within those
classes that are marked with the [McpServerPromptAttribute](ModelContextProtocol.Server.McpServerPromptAttribute.html) and registers them as [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)s
in the `builder`'s [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection).

The method automatically handles both static and instance methods. For instance methods, a new instance
of the containing class is constructed for each invocation of the prompt.

Prompts registered through this method can be discovered by clients using the `list_prompts` request
and invoked using the `prompts/get` request.

Note that this method performs reflection at runtime and might not work in Native AOT scenarios. For
Native AOT compatibility, consider using the generic WithPrompts method instead.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithPrompts<TPromptType>(IMcpServerBuilder, JsonSerializerOptions?)

Adds [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithPrompts<TPromptType>(this IMcpServerBuilder builder, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing prompt parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Type Parameters

`TPromptType`
:   The prompt type.

#### Remarks

This method discovers all instance and static methods (public and non-public) on the specified `TPromptType`
type, where the methods are attributed as [McpServerPromptAttribute](ModelContextProtocol.Server.McpServerPromptAttribute.html), and adds an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
instance for each. For instance methods, an instance is constructed for each invocation of the prompt.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithPrompts<TPromptType>(IMcpServerBuilder, TPromptType, JsonSerializerOptions?)

Adds [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithPrompts<TPromptType>(this IMcpServerBuilder builder, TPromptType target, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`target` TPromptType
:   The target instance from which the prompts should be sourced.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing prompt parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Type Parameters

`TPromptType`
:   The prompt type.

#### Remarks

This method discovers all methods (public and non-public) on the specified `TPromptType`
type, where the methods are attributed as [McpServerPromptAttribute](ModelContextProtocol.Server.McpServerPromptAttribute.html), and adds an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
instance for each, using `target` as the associated instance for instance methods.

However, if `TPromptType` is itself an [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html),
this method registers those prompts directly without scanning for methods on `TPromptType`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `target` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithReadResourceHandler(IMcpServerBuilder, McpRequestHandler<ReadResourceRequestParams, ReadResourceResult>)

Configures a handler for reading a resource available from the Model Context Protocol server.

```
public static IMcpServerBuilder WithReadResourceHandler(this IMcpServerBuilder builder, McpRequestHandler<ReadResourceRequestParams, ReadResourceResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[ReadResourceRequestParams](ModelContextProtocol.Protocol.ReadResourceRequestParams.html), [ReadResourceResult](ModelContextProtocol.Protocol.ReadResourceResult.html)>
:   The handler function that processes resource read requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This handler is typically paired with [WithListResourcesHandler(IMcpServerBuilder, McpRequestHandler<ListResourcesRequestParams, ListResourcesResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithListResourcesHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_ListResourcesRequestParams_ModelContextProtocol_Protocol_ListResourcesResult__) to provide a complete resources implementation,
where the list handler advertises available resources and the read handler provides their content when requested.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithRequestFilters(IMcpServerBuilder, Action<IMcpRequestFilterBuilder>)

Configures request-specific filters for the MCP server.

```
public static IMcpServerBuilder WithRequestFilters(this IMcpServerBuilder builder, Action<IMcpRequestFilterBuilder> configure)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`configure` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[IMcpRequestFilterBuilder](Microsoft.Extensions.DependencyInjection.IMcpRequestFilterBuilder.html)>
:   A callback used to register request-specific filters.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `configure` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithResources(IMcpServerBuilder, IEnumerable<McpServerResource>)

Adds [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithResources(this IMcpServerBuilder builder, IEnumerable<McpServerResource> resourceTemplates)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`resourceTemplates` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)>
:   The [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances to add to the server.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `resourceTemplates` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithResources(IMcpServerBuilder, IEnumerable<Type>)

Adds [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances to the service collection backing `builder`.

```
[RequiresUnreferencedCode("The non-generic WithResources and WithResourcesFromAssembly methods require dynamic lookup of member metadata and might not work in Native AOT. Use the generic WithResources method instead.")]
public static IMcpServerBuilder WithResources(this IMcpServerBuilder builder, IEnumerable<Type> resourceTemplateTypes)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`resourceTemplateTypes` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[Type](https://learn.microsoft.com/dotnet/api/system.type)>
:   Types with marked methods to add as resources to the server.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method discovers all instance and static methods (public and non-public) on the specified `resourceTemplateTypes`
types, where the methods are attributed as [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html), and adds an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
instance for each. For instance methods, an instance is constructed for each invocation of the resource.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `resourceTemplateTypes` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithResourcesFromAssembly(IMcpServerBuilder, Assembly?)

Adds types marked with the [McpServerResourceTypeAttribute](ModelContextProtocol.Server.McpServerResourceTypeAttribute.html) attribute from the given assembly as resources to the server.

```
[RequiresUnreferencedCode("The non-generic WithResources and WithResourcesFromAssembly methods require dynamic lookup of member metadata and might not work in Native AOT. Use the generic WithResources method instead.")]
public static IMcpServerBuilder WithResourcesFromAssembly(this IMcpServerBuilder builder, Assembly? resourceAssembly = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`resourceAssembly` [Assembly](https://learn.microsoft.com/dotnet/api/system.reflection.assembly)
:   The assembly to load the types from. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the calling assembly is used.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method scans the specified assembly (or the calling assembly if none is provided) for classes
marked with the [McpServerResourceTypeAttribute](ModelContextProtocol.Server.McpServerResourceTypeAttribute.html). It then discovers all members within those
classes that are marked with the [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html) and registers them as [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)s
in the `builder`'s [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection).

The method automatically handles both static and instance members. For instance members, a new instance
of the containing class is constructed for each invocation of the resource.

Resource templates registered through this method can be discovered by clients using the `list_resourceTemplates` request
and invoked using the `read_resource` request.

Note that this method performs reflection at runtime and might not work in Native AOT scenarios. For
Native AOT compatibility, consider using the generic WithResources method instead.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithResources<TResourceType>(IMcpServerBuilder)

Adds [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithResources<TResourceType>(this IMcpServerBuilder builder)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Type Parameters

`TResourceType`
:   The resource type.

#### Remarks

This method discovers all instance and static methods (public and non-public) on the specified `TResourceType`
type, where the members are attributed as [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html), and adds an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
instance for each. For instance members, an instance is constructed for each invocation of the resource.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithResources<TResourceType>(IMcpServerBuilder, TResourceType)

Adds [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithResources<TResourceType>(this IMcpServerBuilder builder, TResourceType target)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`target` TResourceType
:   The target instance from which the resources should be sourced.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Type Parameters

`TResourceType`
:   The resource type.

#### Remarks

This method discovers all methods (public and non-public) on the specified `TResourceType`
type, where the methods are attributed as [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html), and adds an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html)
instance for each, using `target` as the associated instance for instance methods.

However, if `TResourceType` is itself an [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [McpServerResource](ModelContextProtocol.Server.McpServerResource.html),
this method registers those resources directly without scanning for methods on `TResourceType`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `target` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithSetLoggingLevelHandler(IMcpServerBuilder, McpRequestHandler<SetLevelRequestParams, EmptyResult>)

Configures a handler for processing logging level change requests from clients.

```
public static IMcpServerBuilder WithSetLoggingLevelHandler(this IMcpServerBuilder builder, McpRequestHandler<SetLevelRequestParams, EmptyResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The server builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[SetLevelRequestParams](ModelContextProtocol.Protocol.SetLevelRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>
:   The handler that processes requests to change the logging level.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

When a client sends a `logging/setLevel` request, this handler will be invoked to process
the requested level change. The server typically adjusts its internal logging level threshold
and might begin sending log messages at or above the specified level to the client.

Regardless of whether a handler is provided, an [McpServer](ModelContextProtocol.Server.McpServer.html) should itself handle
such notifications by updating its [LoggingLevel](ModelContextProtocol.Server.McpServer.html#ModelContextProtocol_Server_McpServer_LoggingLevel) property to return the
most recently set level.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithStdioServerTransport(IMcpServerBuilder)

Adds a server transport that uses standard input (stdin) and standard output (stdout) for communication.

```
public static IMcpServerBuilder WithStdioServerTransport(this IMcpServerBuilder builder)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method configures the server to communicate using the standard input and output streams,
which is commonly used when the Model Context Protocol server is launched locally by a client process.

When using this transport, the server runs as a single-session service that exits when the
stdin stream is closed. This makes it suitable for scenarios where the server should terminate
when the parent process disconnects.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithStreamServerTransport(IMcpServerBuilder, Stream, Stream)

Adds a server transport that uses the specified input and output streams for communication.

```
public static IMcpServerBuilder WithStreamServerTransport(this IMcpServerBuilder builder, Stream inputStream, Stream outputStream)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`inputStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The input [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream) to use as standard input.

`outputStream` [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream)
:   The output [Stream](https://learn.microsoft.com/dotnet/api/system.io.stream) to use as standard output.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `inputStream` or `outputStream` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithSubscribeToResourcesHandler(IMcpServerBuilder, McpRequestHandler<SubscribeRequestParams, EmptyResult>)

Configures a handler for resource subscription requests.

```
public static IMcpServerBuilder WithSubscribeToResourcesHandler(this IMcpServerBuilder builder, McpRequestHandler<SubscribeRequestParams, EmptyResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[SubscribeRequestParams](ModelContextProtocol.Protocol.SubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>
:   The handler function that processes resource subscription requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

The subscribe handler is responsible for registering client interest in specific resources. When a resource
changes, the server can notify all subscribed clients about the change.

This handler is typically paired with [WithUnsubscribeFromResourcesHandler(IMcpServerBuilder, McpRequestHandler<UnsubscribeRequestParams, EmptyResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithUnsubscribeFromResourcesHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_UnsubscribeRequestParams_ModelContextProtocol_Protocol_EmptyResult__) to provide a complete
subscription management system. Resource subscriptions allow clients to maintain up-to-date information without
needing to poll resources constantly.

After registering a subscription, it's the server's responsibility to track which client is subscribed to which
resources and to send appropriate notifications through the connection when resources change.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithTools(IMcpServerBuilder, IEnumerable<McpServerTool>)

Adds [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithTools(this IMcpServerBuilder builder, IEnumerable<McpServerTool> tools)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`tools` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[McpServerTool](ModelContextProtocol.Server.McpServerTool.html)>
:   The [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances to add to the server.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `tools` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithTools(IMcpServerBuilder, IEnumerable<Type>, JsonSerializerOptions?)

Adds [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances to the service collection backing `builder`.

```
[RequiresUnreferencedCode("The non-generic WithTools and WithToolsFromAssembly methods require dynamic lookup of method metadata and might not work in Native AOT. Use the generic WithTools method instead.")]
public static IMcpServerBuilder WithTools(this IMcpServerBuilder builder, IEnumerable<Type> toolTypes, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`toolTypes` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[Type](https://learn.microsoft.com/dotnet/api/system.type)>
:   Types with [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html)-attributed methods to add as tools to the server.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing tool parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method discovers all instance and static methods (public and non-public) on the specified `toolTypes`
types, where the methods are attributed as [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html), and adds an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
instance for each. For instance methods, an instance is constructed for each invocation of the tool.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `toolTypes` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithToolsFromAssembly(IMcpServerBuilder, Assembly?, JsonSerializerOptions?)

Adds types marked with the [McpServerToolTypeAttribute](ModelContextProtocol.Server.McpServerToolTypeAttribute.html) attribute from the given assembly as tools to the server.

```
[RequiresUnreferencedCode("The non-generic WithTools and WithToolsFromAssembly methods require dynamic lookup of method metadata and might not work in Native AOT. Use the generic WithTools method instead.")]
public static IMcpServerBuilder WithToolsFromAssembly(this IMcpServerBuilder builder, Assembly? toolAssembly = null, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`toolAssembly` [Assembly](https://learn.microsoft.com/dotnet/api/system.reflection.assembly)
:   The assembly to load the types from. If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the calling assembly is used.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing tool parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

This method scans the specified assembly (or the calling assembly if none is provided) for classes
marked with the [McpServerToolTypeAttribute](ModelContextProtocol.Server.McpServerToolTypeAttribute.html). It then discovers all methods within those
classes that are marked with the [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html) and registers them as [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)s
in the `builder`'s [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection).

The method automatically handles both static and instance methods. For instance methods, a new instance
of the containing class is constructed for each invocation of the tool.

Tools registered through this method can be discovered by clients using the `list_tools` request
and invoked using the `call_tool` request.

Note that this method performs reflection at runtime and might not work in Native AOT scenarios. For
Native AOT compatibility, consider using the generic WithTools method instead.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithTools<TToolType>(IMcpServerBuilder, JsonSerializerOptions?)

Adds [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithTools<TToolType>(this IMcpServerBuilder builder, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing tool parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Type Parameters

`TToolType`
:   The tool type.

#### Remarks

This method discovers all instance and static methods (public and non-public) on the specified `TToolType`
type, where the methods are attributed as [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html), and adds an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
instance for each. For instance methods, an instance is constructed for each invocation of the tool.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithTools<TToolType>(IMcpServerBuilder, TToolType, JsonSerializerOptions?)

Adds [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) instances to the service collection backing `builder`.

```
public static IMcpServerBuilder WithTools<TToolType>(this IMcpServerBuilder builder, TToolType target, JsonSerializerOptions? serializerOptions = null)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`target` TToolType
:   The target instance from which the tools should be sourced.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The serializer options governing tool parameter marshalling.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Type Parameters

`TToolType`
:   The tool type.

#### Remarks

This method discovers all methods (public and non-public) on the specified `TToolType`
type, where the methods are attributed as [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html), and adds an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
instance for each, using `target` as the associated instance for instance methods.

However, if `TToolType` is itself an [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [McpServerTool](ModelContextProtocol.Server.McpServerTool.html),
this method registers those tools directly without scanning for methods on `TToolType`.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` or `target` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### WithUnsubscribeFromResourcesHandler(IMcpServerBuilder, McpRequestHandler<UnsubscribeRequestParams, EmptyResult>)

Configures a handler for resource unsubscription requests.

```
public static IMcpServerBuilder WithUnsubscribeFromResourcesHandler(this IMcpServerBuilder builder, McpRequestHandler<UnsubscribeRequestParams, EmptyResult> handler)
```

#### Parameters

`builder` [IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder instance.

`handler` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<[UnsubscribeRequestParams](ModelContextProtocol.Protocol.UnsubscribeRequestParams.html), [EmptyResult](ModelContextProtocol.Protocol.EmptyResult.html)>
:   The handler function that processes resource unsubscription requests.

#### Returns

[IMcpServerBuilder](Microsoft.Extensions.DependencyInjection.IMcpServerBuilder.html)
:   The builder provided in `builder`.

#### Remarks

The unsubscribe handler is responsible for removing client interest in specific resources. When a client
no longer needs to receive notifications about resource changes, it can send an unsubscribe request.

This handler is typically paired with [WithSubscribeToResourcesHandler(IMcpServerBuilder, McpRequestHandler<SubscribeRequestParams, EmptyResult>)](Microsoft.Extensions.DependencyInjection.McpServerBuilderExtensions.html#Microsoft_Extensions_DependencyInjection_McpServerBuilderExtensions_WithSubscribeToResourcesHandler_Microsoft_Extensions_DependencyInjection_IMcpServerBuilder_ModelContextProtocol_Server_McpRequestHandler_ModelContextProtocol_Protocol_SubscribeRequestParams_ModelContextProtocol_Protocol_EmptyResult__) to provide a complete
subscription management system. The unsubscribe operation is idempotent, meaning it can be called multiple
times for the same resource without causing errors, even if there is no active subscription.

After removing a subscription, the server should stop sending notifications to the client about changes
to the specified resource.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `builder` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).




