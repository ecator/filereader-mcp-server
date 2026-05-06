
##### Table of Contents

# Class ClientCompletionDetails

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides details about why an MCP client session completed.

```
public class ClientCompletionDetails
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ClientCompletionDetails

Derived
:   [HttpClientCompletionDetails](ModelContextProtocol.Client.HttpClientCompletionDetails.html)

    [StdioClientCompletionDetails](ModelContextProtocol.Client.StdioClientCompletionDetails.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Transport implementations may return derived types with additional strongly-typed
information, such as [StdioClientCompletionDetails](ModelContextProtocol.Client.StdioClientCompletionDetails.html).

## Properties

### Exception

Gets the exception that caused the session to close, if any.

```
public Exception? Exception { get; set; }
```

#### Property Value

[Exception](https://learn.microsoft.com/dotnet/api/system.exception)

#### Remarks

This is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) for graceful closure.




