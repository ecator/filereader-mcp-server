
##### Table of Contents

# Class ListPromptsResult

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a server's response to a [PromptsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsList) request from the client, containing available prompts.

```
public sealed class ListPromptsResult : PaginatedResult
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Result](ModelContextProtocol.Protocol.Result.html)

    [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html)

    ListPromptsResult

Inherited Members
:   [PaginatedResult.NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor)

    [Result.Meta](ModelContextProtocol.Protocol.Result.html#ModelContextProtocol_Protocol_Result_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This result is returned when a client sends a [PromptsList](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_PromptsList) request to discover available prompts on the server.

It inherits from [PaginatedResult](ModelContextProtocol.Protocol.PaginatedResult.html), allowing for paginated responses when there are many prompts.
The server can provide the [NextCursor](ModelContextProtocol.Protocol.PaginatedResult.html#ModelContextProtocol_Protocol_PaginatedResult_NextCursor) property to indicate there are more
prompts available beyond what was returned in the current response.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Prompts

Gets or sets a list of prompts or prompt templates that the server offers.

```
[JsonPropertyName("prompts")]
public IList<Prompt> Prompts { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Prompt](ModelContextProtocol.Protocol.Prompt.html)>




