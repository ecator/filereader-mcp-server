
##### Table of Contents

# Delegate McpMessageHandler

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Delegate type for handling incoming JSON-RPC messages.

```
public delegate Task McpMessageHandler(MessageContext context, CancellationToken cancellationToken)
```

#### Parameters

`context` [MessageContext](ModelContextProtocol.Server.MessageContext.html)
:   The message context containing the JSON-RPC message and other metadata.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   A cancellation token to cancel the operation.

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A task representing the asynchronous operation.

## Remarks

This delegate can handle any type of JSON-RPC message, including requests, notifications, responses, and errors.
Use this for implementing cross-cutting concerns that need to intercept all message types,
such as logging, authentication, rate limiting, or request tracing.

For request-specific handling, use [McpRequestHandler<TParams, TResult>](ModelContextProtocol.Server.McpRequestHandler-2.html) instead.




