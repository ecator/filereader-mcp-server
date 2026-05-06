
##### Table of Contents

# Class Completion

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a completion object in the server's response to a [CompletionComplete](ModelContextProtocol.Protocol.RequestMethods.html#ModelContextProtocol_Protocol_RequestMethods_CompletionComplete) request.

```
public sealed class Completion
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Completion

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### HasMore

Gets or sets a value that indicates whether there are additional completion options beyond
those provided in the current response, even if the exact total is unknown.

```
[JsonPropertyName("hasMore")]
public bool? HasMore { get; set; }
```

#### Property Value

[bool](https://learn.microsoft.com/dotnet/api/system.boolean)?

### Total

Gets or sets the total number of completion options available.

```
[JsonPropertyName("total")]
public int? Total { get; set; }
```

#### Property Value

[int](https://learn.microsoft.com/dotnet/api/system.int32)?

#### Remarks

This value can exceed the number of values actually sent in the response.

### Values

Gets or sets an array of completion values (auto-suggestions) for the requested input.

```
[JsonPropertyName("values")]
public IList<string> Values { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

This collection contains the actual text strings to be presented to users as completion suggestions.
The array will be empty if no suggestions are available for the current input.
Per the specification, this collection should not exceed 100 items.




