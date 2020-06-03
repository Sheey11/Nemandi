using Xunit;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Nemandi.Core;
using Nemandi.Core.PluginSupport.CSharp;
using Nemandi.Core.PluginSupport;
using Nemandi.PluginBase;

namespace Nemandi.Test.Plugins {
    public static class MojiJishoTest {
        public static string PluginFolder = Path.GetFullPath("plugins/");

        [Theory]
        [InlineData("watasi")]
        [InlineData("とお")]
        [InlineData("にぎ")]
        public static void QueryTest(string value) {
            var pluginManager = new CSharpPluginManager(PluginFolder);
            Assert.True(pluginManager.LoadPlugins(), "Load plugins faild.");

            var loadedPlugin = pluginManager.Plugins;

            Console.WriteLine();
            Console.WriteLine("==================== Loaded Plugin ===================");
            foreach (var p in loadedPlugin) {
                var info = p.GetInfo();
                Console.WriteLine(info.Name);
            }
            Console.WriteLine("==================== Loaded Plugin ===================");
            Console.WriteLine();

            var moji = (from plugin
                       in loadedPlugin
                        where plugin.GetInfo().Name == "Moji辞書"
                        select plugin).First();
            var instance = moji.Instance as IConfigPlugin;

            var pwList = instance.Autocomplete(value);

            Assert.False(pwList.Count == 0);

            var seletecdPw = pwList.FirstOrDefault();
            var word = instance.Query(seletecdPw);

            Assert.False(word == null);
            Assert.False(word.HeadWord == "");

            Console.WriteLine("==================== Query Result ====================");
            Console.WriteLine(word.HeadWord);
            Console.WriteLine("==================== Query Result ====================");
        }
    }
}
