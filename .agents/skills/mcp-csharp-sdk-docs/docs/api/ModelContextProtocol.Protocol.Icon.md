
##### Table of Contents

# Class Icon

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an icon that can be used to visually identify an implementation, resource, tool, or prompt.

```
public sealed class Icon
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Icon

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Icons enhance user interfaces by providing visual context and improving the discoverability of available functionality.
Each icon includes a source URI pointing to the icon resource, and optional MIME type and size information.

Clients that support rendering icons MUST support at least the following MIME types:

* image/png - PNG images (safe, universal compatibility)
* image/jpeg (and image/jpg) - JPEG images (safe, universal compatibility)

Clients that support rendering icons SHOULD also support:

* image/svg+xml - SVG images (scalable but requires security precautions)
* image/webp - WebP images (modern, efficient format)

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### MimeType

Gets or sets the optional MIME type of the icon.

```
[JsonPropertyName("mimeType")]
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value can be used to override the server's MIME type if it's missing or generic.
Common values include "image/png", "image/jpeg", "image/svg+xml", and "image/webp".

### Sizes

Gets or sets the optional size specifications for the icon.

```
[JsonPropertyName("sizes")]
public IList<string>? Sizes { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

This property can specify one or more sizes at which the icon file can be used.
Examples include "48x48", "any" for scalable formats like SVG.

If not provided, clients should assume that the icon can be used at any size.

### Source

Gets or sets the URI pointing to the icon resource.

```
[JsonPropertyName("src")]
public required string Source { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

This value can be an HTTP/HTTPS URL pointing to an image file or a data URI with base64-encoded image data.

Consumers SHOULD take steps to ensure URLs serving icons are from the same domain as the client/server
or a trusted domain.

Consumers SHOULD take appropriate precautions when consuming SVGs as they can contain executable JavaScript.

### Theme

Gets or sets the optional theme for this icon.

```
[JsonPropertyName("theme")]
public string? Theme { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

[Theme](ModelContextProtocol.Protocol.Icon.html#ModelContextProtocol_Protocol_Icon_Theme) may be "light" or "dark". "light" indicates the icon is designed to be used with a light
background, and "dark" indicates the icon is designed to be used with a dark background.
If not provided, clients should assume the icon can be used with any theme.




