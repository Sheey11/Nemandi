using System;

namespace Nemandi.PluginBase.Configurations {
    public class BoolConfigItem : ConfigurationItem {

        public ConfigurationTypes Types => ConfigurationTypes.Bool;
        public new bool _value { get; set; }
        public new bool Value {
            get => _value;
            set {
                this._value = value;
                OnValueChanged(this, value);
            }
        }
        public new bool DefaultValue { get; protected set; }

        public BoolConfigItem(string name, bool defaultValue) {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}
