
##### Table of Contents

# Class McpServerPromptCreateOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides options for controlling the creation of an [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
public sealed class McpServerPromptCreateOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerPromptCreateOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

These options allow for customizing the behavior and metadata of prompts created with
McpServerPrompt.Create. They provide control over naming, description,
and dependency injection integration.

When creating prompts programmatically rather than using attributes, these options
provide the same level of configuration flexibility.

## Properties

### Description

Gets or sets the description to use for the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but a [DescriptionAttribute](https://learn.microsoft.com/dotnet/api/system.componentmodel.descriptionattribute) is applied to the method,
the description from that attribute is used.

### Icons

Gets or sets the icons for this prompt.

```
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This property can be used by clients to display the prompt's icon in a user interface.

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

This [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) is used to seed the [Meta](ModelContextProtocol.Protocol.Prompt.html#ModelContextProtocol_Protocol_Prompt_Meta) property. Any metadata from
[McpMetaAttribute](ModelContextProtocol.Server.McpMetaAttribute.html) instances on the method will be added to this object, but
properties already present in this [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) will not be overwritten.

Implementations must not make assumptions about its contents.

### Metadata

Gets or sets the metadata associated with the prompt.

```
public IReadOnlyList<object>? Metadata { get; set; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Metadata includes information such as the attributes extracted from the method and its declaring class.
If not provided, metadata will be automatically generated for methods created via reflection.

### Name

Gets or sets the name to use for the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but an [McpServerPromptAttribute](ModelContextProtocol.Server.McpServerPromptAttribute.html) is applied to the method,
the name from the attribute is used. If that's not present, a name based on the method's name is used.

### SchemaCreateOptions

Gets or sets the JSON schema options when creating an Microsoft.Extensions.AI.AIFunction from a method.

```
public AIJsonSchemaCreateOptions? SchemaCreateOptions { get; set; }
```

#### Property Value

AIJsonSchemaCreateOptions

#### Remarks

Defaults to Microsoft.Extensions.AI.AIJsonSchemaCreateOptions.Default if left unspecified.

### SerializerOptions

Gets or sets the JSON serializer options to use when marshalling data to/from JSON.

```
public JsonSerializerOptions? SerializerOptions { get; set; }
```

#### Property Value

[JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)

#### Remarks

Defaults to [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions) if left unspecified.

### Services

Gets or sets optional services used in the construction of the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
public IServiceProvider? Services { get; set; }
```

#### Property Value

[IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)

#### Remarks

These services will be used to determine which parameters should be satisfied from dependency injection. As such,
what services are satisfied via this provider should match what's satisfied via the provider passed in at invocation time.

### Title

Gets or sets the title to use for the [McpServerPrompt](ModelContextProtocol.Server.McpServerPrompt.html).

```
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




