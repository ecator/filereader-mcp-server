
##### Table of Contents

# Class ElicitRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a message issued from the server to elicit additional information from the user via the client.

```
public sealed class ElicitRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    ElicitRequestParams

Inherited Members
:   [RequestParams.Meta](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_Meta)

    [RequestParams.ProgressToken](ModelContextProtocol.Protocol.RequestParams.html#ModelContextProtocol_Protocol_RequestParams_ProgressToken)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### ElicitationId

Gets or sets a unique identifier for this elicitation request.

```
[JsonPropertyName("elicitationId")]
public string? ElicitationId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Used to track and correlate the elicitation across multiple messages, especially for out-of-band flows
that may complete asynchronously.

Required for url mode elicitation to enable progress tracking and completion detection.

### Message

Gets or sets the message to present to the user.

```
[JsonPropertyName("message")]
public required string Message { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

For form mode, this describes what information is being requested.
For url mode, this explains why the user needs to navigate to the URL.

### Mode

Gets or sets the elicitation mode: "form" for in-band data collection or "url" for out-of-band URL navigation.

```
[JsonPropertyName("mode")]
public string Mode { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

* **form**: Client collects structured data via a form interface. Data is exposed to the client.
* **url**: Client navigates user to a URL for out-of-band interaction. Sensitive data is not exposed to the client.

#### Exceptions

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   The value is not "form" or "url".

### RequestedSchema

Gets or sets the requested schema for form mode elicitation.

```
[JsonPropertyName("requestedSchema")]
public ElicitRequestParams.RequestSchema? RequestedSchema { get; set; }
```

#### Property Value

[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html).[RequestSchema](ModelContextProtocol.Protocol.ElicitRequestParams.RequestSchema.html)
:   Possible values are [ElicitRequestParams.StringSchema](ModelContextProtocol.Protocol.ElicitRequestParams.StringSchema.html), [ElicitRequestParams.NumberSchema](ModelContextProtocol.Protocol.ElicitRequestParams.NumberSchema.html), [ElicitRequestParams.BooleanSchema](ModelContextProtocol.Protocol.ElicitRequestParams.BooleanSchema.html),
    [ElicitRequestParams.UntitledSingleSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.UntitledSingleSelectEnumSchema.html), [ElicitRequestParams.TitledSingleSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledSingleSelectEnumSchema.html),
    [ElicitRequestParams.UntitledMultiSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.UntitledMultiSelectEnumSchema.html), [ElicitRequestParams.TitledMultiSelectEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.TitledMultiSelectEnumSchema.html),
    and [ElicitRequestParams.LegacyTitledEnumSchema](ModelContextProtocol.Protocol.ElicitRequestParams.LegacyTitledEnumSchema.html) (deprecated).

#### Remarks

Only applicable when [Mode](ModelContextProtocol.Protocol.ElicitRequestParams.html#ModelContextProtocol_Protocol_ElicitRequestParams_Mode) is "form".

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

### Url

Gets or sets the URL to navigate to for out-of-band elicitation.

```
[JsonPropertyName("url")]
public string? Url { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Required when [Mode](ModelContextProtocol.Protocol.ElicitRequestParams.html#ModelContextProtocol_Protocol_ElicitRequestParams_Mode) is "url". The client should prompt the user for consent
and then navigate to this URL in a user-agent (browser) where the user completes
the required interaction.

URLs must not appear in any other field of the elicitation request for security reasons.




