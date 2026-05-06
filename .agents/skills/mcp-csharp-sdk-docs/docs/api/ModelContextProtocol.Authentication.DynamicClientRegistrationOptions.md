
##### Table of Contents

# Class DynamicClientRegistrationOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides configuration options for the ModelContextProtocol.Authentication.ClientOAuthProvider related to dynamic client registration (RFC 7591).

```
public sealed class DynamicClientRegistrationOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    DynamicClientRegistrationOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### ClientName

Gets or sets the client name to use during dynamic client registration.

```
public string? ClientName { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value is a human-readable name for the client that can be displayed to users during authorization.

### ClientUri

Gets or sets the client URI to use during dynamic client registration.

```
public Uri? ClientUri { get; set; }
```

#### Property Value

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)

#### Remarks

This value should be a URL pointing to the client's home page or information page.

### InitialAccessToken

Gets or sets the initial access token to use during dynamic client registration.

```
public string? InitialAccessToken { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This token is used to authenticate the client during the registration process.

This token is required if the authorization server does not allow anonymous client registration.

### ResponseDelegate

Gets or sets the delegate used for handling the dynamic client registration response.

```
public Func<DynamicClientRegistrationResponse, CancellationToken, Task>? ResponseDelegate { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-3)<[DynamicClientRegistrationResponse](ModelContextProtocol.Authentication.DynamicClientRegistrationResponse.html), [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken), [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)>

#### Remarks

This delegate is responsible for processing the response from the dynamic client registration endpoint.

The implementation should save the client credentials securely for future use.




