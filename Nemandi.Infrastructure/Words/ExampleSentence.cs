using System;

namespace Nemandi.Infrastructure.Words{
    public class ExampleSentence {
        public string Sentence { get; internal set; }
        public string Translation { get; internal set; }

        public ExampleSentence(string sentence, string translation){
            this.Sentence = sentence;
            this.Translation = translation;
        }
    }
}