
##### Table of Contents

# Enum SseEventStreamMode

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the mode of an SSE event stream.

```
public enum SseEventStreamMode
```

## Fields

`Polling = 1`
:   Causes the event stream returned by [ReadEventsAsync(CancellationToken)](ModelContextProtocol.Server.ISseEventStreamReader.html#ModelContextProtocol_Server_ISseEventStreamReader_ReadEventsAsync_System_Threading_CancellationToken_) to end
    after the most recent event has been consumed. This forces clients to keep making new requests in order to receive
    the latest messages.

`Streaming = 0`
:   Causes the event stream returned by [ReadEventsAsync(CancellationToken)](ModelContextProtocol.Server.ISseEventStreamReader.html#ModelContextProtocol_Server_ISseEventStreamReader_ReadEventsAsync_System_Threading_CancellationToken_) to only end when
    the associated [ISseEventStreamWriter](ModelContextProtocol.Server.ISseEventStreamWriter.html) gets disposed.




