using System;

namespace Nemandi.PluginBase.Configurations {
    public class IntengerConfigItem : ConfigurationItem {

        public ConfigurationTypes Types => ConfigurationTypes.Intenger;
        public new int _value { get; set; }
        public new int Value {
            get => _value;
            set {
                this._value = value;
                OnValueChanged(this, value);
            }
        }
        public new int DefaultValue { get; protected set; }

        public int? Max { get; set; }
        public int? Min { get; set; }

        public IntengerConfigItem(string name, int defaultValue) {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}
