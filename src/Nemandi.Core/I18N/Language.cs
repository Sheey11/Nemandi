using System;
using Nemandi.Infrastructure;

namespace Nemandi.Core.I18N {
    public class Language {
        public string Code { get; internal set; }
        public string DisplayName { get; internal set; }
        public Languages Lang { get; internal set; }

        /// <summary>
        /// Construct a new <see cref="Language"/> class.
        /// </summary>
        /// <param name="code">Language code. Eg. zh-cn</param>
        /// <param name="displayName">Language name in its languages.</param>
        /// <param name="lang">Corresponding language in <seealso cref="Languages"/>.</param>
        public Language(string code, string displayName, Languages lang) {
            this.Code = code;
            this.DisplayName = displayName;
            this.Lang = lang;
        }
    }
}
