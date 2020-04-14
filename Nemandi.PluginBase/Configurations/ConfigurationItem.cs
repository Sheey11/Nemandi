using System;
namespace Nemandi.PluginBase.Configurations {
    public abstract class ConfigurationItem {

        public ConfigurationTypes Type { get; }
        public string Name { get; protected set; }
        public virtual object Value { get; set; }
        public virtual object DefaultValue { get; protected set; }
        public bool Enabled { get; set; }

        public ValueChangedHandler OnValueChanged;

        public ConfigurationItem() {

        }
    }
}
