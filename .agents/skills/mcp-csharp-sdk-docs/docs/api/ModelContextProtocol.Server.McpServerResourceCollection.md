
##### Table of Contents

# Class McpServerResourceCollection

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides a thread-safe collection of [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances, indexed by their URI templates.

```
public sealed class McpServerResourceCollection : McpServerPrimitiveCollection<McpServerResource>, ICollection<McpServerResource>, IReadOnlyCollection<McpServerResource>, IEnumerable<McpServerResource>, IEnumerable
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [McpServerPrimitiveCollection](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html)<[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)>

    McpServerResourceCollection

Implements
:   [ICollection](https://learn.microsoft.com/dotnet/api/system.collections.generic.icollection-1)<[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)>

    [IReadOnlyCollection](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlycollection-1)<[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)>

    [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)<[McpServerResource](ModelContextProtocol.Server.McpServerResource.html)>

    [IEnumerable](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable)

Inherited Members
:   [McpServerPrimitiveCollection<McpServerResource>.Changed](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Changed)

    [McpServerPrimitiveCollection<McpServerResource>.Count](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Count)

    [McpServerPrimitiveCollection<McpServerResource>.IsEmpty](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_IsEmpty)

    [McpServerPrimitiveCollection<McpServerResource>.this[string]](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Item_System_String_)

    [McpServerPrimitiveCollection<McpServerResource>.Clear()](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Clear)

    [McpServerPrimitiveCollection<McpServerResource>.Add(McpServerResource)](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Add__0_)

    [McpServerPrimitiveCollection<McpServerResource>.TryAdd(McpServerResource)](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_TryAdd__0_)

    [McpServerPrimitiveCollection<McpServerResource>.Remove(McpServerResource)](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Remove__0_)

    [McpServerPrimitiveCollection<McpServerResource>.TryGetPrimitive(string, out McpServerResource)](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_TryGetPrimitive_System_String__0__)

    [McpServerPrimitiveCollection<McpServerResource>.Contains(McpServerResource)](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_Contains__0_)

    [McpServerPrimitiveCollection<McpServerResource>.PrimitiveNames](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_PrimitiveNames)

    [McpServerPrimitiveCollection<McpServerResource>.ToArray()](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_ToArray)

    [McpServerPrimitiveCollection<McpServerResource>.CopyTo(McpServerResource[], int)](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_CopyTo__0___System_Int32_)

    [McpServerPrimitiveCollection<McpServerResource>.GetEnumerator()](ModelContextProtocol.Server.McpServerPrimitiveCollection-1.html#ModelContextProtocol_Server_McpServerPrimitiveCollection_1_GetEnumerator)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### McpServerResourceCollection()

Provides a thread-safe collection of [McpServerResource](ModelContextProtocol.Server.McpServerResource.html) instances, indexed by their URI templates.

```
public McpServerResourceCollection()
```




