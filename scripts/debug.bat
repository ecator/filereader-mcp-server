chcp 65001
pushd %~dp0..
dotnet build -c Debug src\FileReaderMcpServer\FileReaderMcpServer.csproj
npx -y @modelcontextprotocol/inspector -e LANGUAGE=zh src\FileReaderMcpServer\bin\Debug\net10.0\filereader-mcp-server.exe