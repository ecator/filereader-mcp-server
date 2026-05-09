using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FileReaderMcpServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderMcpServer.Tests
{
    public class TestBase
    {
        public string AssemblyDirectory { get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        public string TestDataDirectory { get => Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\TestData")); }
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void BaseSetup()
        {
            GlobalState.AllowedDirectories.Clear();
            GlobalState.AllowedDirectories.Add(TestDataDirectory);
        }
    }
}
