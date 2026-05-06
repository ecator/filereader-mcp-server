
##### Table of Contents

# Class ImageContentBlock

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents an image provided to or from an LLM.

```
public sealed class ImageContentBlock : ContentBlock
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)

    ImageContentBlock

Inherited Members
:   [ContentBlock.Annotations](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Annotations)

    [ContentBlock.Meta](ModelContextProtocol.Protocol.ContentBlock.html#ModelContextProtocol_Protocol_ContentBlock_Meta)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

Extension Methods
:   [AIContentExtensions.ToAIContent(ContentBlock, JsonSerializerOptions?)](ModelContextProtocol.AIContentExtensions.html#ModelContextProtocol_AIContentExtensions_ToAIContent_ModelContextProtocol_Protocol_ContentBlock_System_Text_Json_JsonSerializerOptions_)

## Constructors

### ImageContentBlock()

Initializes a new instance of the [ImageContentBlock](ModelContextProtocol.Protocol.ImageContentBlock.html) class.

```
public ImageContentBlock()
```

## Properties

### Data

Gets or sets the base64-encoded UTF-8 bytes representing the image data.

```
[JsonPropertyName("data")]
public required ReadOnlyMemory<byte> Data { get; set; }
```

#### Property Value

[ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>

#### Remarks

Setting this value will invalidate any cached value of [DecodedData](ModelContextProtocol.Protocol.ImageContentBlock.html#ModelContextProtocol_Protocol_ImageContentBlock_DecodedData).

### DecodedData

Gets the decoded image data represented by [Data](ModelContextProtocol.Protocol.ImageContentBlock.html#ModelContextProtocol_Protocol_ImageContentBlock_Data).

```
[JsonIgnore]
public ReadOnlyMemory<byte> DecodedData { get; }
```

#### Property Value

[ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>

#### Remarks

When getting, this member will decode the value in [Data](ModelContextProtocol.Protocol.ImageContentBlock.html#ModelContextProtocol_Protocol_ImageContentBlock_Data) and cache the result.
Subsequent accesses return the cached value unless [Data](ModelContextProtocol.Protocol.ImageContentBlock.html#ModelContextProtocol_Protocol_ImageContentBlock_Data) is modified.

### MimeType

Gets or sets the MIME type (or "media type") of the content, specifying the format of the data.

```
[JsonPropertyName("mimeType")]
public required string MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Common values include "image/png" and "image/jpeg".

### Type

When overridden in a derived class, gets the type of content.

```
public override string Type { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The type of content. Valid values include "image", "audio", "text", "resource", "resource\_link", "tool\_use", and "tool\_result".

#### Remarks

This value determines the structure of the content object.

## Methods

### FromBytes(ReadOnlyMemory<byte>, string)

Creates an [ImageContentBlock](ModelContextProtocol.Protocol.ImageContentBlock.html) from decoded image bytes.

```
public static ImageContentBlock FromBytes(ReadOnlyMemory<byte> bytes, string mimeType)
```

#### Parameters

`bytes` [ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>
:   The unencoded image bytes.

`mimeType` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The MIME type of the image.

#### Returns

[ImageContentBlock](ModelContextProtocol.Protocol.ImageContentBlock.html)
:   A new [ImageContentBlock](ModelContextProtocol.Protocol.ImageContentBlock.html) instance.

#### Remarks

This method stores the provided bytes as [DecodedData](ModelContextProtocol.Protocol.ImageContentBlock.html#ModelContextProtocol_Protocol_ImageContentBlock_DecodedData) and lazily encodes them to base64 UTF-8 bytes for [Data](ModelContextProtocol.Protocol.ImageContentBlock.html#ModelContextProtocol_Protocol_ImageContentBlock_Data).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `mimeType` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `mimeType` is empty or composed entirely of whitespace.




