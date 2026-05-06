
##### Table of Contents

# Class HttpClientTransportOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides options for configuring [HttpClientTransport](ModelContextProtocol.Client.HttpClientTransport.html) instances.

```
public sealed class HttpClientTransportOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    HttpClientTransportOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### AdditionalHeaders

Gets or sets custom HTTP headers to include in requests to the SSE server.

```
public IDictionary<string, string>? AdditionalHeaders { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

Use this property to specify custom HTTP headers that should be sent with each request to the server.

### ConnectionTimeout

Gets or sets a timeout used to establish the initial connection to the SSE server.

```
public TimeSpan ConnectionTimeout { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)
:   The timeout used to establish the initial connection to the SSE server. The default is 30 seconds.

#### Remarks

This timeout controls how long the client waits for:

* The initial HTTP connection to be established with the SSE server.
* The endpoint event to be received, which indicates the message endpoint URL.

If the timeout expires before the connection is established, a [TimeoutException](https://learn.microsoft.com/dotnet/api/system.timeoutexception) is thrown.

### DefaultReconnectionInterval

Gets or sets the default interval at which the client attempts reconnection after an SSE stream is disconnected.

```
public TimeSpan DefaultReconnectionInterval { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)

#### Remarks

The default value is 1 second.

If the server sends a message specifying a different reconnection interval, that new value will be used for all
subsequent reconnection attempts for that stream.

### Endpoint

Gets or sets the base address of the server for SSE connections.

```
public required Uri Endpoint { get; set; }
```

#### Property Value

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   The value is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   The value is not an absolute URI, or does not use the HTTP or HTTPS scheme.

### KnownSessionId

Gets or sets a session identifier that should be reused when connecting to a Streamable HTTP server.

```
public string? KnownSessionId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

When non-[null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the transport assumes the server already created the session and will include the
specified session identifier in every HTTP request. This allows reconnecting to an existing session created in a
previous process. This option is only supported by the Streamable HTTP transport mode.

Clients should pair this with
[ResumeSessionAsync(IClientTransport, ResumeClientSessionOptions, McpClientOptions?, ILoggerFactory?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_ResumeSessionAsync_ModelContextProtocol_Client_IClientTransport_ModelContextProtocol_Client_ResumeClientSessionOptions_ModelContextProtocol_Client_McpClientOptions_Microsoft_Extensions_Logging_ILoggerFactory_System_Threading_CancellationToken_)
to skip the initialization handshake when rehydrating a previously negotiated session.

### MaxReconnectionAttempts

Gets or sets the maximum number of consecutive reconnection attempts when an SSE stream is disconnected.

```
public int MaxReconnectionAttempts { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)
:   The maximum number of reconnection attempts. The default is 5.

#### Remarks

When an SSE stream is disconnected (e.g., due to a network issue), the client will attempt to
reconnect using the Last-Event-ID header to resume from where it left off. This property controls
how many consecutive reconnection attempts are made before giving up. The counter resets to zero
on each successful stream read, so this value only limits consecutive failures.

### Name

Gets or sets a transport identifier used for logging purposes.

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### OAuth

Gets or sets the authorization provider to use for authentication.

```
public ClientOAuthOptions? OAuth { get; set; }
```

#### Property Value

[ClientOAuthOptions](ModelContextProtocol.Authentication.ClientOAuthOptions.html)

### OwnsSession

Gets or sets a value indicating whether this transport endpoint is responsible for ending the session on dispose.

```
public bool OwnsSession { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

#### Remarks

When [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) (default), the transport sends a DELETE request that informs the server the session is
complete. Set this to [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) when creating a transport used solely to bootstrap session information
that will later be resumed elsewhere.

### TransportMode

Gets or sets the transport mode to use for the connection.

```
public HttpTransportMode TransportMode { get; set; }
```

#### Property Value

[HttpTransportMode](ModelContextProtocol.Client.HttpTransportMode.html)
:   The transport mode to use for the connection. The default is [AutoDetect](ModelContextProtocol.Client.HttpTransportMode.html#ModelContextProtocol_Client_HttpTransportMode_AutoDetect).

#### Remarks

When set to [AutoDetect](ModelContextProtocol.Client.HttpTransportMode.html#ModelContextProtocol_Client_HttpTransportMode_AutoDetect) (the default), the client will first attempt to use
Streamable HTTP transport and automatically fall back to SSE transport if the server doesn't support it.

See Also
:   [Streamable HTTP transport specification](https://modelcontextprotocol.io/specification/2025-11-25/basic/transports#streamable-http)

    [HTTP with SSE transport specification](https://modelcontextprotocol.io/specification/2024-11-05/basic/transports#http-with-sse)




