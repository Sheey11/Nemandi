using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words {
    public class PartOfSpeech {
        public string POS { get; set; }
        public List<Definition> Definitions;

        public PartOfSpeech(string pos, List<Definition> defs) {
            this.POS = pos;
            this.Definitions = defs;
        }
    }
}
