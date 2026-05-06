
##### Table of Contents

# Struct ProgressToken

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a progress token, which can be either a string or an integer.

```
[JsonConverter(typeof(ProgressToken.Converter))]
public readonly struct ProgressToken : IEquatable<ProgressToken>
```

Implements
:   [IEquatable](https://learn.microsoft.com/dotnet/api/system.iequatable-1)<[ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)>

Inherited Members
:   [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Constructors

### ProgressToken(long)

Initializes a new instance of the [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html) with a specified value.

```
public ProgressToken(long value)
```

#### Parameters

`value` [long](https://learn.microsoft.com/dotnet/api/system.int64)
:   The required ID value.

### ProgressToken(string)

Initializes a new instance of the [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html) with a specified value.

```
public ProgressToken(string value)
```

#### Parameters

`value` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The required ID value.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `value` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Token

Gets the underlying object for this token.

```
public object? Token { get; }
```

#### Property Value

[object](https://learn.microsoft.com/dotnet/api/system.object)

#### Remarks

This will either be a [string](https://learn.microsoft.com/dotnet/api/system.string), a boxed [long](https://learn.microsoft.com/dotnet/api/system.int64), or [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Methods

### Equals(ProgressToken)

Indicates whether the current object is equal to another object of the same type.

```
public bool Equals(ProgressToken other)
```

#### Parameters

`other` [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)
:   An object to compare with this object.

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the current object is equal to the `other` parameter; otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### Equals(object?)

Indicates whether this instance and a specified object are equal.

```
public override bool Equals(object? obj)
```

#### Parameters

`obj` [object](https://learn.microsoft.com/dotnet/api/system.object)
:   The object to compare with the current instance.

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if `obj` and this instance are the same type and represent the same value; otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

### GetHashCode()

Returns the hash code for this instance.

```
public override int GetHashCode()
```

#### Returns

[int](https://learn.microsoft.com/dotnet/api/system.int32)
:   A 32-bit signed integer that is the hash code for this instance.

### ToString()

Returns the fully qualified type name of this instance.

```
public override string? ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   The fully qualified type name.

## Operators

### operator ==(ProgressToken, ProgressToken)

```
public static bool operator ==(ProgressToken left, ProgressToken right)
```

#### Parameters

`left` [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)

`right` [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### operator !=(ProgressToken, ProgressToken)

```
public static bool operator !=(ProgressToken left, ProgressToken right)
```

#### Parameters

`left` [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)

`right` [ProgressToken](ModelContextProtocol.Protocol.ProgressToken.html)

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)




