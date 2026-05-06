
##### Table of Contents

# Class ClientOAuthOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides configuration options for the ModelContextProtocol.Authentication.ClientOAuthProvider.

```
public sealed class ClientOAuthOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ClientOAuthOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### AdditionalAuthorizationParameters

Gets or sets additional parameters to include in the query string of the OAuth authorization request
providing extra information or fulfilling specific requirements of the OAuth provider.

```
public IDictionary<string, string> AdditionalAuthorizationParameters { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

Parameters specified cannot override or append to any automatically set parameters like the "redirect\_uri",
which should instead be configured via [RedirectUri](ModelContextProtocol.Authentication.ClientOAuthOptions.html#ModelContextProtocol_Authentication_ClientOAuthOptions_RedirectUri).

### AuthServerSelector

Gets or sets the authorization server selector function.

```
public Func<IReadOnlyList<Uri>, Uri?>? AuthServerSelector { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-2)<[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[Uri](https://learn.microsoft.com/dotnet/api/system.uri)>, [Uri](https://learn.microsoft.com/dotnet/api/system.uri)>

#### Remarks

This function is used to select which authorization server to use when multiple servers are available.
If not specified, the first available server will be selected.

The function receives a list of available authorization server URIs and should return the selected server,
or null if no suitable server is found.

### AuthorizationRedirectDelegate

Gets or sets the authorization redirect delegate for handling the OAuth authorization flow.

```
public AuthorizationRedirectDelegate? AuthorizationRedirectDelegate { get; set; }
```

#### Property Value

[AuthorizationRedirectDelegate](ModelContextProtocol.Authentication.AuthorizationRedirectDelegate.html)

#### Remarks

This delegate is responsible for handling the OAuth authorization URL and obtaining the authorization code.
If not specified, a default implementation will be used that prompts the user to enter the code manually.

Custom implementations might open a browser, start an HTTP listener, or use other mechanisms to capture
the authorization code from the OAuth redirect.

### ClientId

Gets or sets the OAuth client ID. If not provided, the client will attempt to register dynamically.

```
public string? ClientId { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ClientMetadataDocumentUri

Gets or sets the HTTPS URL pointing to this client's metadata document.

```
public Uri? ClientMetadataDocumentUri { get; set; }
```

#### Property Value

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)

#### Remarks

When specified, and when the authorization server metadata reports
`client_id_metadata_document_supported = true`, the OAuth client will respond to
challenges by sending this URL as the client identifier instead of performing dynamic
client registration.

### ClientSecret

Gets or sets the OAuth client secret.

```
public string? ClientSecret { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This secret is optional for public clients or when using PKCE without client authentication.

### DynamicClientRegistration

Gets or sets the options to use during dynamic client registration.

```
public DynamicClientRegistrationOptions? DynamicClientRegistration { get; set; }
```

#### Property Value

[DynamicClientRegistrationOptions](ModelContextProtocol.Authentication.DynamicClientRegistrationOptions.html)

#### Remarks

This value is only used when no [ClientId](ModelContextProtocol.Authentication.ClientOAuthOptions.html#ModelContextProtocol_Authentication_ClientOAuthOptions_ClientId) is specified.

### RedirectUri

Gets or sets the OAuth redirect URI.

```
public required Uri RedirectUri { get; set; }
```

#### Property Value

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)

### Scopes

Gets or sets the OAuth scopes to request.

```
public IEnumerable<string>? Scopes { get; set; }
```

#### Property Value

[IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

When specified, these scopes will be used instead of the scopes advertised by the protected resource.
If not specified, the provider will use the scopes from the protected resource metadata.

Common OAuth scopes include "openid", "profile", and "email".

### TokenCache

Gets or sets the token cache to use for storing and retrieving tokens beyond the lifetime of the transport.
If none is provided, tokens will be cached with the transport.

```
public ITokenCache? TokenCache { get; set; }
```

#### Property Value

[ITokenCache](ModelContextProtocol.Authentication.ITokenCache.html)




