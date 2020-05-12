using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using Nemandi.Infrastructure.Words;
using Nemandi.Infrastructure.CommonUtilities;

namespace Nemandi.Plugins.MojiJisho {
    internal static class MojiJishoInteraction {

        private static string AUTOCOMPLETE_URL = @"https://api.mojidict.com/parse/functions/search_v3";
        private static string QUERY_WORDS_URL = @"https://api.mojidict.com/parse/functions/fetchWord_v2";

        internal static void Login() {
            // TODO
            throw new NotImplementedException();
        }

        internal static List<PreviewWord> Autocomplete(string str, string session) {
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

        internal static Word QueryWords(string objId, string session) {
            var memStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(memStream);
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("wordId", objId);
            jsonWriter.WriteString("_ApplicationId", "E62VyFVLMiW7kvbtVq3p");
            if (session != null && session != "")
                jsonWriter.WriteString("_SessionToken", session);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();
            var json = Encoding.UTF8.GetString(memStream.ToArray());

            var retJson = Http.Post(QUERY_WORDS_URL, json);
            var jsonDom = JsonDocument.Parse(retJson);
            var result = jsonDom.RootElement.GetProperty("result");

            var word = result.GetProperty("word");
            var details = result.GetProperty("details").EnumerateArray();
            var subdetails = result.GetProperty("subdetails").EnumerateArray();
            var examples = result.GetProperty("examples").EnumerateArray();

            // word properties
            var retHeadword = word.GetProperty("spell").GetString();
            var retPronunciation = word.GetProperty("pron").GetString();
            var retTone = word.GetProperty("accent").GetString();

            var retPoses = new List<PartOfSpeech>();

            // find all pos
            foreach(var detail in details) {
                var retPos = detail.GetProperty("title").GetString();
                var posId = detail.GetProperty("objectId").GetString();

                var sub = from subdetail
                          in subdetails
                          where subdetail.GetProperty("detailsId").GetString() == posId
                          select subdetail;

                var retDefines = new List<Definition>();

                // find all defines
                foreach (var subdetail in sub) {
                    var retDefine = subdetail.GetProperty("title").GetString();
                    var defineId = subdetail.GetProperty("objectId").GetString();

                    var exps = from example
                               in examples
                               where example.GetProperty("subdetailsId").GetString() == defineId
                               select example;

                    var retExampleSentences = new List<ExampleSentence>();

                    // find all example sentences
                    foreach (var exp in exps) {
                        var retSentence = exp.GetProperty("title").GetString();
                        var retTranslation = exp.GetProperty("trans").GetString();

                        retExampleSentences.Add(new ExampleSentence(retSentence, retTranslation));
                    }
                    retDefines.Add(new Definition(retDefine, retExampleSentences));
                }
                retPoses.Add(new PartOfSpeech(retPos, retDefines));
            }

            var pronunciations = new List<Pronunciation>() {
                new Pronunciation ("", $"{retPronunciation} {retTone}", "")
            };

            return new Word(retHeadword, pronunciations, retPoses);
        }
    }
}
