using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.PluginBase {
    public interface IConfigPlugin : IPlugin {
        List<ConfigurationItem> ConfigurationItems { get; }

        event OnConfigListChanged onConfigListChanged;
    }
}
