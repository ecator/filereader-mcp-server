
##### Table of Contents

# Class UrlElicitationRequiredException

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an exception used to indicate that URL-mode elicitation must be completed before the request can proceed.

```
public sealed class UrlElicitationRequiredException : McpProtocolException, ISerializable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Exception](https://learn.microsoft.com/dotnet/api/system.exception)

    [McpException](ModelContextProtocol.McpException.html)

    [McpProtocolException](ModelContextProtocol.McpProtocolException.html)

    UrlElicitationRequiredException

Implements
:   [ISerializable](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

Inherited Members
:   [McpProtocolException.ErrorCode](ModelContextProtocol.McpProtocolException.html#ModelContextProtocol_McpProtocolException_ErrorCode)

    [Exception.GetBaseException()](https://learn.microsoft.com/dotnet/api/system.exception.getbaseexception)

    [Exception.GetType()](https://learn.microsoft.com/dotnet/api/system.exception.gettype)

    [Exception.ToString()](https://learn.microsoft.com/dotnet/api/system.exception.tostring)

    [Exception.Data](https://learn.microsoft.com/dotnet/api/system.exception.data)

    [Exception.HelpLink](https://learn.microsoft.com/dotnet/api/system.exception.helplink)

    [Exception.HResult](https://learn.microsoft.com/dotnet/api/system.exception.hresult)

    [Exception.InnerException](https://learn.microsoft.com/dotnet/api/system.exception.innerexception)

    [Exception.Message](https://learn.microsoft.com/dotnet/api/system.exception.message)

    [Exception.Source](https://learn.microsoft.com/dotnet/api/system.exception.source)

    [Exception.StackTrace](https://learn.microsoft.com/dotnet/api/system.exception.stacktrace)

    [Exception.TargetSite](https://learn.microsoft.com/dotnet/api/system.exception.targetsite)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Constructors

### UrlElicitationRequiredException(string, IEnumerable<ElicitRequestParams>)

Initializes a new instance of the [UrlElicitationRequiredException](ModelContextProtocol.UrlElicitationRequiredException.html) class with the specified message and pending elicitations.

```
public UrlElicitationRequiredException(string message, IEnumerable<ElicitRequestParams> elicitations)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   A description of why the elicitation is required.

`elicitations` [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html)>
:   One or more URL-mode elicitation requests that must complete before retrying the original request.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `elicitations` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `elicitations` is empty or contains invalid elicitations.

## Properties

### Elicitations

Gets the collection of pending URL-mode elicitation requests that must be completed.

```
public IReadOnlyList<ElicitRequestParams> Elicitations { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[ElicitRequestParams](ModelContextProtocol.Protocol.ElicitRequestParams.html)>




