using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nemandi.Core.I18N;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase;
using NTextCat;

namespace Nemandi.Core.Querying {
    public static class Querying {
        public static List<PreviewWord> AutocompleteAsync(IPlugin plugin, string queryWord) {
            return plugin.Autocomplete(queryWord);
        }

        public static List<PreviewWord> Autocomplete(Languages lang, string queryWord) {
            // TODO
            throw new NotImplementedException();
        }

        public static List<PreviewWord> Autocomplete(string queryWord) {
            return new List<PreviewWord>(
                PluginSupport.PluginManager.LoadedPlugins.SelectMany(
                    p => p.Autocomplete(queryWord)
                    )
                );

            //var factory = new RankedLanguageIdentifierFactory();

            //var identifier = factory.Load("./Resources/NTextCat/Core14.profile.xml");
            //var languages = identifier.Identify(queryWord);

            //var mostCertainLanguage = languages.FirstOrDefault();

            //if(mostCertainLanguage != null)
            //    return Autocomplete(mostCertainLanguage.Item1.ToLanguages(), queryWord);
            //return null;
        }

        public static Word Query(PreviewWord word) {
            if (word == null) return null;

            var plugin = PluginSupport.PluginManager.LoadedPlugins.Where(p => p.PluginName == word.Originate).FirstOrDefault();
            if (plugin == null) throw new NullReferenceException($"The PreviewWord {word.HeadWord} originates from an unknown plugin.");
            return plugin.Query(word);
        }
    }

    public static class LanguageExtension {
        public static Languages ToLanguages(this LanguageInfo lang) {
            return (lang.Iso639_3.ToLower()) switch {
                "zho" => Languages.ChineseSimplified,
                "dan" => Languages.Danish,
                "deu" => Languages.German,
                "eng" => Languages.English,
                "fra" => Languages.French,
                "ita" => Languages.Italian,
                "jpa" => Languages.Japanese,
                "koa" => Languages.Korean,
                "nld" => Languages.Dutch,
                "nor" => Languages.Norwegian,
                "por" => Languages.Portuguese,
                "rus" => Languages.Russian,
                "spa" => Languages.Spanish,
                "swe" => Languages.Swedish,
                _ => Languages.Unknown,
            };
        }
    }
}
