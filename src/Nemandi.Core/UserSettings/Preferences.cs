using System;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Globalization;

namespace Nemandi.Core.UserSettings {
    public static class Preferences {
        public static CultureInfo UILanguage => CultureInfo.CurrentUICulture;
        // TODO

        private static string PreferenceFilePath => Path.GetFileName(@"./config/preference.json");
        private static string PreferenceFolder => Path.GetDirectoryName(PreferenceFilePath);

        public static void Save() {
            Directory.CreateDirectory(PreferenceFolder);

            using var stream = File.OpenWrite(PreferenceFilePath);
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartObject();

            foreach (var item in typeof(Preferences).GetProperties(BindingFlags.Public)) {
                var value = item.GetConstantValue();
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
    }
}
