using System;
using Xunit;
using System.IO;
using Nemandi.Test.Plugins;
using Xunit.Abstractions;

namespace Nemandi.Test {
    
    public class BasicInfo {
        private readonly ITestOutputHelper outputHelper;

        public BasicInfo(ITestOutputHelper helper) {
            this.outputHelper = helper;
        }

        [Fact]
        public void PrintBasicInfo() {
            this.outputHelper.WriteLine("");
            this.outputHelper.WriteLine("=============== Basic Infomation Start ===============");
            this.outputHelper.WriteLine($"Test in current running at {Path.GetFullPath(".")}");
            this.outputHelper.WriteLine("================ Basic Infomation End ================");
            this.outputHelper.WriteLine("");
        }
    }
}
