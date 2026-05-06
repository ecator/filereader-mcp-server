
##### Table of Contents

# Class McpServerResourceCreateOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Server](ModelContextProtocol.Server.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides options for controlling the creation of an [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public sealed class McpServerResourceCreateOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    McpServerResourceCreateOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

These options allow for customizing the behavior and metadata of resources created with
McpServerResource.Create. They provide control over naming, description,
and dependency injection integration.

When creating resources programmatically rather than using attributes, these options
provide the same level of configuration flexibility.

## Properties

### Description

Gets or sets the description to use for the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public string? Description { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but a [DescriptionAttribute](https://learn.microsoft.com/dotnet/api/system.componentmodel.descriptionattribute) is applied to the member,
the description from that attribute is used.

### Icons

Gets or sets the icons for this resource.

```
public IList<Icon>? Icons { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[Icon](ModelContextProtocol.Protocol.Icon.html)>

#### Remarks

This property can be used by clients to display the resource's icon in a user interface.

### Meta

Gets or sets metadata reserved by MCP for protocol-level metadata.

```
public JsonObject? Meta { get; set; }
```

#### Property Value

[JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject)

#### Remarks

This [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) is used to seed the [Meta](ModelContextProtocol.Protocol.Resource.html#ModelContextProtocol_Protocol_Resource_Meta) property. Any metadata from
[McpMetaAttribute](ModelContextProtocol.Server.McpMetaAttribute.html) instances on the method will be added to this object, but
properties already present in this [JsonObject](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonobject) are not overwritten.

Implementations must not make assumptions about its contents.

### Metadata

Gets or sets the metadata associated with the resource.

```
public IReadOnlyList<object>? Metadata { get; set; }
```

#### Property Value

[IReadOnlyList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1)<[object](https://learn.microsoft.com/dotnet/api/system.object)>

#### Remarks

Metadata includes information such as attributes extracted from the method and its declaring class.
If not provided, metadata will be automatically generated for methods created via reflection.

### MimeType

Gets or sets the MIME (media) type of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public string? MimeType { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Name

Gets or sets the name to use for the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but an [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html) is applied to the member,
the name from the attribute is used. If that's not present, a name based on the member's name is used.

### SchemaCreateOptions

Gets or sets the JSON schema options when creating Microsoft.Extensions.AI.AIFunction from a method.

```
public AIJsonSchemaCreateOptions? SchemaCreateOptions { get; set; }
```

#### Property Value

AIJsonSchemaCreateOptions
:   The default is Microsoft.Extensions.AI.AIJsonSchemaCreateOptions.Default.

### SerializerOptions

Gets or sets the JSON serializer options to use when marshalling data to/from JSON.

```
public JsonSerializerOptions? SerializerOptions { get; set; }
```

#### Property Value

[JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)
:   The default is [DefaultOptions](ModelContextProtocol.McpJsonUtilities.html#ModelContextProtocol_McpJsonUtilities_DefaultOptions).

### Services

Gets or sets optional services used in the construction of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public IServiceProvider? Services { get; set; }
```

#### Property Value

[IServiceProvider](https://learn.microsoft.com/dotnet/api/system.iserviceprovider)

#### Remarks

These services will be used to determine which parameters should be satisfied from dependency injection. As such,
what services are satisfied via this provider should match what's satisfied via the provider passed in at invocation time.

### Title

Gets or sets the title to use for the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public string? Title { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### UriTemplate

Gets or sets the URI template of the [McpServerResource](ModelContextProtocol.Server.McpServerResource.html).

```
public string? UriTemplate { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Remarks

If [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), but an [McpServerResourceAttribute](ModelContextProtocol.Server.McpServerResourceAttribute.html) is applied to the member,
the [UriTemplate](ModelContextProtocol.Server.McpServerResourceAttribute.html#ModelContextProtocol_Server_McpServerResourceAttribute_UriTemplate) from the attribute is used. If that's not present,
a URI template will be inferred from the member's signature.




