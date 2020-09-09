using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words {
    public class Phrase {
        /// <summary>
        /// Phrase.
        /// </summary>
        public string Ph { get; set; }
        /// <summary>
        /// Explanation.
        /// </summary>
        public string Explanation { get; set; }
        /// <summary>
        /// Example Sentences.
        /// </summary>
        public List<ExampleSentence> ExampleSentence { get; set; }

        public Phrase(string phrase, string explanation, List<ExampleSentence> sentences) {
            this.Ph = phrase;
            this.Explanation = explanation;
            this.ExampleSentence = sentences;
        }

        public Phrase(string phrase, string explanation) {
            this.Ph = phrase;
            this.Explanation = explanation;
        }
    }
}