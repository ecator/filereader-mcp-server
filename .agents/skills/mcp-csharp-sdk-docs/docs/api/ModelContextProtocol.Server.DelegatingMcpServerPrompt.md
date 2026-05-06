
##### Table of Contents

# Class DelegatingMcpServerPrompt

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html) that delegates all operations to an inner [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
public abstract class DelegatingMcpServerPrompt : McpServerPrompt, IMcpServerPrimitive
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)

    DelegatingMcpServerPrompt

Implements
:   [IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

Inherited Members
:   [McpServerPrompt.Create(Delegate, McpServerPromptCreateOptions)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_Create_System_Delegate_ModelContextProtocol_Server_McpServerPromptCreateOptions_)

    [McpServerPrompt.Create(MethodInfo, object, McpServerPromptCreateOptions)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_Create_System_Reflection_MethodInfo_System_Object_ModelContextProtocol_Server_McpServerPromptCreateOptions_)

    [McpServerPrompt.Create(MethodInfo, Func<RequestContext<GetPromptRequestParams>, object>, McpServerPromptCreateOptions)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_Create_System_Reflection_MethodInfo_System_Func_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_GetPromptRequestParams__System_Object__ModelContextProtocol_Server_McpServerPromptCreateOptions_)

    [McpServerPrompt.Create(AIFunction, McpServerPromptCreateOptions)](ModelContextProtocol.Server.McpServerPrompt.html#ModelContextProtocol_Server_McpServerPrompt_Create_Microsoft_Extensions_AI_AIFunction_ModelContextProtocol_Server_McpServerPromptCreateOptions_)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

This is recommended as a base type when building prompts that can be chained around an underlying [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).
The default implementation simply passes each call to the inner prompt instance.

## Constructors

### DelegatingMcpServerPrompt(McpServerPrompt)

Initializes a new instance of the [DelegatingMcpServerPrompt](ModelContextProtocol.Server.DelegatingMcpServerPrompt.html) class around the specified `innerPrompt`.

```
protected DelegatingMcpServerPrompt(McpServerPrompt innerPrompt)
```

#### Parameters

`innerPrompt` [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html)
:   The inner prompt wrapped by this delegating prompt.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `innerPrompt` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Metadata

Gets the metadata for this prompt instance.

```
public override IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.

### ProtocolPrompt

Gets the protocol [Prompt](ModelContextProtocol.Protocol.Prompt.html) type for this instance.

```
public override Prompt ProtocolPrompt { get; }
```

#### Property Value

[Prompt](ModelContextProtocol.Protocol.Prompt.html)

#### Remarks

The ProtocolPrompt property represents the underlying prompt definition as defined in the
Model Context Protocol specification. It contains metadata like the prompt's name,
description, and acceptable arguments.

## Methods

### GetAsync(RequestContext<GetPromptRequestParams>, CancellationToken)

Gets the prompt, rendering it with the provided request parameters and returning the prompt result.

```
public override ValueTask<GetPromptResult> GetAsync(RequestContext<GetPromptRequestParams> request, CancellationToken cancellationToken = default)
```

#### Parameters

`request` [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[GetPromptRequestParams](ModelContextProtocol.Protocol.GetPromptRequestParams.html)>
:   The request context containing information about the prompt invocation, including any arguments
    passed to the prompt. This object provides access to both the request parameters and the server context.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html)>
:   A [Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task) representing the asynchronous operation, containing a [GetPromptResult](ModelContextProtocol.Protocol.GetPromptResult.html) with
    the prompt content and messages.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `request` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

[InvalidOperationException](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception)
:   The prompt implementation returns [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null) or an unsupported result type.

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




