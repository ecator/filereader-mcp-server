
##### Table of Contents

# Class CompleteRequestParams

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the parameters used with a [CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete) request from
a client to ask a server for auto-completion suggestions.

```
public sealed class CompleteRequestParams : RequestParams
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [RequestParams](ModelContextProtocol.Protocol.RequestParams.html)

    CompleteRequestParams

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

[CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete) is used in the Model Context Protocol completion workflow
to provide intelligent suggestions for partial inputs related to resources, prompts, or other referenceable entities.
The completion mechanism in MCP allows clients to request suggestions based on partial inputs.
The server will respond with a [CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html) containing matching values.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Argument

Gets or sets the argument information for the completion request, specifying what is being completed
and the current partial input.

```
[JsonPropertyName("argument")]
public required Argument Argument { get; set; }
```

#### Property Value

[Argument](ModelContextProtocol.Protocol.Argument.html)

### Context

Gets or sets additional, optional context for completions.

```
[JsonPropertyName("context")]
public CompleteContext? Context { get; set; }
```

#### Property Value

[CompleteContext](ModelContextProtocol.Protocol.CompleteContext.html)

### Ref

Gets or sets the reference's information.

```
[JsonPropertyName("ref")]
public required Reference Ref { get; set; }
```

#### Property Value

[Reference](ModelContextProtocol.Protocol.Reference.html)




