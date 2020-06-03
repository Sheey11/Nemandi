using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport.CSharp {
    public class CSharpPluginManager {
        private string pluginFolderPath { get; set; }

        public List<NemandiCSharpPlugin> Plugins { get; set; }

        /// <summary>
        /// Create a new PluginManager.
        /// </summary>
        /// <param name="path">Absolute path to the plugins folder.</param>
        public CSharpPluginManager(string path) {
            pluginFolderPath = path;
        }

        public bool LoadPlugins() {
            var result = new List<NemandiCSharpPlugin>();

            // if the folder is empty
            var isEmpty = !Directory.EnumerateFileSystemEntries(this.pluginFolderPath).Any((n) =>
                    n.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) &&
                    Path.GetFileName(n).StartsWith("Nemandi.Plugin", StringComparison.OrdinalIgnoreCase)
                );

            if (isEmpty)
                return true;

            // filter non-assembly file
            var fnames = from f
                         in Directory.GetFiles(this.pluginFolderPath)
                         where f.EndsWith(".dll", StringComparison.OrdinalIgnoreCase) &&
                               Path.GetFileName(f).StartsWith("Nemandi.Plugin", StringComparison.OrdinalIgnoreCase)
                         select f;

            foreach(var pluginPath in fnames) {
                try {
                    // load each file
                    Assembly plugin = LoadPlugin(pluginPath);

                    // create PluginInfo for every Instance
                    var instances = CreatePlugin(plugin);

                    foreach (var instance in instances) {
                        // need optimization
                        instance.OnInit(new PluginInitContext());

                        result.Add(NemandiPlugin.CreateCSharpPlugin(instance, pluginPath));
                    }
                }catch(Exception e) {
                    // TODO: Logging, and more
                    continue;
                }
            }

            this.Plugins = result;

            return true;
        }

        private Assembly LoadPlugin(string path) {
            CSharpPluginLoadContext loadContext = new CSharpPluginLoadContext(path);
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
