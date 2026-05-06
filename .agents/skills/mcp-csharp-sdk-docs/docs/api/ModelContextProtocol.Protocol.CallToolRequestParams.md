
##### Table of Contents

# Class CallToolRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [ToolsCall](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_ToolsCall) request from a client to invoke a tool provided by the server.

```
public sealed class CallToolRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    CallToolRequestParams

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

The server will respond with a [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html) containing the result of the tool invocation.
See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Arguments

Gets or sets optional arguments to pass to the tool when invoking it on the server.

```
[JsonPropertyName("arguments")]
public IDictionary<string, JsonElement>? Arguments { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)>

#### Remarks

This dictionary contains the parameter values to be passed to the tool. Each key-value pair represents
a parameter name and its corresponding argument value.

### Name

Gets or sets the name of the tool to invoke.

```
[JsonPropertyName("name")]
public required string Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

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




