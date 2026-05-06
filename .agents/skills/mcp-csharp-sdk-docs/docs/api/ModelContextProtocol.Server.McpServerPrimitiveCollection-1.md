
##### Table of Contents

# Class McpServerPrimitiveCollection<T>

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a thread-safe collection of `T` instances, indexed by their names.

```
public class McpServerPrimitiveCollection<T> : ICollection<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable where T : IMcpServerPrimitive
```

#### Type Parameters

`T`
:   The type of primitive stored in the collection.

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerPrimitiveCollection<T>

Implements
:   [ICollection](https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1)<T>

    [IReadOnlyCollection](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlycollection-1)<T>

    [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<T>

    [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable)

Derived
:   [McpServerResourceCollection](ModelContextProtocol.Server.McpServerResourceCollection.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### McpServerPrimitiveCollection(IEqualityComparer<string>?)

Initializes a new instance of the [McpServerPrimitiveCollection<T>](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html) class.

```
public McpServerPrimitiveCollection(IEqualityComparer<string>? keyComparer = null)
```

#### Parameters

`keyComparer` [IEqualityComparer](https://learn.microsoft.com/dotnet/api/system.collections.generic.iequalitycomparer-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

## Properties

### Count

Gets the number of primitives in the collection.

```
public int Count { get; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)

### IsEmpty

Gets a value that indicates whether there are any primitives in the collection.

```
public bool IsEmpty { get; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### this[string]

Gets the `T` with the specified `name` from the collection.

```
public T this[string name] { get; }
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the primitive to retrieve.

#### Property Value

T
:   The `T` with the specified name.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `name` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[KeyNotFoundException](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception)
:   A primitive with the specified name does not exist in the collection.

### PrimitiveNames

Gets the names of all of the primitives in the collection.

```
public virtual ICollection<string> PrimitiveNames { get; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

## Methods

### Add(T)

Adds the specified `T` to the collection.

```
public void Add(T primitive)
```

#### Parameters

`primitive` T
:   The primitive to be added.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `primitive` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   A primitive with the same name as `primitive` already exists in the collection.

### Clear()

Clears all primitives from the collection.

```
public virtual void Clear()
```

### Contains(T)

Checks if a specific primitive is present in the collection of primitives.

```
public virtual bool Contains(T primitive)
```

#### Parameters

`primitive` T
:   The primitive to search for in the collection.

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the primitive was found in the collection and returned; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it wasn't found.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `primitive` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### CopyTo(T[], int)

Copies the elements of the [ICollection<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1) to an [Array](https://learn.microsoft.com/dotnet/api/system.array), starting at a particular [Array](https://learn.microsoft.com/dotnet/api/system.array) index.

```
public virtual void CopyTo(T[] array, int arrayIndex)
```

#### Parameters

`array` T[]
:   The one-dimensional [Array](https://learn.microsoft.com/dotnet/api/system.array) that is the destination of the elements copied from [ICollection<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1). The [Array](https://learn.microsoft.com/dotnet/api/system.array) must have zero-based indexing.

`arrayIndex` [int](https://learn.microsoft.com/dotnet/api/system.int32)
:   The zero-based index in `array` at which copying begins.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `array` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[ArgumentOutOfRangeException](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception)
:   `arrayIndex` is less than 0.

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   The number of elements in the source [ICollection<T>](https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1) is greater than the available space from `arrayIndex` to the end of the destination `array`.

### GetEnumerator()

```
public virtual IEnumerator<T> GetEnumerator()
```

#### Returns

[IEnumerator](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1)<T>

### RaiseChanged()

Raises [Changed](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Changed) if there are registered handlers.

```
protected void RaiseChanged()
```

### Remove(T)

Removes the specified primitive from the collection.

```
public virtual bool Remove(T primitive)
```

#### Parameters

`primitive` T
:   The primitive to be removed from the collection.

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the primitive was found in the collection and removed; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it wasn't found.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `primitive` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToArray()

Creates an array containing all of the primitives in the collection.

```
public virtual T[] ToArray()
```

#### Returns

T[]
:   An array containing all of the primitives in the collection.

### TryAdd(T)

Adds the specified `T` to the collection.

```
public virtual bool TryAdd(T primitive)
```

#### Parameters

`primitive` T
:   The primitive to be added.

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the primitive was added; otherwise, [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool).

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `primitive` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### TryGetPrimitive(string, out T?)

Attempts to get the primitive with the specified name from the collection.

```
public virtual bool TryGetPrimitive(string name, out T? primitive)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)
:   The name of the primitive to retrieve.

`primitive` T
:   The primitive, if found; otherwise, [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

#### Returns

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)
:   [true](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if the primitive was found in the collection and returned; [false](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool) if it wasn't found.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `name` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Events

### Changed

Occurs when the collection is changed.

```
public event EventHandler? Changed
```

#### Event Type

[EventHandler](https://learn.microsoft.com/dotnet/api/system.eventhandler)

#### Remarks

By default, this event is raised when a primitive is added or removed. However, a derived implementation
might raise this event for other reasons, such as when a primitive is modified.




