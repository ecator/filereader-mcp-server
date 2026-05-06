
##### Table of Contents

# Enum Role

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Protocol](ModelContextProtocol.Protocol.html)

Assembly
:   ModelContextProtocol.Core.dll

Represents the type of role in the Model Context Protocol conversation.

```
[JsonConverter(typeof(JsonStringEnumConverter<Role>))]
public enum Role
```

## Fields

`[JsonStringEnumMemberName("assistant")] Assistant = 1`
:   Corresponds to the AI assistant in the conversation.

`[JsonStringEnumMemberName("user")] User = 0`
:   Corresponds to a human user in the conversation.




