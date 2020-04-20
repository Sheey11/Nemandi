using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public class PluginsManager {
        private string pluginFolderPath { get; set; }

        public List<PluginInfo> Plugins { get; set; }

        /// <summary>
        /// Create a new PluginManager.
        /// </summary>
        /// <param name="path">Absolute path to the plugins folder.</param>
        public PluginsManager(string path) {
            pluginFolderPath = path;
        }

        public PluginLoadResult LoadPlugins() {
            var result = new PluginLoadResult();
            result.Loaded = new List<PluginInfo>();

            // if the folder is empty
            var isEmpty = !Directory.EnumerateFileSystemEntries(this.pluginFolderPath).Any((n) => n.EndsWith(".dll"));
            if (isEmpty)
                return result;

            // filter non-assembly file
            var fnames = from f in Directory.GetFiles(this.pluginFolderPath) where f.EndsWith(".dll") select f;

            foreach(var pluginPath in fnames) {
                // load each file
                Assembly plugin = LoadPlugin(pluginPath);
                var instances = CreatePlugin(plugin);

                // create PluginInfo for every Instance
                foreach (var instance in instances) {
                    result.Add(instance, pluginPath);
                }
            }

            this.Plugins = result.Loaded;

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
