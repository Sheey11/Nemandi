using System;
using System.Collections.Generic;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public abstract class NemandiPlugin {
        public string Path { get; set; }
        public abstract string PluginName { get; }

        public static NemandiCSharpPlugin CreateCSharpPlugin(IPlugin instance, string path) {
            return new NemandiCSharpPlugin(instance, path);
        }

        public static NemandiJSPlugin CreateJSPlugin() {
            return new NemandiJSPlugin();
        }

        public abstract PluginInfo GetInfo();
        public abstract List<PreviewWord> Autocomplete(string queryStr);
        public abstract Word Query(PreviewWord word);
    }
}
