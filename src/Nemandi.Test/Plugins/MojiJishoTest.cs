using Xunit;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Nemandi.Core;
using Nemandi.Core.PluginSupport.CSharp;
using Nemandi.Core.PluginSupport;
using Nemandi.PluginBase;
using Xunit.Abstractions;

namespace Nemandi.Test.Plugins {
    public class MojiJishoTest {

        private readonly ITestOutputHelper outputHelper;

        public MojiJishoTest(ITestOutputHelper output) {
            this.outputHelper = output;
        }

        public string PluginFolder = Path.GetFullPath("plugins/");

        [Theory]
        [InlineData("watasi")]
        [InlineData("とお")]
        [InlineData("にぎ")]
        public void QueryTest(string value) {
            PluginManager.LoadFrom(PluginFolder);
            Assert.False (PluginManager.LoadedPlugins.Count == 0, "Load plugins failed.");

            var loadedPlugin = PluginManager.LoadedPlugins;

            this.outputHelper.WriteLine("");
            this.outputHelper.WriteLine("==================== Loaded Plugin ===================");
            foreach (var p in loadedPlugin) {
                var info = p.GetInfo();
                this.outputHelper.WriteLine(info.Name);
            }
            this.outputHelper.WriteLine("==================== Loaded Plugin ===================");
            this.outputHelper.WriteLine("");

            var moji = (from plugin
                    in loadedPlugin
                where plugin.GetInfo().Name == "Moji辞書"
                select plugin).First();

            var pwList = moji.Autocomplete(value);

            Assert.False(pwList?.Count == 0);

            var selectedPw = pwList?.FirstOrDefault();
            var word = moji.Query(selectedPw);

            Assert.False(word == null);
            Assert.False(word.HeadWord == "");

            this.outputHelper.WriteLine("==================== Query Result ====================");
            this.outputHelper.WriteLine(word.HeadWord);
            this.outputHelper.WriteLine("==================== Query Result ====================");
        }
    }
}
