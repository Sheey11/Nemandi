using System;

namespace Nemandi.PluginBase.Configurations {
    public class IntengerConfigItem : ConfigurationItem {

        public ConfigurationTypes Types => ConfigurationTypes.Intenger;
        public new int Value { get; set; }
        public new int DefaultValue { get; protected set; }

        public int? Max { get; set; }
        public int? Min { get; set; }

        public IntengerConfigItem(string name, int defaultValue) {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }
    }
}
