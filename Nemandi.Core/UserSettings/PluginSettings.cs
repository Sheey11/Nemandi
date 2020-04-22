using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Nemandi.PluginBase;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.Core.UserSettings {
    public class PluginSettings {

        private readonly IPlugin _parentPlugin;
        private List<ConfigurationItem> Configurations => _parentPlugin.ConfigurationItems;

        private string ConfigFilePath => Path.GetFullPath($"./config/plugins/{_parentPlugin.Name}.json");
        private string ConfigFileFolder => Path.GetDirectoryName(this.ConfigFilePath);

        public PluginSettings(IPlugin plugin) {
            this._parentPlugin = plugin;
        }

        public void Save() {
            Directory.CreateDirectory(this.ConfigFileFolder);
            var path = Path.GetFullPath(this.ConfigFilePath);

            using (var fs = File.OpenWrite(path)) {
                using(var writer = new Utf8JsonWriter(fs)) {
                    // start of the json
                    writer.WriteStartObject();
                    foreach(var item in this.Configurations) {
                        // start of the item
                        writer.WriteStartObject(item.Name);
                        // item configuration
                        switch (item) {
                            case BoolConfigItem c when item.Type == ConfigurationTypes.Bool:
                                writer.WriteBoolean("Value", c.Value);
                                break;
                            case DecimalConfigItem c when item.Type == ConfigurationTypes.Decimal:
                                writer.WriteNumber("Value", c.Value);
                                break;
                            case IntengerConfigItem c when item.Type == ConfigurationTypes.Intenger:
                                writer.WriteNumber("Value", c.Value);
                                break;
                            case TextConfigItem c when item.Type == ConfigurationTypes.Text:
                                writer.WriteString("Value", c.Value);
                                break;
                        }
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                }
            }
        }

        public Task SaveAsync() {
            return Task.Run(() => Save());
        }

        public void Load() {
            if (!File.Exists(this.ConfigFilePath))
                return;

            using (var fs = File.OpenRead(this.ConfigFilePath)) {
                using(var document = JsonDocument.Parse(fs)) {
                    var root = document.RootElement;

                    foreach (var item in this.Configurations) {
                        // compatible with new version of plugin which has more config items
                        JsonElement ele;
                        try {
                            ele = root.GetProperty(item.Name);
                        } catch(KeyNotFoundException) {
                            continue;
                        } catch (Exception e) {
                            throw e;
                        }

                        switch (item.Type) {
                            case ConfigurationTypes.Bool:
                                item.SetInitValue(ele.GetProperty("Value").GetBoolean());
                                break;
                            case ConfigurationTypes.Decimal:
                                item.SetInitValue(ele.GetProperty("Value").GetDouble());
                                break;
                            case ConfigurationTypes.Intenger:
                                item.SetInitValue(ele.GetProperty("Value").GetInt32());
                                break;
                            case ConfigurationTypes.Text:
                                item.SetInitValue(ele.GetProperty("Value").GetString());
                                break;
                        }
                    }
                }
            }
        }

        public Task LoadAsync() {
            return Task.Run(() => Load());
        }
    }
}
