
##### Table of Contents

# Class ElicitationCapability

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the capability for a client to provide server-requested additional information during interactions.

```
[JsonConverter(typeof(ElicitationCapability.Converter))]
public sealed class ElicitationCapability
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    ElicitationCapability

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

This capability enables the MCP client to respond to elicitation requests from an MCP server.
Clients must support at least one elicitation mode: form (in-band) or url (out-of-band via URL).

When this capability is enabled, an MCP server can request the client to provide additional information
during interactions. The client must set a [ElicitationHandler](ModelContextProtocol.Client.McpClientHandlers.html#ModelContextProtocol_Client_McpClientHandlers_ElicitationHandler) to process these requests.

Two modes of elicitation are supported:

* **form**: In-band elicitation where data is collected via a form and exposed to the client
* **url**: URL mode (out-of-band) elicitation via navigation where sensitive data is not exposed to the client

## Properties

### Form

Gets or sets the form mode elicitation (in-band) capability, indicating support for in-band elicitation.

```
[JsonPropertyName("form")]
public FormElicitationCapability? Form { get; set; }
```

#### Property Value

[FormElicitationCapability](ModelContextProtocol.Protocol.FormElicitationCapability.html)

#### Remarks

When present, indicates the client supports form mode elicitation where structured data
is collected through a form interface and returned to the server.

### Url

Gets or sets the URL mode (out-of-band) elicitation capability.

```
[JsonPropertyName("url")]
public UrlElicitationCapability? Url { get; set; }
```

#### Property Value

[UrlElicitationCapability](ModelContextProtocol.Protocol.UrlElicitationCapability.html)

#### Remarks

When present, indicates the client supports URL mode elicitation for secure out-of-band
interactions such as OAuth flows, payments, or collecting sensitive credentials.




