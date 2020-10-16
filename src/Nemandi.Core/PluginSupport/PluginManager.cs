using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Nemandi.Core.PluginSupport.CSharp;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public static class PluginManager {
        public static List<NemandiPlugin> LoadedPlugins {
            get {
                return new List<NemandiPlugin>(csPluginManager.SelectMany((m) => m.Plugins));
            }
        }
        private static List<CSharpPluginManager> csPluginManager = new List<CSharpPluginManager>();

        public static void LoadFrom(string path) {
            var csm = new CSharpPluginManager(path);
            if (csm.LoadPlugins())
                csPluginManager.Add(csm);
        }

        public static List<PreviewWord> Autocomplete(string queryStr) {
            return new List<PreviewWord>(LoadedPlugins.SelectMany(p => p.Autocomplete(queryStr)));
        }

        public static Word Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
