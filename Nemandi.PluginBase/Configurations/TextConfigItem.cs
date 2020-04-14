using System;

namespace Nemandi.PluginBase.Configurations {
    public class TextConfigItem : ConfigurationItem {

        public ConfigurationTypes Types => ConfigurationTypes.Text;
        public new string Value { get; set; }
        public new string DefaultValue { get; protected set; }

        public string PlaceHolder { get; set; }
        public bool AllowMultiline { get; set; } = false;

        public TextConfigItem(string name, string defaultValue) {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}
