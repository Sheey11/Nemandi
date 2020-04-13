using System;
using System.Collections.Generic;
using Nemandi.PluginBase;

namespace Nemandi.PluginSupport {
    public class PluginLoadResult {
        public List<IPlugin> Loaded { get; internal set; }
    }
}
