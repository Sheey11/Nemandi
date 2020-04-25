using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase.Actions;

namespace Nemandi.PluginBase {
    public interface IActionPlugin : IPlugin {
        List<PluginAction> Actions { get; }

        event OnActionListChanged OnActionListChanged;
    }
}
