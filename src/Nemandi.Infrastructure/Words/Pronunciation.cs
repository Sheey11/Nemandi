using System;

namespace Nemandi.Infrastructure.Words {
    public class Pronunciation {
        public string Pronun { get; internal set; }
        public string PronunUrl { get; internal set; }

        public Pronunciation(string pronun, string url) {
            this.Pronun = pronun;
            this.PronunUrl = url;
        }
    }
}
