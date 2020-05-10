using System;
namespace Nemandi.Core.I18N {
    public class I18NManager {
        // TODO
        private Language lang { get; set; }
        public I18NManager(string languageCode = "en") {
            this.lang = AvaliableLanguages.GetLanguage(languageCode);
        }

        public string AquireString(string strCode) {
            // TODO
            throw new NotImplementedException();
        }
    }
}
