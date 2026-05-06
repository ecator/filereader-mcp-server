
##### Table of Contents

# Class TokenContainer

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Authentication](ModelContextProtocol.Authentication.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a cacheable combination of tokens ready to be used for authentication.

```
public sealed class TokenContainer
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    TokenContainer

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### AccessToken

Gets or sets the access token.

```
public required string AccessToken { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ExpiresIn

Gets or sets the number of seconds until the access token expires.

```
public int? ExpiresIn { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

### ObtainedAt

Gets or sets the timestamp when the token was obtained.

```
public required DateTimeOffset ObtainedAt { get; set; }
```

#### Property Value

[DateTimeOffset](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

### RefreshToken

Gets or sets the refresh token.

```
public string? RefreshToken { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Scope

Gets or sets the scope of the access token.

```
public string? Scope { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### TokenType

Gets or sets the token type (typically "Bearer").

```
public required string TokenType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




