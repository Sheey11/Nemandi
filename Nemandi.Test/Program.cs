using System;
using System.IO;
using Nemandi.PluginSupport;

namespace Nemandi.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginFolder = Path.GetFullPath("plugins/");
            Console.WriteLine($"Load plugin in {pluginFolder}");

            var manager = new PluginsManager(pluginFolder);
            var result = manager.LoadPlugins();

            foreach(var plugin in result.Loaded) {
                Console.WriteLine($"Name: {plugin.Name}, Source lang: {plugin.SourceLang}");
            }
            
        }
    }
}
