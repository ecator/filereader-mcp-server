
##### Table of Contents

# Class DynamicClientRegistrationResponse

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a client registration response for OAuth 2.0 Dynamic Client Registration (RFC 7591).

```
public sealed class DynamicClientRegistrationResponse
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    DynamicClientRegistrationResponse

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### ClientId

Gets or initializes the client identifier.

```
[JsonPropertyName("client_id")]
public required string ClientId { get; init; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ClientIdIssuedAt

Gets or initializes the timestamp at which the client ID was issued.

```
[JsonPropertyName("client_id_issued_at")]
public long? ClientIdIssuedAt { get; init; }
```

#### Property Value

[long](https://learn.microsoft.com/dotnet/api/system.int64)?

### ClientSecret

Gets or initializes the client secret.

```
[JsonPropertyName("client_secret")]
public string? ClientSecret { get; init; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ClientSecretExpiresAt

Gets or initializes the client secret expiration time.

```
[JsonPropertyName("client_secret_expires_at")]
public long? ClientSecretExpiresAt { get; init; }
```

#### Property Value

[long](https://learn.microsoft.com/dotnet/api/system.int64)?

### GrantTypes

Gets or initializes the grant types that the client will use.

```
[JsonPropertyName("grant_types")]
public IList<string>? GrantTypes { get; init; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### RedirectUris

Gets or initializes the redirect URIs for the client.

```
[JsonPropertyName("redirect_uris")]
public IList<string>? RedirectUris { get; init; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### ResponseTypes

Gets or initializes the response types that the client will use.

```
[JsonPropertyName("response_types")]
public IList<string>? ResponseTypes { get; init; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### TokenEndpointAuthMethod

Gets or initializes the token endpoint authentication method.

```
[JsonPropertyName("token_endpoint_auth_method")]
public string? TokenEndpointAuthMethod { get; init; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




