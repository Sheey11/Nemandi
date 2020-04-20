using System;
using System.IO;
using System.Text.Json.Serialization;
using Nemandi.PluginBase;
using Nemandi.PluginBase.Configurations;
using Nemandi.Infrastructure;

namespace Nemandi.Core.PluginSupport {
	public class PluginInfo {

		public IPlugin Instance { get; set; }

        public string FilePath { get; set; }
		public string Name => Instance.Name;
		public string Author => Instance.Author;
		public string Website => Instance.Website;
		public Version Version => Instance.Version;
		public string Email => Instance.Email;
		public string Description => Instance.Description;

		public Languages SourceLang => Instance.SourceLang;
		public Languages QueryLang => Instance.QueryLang;
		public Features SupportedFeature => Instance.SupportedFeature;

		public bool Enabled { get; set; }

		public PluginInfo() { }

        public void SaveConfig() {
            using (var file = File.OpenWrite("plugin-config.json")) {
				foreach (var config in Instance.ConfigurationItems) {
                    switch (config.Type) {
						case ConfigurationTypes.Intenger:
                            // TODO
                            break;
						case ConfigurationTypes.Decimal:
                            // TODO
							break;
						case ConfigurationTypes.Bool:
							// TODO
							break;
						case ConfigurationTypes.Text:
							// TODO
							break;

                    }
				}
			}
        }
	}
}