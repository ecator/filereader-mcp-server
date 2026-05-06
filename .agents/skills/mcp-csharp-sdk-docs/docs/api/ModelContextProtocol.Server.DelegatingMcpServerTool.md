
##### Table of Contents

# Class DelegatingMcpServerTool

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides an [McpServerTool](ModelContextProtocol.Server.McpServerTool.html) that delegates all operations to an inner [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public abstract class DelegatingMcpServerTool : McpServerTool, IMcpServerPrimitive
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)

    DelegatingMcpServerTool

Implements
:   [IMcpServerPrimitive](ModelContextProtocol.Server.IMcpServerPrimitive.html)

Inherited Members
:   [McpServerTool.Create(Delegate, McpServerToolCreateOptions)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_Create_System_Delegate_ModelContextProtocol_Server_McpServerToolCreateOptions_)

    [McpServerTool.Create(MethodInfo, object, McpServerToolCreateOptions)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_Create_System_Reflection_MethodInfo_System_Object_ModelContextProtocol_Server_McpServerToolCreateOptions_)

    [McpServerTool.Create(MethodInfo, Func<RequestContext<CallToolRequestParams>, object>, McpServerToolCreateOptions)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_Create_System_Reflection_MethodInfo_System_Func_ModelContextProtocol_Server_RequestContext_ModelContextProtocol_Protocol_CallToolRequestParams__System_Object__ModelContextProtocol_Server_McpServerToolCreateOptions_)

    [McpServerTool.Create(AIFunction, McpServerToolCreateOptions)](ModelContextProtocol.Server.McpServerTool.html#ModelContextProtocol_Server_McpServerTool_Create_Microsoft_Extensions_AI_AIFunction_ModelContextProtocol_Server_McpServerToolCreateOptions_)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.MemberwiseClone()](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

## Remarks

This is recommended as a base type when building tools that can be chained around an underlying [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).
The default implementation simply passes each call to the inner tool instance.

## Constructors

### DelegatingMcpServerTool(McpServerTool)

Initializes a new instance of the [DelegatingMcpServerTool](ModelContextProtocol.Server.DelegatingMcpServerTool.html) class around the specified `innerTool`.

```
protected DelegatingMcpServerTool(McpServerTool innerTool)
```

#### Parameters

`innerTool` [McpServerTool](ModelContextProtocol.Server.McpServerTool.html)
:   The inner tool wrapped by this delegating tool.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `innerTool` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

## Properties

### Metadata

Gets the metadata for this tool instance.

```
public override IReadOnlyList<object> Metadata { get; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Contains attributes from the associated MethodInfo and declaring class (if any),
with class-level attributes appearing before method-level attributes.

### ProtocolTool

Gets the protocol [Tool](ModelContextProtocol.Protocol.Tool.html) type for this instance.

```
public override Tool ProtocolTool { get; }
```

#### Property Value

[Tool](ModelContextProtocol.Protocol.Tool.html)

## Methods

### InvokeAsync(RequestContext<CallToolRequestParams>, CancellationToken)

Invokes the [McpServerTool](ModelContextProtocol.Server.McpServerTool.html).

```
public override ValueTask<CallToolResult> InvokeAsync(RequestContext<CallToolRequestParams> request, CancellationToken cancellationToken = default)
```

#### Parameters

`request` [RequestContext](ModelContextProtocol.Server.RequestContext-1.html)<[CallToolRequestParams](ModelContextProtocol.Protocol.CallToolRequestParams.html)>
:   The request information resulting in the invocation of this tool.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)
:   The [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) to monitor for cancellation requests. The default is [None](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken.none).

#### Returns

[ValueTask](https://learn.microsoft.com/dotnet/api/system.threading.tasks.valuetask-1)<[CallToolResult](ModelContextProtocol.Protocol.CallToolResult.html)>
:   The call response from invoking the tool.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)
:   `request` is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null).

### ToString()

Returns a string that represents the current object.

```
public override string ToString()
```

#### Returns

[string](https://learn.microsoft.com/dotnet/api/system.string)
:   A string that represents the current object.




