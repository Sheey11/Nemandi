using System;
using System.Collections.Generic;
using System.Text.Json;
using Nemandi.PluginBase;
using Nemandi.Base;
using Nemandi.Base.Words;
using Nemandi.CommonUtility;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.Plugins.MojiJisho {
    public partial class MojiJishoPlugin : IPlugin {
        public string Name => "Moji辞書";
        public string Author => "sheey";
        public Version Version => new Version(1, 0, 0);
        public string Website => "";
        public string Email => "i@sheey.moe";
        public string Description => "An implementation of Moji辞書.";

        public List<ConfigurationItem> ConfigurationItems => new List<ConfigurationItem> {
                    new TextConfigItem("_SessionToken", ""),
                };

        public Languages SourceLang => Languages.ChineseSimplified;
        public Languages QueryLang => Languages.Japanese;
        public Features SupportedFeature => Features.Definition | Features.Pronunciation | Features.Infection;

        public void OnInit(){ }

        public List<PreviewWord> Autocomplete(string queryString) {
            var data = new SearchData{ searchText = queryString };
            var json = JsonSerializer.Serialize(data);
            var r = Http.Post("https://api.mojidict.com/parse/functions/search_v3", json);
            var jsonReader = new Utf8JsonReader(r);
            var search = JsonSerializer.Deserialize<Search>(ref jsonReader);
            var words = search.result.words;
            var pwords = new List<PreviewWord>();
            foreach(var word in words){
                var headword = $"{word.spell} | {word.pron}";
                var pword = new PreviewWord(headword, "", word.excerpt, word.objectId);
            }
            return pwords;
        }

        public List<Word> Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
