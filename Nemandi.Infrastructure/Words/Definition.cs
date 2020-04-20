using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words{
    public class Definition{
        public string PrimaryDef { get; private set; }
        public List<ExampleSentence> ExampleSentences { get; private set;}

        public Definition(string def, List<ExampleSentence> exampleSentences){
            this.PrimaryDef = def;
            this.ExampleSentences = exampleSentences;
        }
    }
}
