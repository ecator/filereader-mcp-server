using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace FileReaderMcpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.Error.WriteLine("Error: At least one folder path must be provided as an argument.");
                Environment.Exit(1);
            }

            foreach (var arg in args)
            {
                if (!System.IO.Directory.Exists(arg))
                {
                    Console.Error.WriteLine($"Error: The directory does not exist: {arg}");
                    Environment.Exit(1);
                }
                var d = Path.GetFullPath(arg).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                GlobalState.AllowedDirectories.Add(d);

            }

            var langEnvRaw = Environment.GetEnvironmentVariable("LANGUAGE");
            if (string.IsNullOrWhiteSpace(langEnvRaw))
            {
                GlobalState.Language = "en";
            }
            else
            {
                var langEnv = langEnvRaw.ToLowerInvariant();
                if (GlobalState.ALLOWED_LANGUAGE.Contains(langEnv))
                {
                    GlobalState.Language = langEnv;
                }
                else
                {
                    Console.Error.WriteLine($"Error: Unsupported LANGUAGE environment variable value '{langEnvRaw}'. Allowed values are {string.Join(",",GlobalState.ALLOWED_LANGUAGE)}.");
                    Environment.Exit(1);
                }
            }

            var timeoutEnvRaw = Environment.GetEnvironmentVariable("TIMEOUT");
            if (!string.IsNullOrWhiteSpace(timeoutEnvRaw))
            {
                if (int.TryParse(timeoutEnvRaw, out int timeoutVal) && timeoutVal > 0)
                {
                    GlobalState.Timeout = timeoutVal;
                }
                else
                {
                    Console.Error.WriteLine($"Warning: Invalid TIMEOUT value '{timeoutEnvRaw}'. Must be a positive integer. Using default ({GlobalState.Timeout}s).");
                }
            }

            var excludeEnvRaw = Environment.GetEnvironmentVariable("EXCLUDE");
            if (!string.IsNullOrWhiteSpace(excludeEnvRaw))
            {
                GlobalState.ExcludePattern = new Regex(
                    excludeEnvRaw,
                    RegexOptions.IgnoreCase | RegexOptions.Compiled
                );
            }

            var builder = Host.CreateApplicationBuilder(args);
            builder.Logging.AddConsole(consoleLogOptions =>
            {
                // Configure all logs to go to stderr
                consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
            });

            builder.Services
                .AddMcpServer(options =>
                {
                    options.ServerInstructions = "Windows MCP Server for search/read Office/PDF/Text files";
                })
                .WithStdioServerTransport()
                .WithToolsFromAssembly()
                .WithListResourcesHandler(async (ctx, ct) =>
                {
                    return new ListResourcesResult
                    {
                        Resources = []
                    };
                })
                .WithListPromptsHandler(async (request, cancellationToken) =>
                {
                    return new()
                    {
                        NextCursor = null,
                        Prompts = [],
                    };
                });
            builder.Build().Run();
        }
    }
}
