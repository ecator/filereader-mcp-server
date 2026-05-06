
##### Table of Contents

# Enum HttpTransportMode

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Specifies the transport mode for HTTP client connections.

```
public enum HttpTransportMode
```

## Fields

`AutoDetect = 0`
:   Automatically detect the appropriate transport by trying Streamable HTTP first, then falling back to SSE if that fails.
    This is the recommended mode for maximum compatibility.

`Sse = 2`
:   Use only the HTTP with SSE transport.

`StreamableHttp = 1`
:   Use only the Streamable HTTP transport.




