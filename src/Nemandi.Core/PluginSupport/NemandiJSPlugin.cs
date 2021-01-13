using System;
using System.Collections.Generic;
using Nemandi.Infrastructure.Words;

namespace Nemandi.Core.PluginSupport {
    public class NemandiJSPlugin : NemandiPlugin {
        public override string PluginName => throw new NotImplementedException();

        public NemandiJSPlugin() {
            // TODO
        }

        public override PluginInfo GetInfo() {
            // TODO
            throw new NotImplementedException();
        }

        public override List<PreviewWord> Autocomplete(string queryStr) {
            throw new NotImplementedException();
        }

        public override Word Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
