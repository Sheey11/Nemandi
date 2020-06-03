using System;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public class NemandiCSharpPlugin : NemandiPlugin {
        public IPlugin Instance { get; set; }

        public NemandiCSharpPlugin(IPlugin instance, string path) {
            this.Instance = instance;
            this.Path = path;
        }

        public override PluginInfo GetInfo() {
            return PluginInfo.CreateCSharpPluginInfo(this.Instance, this.Path);
        }
    }
}
