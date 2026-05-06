
##### Table of Contents

# Class ProtectedResourceMetadata

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the resource metadata for OAuth authorization as defined in [RFC 9728](https://datatracker.ietf.org/doc/rfc9728/).

```
public sealed class ProtectedResourceMetadata
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ProtectedResourceMetadata

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### AuthorizationDetailsTypesSupported

Gets or sets the list of the authorization details type values supported by the resource server.

```
[JsonPropertyName("authorization_details_types_supported")]
public IList<string>? AuthorizationDetailsTypesSupported { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A JSON array containing a list of the authorization details type values supported by the resource server
    when the authorization\_details request parameter is used.

#### Remarks

OPTIONAL.

### AuthorizationServers

Gets or sets the list of authorization server URIs.

```
[JsonPropertyName("authorization_servers")]
public IList<string> AuthorizationServers { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A JSON array containing a list of OAuth authorization server issuer identifiers
    for authorization servers that can be used with this protected resource.

#### Remarks

OPTIONAL.

### BearerMethodsSupported

Gets or sets the supported bearer token methods.

```
[JsonPropertyName("bearer_methods_supported")]
public IList<string> BearerMethodsSupported { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A JSON array containing a list of the supported methods of sending an OAuth 2.0 bearer token
    to the protected resource. Defined values are ["header", "body", "query"].

#### Remarks

OPTIONAL.

### DpopBoundAccessTokensRequired

Gets or sets a value indicating whether the protected resource always requires the use of DPoP-bound access tokens.

```
[JsonPropertyName("dpop_bound_access_tokens_required")]
public bool? DpopBoundAccessTokensRequired { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the protected resource always requires the use of DPoP-bound access tokens; otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool). The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

OPTIONAL.

### DpopSigningAlgValuesSupported

Gets or sets the list of the JWS algorithm values supported by the resource server for validating DPoP proof JWTs.

```
[JsonPropertyName("dpop_signing_alg_values_supported")]
public IList<string>? DpopSigningAlgValuesSupported { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A JSON array containing a list of the JWS alg values supported by the resource server
    for validating Demonstrating Proof of Possession (DPoP) proof JWTs.

#### Remarks

OPTIONAL.

### JwksUri

Gets or sets the URL of the protected resource's JSON Web Key (JWK) Set document.

```
[JsonPropertyName("jwks_uri")]
[StringSyntax("Uri")]
public string? JwksUri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

OPTIONAL. This document contains public keys belonging to the protected resource, such as signing keys
that the resource server uses to sign resource responses. This URL MUST use the HTTPS scheme.

### Resource

Gets or sets the resource URI.

```
[JsonPropertyName("resource")]
[StringSyntax("Uri")]
public string? Resource { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The protected resource's resource identifier.

#### Remarks

OPTIONAL. When omitted, the MCP authentication handler infers the resource URI from the incoming request only when serving
the default `/.well-known/oauth-protected-resource` endpoint. If a custom `ResourceMetadataUri` is configured,
**Resource** must be explicitly set. Automatic inference only works with the default endpoint pattern.

### ResourceDocumentation

Gets or sets the URI to the resource documentation.

```
[JsonPropertyName("resource_documentation")]
[StringSyntax("Uri")]
public string? ResourceDocumentation { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URL of a page containing human-readable information that developers might want or need to know
    when using the protected resource.

#### Remarks

OPTIONAL.

### ResourceName

Gets or sets the human-readable name of the protected resource intended for display to the end user.

```
[JsonPropertyName("resource_name")]
public string? ResourceName { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

RECOMMENDED. It is recommended that protected resource metadata include this field.
The value of this field MAY be internationalized.

### ResourcePolicyUri

Gets or sets the URL of a page containing human-readable information about the protected resource's requirements.

```
[JsonPropertyName("resource_policy_uri")]
[StringSyntax("Uri")]
public string? ResourcePolicyUri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URL of a page that contains information about how the client can use the data provided by the protected resource.

#### Remarks

OPTIONAL.

### ResourceSigningAlgValuesSupported

Gets or sets the list of the JWS signing algorithms supported by the protected resource for signing resource responses.

```
[JsonPropertyName("resource_signing_alg_values_supported")]
public IList<string>? ResourceSigningAlgValuesSupported { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A JSON array containing a list of the JWS signing algorithms (alg values) supported by the protected resource
    for signing resource responses.

#### Remarks

OPTIONAL. No default algorithms are implied if this entry is omitted. The value "none" MUST NOT be used.

### ResourceTosUri

Gets or sets the URL of a page containing human-readable information about the protected resource's terms of service.

```
[JsonPropertyName("resource_tos_uri")]
[StringSyntax("Uri")]
public string? ResourceTosUri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

OPTIONAL. The value of this field MAY be internationalized.

### ScopesSupported

Gets or sets the supported scopes.

```
[JsonPropertyName("scopes_supported")]
public IList<string> ScopesSupported { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>
:   A JSON array containing a list of scope values that are used in authorization
    requests to request access to this protected resource.

#### Remarks

RECOMMENDED.

### TlsClientCertificateBoundAccessTokens

Gets or sets a value indicating whether there is protected resource support for mutual-TLS client certificate-bound access tokens.

```
[JsonPropertyName("tls_client_certificate_bound_access_tokens")]
public bool? TlsClientCertificateBoundAccessTokens { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if there's protected resource support for mutual-TLS client certificate-bound access tokens; otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool). The default is [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Remarks

OPTIONAL.

## Methods

### Clone(string?)

Creates a deep copy of this [ProtectedResourceMetadata](ModelContextProtocol.Authentication.ProtectedResourceMetadata.html) instance, optionally overriding the Resource property.

```
public ProtectedResourceMetadata Clone(string? derivedResource = null)
```

#### Parameters

`derivedResource` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   Optional resource URI string to use for the Resource property if the original Resource is null.

#### Returns

[ProtectedResourceMetadata](ModelContextProtocol.Authentication.ProtectedResourceMetadata.html)
:   A new instance of [ProtectedResourceMetadata](ModelContextProtocol.Authentication.ProtectedResourceMetadata.html) with cloned values.




