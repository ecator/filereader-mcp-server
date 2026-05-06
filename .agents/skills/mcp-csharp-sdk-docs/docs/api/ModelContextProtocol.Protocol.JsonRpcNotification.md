
##### Table of Contents

# Class JsonRpcNotification

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents a notification message in the JSON-RPC protocol.

```
public sealed class JsonRpcNotification : JsonRpcMessage
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    [JsonRpcMessage](ModelContextProtocol.Protocol.JsonRpcMessage.html)

    JsonRpcNotification

Inherited Members
:   [JsonRpcMessage.JsonRpc](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_JsonRpc)

    [JsonRpcMessage.Context](ModelContextProtocol.Protocol.JsonRpcMessage.html#ModelContextProtocol_Protocol_JsonRpcMessage_Context)

    [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Remarks

Notifications are messages that do not require a response and are not matched with a response message.
They are useful for one-way communication, such as log notifications and progress updates.
Unlike requests, notifications do not include an ID field, since there will be no response to match with it.

## Properties

### Method

Gets or sets the name of the notification method.

```
[JsonPropertyName("method")]
public required string Method { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### Params

Gets or sets optional parameters for the notification.

```
[JsonPropertyName("params")]
public JsonNode? Params { get; set; }
```

#### Property Value

[JsonNode](https://learn.microsoft.com/dotnet/api/system.text.json.nodes.jsonnode)




