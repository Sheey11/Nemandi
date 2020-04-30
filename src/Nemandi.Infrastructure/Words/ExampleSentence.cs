using System;

namespace Nemandi.Infrastructure.Words{
    public class ExampleSentence {
        /// <summary>
        /// The sentence.
        /// </summary>
        public string Sentence { get; internal set; }
        /// <summary>
        /// The translation of that sentence.
        /// </summary>
        public string Translation { get; internal set; }

        /// <summary>
        /// Construct a new <see cref="ExampleSentence"/> class.
        /// </summary>
        /// <param name="sentence">
        /// The sentence.
        /// </param>
        /// <param name="translation">
        /// The translation of that sentence.
        /// </param>
        public ExampleSentence(string sentence, string translation){
            this.Sentence = sentence;
            this.Translation = translation;
        }
    }
}