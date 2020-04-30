using System;
using System.Collections.Generic;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.Plugins.OxfordLearnersDict {
    public class OxfordLearnersDictPlugin : IConfigPlugin {
        public string Name => "Oxford Learner's Dictionaries";
        public string Author => "sheey";
        public string Website => "https://www.oxfordlearnersdictionaries.com/";
        public Version Version => new Version(1,0,0);
        public string Email => "i@sheey.moe";
        public string Description => "An implementation of Oxford Learner's Dictionaries.";

        public List<ConfigurationItem> ConfigurationItems => new List<ConfigurationItem>() {
                    new TextConfigItem("API key", ""),
                };
        public event OnConfigListChanged OnConfigListChanged;

        public Languages SourceLang => Languages.English;
        public Languages TargetLang => Languages.English;
        public Features SupportedFeature => Features.Definition | Features.Pronunciation;

        public List<PreviewWord> Autocomplete(string queryString) {
            throw new NotImplementedException();
        }

        public void OnInit(PluginInitContext context) {
            throw new NotImplementedException();
        }

        public Word Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
