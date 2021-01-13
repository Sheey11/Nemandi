using System;
using System.Collections.Generic;
using System.Linq;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase;

namespace Nemandi.Core.PluginSupport {
    public class NemandiCSharpPlugin : NemandiPlugin {
        public IPlugin Instance { get; }

        public override string PluginName => this.Instance.Name;

        public NemandiCSharpPlugin(IPlugin instance, string path) {
            this.Instance = instance;
            this.Path = path;
        }

        public override PluginInfo GetInfo() {
            return PluginInfo.CreateCSharpPluginInfo(this.Instance, this.Path);
        }

        public override List<PreviewWord> Autocomplete(string queryStr) {
            return this.Instance.Autocomplete(queryStr).Select(pw => {
                pw.Originate = this.Instance.Name;
                return pw;
            }).ToList();
        }

        public override Word Query(PreviewWord word) {
            return this.Instance.Query(word);
        }
    }
}
