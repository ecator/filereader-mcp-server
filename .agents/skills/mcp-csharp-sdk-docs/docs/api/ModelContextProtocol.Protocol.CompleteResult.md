
##### Table of Contents

# Class CompleteResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the server's response to a [CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete) request,
containing suggested values for a given argument.

```
public sealed class CompleteResult : Result
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    CompleteResult

Inherited Members
:   [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

[CompleteResult](ModelContextProtocol.Protocol.CompleteResult.html) is returned by the server in response to a [CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete)
request from the client. It provides suggested completions or valid values for a specific argument in a tool or resource reference.

The result contains a [Completion](ModelContextProtocol.Protocol.CompleteResult.html#ModelContextProtocol_Protocol_CompleteResult_Completion) object with suggested values, pagination information,
and the total number of available completions. This is similar to auto-completion functionality in code editors.

Clients typically use this to implement auto-suggestion features when users are inputting parameters
for tool calls or resource references.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Completion

Gets or sets the completion object containing the suggested values and pagination information.

```
[JsonPropertyName("completion")]
public Completion Completion { get; set; }
```

#### Property Value

[Completion](ModelContextProtocol.Protocol.Completion.html)

#### Remarks

If no completions are available for the given input, the [Values](ModelContextProtocol.Protocol.Completion.html#ModelContextProtocol_Protocol_Completion_Values)
collection will be empty.




