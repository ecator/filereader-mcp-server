
##### Table of Contents

# Class McpAuthenticationExtensions

Namespace
:   [Microsoft](Microsoft.html).[Extensions](Microsoft.Extensions.html).[DependencyInjection](Microsoft.Extensions.DependencyInjection.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Extension methods for adding MCP authentication support to ASP.NET Core applications.

```
public static class McpAuthenticationExtensions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpAuthenticationExtensions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### AddMcp(AuthenticationBuilder, Action<McpAuthenticationOptions>?)

Adds MCP authentication support to the application.

```
public static AuthenticationBuilder AddMcp(this AuthenticationBuilder builder, Action<McpAuthenticationOptions>? configureOptions = null)
```

#### Parameters

`builder` [AuthenticationBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationbuilder)
:   The authentication builder.

`configureOptions` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)>
:   An action to configure MCP authentication options.

#### Returns

[AuthenticationBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationbuilder)
:   The authentication builder for chaining.

### AddMcp(AuthenticationBuilder, string, string, Action<McpAuthenticationOptions>?)

Adds MCP authentication support to the application with a custom scheme name.

```
public static AuthenticationBuilder AddMcp(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<McpAuthenticationOptions>? configureOptions = null)
```

#### Parameters

`builder` [AuthenticationBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationbuilder)
:   The authentication builder.

`authenticationScheme` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The authentication scheme name to use.

`displayName` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The display name for the authentication scheme.

`configureOptions` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)>
:   An action to configure MCP authentication options.

#### Returns

[AuthenticationBuilder](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationbuilder)
:   The authentication builder for chaining.




