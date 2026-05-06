
##### Table of Contents

# Class StdioClientCompletionDetails

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides details about the completion of a stdio-based MCP client session.

```
public sealed class StdioClientCompletionDetails : ClientCompletionDetails
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ClientCompletionDetails](ModelContextProtocol.Client.ClientCompletionDetails.html)

    StdioClientCompletionDetails

Inherited Members
:   [ClientCompletionDetails.Exception](ModelContextProtocol.Client.ClientCompletionDetails.html#ModelContextProtocol_Client_ClientCompletionDetails_Exception)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### ExitCode

Gets the exit code of the server process, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unavailable.

```
public int? ExitCode { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

### ProcessId

Gets the process ID of the server process, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unavailable.

```
public int? ProcessId { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

### StandardErrorTail

Gets the last lines of the server process's standard error output, or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) if unavailable.

```
public IReadOnlyList<string>? StandardErrorTail { get; set; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>




