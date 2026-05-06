
##### Table of Contents

# Delegate AuthorizationRedirectDelegate

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a method that handles the OAuth authorization URL and returns the authorization code.

```
public delegate Task<string?> AuthorizationRedirectDelegate(Uri authorizationUri, Uri redirectUri, CancellationToken cancellationToken)
```

#### Parameters

`authorizationUri` [Uri](https://learn.microsoft.com/dotnet/api/system.uri)
:   The authorization URL that the user needs to visit.

`redirectUri` [Uri](https://learn.microsoft.com/dotnet/api/system.uri)
:   The redirect URI where the authorization code will be sent.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A task that represents the asynchronous operation. The task result contains the authorization code if successful, or null if the operation failed or was cancelled.

## Remarks

This delegate provides SDK consumers with full control over how the OAuth authorization flow is handled.
Implementers can choose to:

* Start a local HTTP server and open a browser (default behavior)
* Display the authorization URL to the user for manual handling
* Integrate with a custom UI or authentication flow
* Use a different redirect mechanism altogether

The implementation should handle user interaction to visit the authorization URL and extract
the authorization code from the callback. The authorization code is typically provided as
a query parameter in the redirect URI callback.




