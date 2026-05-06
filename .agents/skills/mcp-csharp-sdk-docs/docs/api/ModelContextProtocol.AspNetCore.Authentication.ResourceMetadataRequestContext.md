
##### Table of Contents

# Class ResourceMetadataRequestContext

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[AspNetCore](ModelContextProtocol.AspNetCore.html).[Authentication](ModelContextProtocol.AspNetCore.Authentication.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Represents the context for resource metadata request events.

```
public class ResourceMetadataRequestContext : HandleRequestContext<McpAuthenticationOptions>
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [BaseContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.basecontext-1)<[McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)>

    [HandleRequestContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.handlerequestcontext-1)<[McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)>

    ResourceMetadataRequestContext

Inherited Members
:   [HandleRequestContext<McpAuthenticationOptions>.HandleResponse()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.handlerequestcontext-1.handleresponse)

    [HandleRequestContext<McpAuthenticationOptions>.SkipHandler()](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.handlerequestcontext-1.skiphandler)

    [HandleRequestContext<McpAuthenticationOptions>.Result](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.handlerequestcontext-1.result)

    [BaseContext<McpAuthenticationOptions>.Scheme](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.basecontext-1.scheme)

    [BaseContext<McpAuthenticationOptions>.Options](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.basecontext-1.options)

    [BaseContext<McpAuthenticationOptions>.HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.basecontext-1.httpcontext)

    [BaseContext<McpAuthenticationOptions>.Request](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.basecontext-1.request)

    [BaseContext<McpAuthenticationOptions>.Response](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.basecontext-1.response)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### ResourceMetadataRequestContext(HttpContext, AuthenticationScheme, McpAuthenticationOptions)

Initializes a new instance of the [ResourceMetadataRequestContext](ModelContextProtocol.AspNetCore.Authentication.ResourceMetadataRequestContext.html) class.

```
public ResourceMetadataRequestContext(HttpContext context, AuthenticationScheme scheme, McpAuthenticationOptions options)
```

#### Parameters

`context` [HttpContext](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext)
:   The HTTP context.

`scheme` [AuthenticationScheme](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.authentication.authenticationscheme)
:   The authentication scheme.

`options` [McpAuthenticationOptions](ModelContextProtocol.AspNetCore.Authentication.McpAuthenticationOptions.html)
:   The authentication options.

## Properties

### ResourceMetadata

Gets or sets the protected resource metadata for the current request.

```
public ProtectedResourceMetadata? ResourceMetadata { get; set; }
```

#### Property Value

[ProtectedResourceMetadata](ModelContextProtocol.Authentication.ProtectedResourceMetadata.html)




