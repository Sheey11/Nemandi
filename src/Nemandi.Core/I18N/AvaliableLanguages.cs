using System;
using System.Linq;
using System.Collections.Generic;
using Nemandi.Infrastructure;

namespace Nemandi.Core.I18N {
    internal static class AvaliableLanguages {
        public static Language English = new Language("en", "English", Languages.English);
        public static Language ChineseSimplified = new Language("zh-cn", "中文（简体）", Languages.ChineseSimplified);
        public static Language ChineseTraditional = new Language("zh-tw", "中文（繁体）", Languages.ChineseTraditional);
        public static Language Japanese = new Language("ja", " 日本語 ", Languages.Japanese);

        public static List<Language> GetAvaliableLanguages() {
            return new List<Language>() {
                English,
                ChineseSimplified,
                ChineseTraditional,
                Japanese,
            };
        }

        public static Language GetLanguage(string code) {
            var langs = from lang
                        in GetAvaliableLanguages()
                        where lang.Code == code
                        select lang;

            return langs.First();
        }
    }
}
