using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using Nemandi.Infrastructure.Words;
using Nemandi.CommonUtility;

namespace Nemandi.Plugins.MojiJisho {
    public static class MojiJishoInteraction {

        private static string AUTOCOMPLETE_URL = @"https://api.mojidict.com/parse/functions/search_v3";

        public static void Login() {
            throw new NotImplementedException();
        }

        public static List<PreviewWord> Autocomplete(string str, string session) {
            var memoryStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(memoryStream);
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("searchText", str);
            jsonWriter.WriteBoolean("needWords", true);
            jsonWriter.WriteString("langEnv", "zh-CN_ja");
            jsonWriter.WriteString("_ApplicationId", "E62VyFVLMiW7kvbtVq3p");
            if(session != null && session != "")
                jsonWriter.WriteString("_SessionToken", session);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();
            var json = Encoding.UTF8.GetString(memoryStream.ToArray());

            var retJson = Http.PostString(AUTOCOMPLETE_URL, json);
            var jsonDom = JsonDocument.Parse(retJson);
            var result = jsonDom.RootElement.GetProperty("result");

            var words = result.GetProperty("words").EnumerateArray();
            var ret = new List<PreviewWord>();
            foreach(var word in words) {
                var spell = word.GetProperty("spell").GetString();
                var pronunciation = word.GetProperty("pron").GetString();
                var accent = word.GetProperty("accent").GetString();
                var headword = $"{spell} | {pronunciation} {accent}";
                var exceprt = word.GetProperty("excerpt").GetString();
                var objId = word.GetProperty("objectId").GetString();

                var pw = new PreviewWord(headword, "", exceprt, objId);
                ret.Add(pw);
            }

            return ret;
        }
    }
}
