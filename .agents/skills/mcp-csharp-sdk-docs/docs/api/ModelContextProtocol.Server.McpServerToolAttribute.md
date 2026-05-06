
##### Table of Contents

# Class McpServerToolAttribute

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Indicates that a method should be considered an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
[AttributeUsage(AttributeTargets.Method)]
public sealed class McpServerToolAttribute : Attribute
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Attribute](https://learn.microsoft.com/dotnet/api/system.attribute)

    McpServerToolAttribute

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

This attribute is applied to methods that should be exposed as tools in the Model Context Protocol. When a class
containing methods marked with this attribute is registered with McpServerBuilderExtensions,
these methods become available as tools that can be called by MCP clients.

When methods are provided directly to McpServerTool.Create, the attribute is not required.

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
  from the [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided when the tool is invoked rather than from the argument collection.
* Any parameter attributed with [FromKeyedServicesAttribute](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.fromkeyedservicesattribute) will similarly be resolved from the
  [IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider) provided when the tool is invoked rather than from the argument
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
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [string](https://learn.microsoft.com/dotnet/api/system.string) | Each [string](https://learn.microsoft.com/dotnet/api/system.string) is converted to a [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object with its text set to the string value. |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of Microsoft.Extensions.AI.AIContent | Each Microsoft.Extensions.AI.AIContent is converted to a [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object using [ToContentBlock(AIContent, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToContentBlock_Microsoft_Extensions_AI_AIContent_System_Text_Json_JsonSerializerOptions_). |
| [IEnumerable<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) of [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) | Returned as the [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) list. |
| [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) | Returned directly without modification. |
| Other types | Serialized to JSON and returned as a single [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html) object with [Type](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Type) set to "text". |

## Constructors

### McpServerToolAttribute()

Initializes a new instance of the [McpServerToolAttribute](ModelContextProtocol.Server.McpServerToolAttribute.html) class.

```
public McpServerToolAttribute()
```

## Properties

### Destructive

Gets or sets a value that indicates whether the tool might perform destructive updates to its environment.

```
public bool Destructive { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool might perform destructive updates to its environment.
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool performs only additive updates.
    The default is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

This property is most relevant when the tool modifies its environment (ReadOnly = false).

### IconSource

Gets or sets the source URI for the tool's icon.

```
public string? IconSource { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value can be an HTTP/HTTPS URL pointing to an image file or a data URI with base64-encoded image data.
When specified, a single icon will be added to the tool.

For more advanced icon configuration (multiple icons, MIME type specification, size characteristics),
use [Icons](ModelContextProtocol.Server.McpServerToolCreateOptions.html#ModelContextProtocol_Server_McpServerToolCreateOptions_Icons) when creating the tool programmatically.

### Idempotent

Gets or sets a value that indicates whether calling the tool repeatedly with the same arguments
has no additional effect on its environment.

```
public bool Idempotent { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if calling the tool repeatedly with the same arguments
    has no additional effect on the environment; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it does.
    The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

This property is most relevant when the tool modifies its environment (ReadOnly = false).

### Name

Gets the name of the tool.

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the method name is used.

### OpenWorld

Gets or sets a value that indicates whether this tool can interact with an "open world" of external entities.

```
public bool OpenWorld { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool can interact with an unpredictable or dynamic set of entities (like web search).
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool's domain of interaction is closed and well-defined (like memory access).
    The default is [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### OutputSchemaType

Gets or sets a [Type](https://learn.microsoft.com/dotnet/api/system.type) from which to generate the tool's output schema.

```
public Type? OutputSchemaType { get; set; }
```

#### Property Value

[Type](https://learn.microsoft.com/dotnet/api/system.type)
:   The default is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), which means the output schema is inferred from the return type.

#### Remarks

When set, a JSON schema is generated from the specified [Type](https://learn.microsoft.com/dotnet/api/system.type) and used as the
[OutputSchema](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_OutputSchema) instead of the schema inferred from the tool method's return type.
This is particularly useful when a tool method returns [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) directly
(to control properties like [Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta), [IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError),
or [StructuredContent](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_StructuredContent)) but still needs to advertise a meaningful output
schema to clients.

[UseStructuredContent](ModelContextProtocol.Server.McpServerToolAttribute.html#ModelContextProtocol_Server_McpServerToolAttribute_UseStructuredContent) must also be set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) for this property to take effect.

### ReadOnly

Gets or sets a value that indicates whether this tool does not modify its environment.

```
public bool ReadOnly { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool only performs read operations without changing state.
    [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the tool might make modifications to its environment.
    The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

Read-only tools do not have side effects beyond computational resource usage.
They don't create, update, or delete data in any system.

### TaskSupport

Gets or sets the task support configuration for the tool.

```
[Experimental("MCPEXP001", UrlFormat = "https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/list-of-diagnostics.md#mcpexp001")]
public ToolTaskSupport TaskSupport { get; set; }
```

#### Property Value

[ToolTaskSupport](ModelContextProtocol.Protocol.ToolTaskSupport.html)
:   A [ToolTaskSupport](ModelContextProtocol.Protocol.ToolTaskSupport.html) value indicating how the tool supports task-based invocation.
    The default value is [Forbidden](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Forbidden).

#### Remarks

When set to [Forbidden](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Forbidden), clients must not attempt to invoke the tool as a task.
When set to [Optional](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Optional), clients may invoke the tool as a task or as a normal request.
When set to [Required](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Required), clients must invoke the tool as a task.

If this property is not explicitly set on the attribute, the task support behavior will be determined
automatically based on the tool's characteristics (e.g., async methods default to [Optional](ModelContextProtocol.Protocol.ToolTaskSupport.html#ModelContextProtocol_Protocol_ToolTaskSupport_Optional)).

### Title

Gets or sets a human-readable title for the tool that can be displayed to users.

```
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

The title provides a more descriptive, user-friendly name for the tool than the tool's
programmatic name. It is intended for display purposes and to help users understand
the tool's purpose at a glance.

Unlike the tool name (which follows programmatic naming conventions), the title can
include spaces, special characters, and be phrased in a more natural language style.

### UseStructuredContent

Gets or sets a value that indicates whether the tool should report an output schema for structured content.

```
public bool UseStructuredContent { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

When enabled, the tool will attempt to populate the [OutputSchema](ModelContextProtocol.Protocol.Tool.html#ModelContextProtocol_Protocol_Tool_OutputSchema)
and provide structured content in the [StructuredContent](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_StructuredContent) property.




