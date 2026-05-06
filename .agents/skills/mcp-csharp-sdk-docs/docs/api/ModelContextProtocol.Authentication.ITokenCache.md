
##### Table of Contents

# Interface ITokenCache

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Allows the client to cache access tokens beyond the lifetime of the transport.

```
public interface ITokenCache
```

## Methods

### GetTokensAsync(CancellationToken)

Get the cached token. This method is invoked for every request.

```
ValueTask<TokenContainer?> GetTokensAsync(CancellationToken cancellationToken)
```

#### Parameters

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[TokenContainer](ModelContextProtocol.Authentication.TokenContainer.html)>

### StoreTokensAsync(TokenContainer, CancellationToken)

Cache the token. After a new access token is acquired, this method is invoked to store it.

```
ValueTask StoreTokensAsync(TokenContainer tokens, CancellationToken cancellationToken)
```

#### Parameters

`tokens` [TokenContainer](ModelContextProtocol.Authentication.TokenContainer.html)

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask)




