using System;
namespace Nemandi.PluginBase.Actions {
    public abstract class PluginAction {

        public Action Action { get; set; }

        public PluginAction(Action action) {
            this.Action = action;
        }
    }
}
