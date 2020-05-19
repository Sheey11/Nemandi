using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;
using Nemandi.Core;
using Nemandi.Core.PluginSupport;
using Nemandi.PluginBase;

namespace Nemandi.Test.Plugins {
    public class MojiJishoTest {

        static List<PluginInfo> plugins = PluginTest.LoadedPlugin;
        static PluginInfo moji = (from PluginInfo plugin
                   in plugins
                    where plugin.Name == "Moji辞書"
                    select plugin).First();
        static IConfigPlugin instance = moji.Instance as IConfigPlugin;


        [Theory]
        [InlineData("watasi")]
        [InlineData("とお")]
        [InlineData("にぎ")]
        public void QueryTest(string value) {
            var pwList = instance.Autocomplete(value);

            Assert.True(pwList.Count == 0);

            var seletecdPw = pwList.FirstOrDefault();
            var word = instance.Query(seletecdPw);

            Assert.True(word == null);
            Assert.True(word.HeadWord == "");
        }
    }
}
