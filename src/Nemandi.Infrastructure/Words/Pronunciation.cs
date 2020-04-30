using System;

namespace Nemandi.Infrastructure.Words {
    public class Pronunciation {
        /// <summary>
        /// Specify the indentity of pronunciation, eg. BrE, AmE.
        /// </summary>
        public string Identity { get; internal set; }
        /// <summary>
        /// Pronunciation, eg. phonetic symbol, romanji.
        /// </summary>
        public string Pronun { get; internal set; }
        /// <summary>
        /// The URL to the pronuncaition sound.
        /// </summary>
        public string PronunUrl { get; internal set; }

        /// <summary>
        /// Construct a new <see cref="Pronunciation"/> class.
        /// </summary>
        /// <param name="identity">
        /// Specify the indentity of pronunciation, eg. BrE, AmE. 
        /// Set to empty if there is only one pronunciation.
        /// </param>
        /// <param name="pronun">
        /// Pronunciation, eg. phonetic symbol, romanji.
        /// </param>
        /// <param name="url">
        /// The URL to the pronuncaition sound.
        /// </param>
        public Pronunciation(string identity, string pronun, string url) {
            this.Identity = identity;
            this.Pronun = pronun;
            this.PronunUrl = url;
        }
    }
}
