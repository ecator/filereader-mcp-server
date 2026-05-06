
##### Table of Contents

# Class XmlToDescriptionGenerator

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Analyzers](ModelContextProtocol.Analyzers.html)

Assembly
:   ModelContextProtocol.Analyzers.dll

Source generator that creates [Description] attributes from XML comments
for partial methods tagged with MCP attributes.

```
[Generator]
public sealed class XmlToDescriptionGenerator : IIncrementalGenerator
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    XmlToDescriptionGenerator

Implements
:   [IIncrementalGenerator](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.iincrementalgenerator)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### Initialize(IncrementalGeneratorInitializationContext)

Called to initialize the generator and register generation steps via callbacks
on the `context`

```
public void Initialize(IncrementalGeneratorInitializationContext context)
```

#### Parameters

`context` [IncrementalGeneratorInitializationContext](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.incrementalgeneratorinitializationcontext)
:   The [IncrementalGeneratorInitializationContext](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.incrementalgeneratorinitializationcontext) to register callbacks on




