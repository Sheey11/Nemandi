using System;
using System.Collections.Generic;

namespace Nemandi.Base.Words {
    public class Word {
        public string HeadWord { get; private set; }
        public string POS { get; private set; }
        public List<string> Tags { get; private set; }
        public List<Pronunciation> Pronunciations { get; private set; }
        public List<Definition> Definitions { get; private set; }

    }
}