
##### Table of Contents

# Class McpProtocolException

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an exception that is thrown when a Model Context Protocol (MCP) protocol-level error occurs.

```
public class McpProtocolException : McpException, ISerializable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Exception](https://learn.microsoft.com/dotnet/api/system.exception)

    [McpException](ModelContextProtocol.McpException.html)

    McpProtocolException

Implements
:   [ISerializable](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

Derived
:   [UrlElicitationRequiredException](ModelContextProtocol.UrlElicitationRequiredException.html)

Inherited Members
:   [Exception.GetBaseException()](https://learn.microsoft.com/dotnet/api/system.exception.getbaseexception)

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

    [Exception.SerializeObjectState](https://learn.microsoft.com/dotnet/api/system.exception.serializeobjectstate)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

This exception is used to represent failures related to protocol-level concerns, such as malformed
JSON-RPC requests, unknown methods, unknown primitive names (tools/prompts/resources), or internal
server errors. It is not intended to be used for tool execution errors, including input validation failures.

Tool execution errors (including input validation errors, API failures, and business logic errors)
should be returned in the result object with `IsError` set to [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool), allowing
language models to see error details and self-correct. Only protocol-level issues should throw
[McpProtocolException](ModelContextProtocol.McpProtocolException.html).

[Message](https://learn.microsoft.com/dotnet/api/system.exception.message) or [ErrorCode](ModelContextProtocol.McpProtocolException.html#ModelContextProtocol_McpProtocolException_ErrorCode) from a [McpProtocolException](ModelContextProtocol.McpProtocolException.html) may be
propagated to the remote endpoint; sensitive information should not be included. If sensitive details need
to be included, a different exception type should be used.

## Constructors

### McpProtocolException()

Initializes a new instance of the [McpProtocolException](ModelContextProtocol.McpProtocolException.html) class.

```
public McpProtocolException()
```

### McpProtocolException(string)

Initializes a new instance of the [McpProtocolException](ModelContextProtocol.McpProtocolException.html) class with a specified error message.

```
public McpProtocolException(string message)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message that describes the error.

### McpProtocolException(string, McpErrorCode)

Initializes a new instance of the [McpProtocolException](ModelContextProtocol.McpProtocolException.html) class with a specified error message and JSON-RPC error code.

```
public McpProtocolException(string message, McpErrorCode errorCode)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message that describes the error.

`errorCode` [McpErrorCode](ModelContextProtocol.McpErrorCode.html)
:   An [McpErrorCode](ModelContextProtocol.McpErrorCode.html).

### McpProtocolException(string, Exception?)

Initializes a new instance of the [McpProtocolException](ModelContextProtocol.McpProtocolException.html) class with a specified error message and a reference to the inner exception that is the cause of this exception.

```
public McpProtocolException(string message, Exception? innerException)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message that describes the error.

`innerException` [Exception](https://learn.microsoft.com/dotnet/api/system.exception)
:   The exception that is the cause of the current exception, or a null reference if no inner exception is specified.

### McpProtocolException(string, Exception?, McpErrorCode)

Initializes a new instance of the [McpProtocolException](ModelContextProtocol.McpProtocolException.html) class with a specified error message, inner exception, and JSON-RPC error code.

```
public McpProtocolException(string message, Exception? innerException, McpErrorCode errorCode)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message that describes the error.

`innerException` [Exception](https://learn.microsoft.com/dotnet/api/system.exception)
:   The exception that is the cause of the current exception, or a null reference if no inner exception is specified.

`errorCode` [McpErrorCode](ModelContextProtocol.McpErrorCode.html)
:   An [McpErrorCode](ModelContextProtocol.McpErrorCode.html).

## Properties

### ErrorCode

Gets the error code associated with this exception.

```
public McpErrorCode ErrorCode { get; }
```

#### Property Value

[McpErrorCode](ModelContextProtocol.McpErrorCode.html)

#### Remarks

This property contains a standard JSON-RPC error code as defined in the MCP specification. Common error codes include:

* -32700: Parse error - Invalid JSON received
* -32600: Invalid request - The JSON is not a valid Request object
* -32601: Method not found - The method does not exist or is not available
* -32602: Invalid params - Malformed request or unknown primitive name (tool/prompt/resource)
* -32603: Internal error - Internal JSON-RPC error




