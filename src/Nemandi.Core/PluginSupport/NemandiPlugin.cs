using System;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public abstract class NemandiPlugin {
        public string Path { get; set; }

        public static NemandiCSharpPlugin CreateCSharpPlugin(IPlugin instance, string path) {
            return new NemandiCSharpPlugin(instance, path);
        }

        public static NemandiJSPlugin CreateJSPlugin() {
            return new NemandiJSPlugin();
        }

        public abstract PluginInfo GetInfo();
    }
}
