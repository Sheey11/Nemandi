using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words {
    public class Word {
        /// <summary>
        /// The word.
        /// </summary>
        public string HeadWord { get; private set; }
        /// <summary>
        /// Tags you may want to show, eg. Oxford 3000.
        /// </summary>
        public List<string> Tags { get; private set; }
        /// <summary>
        /// Inflections of the word.
        /// </summary>
        public Dictionary<string, string> Inflections { get; private set; }
        /// <summary>
        /// List of <see cref="Pronunciation"/>.
        /// </summary>
        public List<Pronunciation> Pronunciations { get; private set; }
        /// <summary>
        /// List of <see cref="PartOfSpeech"/>.
        /// </summary>
        public List<PartOfSpeech> PartOfSpeeches { get; private set; }

        /// <summary>
        /// Construct a new <see cref="Word"/> class.
        /// </summary>
        /// <param name="headWord"></param>
        /// <param name="pronunciations"></param>
        /// <param name="pos"></param>
        /// <param name="tags"></param>
        /// <param name="transformations"></param>
        public Word(string headWord, List<Pronunciation> pronunciations, List<PartOfSpeech> pos, List<string> tags = null, Dictionary<string, string> transformations = null) {
            this.HeadWord = headWord;
            this.Pronunciations = pronunciations;
            this.PartOfSpeeches = pos;
            this.Tags = tags;
            this.Inflections = transformations;
        }
    }
}
