
##### Table of Contents

# Class AudioContentBlock

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents audio provided to or from an LLM.

```
public sealed class AudioContentBlock : ContentBlock
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [ContentBlock](ModelContextProtocol.Protocol.ContentBlock.html)

    AudioContentBlock

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

### AudioContentBlock()

Initializes a new instance of the [AudioContentBlock](ModelContextProtocol.Protocol.AudioContentBlock.html) class.

```
public AudioContentBlock()
```

## Properties

### Data

Gets or sets the base64-encoded UTF-8 bytes representing the audio data.

```
[JsonPropertyName("data")]
public required ReadOnlyMemory<byte> Data { get; set; }
```

#### Property Value

[ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>

#### Remarks

Setting this value will invalidate any cached value of [DecodedData](ModelContextProtocol.Protocol.AudioContentBlock.html#ModelContextProtocol_Protocol_AudioContentBlock_DecodedData).

### DecodedData

Gets the decoded audio data represented by [Data](ModelContextProtocol.Protocol.AudioContentBlock.html#ModelContextProtocol_Protocol_AudioContentBlock_Data).

```
[JsonIgnore]
public ReadOnlyMemory<byte> DecodedData { get; }
```

#### Property Value

[ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>

#### Remarks

When getting, this member will decode the value in [Data](ModelContextProtocol.Protocol.AudioContentBlock.html#ModelContextProtocol_Protocol_AudioContentBlock_Data) and cache the result.
Subsequent accesses return the cached value unless [Data](ModelContextProtocol.Protocol.AudioContentBlock.html#ModelContextProtocol_Protocol_AudioContentBlock_Data) is modified.

### MimeType

Gets or sets the MIME type (or "media type") of the content, specifying the format of the data.

```
[JsonPropertyName("mimeType")]
public required string MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

Common values include "audio/wav" and "audio/mp3".

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

Creates an [AudioContentBlock](ModelContextProtocol.Protocol.AudioContentBlock.html) from decoded audio bytes.

```
public static AudioContentBlock FromBytes(ReadOnlyMemory<byte> bytes, string mimeType)
```

#### Parameters

`bytes` [ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[byte](https://learn.microsoft.com/dotnet/api/system.byte)>
:   The unencoded audio bytes.

`mimeType` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The MIME type of the audio.

#### Returns

[AudioContentBlock](ModelContextProtocol.Protocol.AudioContentBlock.html)
:   A new [AudioContentBlock](ModelContextProtocol.Protocol.AudioContentBlock.html) instance.

#### Remarks

This method stores the provided bytes as [DecodedData](ModelContextProtocol.Protocol.AudioContentBlock.html#ModelContextProtocol_Protocol_AudioContentBlock_DecodedData) and lazily encodes them to base64 UTF-8 bytes for [Data](ModelContextProtocol.Protocol.AudioContentBlock.html#ModelContextProtocol_Protocol_AudioContentBlock_Data).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `mimeType` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   `mimeType` is empty or composed entirely of whitespace.




