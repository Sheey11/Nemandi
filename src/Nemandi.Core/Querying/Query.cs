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
    public static class Query {
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
    }

    public static class LanguageExtension {
        public static Languages ToLanguages(this LanguageInfo lang) {
            switch (lang.Iso639_3.ToLower()) {
                case "zho":
                    return Languages.ChineseSimplified;
                case "dan":
                    return Languages.Danish;
                case "deu":
                    return Languages.German;
                case "eng":
                    return Languages.English;
                case "fra":
                    return Languages.French;
                case "ita":
                    return Languages.Italian;
                case "jpa":
                    return Languages.Japanese;
                case "koa":
                    return Languages.Korean;
                case "nld":
                    return Languages.Dutch;
                case "nor":
                    return Languages.Norwegian;
                case "por":
                    return Languages.Portuguese;
                case "rus":
                    return Languages.Russian;
                case "spa":
                    return Languages.Spanish;
                case "swe":
                    return Languages.Swedish;
                default:
                    return Languages.Unknown;
            }
        }
    }
}
