
##### Table of Contents

# Class BlobResourceContents

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the binary contents of a resource in the Model Context Protocol.

```
public sealed class BlobResourceContents : ResourceContents
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html)

    BlobResourceContents

Inherited Members
:   [ResourceContents.Uri](ModelContextProtocol.Protocol.ResourceContents.html#ModelContextProtocol_Protocol_ResourceContents_Uri)

    [ResourceContents.MimeType](ModelContextProtocol.Protocol.ResourceContents.html#ModelContextProtocol_Protocol_ResourceContents_MimeType)

    [ResourceContents.Meta](ModelContextProtocol.Protocol.ResourceContents.html#ModelContextProtocol_Protocol_ResourceContents_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToAIContent(ResourceContents)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ResourceContents_)

## Remarks

[BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) is used when binary data needs to be exchanged through
the Model Context Protocol. The binary data is represented as base64-encoded UTF-8 bytes
in the [Blob](ModelContextProtocol.Protocol.BlobResourceContents.html#ModelContextProtocol_Protocol_BlobResourceContents_Blob) property.

This class inherits from [ResourceContents](ModelContextProtocol.Protocol.ResourceContents.html), which also has a sibling implementation
[TextResourceContents](ModelContextProtocol.Protocol.TextResourceContents.html) for text-based resources. When working with resources, the
appropriate type is chosen based on the nature of the content.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for more details.

## Constructors

### BlobResourceContents()

Initializes a new instance of the [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) class.

```
public BlobResourceContents()
```

## Properties

### Blob

Gets or sets the base64-encoded UTF-8 bytes representing the binary data of the item.

```
[JsonPropertyName("blob")]
public required ReadOnlyMemory<byte> Blob { get; set; }
```

#### Property Value

[ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>

#### Remarks

Setting this value will invalidate any cached value of [DecodedData](ModelContextProtocol.Protocol.BlobResourceContents.html#ModelContextProtocol_Protocol_BlobResourceContents_DecodedData).

### DecodedData

Gets the decoded data represented by [Blob](ModelContextProtocol.Protocol.BlobResourceContents.html#ModelContextProtocol_Protocol_BlobResourceContents_Blob).

```
[JsonIgnore]
public ReadOnlyMemory<byte> DecodedData { get; }
```

#### Property Value

[ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>

#### Remarks

When getting, this member will decode the value in [Blob](ModelContextProtocol.Protocol.BlobResourceContents.html#ModelContextProtocol_Protocol_BlobResourceContents_Blob) and cache the result.
Subsequent accesses return the cached value unless [Blob](ModelContextProtocol.Protocol.BlobResourceContents.html#ModelContextProtocol_Protocol_BlobResourceContents_Blob) is modified.

## Methods

### FromBytes(ReadOnlyMemory<byte>, string, string?)

Creates a [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) from raw data.

```
public static BlobResourceContents FromBytes(ReadOnlyMemory<byte> bytes, string uri, string? mimeType = null)
```

#### Parameters

`bytes` [ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>
:   The raw unencoded data.

`uri` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The URI of the blob resource.

`mimeType` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The optional MIME type of the data.

#### Returns

[BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html)
:   A new [BlobResourceContents](ModelContextProtocol.Protocol.BlobResourceContents.html) instance.




