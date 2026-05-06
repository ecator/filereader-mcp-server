
##### Table of Contents

# Class McpAuthenticationEvents

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[AspNetCore](ModelContextProtocol.AspNetCore.html).[Authentication](ModelContextProtocol.AspNetCore.Authentication.html)

Assembly
:   ModelContextProtocol.AspNetCore.dll

Represents the authentication events for Model Context Protocol.

```
public class McpAuthenticationEvents
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpAuthenticationEvents

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### OnResourceMetadataRequest

Gets or sets the function that's invoked when resource metadata is requested.

```
public Func<ResourceMetadataRequestContext, Task> OnResourceMetadataRequest { get; set; }
```

#### Property Value

[Func](https://learn.microsoft.com/dotnet/api/system.func-2)<[ResourceMetadataRequestContext](ModelContextProtocol.AspNetCore.Authentication.ResourceMetadataRequestContext.html), [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)>

#### Remarks

This function is called when a resource metadata request is made to the protected resource metadata endpoint.
The implementer should set the [ResourceMetadata](ModelContextProtocol.AspNetCore.Authentication.ResourceMetadataRequestContext.html#ModelContextProtocol_AspNetCore_Authentication_ResourceMetadataRequestContext_ResourceMetadata) property
to provide the appropriate metadata for the current request.




