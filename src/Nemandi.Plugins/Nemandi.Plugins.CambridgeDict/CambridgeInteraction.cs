using System;
using System.Collections.Generic;
using Nemandi.Infrastructure.Words;
using Nemandi.Infrastructure.CommonUtilities;
using System.Web;
using System.Text.Json;

namespace Nemandi.Plugins.CambridgeDict {
    internal static class CambridgeInteraction {

        internal static string AUTOCOMPLETE_URL = @"https://dictionary.cambridge.org/autocomplete/amp?dataset=english-chinese-simplified&q=";

        internal static List<PreviewWord> Autocomplete(string query) {
            query = HttpUtility.UrlEncode(query);

            var json = Http.GetString(AUTOCOMPLETE_URL + query);
            var jsonDoc = JsonDocument.Parse(json);
            var wordlist = jsonDoc.RootElement.EnumerateArray();

            var retPW = new List<PreviewWord>();
            foreach(var word in wordlist) {
                retPW.Add(new PreviewWord(
                    word.GetProperty("word").GetString(),
                    "",
                    "",
                    word.GetProperty("url").GetString()
                    ));
            }

            return retPW;
        }

        internal static Word Query(PreviewWord word) {
            throw new NotImplementedException();
        }
    }
}
