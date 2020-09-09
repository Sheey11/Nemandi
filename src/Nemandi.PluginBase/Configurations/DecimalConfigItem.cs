using System;

namespace Nemandi.PluginBase.Configurations {
    public class DecimalConfigItem : ConfigurationItem {

        public ConfigurationTypes Types => ConfigurationTypes.Intenger;
        public new double _value { get; set; }
        public new double Value {
            get => _value;
            set {
                this._value = value;
                OnValueChanged(this, value);
            }
        }
        public new double DefaultValue { get; protected set; }

        public double? Max { get; set; }
        public double? Min { get; set; }

        public DecimalConfigItem(string name, double defaultValue) {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}
