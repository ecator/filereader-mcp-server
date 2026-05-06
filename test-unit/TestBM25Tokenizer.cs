using FileReaderMcpServer.Search;

namespace TestUnit
{
    [TestClass]
    public sealed class TestBM25Tokenizer: TestBase
    {
        [TestMethod]
        public void TestTokenizerZh()
        {
            var content = @"
**模型上下文协议（Model Context Protocol，简称 MCP）** 是一项由 Anthropic 推出的开放标准，旨在解决 AI 模型（如 Claude、GPT-4 等）与外部数据源及工具之间“连接碎片化”的核心痛点。

您可以将 MCP 理解为 **AI 界的 USB 接口**。在 MCP 出现之前，如果你想让 AI 访问你的本地数据库、Google Drive 或 Slack，开发者必须为每一个数据源编写特定的、不可通用的集成代码；而 MCP 提供了一个统一的、标准化的通信协议。

---

## 1. 核心架构与工作原理

MCP 的架构基于一种简单的**客户机-服务器（Client-Server）模型**：

*   **MCP Host（宿主/客户端）：** 指的是用户交互的界面，例如 Claude Desktop、IDE（如 Cursor 或 VS Code）或任何集成了 AI 的应用程序。
*   **MCP Client（客户端）：** 运行在宿主程序内部，负责向服务器发送指令和数据请求。
*   **MCP Server（服务器）：** 这是一个轻量级程序，专门负责连接特定数据源（如 GitHub、本地文件系统、PostgreSQL 数据库）。它通过 MCP 协议向 AI 暴露其能力。



---

## 2. MCP 的三大核心功能

MCP 主要定义了三种 AI 可以与之交互的资源类型：

1.  **Resources（资源）：**
    类似“只读”的数据流。允许模型安全地读取外部信息，例如读取一份本地文档、查看数据库架构或获取 API 文档。
2.  **Prompts（提示词模板）：**
    服务器可以提供预设的提示词模板。例如，一个调试服务器可以提供“分析此错误日志”的模板，简化用户的输入过程。
3.  **Tools（工具）：**
    允许模型执行具体的“动作”。这是 MCP 最强大的地方，模型可以触发函数调用，例如“在 GitHub 上创建一个 Issue”、“执行一段 Python 代码”或“发送一封邮件”。

---

## 3. 为什么 MCP 如此重要？

### 🔌 统一标准，避免“重复造轮子”
以往，如果有人为 Slack 开发了一个 AI 插件，它只能在特定的 AI 平台上使用。有了 MCP，只要开发者编写了一个 **MCP Slack Server**，任何支持 MCP 协议的 AI 客户端（无论是什么品牌）都能立即拥有操作 Slack 的能力。

### 🛡️ 增强的安全性和隐私性
MCP 允许数据保留在本地或受控环境中。AI 模型并不直接接管你的系统，而是通过 MCP Server 发出请求。用户可以清楚地看到 AI 想要读取什么文件或执行什么操作。

### 🚀 极大地扩展 AI 的能力边界
通过 MCP，AI 不再局限于其训练数据，而是变成了一个**具备行动能力的操作系统中心**。它可以实时检索你的笔记、分析你的代码库、甚至控制你的本地智能家居设备。

---

## 4. 常见的应用场景

*   **编程辅助：** AI 可以直接读取你的本地 Git 仓库，理解复杂的项目结构，并直接应用代码修复。
*   **数据分析：** AI 可以直接连接到 SQL 数据库，根据你的自然语言指令编写并运行查询语句，最后生成分析报告。
*   **企业知识库：** 员工可以通过 AI 界面无缝搜索公司内部存储在 Notion、Google Drive 或本地服务器上的敏感文档。

---

## 5. 如何使用？

*   **对于开发者：** 你可以使用 TypeScript 或 Python SDK 快速构建自己的 MCP Server，将你的服务暴露给 AI。
*   **对于普通用户：** 如果你使用 Claude Desktop，只需在配置文件中添加几行 JSON 代码，指向已有的开源 MCP Server（如 `mcp-server-sqlite` 或 `mcp-server-github`），你的 AI 助手就会立刻多出这些新技能。

> **总结：** MCP 正在构建一个**互联的 AI 生态系统**。它将 AI 从一个孤立的对话框，转变为一个能够理解并操作整个数字化世界的强大智能引擎。
";
            var tokens = Tokenizer.Tokenize(content, "zh");
            foreach (var token in tokens)
            {
                TestContext.WriteLine(token);
            }
        }
        [TestMethod]
        public void TestTokenizerJa()
        {
            var content = @"
MCP（Model Context Protocol）に関する詳細な解説を日本語に翻訳しました。

---

## **モデル・コンテキスト・プロトコル（MCP）の概要**

**Model Context Protocol（MCP）**は、Anthropicが発表したオープン標準であり、AIモデル（Claude、GPT-4など）と外部データソースやツールとの間にある「接続の断片化」という課題を解決するために設計されました。

例えるなら、MCPは**「AI界のUSB規格」**です。MCPが登場する前は、AIにローカルデータベース、Googleドライブ、Slackなどにアクセスさせたい場合、開発者は各プラットフォームごとに固有のコードを書く必要がありました。MCPは、これらを統一された標準的な方法で通信可能にするプロトコルを提供します。

---

## 1. コアアーキテクチャと動作原理

MCPのアーキテクチャは、シンプルな**クライアント・サーバー（Client-Server）モデル**に基づいています。

*   **MCP Host（ホスト/クライアント）:** ユーザーが操作するインターフェースを指します。例えば、Claude Desktop、CursorやVS CodeなどのIDE、あるいはAIを統合したあらゆるアプリケーションです。
*   **MCP Client（クライアント）:** ホストプログラム内で動作し、サーバーに対して指示やデータリクエストを送信する役割を担います。
*   **MCP Server（サーバー）:** 特定のデータソース（GitHub、ローカルファイルシステム、PostgreSQLデータベースなど）に接続するために特化した軽量なプログラムです。MCPプロトコルを通じて、その能力をAIに公開します。



---

## 2. MCPの3つの主要機能

MCPは、AIが対話できるリソースのタイプを主に3つ定義しています。

1.  **Resources（リソース）:**
    「読み取り専用」のデータストリームのようなものです。AIが外部情報を安全に読み取ることを許可します。例えば、ローカルドキュメントの読み込み、データベースのスキーマ確認、APIドキュメントの取得などが含まれます。
2.  **Prompts（プロンプト・テンプレート）:**
    サーバー側で事前に設定されたプロンプトのテンプレートを提供できます。例えば、デバッグ用サーバーが「このエラーログを分析して」というテンプレートを提供することで、ユーザーの入力を簡略化できます。
3.  **Tools（ツール）:**
    AIに具体的な「アクション」を実行させます。これはMCPの最も強力な部分であり、AIが関数を呼び出して「GitHubでIssueを作成する」「Pythonコードを実行する」「メールを送信する」といった操作を直接行えるようになります。

---

## 3. なぜMCPが重要なのか？

### 🔌 標準化による相互運用性
以前は、誰かがSlack用のAIプラグインを開発しても、それは特定のプラットフォームでしか使えませんでした。MCPがあれば、開発者が一度 **MCP Slack Server** を作成するだけで、MCPに対応しているあらゆるAIクライアントが即座にSlackを操作できるようになります。

### 🛡️ セキュリティとプライバシーの強化
MCPはデータをローカルや管理下にある環境に保持したまま利用できます。AIモデルが直接システムを乗っ取るのではなく、MCPサーバーを介してリクエストを送るため、ユーザーはAIがどのファイルを読み込もうとしているか、どのアクションを実行しようとしているかを明確に把握・制御できます。

### 🚀 AIの能力限界の拡張
MCPを通じて、AIは学習データの中に閉じこもるのではなく、**「行動能力を持つオペレーティングシステムの中心」**へと進化します。リアルタイムでメモを検索し、コードベースを分析し、さらにはローカルのスマートホームデバイスを操作することさえ可能になります。

---

## 4. 主な活用シーン

*   **プログラミング支援:** AIがローカルのGitリポジトリを直接読み込み、複雑なプロジェクト構造を理解した上で、直接コードの修正を適用できます。
*   **データ分析:** AIがSQLデータベースに直接接続し、自然言語の指示に従ってクエリを作成・実行し、分析レポートを生成します。
*   **企業内ナレッジベース:** Notion、Googleドライブ、または社内サーバーにある機密文書を、AIインターフェースからシームレスに検索・活用できます。

---

## 5. 使い始めるには？

*   **開発者の場合:** TypeScriptやPythonのSDKを使用して、独自のMCPサーバーを構築し、自社のサービスをAIに公開できます。
*   **一般ユーザーの場合:** Claude Desktopなどを使用している場合、設定ファイル（JSON）に数行追加して、公開されている既存のMCPサーバー（`mcp-server-sqlite` や `mcp-server-github` など）を指定するだけで、AIアシスタントに新しいスキルを即座に追加できます。

> **まとめ:** MCPは、**「相互接続されたAIエコシステム」**を構築しています。AIを単なる孤立したチャットボックスから、デジタル世界全体を理解し操作できる強力なインテリジェント・エンジンへと変貌させるものです。
";
            var tokens = Tokenizer.Tokenize(content, "ja");
            foreach (var token in tokens)
            {
                TestContext.WriteLine(token);
            }
        }
        [TestMethod]
        public void TestTokenizerEn()
        {
            var content = @"
Here is the detailed introduction to the **Model Context Protocol (MCP)** in English:

---

## **Introduction to Model Context Protocol (MCP)**

The **Model Context Protocol (MCP)** is an open standard introduced by Anthropic designed to solve the ""connectivity fragmentation"" between AI models (such as Claude or GPT-4) and external data sources or local tools.

Think of MCP as the **""USB-C port for the AI era.""** Before MCP, if you wanted an AI to access your local database, Google Drive, or Slack, developers had to write custom, non-portable integration code for every single data source. MCP provides a unified, standardized communication protocol that makes these integrations ""plug-and-play.""

---

## 1. Core Architecture and How It Works

MCP architecture is based on a simple **Client-Server model**:

*   **MCP Host:** The user-facing interface, such as Claude Desktop, IDEs (like Cursor or VS Code), or any AI-integrated application.
*   **MCP Client:** Runs inside the host program and is responsible for sending instructions and data requests to the server.
*   **MCP Server:** A lightweight program specifically designed to connect to a data source (e.g., GitHub, a local file system, or a PostgreSQL database). It exposes these capabilities to the AI via the MCP protocol.

---

## 2. Three Core Capabilities of MCP

MCP defines three primary ways an AI can interact with external resources:

1.  **Resources:**
    Think of these as ""read-only"" data streams. They allow the model to safely read external information, such as opening a local document, inspecting a database schema, or fetching API documentation.
2.  **Prompts:**
    Servers can provide pre-set prompt templates. For example, a debugging server could offer an ""Analyze this error log"" template, simplifying the user’s input process.
3.  **Tools:**
    These allow the model to take **actions**. This is the most powerful aspect of MCP—the model can trigger function calls to perform tasks like ""Create a GitHub Issue,"" ""Execute a Python script,"" or ""Send an email.""

---

## 3. Why is MCP Important?

### 🔌 Standardized Interoperability
Previously, if someone built an AI plugin for Slack, it only worked on that specific AI platform. With MCP, once a developer builds an **MCP Slack Server**, any MCP-compatible AI client—regardless of the brand—can immediately interact with Slack.

### 🛡️ Enhanced Security and Privacy
MCP allows data to stay local or within a controlled environment. The AI model doesn't ""take over"" your system; instead, it sends requests through the MCP Server. Users have clear visibility and control over what files the AI is reading or what actions it is attempting to execute.

### 🚀 Expanding the Boundaries of AI
Through MCP, AI is no longer confined to its training data. It evolves into the **hub of an ""action-oriented"" operating system**. It can search your notes in real-time, analyze your codebase, and even control local smart home devices.

---

## 4. Key Use Cases

*   **Coding Assistance:** An AI can directly read your local Git repository, understand complex project structures, and apply code fixes directly to your files.
*   **Data Analysis:** An AI can connect to a SQL database, write and run queries based on your natural language instructions, and generate a final analysis report.
*   **Enterprise Knowledge Base:** Employees can seamlessly search through internal documents stored across Notion, Google Drive, or local servers through a single AI interface.

---

## 5. How to Get Started?

*   **For Developers:** You can use the TypeScript or Python SDKs to quickly build your own MCP Server and expose your services or data to any AI client.
*   **For Users:** If you use Claude Desktop, you can simply add a few lines of JSON to your configuration file to point to existing open-source MCP Servers (like `mcp-server-sqlite` or `mcp-server-github`) to instantly give your AI assistant new ""skills.""

> **Summary:** MCP is building an **interconnected AI ecosystem**. It transforms AI from an isolated chat box into a powerful intelligent engine capable of understanding and operating the entire digital world.
";
            var tokens = Tokenizer.Tokenize(content, "en");
            foreach (var token in tokens)
            {
                TestContext.WriteLine(token);
            }
        }
    }
}
