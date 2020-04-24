using System;

namespace Nemandi.PluginBase.Configurations {
    public class PasswordConfigItem : ConfigurationItem {

        public ConfigurationTypes Types => ConfigurationTypes.Password;
        public new string _value { get; set; }
        public new string Value {
            get => _value;
            set {
                this._value = value;
                OnValueChanged(this, value);
            }
        }
        public new string DefaultValue { get; protected set; }

        public string PlaceHolder { get; set; }

        public PasswordConfigItem(string name, string defaultValue) {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}
