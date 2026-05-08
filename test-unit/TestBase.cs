using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FileReaderMcpServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnit
{
    public class TestBase
    {
        public string AssemblyDirectory { get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        public string TestDataDirectory { get => Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\test-data")); }
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            GlobalState.AllowedDirectories.Clear();
            GlobalState.AllowedDirectories.Add(TestDataDirectory);
        }
    }
}
