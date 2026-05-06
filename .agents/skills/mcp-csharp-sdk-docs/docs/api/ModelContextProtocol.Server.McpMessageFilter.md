
##### Table of Contents

# Delegate McpMessageFilter

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Delegate type for applying filters to JSON-RPC messages.

```
public delegate McpMessageHandler McpMessageFilter(McpMessageHandler next)
```

#### Parameters

`next` [McpMessageHandler](ModelContextProtocol.Server.McpMessageHandler.html)
:   The next message handler in the pipeline.

#### Returns

[McpMessageHandler](ModelContextProtocol.Server.McpMessageHandler.html)
:   The next message handler wrapped with the filter.

## Remarks

Message filters allow you to intercept and process JSON-RPC messages before they reach
their respective handlers (incoming) or before they are sent (outgoing). This is useful for implementing
cross-cutting concerns that need to apply to all message types, such as logging, authentication, rate limiting,
redaction, or request tracing.

Filters are applied in the order they are registered, with the first registered filter being the outermost.
Each filter receives the next handler in the pipeline and can choose to:

* Call the next handler to continue processing (await next(context, cancellationToken))
* Skip the default handlers entirely by not calling next
* Perform operations before and/or after calling next
* Catch and handle exceptions from inner handlers

For request-specific filters, use [McpRequestFilter<TParams, TResult>](ModelContextProtocol.Server.McpRequestFilter-2.html) instead.




