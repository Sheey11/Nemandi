using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Nemandi.PluginBase;

namespace Nemandi.PluginSupport {
    public class PluginsManager {
        private string pluginFolderPath { get; set; }

        public PluginsManager(string path) {
            pluginFolderPath = path;
        }

        public PluginLoadResult LoadPlugins() {
            var result = new PluginLoadResult();
            result.Loaded = new List<IPlugin>();

            var fnames = Directory.GetFiles(this.pluginFolderPath);
            var plugins = fnames.SelectMany(pluginPath => {
                // load each file
                Assembly plugin = LoadPlugin(pluginPath);
                return CreatePlugin(plugin);
            }).ToList();

            result.Loaded.AddRange(plugins);
            return result;
        }

        private Assembly LoadPlugin(string path) {
            PluginLoadContext loadContext = new PluginLoadContext(path);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(path)));
        }

        private IEnumerable<IPlugin> CreatePlugin(Assembly assembly) {
            foreach(var type in assembly.GetTypes()) {
                if (typeof(IPlugin).IsAssignableFrom(type)) {
                    var plugin = Activator.CreateInstance(type) as IPlugin;
                    if(plugin != null) 
                        yield return plugin;
                }
            }
        }
    }
}
