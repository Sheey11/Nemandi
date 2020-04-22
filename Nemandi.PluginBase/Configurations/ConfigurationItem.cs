using System;
namespace Nemandi.PluginBase.Configurations {
    public abstract class ConfigurationItem {

        public ConfigurationTypes Type { get; }
        public string Name { get; protected set; }
        public object _value;
        public virtual object Value {
            get => _value;
            set {
                _value = value;
                OnValueChanged(this, value);
            }
        }
        public virtual object DefaultValue { get; protected set; }
        public bool Enabled { get; set; }

        public ValueChangedHandler OnValueChanged;

        public ConfigurationItem() {

        }

        public void SetInitValue(object value) {
            this._value = value;
            OnValueChanged(this, value, true);
        }
    }
}
