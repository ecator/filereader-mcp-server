
##### Table of Contents

# Delegate McpRequestFilter<TParams, TResult>

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Delegate type for applying filters to incoming MCP requests with specific parameter and result types.

```
public delegate McpRequestHandler<TParams, TResult> McpRequestFilter<TParams, TResult>(McpRequestHandler<TParams, TResult> next)
```

#### Parameters

`next` [McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<TParams, TResult>
:   The next request handler in the pipeline.

#### Returns

[McpRequestHandler](ModelContextProtocol.Server.McpRequestHandler-2.html)<TParams, TResult>
:   The next request handler wrapped with the filter.

#### Type Parameters

`TParams`
:   The type of the parameters sent with the request.

`TResult`
:   The type of the response returned by the handler.




