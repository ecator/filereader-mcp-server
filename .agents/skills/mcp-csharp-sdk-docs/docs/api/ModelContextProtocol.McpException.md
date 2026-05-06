
##### Table of Contents

# Class McpException

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an exception that is thrown when a Model Context Protocol (MCP) error occurs.

```
public class McpException : Exception, ISerializable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [Exception](https://learn.microsoft.com/dotnet/api/system.exception)

    McpException

Implements
:   [ISerializable](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

Derived
:   [McpProtocolException](ModelContextProtocol.McpProtocolException.html)

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

The [Message](https://learn.microsoft.com/dotnet/api/system.exception.message) from a [McpException](ModelContextProtocol.McpException.html) might be propagated to the remote
endpoint; sensitive information should not be included. If sensitive details need to be included,
a different exception type should be used.

This exception type can be thrown by MCP tools or tool call filters to propagate detailed error messages
from [Message](https://learn.microsoft.com/dotnet/api/system.exception.message) when a tool execution fails via a [CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html).
This includes input validation errors, business logic errors, or any other failure that the model should
be informed about. For example, if a required field is missing or a value is out of range, throwing an
[McpException](ModelContextProtocol.McpException.html) with a descriptive message allows the model to understand the issue and
potentially self-correct in a subsequent request.

For non-tool calls, this exception controls the message propagated via a [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html).

[McpProtocolException](ModelContextProtocol.McpProtocolException.html) is a derived type that can be used to also specify the
[McpErrorCode](ModelContextProtocol.McpErrorCode.html) that should be used for the resulting [JsonRpcError](ModelContextProtocol.Protocol.JsonRpcError.html).

## Constructors

### McpException()

Initializes a new instance of the [McpException](ModelContextProtocol.McpException.html) class.

```
public McpException()
```

### McpException(string)

Initializes a new instance of the [McpException](ModelContextProtocol.McpException.html) class with a specified error message.

```
public McpException(string message)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message that describes the error.

### McpException(string, Exception?)

Initializes a new instance of the [McpException](ModelContextProtocol.McpException.html) class with a specified error message and
a reference to the inner exception that is the cause of this exception.

```
public McpException(string message, Exception? innerException)
```

#### Parameters

`message` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The message that describes the error.

`innerException` [Exception](https://learn.microsoft.com/dotnet/api/system.exception)
:   The exception that is the cause of the current exception, or a null
    reference if no inner exception is specified.




