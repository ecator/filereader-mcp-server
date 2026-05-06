
##### Table of Contents

# Class McpAuthenticationOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[AspNetCore](ModelContextProtocol.AspNetCore.html).[Authentication](ModelContextProtocol.AspNetCore.Authentication.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Represents options for the MCP authentication handler.

```
public class McpAuthenticationOptions : AuthenticationSchemeOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [AuthenticationSchemeOptions](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions)

    McpAuthenticationOptions

Inherited Members
:   [AuthenticationSchemeOptions.Validate()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.validate#microsoft-aspnetcore-authentication-authenticationschemeoptions-validate)

    [AuthenticationSchemeOptions.Validate(string)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.validate#microsoft-aspnetcore-authentication-authenticationschemeoptions-validate(system-string))

    [AuthenticationSchemeOptions.ClaimsIssuer](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.claimsissuer)

    [AuthenticationSchemeOptions.EventsType](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.eventstype)

    [AuthenticationSchemeOptions.ForwardDefault](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwarddefault)

    [AuthenticationSchemeOptions.ForwardAuthenticate](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwardauthenticate)

    [AuthenticationSchemeOptions.ForwardChallenge](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwardchallenge)

    [AuthenticationSchemeOptions.ForwardForbid](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwardforbid)

    [AuthenticationSchemeOptions.ForwardSignIn](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwardsignin)

    [AuthenticationSchemeOptions.ForwardSignOut](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwardsignout)

    [AuthenticationSchemeOptions.ForwardDefaultSelector](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.forwarddefaultselector)

    [AuthenticationSchemeOptions.TimeProvider](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions.timeprovider)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### McpAuthenticationOptions()

Initializes a new instance of the [McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html) class.

```
public McpAuthenticationOptions()
```

## Properties

### Events

Gets or sets the events used to handle authentication events.

```
public McpAuthenticationEvents Events { get; set; }
```

#### Property Value

[McpAuthenticationEvents](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationEvents.html)

### ResourceMetadata

Gets or sets the protected resource metadata.

```
public ProtectedResourceMetadata? ResourceMetadata { get; set; }
```

#### Property Value

[ProtectedResourceMetadata](ModelContextProtocol.Authentication.ProtectedResourceMetadata.html)

#### Remarks

This contains the OAuth metadata for the protected resource, including authorization servers,
supported scopes, and other information needed for clients to authenticate.

### ResourceMetadataUri

Gets or sets the URI to the resource metadata document.

```
public Uri? ResourceMetadataUri { get; set; }
```

#### Property Value

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)

#### Remarks

This URI is included in the WWW-Authenticate header when a 401 response is returned.
When [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), the handler automatically uses the default
`/.well-known/oauth-protected-resource/<resource-path>` endpoint that mirrors the requested resource path.




