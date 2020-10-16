using System;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Nemandi.Core.UserSettings {
    public static class Preferences {

        [UserSettingItem("UILanguage")]
        public static CultureInfo UILanguage { get; set; } = CultureInfo.CurrentUICulture;
        // TODO

        private static string PreferenceFilePath => Path.GetFileName(@"./config/preference.json");
        private static string PreferenceFolder => Path.GetDirectoryName(PreferenceFilePath);

        public static void Save() {
            Directory.CreateDirectory(PreferenceFolder);

            using var stream = File.OpenWrite(PreferenceFilePath);
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartObject();

            var preItems = from propInfo
                           in typeof(Preferences).GetProperties(BindingFlags.Public)
                           let attr = propInfo.GetCustomAttribute(typeof(UserSettingItem))
                           where attr != null
                           select propInfo;

            foreach (var item in preItems) {
                var value = item.GetValue(null);
                switch (value) {
                    case bool b:
                        writer.WriteBoolean(item.Name, b);
                        break;
                    case int i:
                        writer.WriteNumber(item.Name, i);
                        break;
                    default:
                        writer.WriteString(item.Name, value.ToString());
                        break;
                }
            }
            writer.WriteEndObject();
            writer.Flush();
        }

        public static int Load() {
            if (!File.Exists(PreferenceFilePath)) return 0;

            using var file = File.OpenRead(PreferenceFilePath);
            var json = JsonDocument.Parse(file);
            var root = json.RootElement;

            var props = new List<PropertyInfo>(typeof(Preferences).GetProperties(BindingFlags.Public));

            var preItems = from PropertyInfo propInfo
                           in props
                           let attr = propInfo.GetCustomAttribute(typeof(UserSettingItem))
                           where attr != null
                           select propInfo;

            var itemSettled = 0;

            foreach (var item in preItems) {
                if (!root.TryGetProperty(item.Name, out var jsonEle)) continue;
                switch (item.GetValue(null)) {
                    case bool _:
                        item.SetValue(null, root.GetProperty(item.Name));
                        break;
                    case int _:
                        item.SetValue(null, root.GetProperty(item.Name));
                        break;
                    default:
                        throw new NotImplementedException();
                        // TODO
                        break;
                }
                itemSettled++;
            }

            return itemSettled;
        }
    }
}
