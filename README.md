[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Workflow Status](https://github.com/ecator/filereader-mcp-server/actions/workflows/build.yml/badge.svg)](https://github.com/ecator/filereader-mcp-server/releases)

[🇨🇳中文](https://www.readme-i18n.com/zh/ecator/filereader-mcp-server)
[🇯🇵日本語](https://www.readme-i18n.com/ja/ecator/filereader-mcp-server)
[🇰🇷한국어](https://www.readme-i18n.com/ko/ecator/filereader-mcp-server)
[🇩🇪Deutsch](https://www.readme-i18n.com/de/ecator/filereader-mcp-server) 
[🇪🇸Español](https://www.readme-i18n.com/es/ecator/filereader-mcp-server)
[🇫🇷français](https://www.readme-i18n.com/fr/ecator/filereader-mcp-server)
[🇵🇹Português](https://www.readme-i18n.com/pt/ecator/filereader-mcp-server)
[🇷🇺Русский](https://www.readme-i18n.com/ru/ecator/filereader-mcp-server)

# Overview

The MCP Server for search/read Excel, Word, PowerPoint, PDF, md/txt files.

You must install Office 2016 and later versions to use this MCP server.

# Use

[Download the latest version](https://github.com/ecator/filereader-mcp-server/releases) and extract it to any location.

Then add the following configuration to the MCP servers configuration.

```json
{
  "mcpServers": {
    "filereader": {
      "command": "DRIVER:\\PATH\\TO\\filereader-mcp-server.exe",
      "args": ["path1", "path2", "path3", "..."],
      "env": {}
    }
  }
}
```

Please refer to the following if you are using [Codex](https://github.com/openai/codex/blob/main/docs/config.md#mcp-integration).

> `%USERPROFILE%\.codex\config.toml`

```toml
[mcp_servers.filereader]
command = 'cmd'
args = [
    "/c",
    'DRIVER:\PATH\TO\filereader-mcp-server.exe',
    'path1','path2','path3', '...',
]
env = { SystemRoot = 'C:\Windows' }
startup_timeout_sec = 300
tool_timeout_sec = 300
enabled = true
```

> **Note that this is only supported on Windows with Office 2016 (64-bit version) or above installed!**

# Tools

//TODO