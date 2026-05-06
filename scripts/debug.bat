chcp 65001
pushd %~dp0..
dotnet build -c Debug filereader-mcp-server\filereader-mcp-server.csproj
npx -y @modelcontextprotocol/inspector filereader-mcp-server\bin\Debug\net10.0\filereader-mcp-server.exe