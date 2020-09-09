using System;
namespace Nemandi.PluginBase.Actions {
    public class SimpleAction : PluginAction {

        public string Name { get; set; }
        public bool Disabled { get; set; } = false;

        public SimpleAction(string name, Action action) : base(action) {
            this.Name = name;
        }
    }
}
