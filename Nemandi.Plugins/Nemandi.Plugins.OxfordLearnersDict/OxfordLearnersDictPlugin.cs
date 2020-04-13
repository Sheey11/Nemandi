using System;
using System.Collections.Generic;
using Nemandi.Base;
using Nemandi.Base.Words;
using Nemandi.PluginBase;

namespace Nemandi.Plugins.OxfordLearnersDict {
    public class OxfordLearnersDictPlugin : IPlugin {
        public string Name => "Oxford Learn's Dictionaries";
        public string Author => "sheey";
        public string Website => "https://oxfordlearnsdictionies.com";
        public Version Version => new Version(1,0,0);
        public string Email => "i@sheey.moe";
        public string Description => "An implementation of Oxford Learn's Dictionaries.";

        public Languages SourceLang => throw new NotImplementedException();

        public Languages QueryLang => throw new NotImplementedException();

        public Features SupportedFeature => throw new NotImplementedException();

        public List<PreviewWord> Autocomplete(string queryString) {
            throw new NotImplementedException();
        }

        public void OnInit() {
            throw new NotImplementedException();
        }

        public List<Word> Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
