
##### Table of Contents

# Class ProgressNotificationValue

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a progress value that can be sent using [IProgress<T>](https://learn.microsoft.com/dotnet/api/system.iprogress-1).

```
public sealed class ProgressNotificationValue
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ProgressNotificationValue

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Message

Gets or initializes an optional message describing the current progress.

```
public string? Message { get; init; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Progress

Gets or initializes the progress thus far.

```
public required float Progress { get; init; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)

#### Remarks

This value typically represents either a percentage (0-100) or the number of items processed so far (when used with the [Total](ModelContextProtocol.ProgressNotificationValue.html#ModelContextProtocol_ProgressNotificationValue_Total) property).

When reporting progress, this value should increase monotonically as the operation proceeds.
Values are typically between 0 and 100 when representing percentages, or can be any positive number
when representing completed items in combination with the [Total](ModelContextProtocol.ProgressNotificationValue.html#ModelContextProtocol_ProgressNotificationValue_Total) property.

### Total

Gets or initializes the total number of items to process (or total progress required), if known.

```
public float? Total { get; init; }
```

#### Property Value

[float](https://learn.microsoft.com/dotnet/api/system.single)?




