
##### Table of Contents

# Class CS1066Suppressor

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Analyzers](ModelContextProtocol.Analyzers.html)

Assembly
:   ModelContextProtocol.Analyzers.dll

Suppresses CS1066 warnings for MCP server methods that have optional parameters.

```
[DiagnosticAnalyzer("C#", new string[] { })]
public sealed class CS1066Suppressor : DiagnosticSuppressor
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [DiagnosticAnalyzer](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticanalyzer)

    [DiagnosticSuppressor](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticsuppressor)

    CS1066Suppressor

Inherited Members
:   [DiagnosticSuppressor.Initialize(AnalysisContext)](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticsuppressor.initialize)

    [DiagnosticSuppressor.SupportedDiagnostics](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticsuppressor.supporteddiagnostics)

    [DiagnosticAnalyzer.Equals(object)](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticanalyzer.equals)

    [DiagnosticAnalyzer.GetHashCode()](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticanalyzer.gethashcode)

    [DiagnosticAnalyzer.ToString()](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.diagnosticanalyzer.tostring)

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

CS1066 is issued when a partial method's implementing declaration has default parameter values.
For partial methods, only the defining declaration's defaults are used by callers,
making the implementing declaration's defaults redundant.

However, for MCP tool, prompt, and resource methods, users often want to specify default values
in their implementing declaration for documentation purposes. The XmlToDescriptionGenerator
automatically copies these defaults to the generated defining declaration, making them functional.

This suppressor suppresses CS1066 for methods marked with [McpServerTool], [McpServerPrompt],
or [McpServerResource] attributes, allowing users to specify defaults in their code without warnings.

## Properties

### SupportedSuppressions

Returns a set of descriptors for the suppressions that this suppressor is capable of producing.

```
public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions { get; }
```

#### Property Value

[ImmutableArray](https://learn.microsoft.com/dotnet/api/system.collections.immutable.immutablearray-1)<[SuppressionDescriptor](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.suppressiondescriptor)>

## Methods

### ReportSuppressions(SuppressionAnalysisContext)

Suppress analyzer and/or compiler non-error diagnostics reported for the compilation.
This may be a subset of the full set of reported diagnostics, as an optimization for
supporting incremental and partial analysis scenarios.
A diagnostic is considered suppressible by a DiagnosticSuppressor if *all* of the following conditions are met:
1. Diagnostic is not already suppressed in source via pragma/suppress message attribute.
2. Diagnostic's [DefaultSeverity](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostic.defaultseverity) is not [Error](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnosticseverity#microsoft-codeanalysis-diagnosticseverity-error).
3. Diagnostic is not tagged with [NotConfigurable](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.wellknowndiagnostictags.notconfigurable) custom tag.

```
public override void ReportSuppressions(SuppressionAnalysisContext context)
```

#### Parameters

`context` [SuppressionAnalysisContext](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.diagnostics.suppressionanalysiscontext)




