using System;
using System.Linq;
using System.IO;
using Nemandi.Core.PluginSupport;
using Nemandi.PluginBase;

namespace Nemandi.Test {
    class Program {
        static void Main(string[] args) {
            var pluginFolder = Path.GetFullPath("plugins/");
            Console.WriteLine($"Load plugin in {pluginFolder}");

            var manager = new PluginsManager(pluginFolder);
            var result = manager.LoadPlugins();

            foreach (var plugin in result.Loaded) {
                Console.WriteLine($"Name: {plugin.Name}, Source lang: {plugin.SourceLang}");
            }

            var moji = (from p
                        in result.Loaded
                        where p.Name == "Moji辞書"
                        select p).FirstOrDefault();

            (moji.Instance as IConfigPlugin).ConfigurationItems[0].Value = "";
            var pwList = moji.Instance.Autocomplete("wata");
            foreach(var pw in pwList) {
                Console.WriteLine(pw.HeadWord);
            }
        }
    }
}
