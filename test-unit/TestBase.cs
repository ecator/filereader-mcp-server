using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestUnit
{
    public class TestBase
    {
        public string AssemblyDirectory { get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        public string TestDataDirectory { get => Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\..\..\test-data")); }
        public TestContext TestContext { get; set; }
    }
}
