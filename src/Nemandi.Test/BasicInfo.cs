using System;
using Xunit;
using System.IO;
using Nemandi.Test.Plugins;

namespace Nemandi.Test {
    
    public static class BasicInfo {
        [Fact]
        public static void PrintBasicInfo() {
            Console.WriteLine();
            Console.WriteLine("=============== Basic Infomation Start ===============");
            Console.WriteLine($"Test in current running at {Path.GetFullPath(".")}");
            Console.WriteLine($"Loading plugins at {MojiJishoTest.PluginFolder}");
            Console.WriteLine("================ Basic Infomation End ================");
            Console.WriteLine();
        }
    }
}
