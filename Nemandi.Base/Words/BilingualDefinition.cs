using System;
using System.Collections.Generic;

namespace Nemandi.Base.Words{
    public class BilingualDefinition : Definition{
        public string SecondaryDef { get; private set; }

        public BilingualDefinition(string primaryDef, string secondaryDef, List<ExampleSentence> exampleSentences) : base(primaryDef, exampleSentences){
            this.SecondaryDef = secondaryDef;
        }
    }
}