
##### Table of Contents

# Enum McpErrorCode

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents standard JSON-RPC error codes as defined in the MCP specification.

```
public enum McpErrorCode
```

## Fields

`InternalError = -32603`
:   Indicates that an internal error occurred while processing the request.

    This error is used when the endpoint encounters an unexpected condition that prevents it from fulfilling the request.

`InvalidParams = -32602`
:   Indicates that the request parameters are invalid at the protocol level.

    In MCP, this error is returned for protocol-level parameter validation failures in various contexts:

    * **Tools**: Unknown tool name or invalid protocol-level tool arguments.
    * **Prompts**: Unknown prompt name or missing required protocol-level arguments.
    * **Pagination**: Invalid or expired cursor values.
    * **Logging**: Invalid log level.
    * **Tasks**: Invalid or nonexistent task ID or invalid cursor.
    * **Elicitation**: Server requests an elicitation mode not declared in client capabilities.
    * **Sampling**: Missing tool result or tool results mixed with other content.

    Note: Application-layer validation errors within tool/prompt/resource arguments should be reported as execution errors
    (for example, via [IsError](ModelContextProtocol.Protocol.CallToolResult.html#ModelContextProtocol_Protocol_CallToolResult_IsError)) rather than as protocol errors, allowing language
    models to receive error feedback and self-correct.

`InvalidRequest = -32600`
:   Indicates that the JSON payload does not conform to the expected Request object structure.

    The request is considered invalid if it lacks required fields or fails to follow the JSON-RPC protocol.

`MethodNotFound = -32601`
:   Indicates that the requested method does not exist or is not available.

    In MCP, this error is returned when a request is made for a method that requires a capability
    that has not been declared. This can occur in either direction:

    * A server returning this error when the client requests a capability it doesn't support
      (for example, requesting completions when the `completions` capability was not advertised).
    * A client returning this error when the server requests a capability it doesn't support
      (for example, requesting roots when the client did not declare the `roots` capability).

`ParseError = -32700`
:   Indicates that the JSON received could not be parsed.

    This error occurs when the input contains malformed JSON or incorrect syntax.

`ResourceNotFound = -32002`
:   Indicates that the requested resource could not be found.

    This error should be used when a resource URI does not match any available resource on the server.
    It allows clients to distinguish between missing resources and other types of errors.

`UrlElicitationRequired = -32042`
:   Indicates that URL-mode elicitation is required to complete the requested operation.

    This error is returned when a server operation requires additional user input through URL-mode elicitation
    before it can proceed. The error data must include the `data.elicitations` payload describing the pending
    elicitation(s) for the client to present to the user.

    Common scenarios include OAuth authorization and other out-of-band flows that cannot be completed inside
    the MCP client.




