
##### Table of Contents

# Class StdioClientTransportOptions

Namespace
:   [ModelContextProtocol](ModelContextProtocol.html).[Client](ModelContextProtocol.Client.html)

Assembly
:   ModelContextProtocol.Core.dll

Provides options for configuring [StdioClientTransport](ModelContextProtocol.Client.StdioClientTransport.html) instances.

```
public sealed class StdioClientTransportOptions
```

Inheritance
:   [object](https://learn.microsoft.com/dotnet/api/system.object)

    StdioClientTransportOptions

Inherited Members
:   [object.Equals(object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object))

    [object.Equals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object-system-object))

    [object.GetHashCode()](https://learn.microsoft.com/dotnet/api/system.object.gethashcode)

    [object.GetType()](https://learn.microsoft.com/dotnet/api/system.object.gettype)

    [object.ReferenceEquals(object, object)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals)

    [object.ToString()](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### Arguments

Gets or sets the arguments to pass to the server process when it is started.

```
public IList<string>? Arguments { get; set; }
```

#### Property Value

[IList](https://learn.microsoft.com/dotnet/api/system.collections.generic.ilist-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### Command

Gets or sets the command to execute to start the server process.

```
public required string Command { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

#### Exceptions

[ArgumentException](https://learn.microsoft.com/dotnet/api/system.argumentexception)
:   The value is [null](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/null), empty, or composed entirely of whitespace.

### EnvironmentVariables

Gets or sets environment variables to set for the server process.

```
public IDictionary<string, string?>? EnvironmentVariables { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[string](https://learn.microsoft.com/dotnet/api/system.string), [string](https://learn.microsoft.com/dotnet/api/system.string)>

#### Remarks

This property allows you to specify environment variables that will be set in the server process's
environment. Setting these variables is useful for passing configuration, authentication information, or runtime flags
to the server without modifying its code.

By default, when starting the server process, the server process will inherit the current environment's variables,
as discovered via [GetEnvironmentVariables()](https://learn.microsoft.com/dotnet/api/system.environment.getenvironmentvariables#system-environment-getenvironmentvariables). After those variables are found, the entries
in this [EnvironmentVariables](ModelContextProtocol.Client.StdioClientTransportOptions.html#ModelContextProtocol_Client_StdioClientTransportOptions_EnvironmentVariables) dictionary are used to augment and overwrite the entries read from the environment.
That includes removing the variables for any of this collection's entries with a null value.

### Name

Gets or sets a transport identifier used for logging purposes.

```
public string? Name { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)

### ShutdownTimeout

Gets or sets the timeout to wait for the server to shut down gracefully.

```
public TimeSpan ShutdownTimeout { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)
:   The amount of time to wait for the server to shut down gracefully. The default is 5 seconds.

#### Remarks

This property dictates how long the client should wait for the server process to exit cleanly during shutdown
before forcibly terminating it. This balances giving the server enough time to clean up
resources and not hanging indefinitely if a server process becomes unresponsive.

### StandardErrorLines

Gets or sets a callback that is invoked for each line of stderr received from the server process.

```
public Action<string>? StandardErrorLines { get; set; }
```

#### Property Value

[Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[string](https://learn.microsoft.com/dotnet/api/system.string)>

### WorkingDirectory

Gets or sets the working directory for the server process.

```
public string? WorkingDirectory { get; set; }
```

#### Property Value

[string](https://learn.microsoft.com/dotnet/api/system.string)




