using System;
using System.Collections.Generic;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public class PluginLoadResult {
        public List<PluginInfo> Loaded { get; internal set; }
        public void Add(IPlugin instance, string path) {
            this.Loaded.Add(new PluginInfo() {
                Instance = instance,
                FilePath = path,
            });
        }
    }
}
