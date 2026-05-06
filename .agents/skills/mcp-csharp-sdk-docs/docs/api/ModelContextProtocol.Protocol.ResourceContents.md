
##### Table of Contents

# Class ResourceContents

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a base class representing contents of a resource in the Model Context Protocol.

```
[JsonConverter(typeof(ResourceContents.Converter))]
public abstract class ResourceContents
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ResourceContents

Derived
:   [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html)

    [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToAIContent(ResourceContents)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ResourceContents_)

## Remarks

[ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html) serves as the base class for different types of resources that can be
exchanged through the Model Context Protocol. Resources are identified by URIs and can contain
different types of data.

This class is abstract and has two concrete implementations:

* [TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html) - For text-based resources
* [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) - For binary data resources

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for more details.

## Properties

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
[JsonPropertyName("_meta")]
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

Implementations must not make assumptions about its contents.

### MimeType

Gets or sets the MIME type of the resource content.

```
[JsonPropertyName("mimeType")]
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Uri

Gets or sets the URI of the resource.

```
[JsonPropertyName("uri")]
[StringSyntax("Uri")]
public required string Uri { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




