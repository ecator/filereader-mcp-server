
##### Table of Contents

# Class HttpClientCompletionDetails

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides details about the completion of an HTTP-based MCP client session,
including sessions using the legacy SSE transport or the Streamable HTTP transport.

```
public sealed class HttpClientCompletionDetails : ClientCompletionDetails
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ClientCompletionDetails](ModelContextProtocol.Client.ClientCompletionDetails.html)

    HttpClientCompletionDetails

Inherited Members
:   [ClientCompletionDetails.Exception](ModelContextProtocol.Client.ClientCompletionDetails.html#ModelContextProtocol_Client_ClientCompletionDetails_Exception)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### HttpStatusCode

Gets the HTTP status code that caused the session to close, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unavailable.

```
public HttpStatusCode? HttpStatusCode { get; set; }
```

#### Property Value

[HttpStatusCode](https://learn.microsoft.com/dotnet/api/system.net.httpstatuscode)?




