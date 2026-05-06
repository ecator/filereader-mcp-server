
##### Table of Contents

# Delegate McpRequestHandler<TParams, TResult>

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Delegate type for handling incoming MCP requests with specific parameter and result types.

```
public delegate ValueTask<TResult> McpRequestHandler<TParams, TResult>(RequestContext<TParams> request, CancellationToken cancellationToken)
```

#### Parameters

`request` [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<TParams>
:   The request context containing the parameters and other metadata.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<TResult>
:   A task representing the asynchronous operation, with the result of the handler.

#### Type Parameters

`TParams`
:   The type of the parameters sent with the request.

`TResult`
:   The type of the response returned by the handler.




