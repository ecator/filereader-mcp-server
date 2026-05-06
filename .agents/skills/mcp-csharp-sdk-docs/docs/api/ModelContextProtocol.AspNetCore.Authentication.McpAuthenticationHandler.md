
##### Table of Contents

# Class McpAuthenticationHandler

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[AspNetCore](ModelContextProtocol.AspNetCore.html).[Authentication](ModelContextProtocol.AspNetCore.Authentication.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Represents an authentication handler for MCP protocol that adds resource metadata to challenge responses
and handles resource metadata endpoint requests.

```
public class McpAuthenticationHandler : AuthenticationHandler<McpAuthenticationOptions>, IAuthenticationRequestHandler, IAuthenticationHandler
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [AuthenticationHandler](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1)<[McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)>

    McpAuthenticationHandler

Implements
:   [IAuthenticationRequestHandler](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.iauthenticationrequesthandler)

    [IAuthenticationHandler](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.iauthenticationhandler)

Inherited Members
:   [AuthenticationHandler<McpAuthenticationOptions>.InitializeAsync(AuthenticationScheme, HttpContext)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.initializeasync)

    [AuthenticationHandler<McpAuthenticationOptions>.InitializeEventsAsync()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.initializeeventsasync)

    [AuthenticationHandler<McpAuthenticationOptions>.CreateEventsAsync()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.createeventsasync)

    [AuthenticationHandler<McpAuthenticationOptions>.InitializeHandlerAsync()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.initializehandlerasync)

    [AuthenticationHandler<McpAuthenticationOptions>.BuildRedirectUri(string)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.buildredirecturi)

    [AuthenticationHandler<McpAuthenticationOptions>.ResolveTarget(string)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.resolvetarget)

    [AuthenticationHandler<McpAuthenticationOptions>.AuthenticateAsync()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.authenticateasync)

    [AuthenticationHandler<McpAuthenticationOptions>.HandleAuthenticateOnceAsync()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.handleauthenticateonceasync)

    [AuthenticationHandler<McpAuthenticationOptions>.HandleAuthenticateOnceSafeAsync()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.handleauthenticateoncesafeasync)

    [AuthenticationHandler<McpAuthenticationOptions>.HandleForbiddenAsync(AuthenticationProperties)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.handleforbiddenasync)

    [AuthenticationHandler<McpAuthenticationOptions>.ChallengeAsync(AuthenticationProperties)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.challengeasync)

    [AuthenticationHandler<McpAuthenticationOptions>.ForbidAsync(AuthenticationProperties)](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.forbidasync)

    [AuthenticationHandler<McpAuthenticationOptions>.Scheme](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.scheme)

    [AuthenticationHandler<McpAuthenticationOptions>.Options](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.options)

    [AuthenticationHandler<McpAuthenticationOptions>.Context](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.context)

    [AuthenticationHandler<McpAuthenticationOptions>.Request](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.request)

    [AuthenticationHandler<McpAuthenticationOptions>.Response](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.response)

    [AuthenticationHandler<McpAuthenticationOptions>.OriginalPath](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.originalpath)

    [AuthenticationHandler<McpAuthenticationOptions>.OriginalPathBase](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.originalpathbase)

    [AuthenticationHandler<McpAuthenticationOptions>.Logger](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.logger)

    [AuthenticationHandler<McpAuthenticationOptions>.UrlEncoder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.urlencoder)

    [AuthenticationHandler<McpAuthenticationOptions>.Clock](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.clock)

    [AuthenticationHandler<McpAuthenticationOptions>.TimeProvider](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.timeprovider)

    [AuthenticationHandler<McpAuthenticationOptions>.OptionsMonitor](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.optionsmonitor)

    [AuthenticationHandler<McpAuthenticationOptions>.Events](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.events)

    [AuthenticationHandler<McpAuthenticationOptions>.ClaimsIssuer](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.claimsissuer)

    [AuthenticationHandler<McpAuthenticationOptions>.CurrentUri](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1.currenturi)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### McpAuthenticationHandler(IOptionsMonitor<McpAuthenticationOptions>, ILoggerFactory, UrlEncoder)

Initializes a new instance of the [McpAuthenticationHandler](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationHandler.html) class.

```
public McpAuthenticationHandler(IOptionsMonitor<McpAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder)
```

#### Parameters

`options` [IOptionsMonitor](https://learn.microsoft.com/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1)<[McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)>

`logger` [ILoggerFactory](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.iloggerfactory)

`encoder` [UrlEncoder](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.urlencoder)

## Methods

### HandleAuthenticateAsync()

Allows derived types to handle authentication.

```
protected override Task<AuthenticateResult> HandleAuthenticateAsync()
```

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[AuthenticateResult](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticateresult)>
:   The [AuthenticateResult](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticateresult).

### HandleChallengeAsync(AuthenticationProperties)

Override this method to deal with 401 challenge concerns if an authentication scheme in question
deals an authentication interaction as part of its request flow (like adding a response header, or
changing the 401 result to 302 of a login page or external sign-in location).

```
protected override Task HandleChallengeAsync(AuthenticationProperties properties)
```

#### Parameters

`properties` [AuthenticationProperties](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationproperties)

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
:   A Task.

### HandleRequestAsync()

Gets a value that determines if the request should stop being processed.

This feature is supported by the Authentication middleware
which does not invoke any subsequent [IAuthenticationHandler](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.iauthenticationhandler) or middleware configured in the request pipeline
if the handler returns [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

```
public Task<bool> HandleRequestAsync()
```

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[bool](https://learn.microsoft.com/dotnet/api/system.boolean)>
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if request processing should stop.



