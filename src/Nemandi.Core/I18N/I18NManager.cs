using System;
namespace Nemandi.Core.I18N {
    public class I18NManager {
        // TODO
        private Language Lang { get; set; }
        public I18NManager(string languageCode = "en") {
            this.Lang = AvaliableLanguages.GetLanguage(languageCode);
        }

        public string AquireString(string strCode) {
            // TODO
            throw new NotImplementedException();
        }
    }
}
