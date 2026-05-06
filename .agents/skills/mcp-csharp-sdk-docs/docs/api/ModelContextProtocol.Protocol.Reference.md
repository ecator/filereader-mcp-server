
##### Table of Contents

# Class Reference

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a reference to a resource or prompt in the Model Context Protocol.

```
[JsonConverter(typeof(Reference.Converter))]
public abstract class Reference
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    Reference

Derived
:   [PromptReference](ModelContextProtocol.Protocol.PromptReference.html)

    [ResourceTemplateReference](ModelContextProtocol.Protocol.ResourceTemplateReference.html)

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

References are commonly used with [CompleteAsync(Reference, string, string, RequestOptions?, CancellationToken)](ModelContextProtocol.Client.McpClient.html#ModelContextProtocol_Client_McpClient_CompleteAsync_ModelContextProtocol_Protocol_Reference_System_String_System_String_ModelContextProtocol_RequestOptions_System_Threading_CancellationToken_)
to request completion suggestions for arguments, and with other methods that need to reference resources or prompts.

See the [schema](https://github.com/modelcontextprotocol/specification/blob/main/schema/) for details.

## Properties

### Type

When overridden in a derived class, gets the type of content.

```
[JsonPropertyName("type")]
public abstract string Type { get; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   "ref/resource" or "ref/prompt".




