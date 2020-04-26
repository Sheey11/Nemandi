using System;
using System.Collections.Generic;
using System.Text.Json;
using Nemandi.PluginBase;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.CommonUtility;
using Nemandi.PluginBase.Configurations;
using Nemandi.PluginBase.Actions;

namespace Nemandi.Plugins.MojiJisho {
    public partial class MojiJishoPlugin : IConfigPlugin {
        public string Name => "Moji辞書";
        public string Author => "sheey";
        public Version Version => new Version(1, 0, 0);
        public string Website => "";
        public string Email => "i@sheey.moe";
        public string Description => "An implementation of Moji辞書.";

        public List<ConfigurationItem> ConfigurationItems { get; } = new List<ConfigurationItem>() {
            new TextConfigItem("_SessionToken", "")
        };

        public event OnConfigListChanged OnConfigListChanged;

        public Languages SourceLang => Languages.ChineseSimplified;
        public Languages QueryLang => Languages.Japanese;
        public Features SupportedFeature => Features.Definition | Features.Pronunciation | Features.Infection;

        public void OnInit(PluginInitContext context){

        }

        public List<PreviewWord> Autocomplete(string queryString) {
            var session = this.ConfigurationItems[0].Value as string;
            return MojiJishoInteraction.Autocomplete(queryString, session);
        }

        public Word Query(PreviewWord word) {
            var objId = word.Props as string;
            var session = this.ConfigurationItems[0].Value as string;
            return MojiJishoInteraction.QueryWords(objId, session);
        }
    }
}
