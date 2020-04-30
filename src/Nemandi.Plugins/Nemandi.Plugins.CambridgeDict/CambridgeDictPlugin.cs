using System;
using System.Collections.Generic;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase;

namespace Nemandi.Plugins.CambridgeDict {
    public class CambridgeDictPlugin : IPlugin {
        public string Name => "Cambridge Dicitonary (zh-cn)";
        public string Author => "Sheey";
        public string Website => "https://dictionary.cambridge.org/";
        public Version Version => new Version(1, 0, 0);
        public string Email => "i@sheey.moe";
        public string Description => "An implementation of Cambridge Dictionary, thanks to https://github.com/xueyuanl/cambrinary.";

        public Languages SourceLang => Languages.English;
        public Languages TargetLang => Languages.ChineseSimplified;
        public Features SupportedFeature => Features.Definition | Features.Phrase | Features.Pronunciation;

        public List<PreviewWord> Autocomplete(string queryString) {
            return CambridgeInteraction.Autocomplete(queryString);
        }

        public void OnInit(PluginInitContext context) {

        }

        public Word Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
