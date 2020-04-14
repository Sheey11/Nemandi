using System;
using System.Collections.Generic;

namespace Nemandi.Base.Words {
    public class Word {
        public string HeadWord { get; private set; }
        public List<string> Tags { get; private set; }
        public Dictionary<string, string> Inflection { get; private set; }
        public List<Pronunciation> Pronunciations { get; private set; }
        public List<PartOfSpeech> PartOfSpeeches { get; private set; }

        public Word(string headWord, List<Pronunciation> pronunciations, List<PartOfSpeech> pos, List<string> tags = null, Dictionary<string, string> transformations = null) {
            this.HeadWord = headWord;
            this.Pronunciations = pronunciations;
            this.PartOfSpeeches = pos;
            this.Tags = tags;
            this.Inflection = transformations;
        }
    }
}
