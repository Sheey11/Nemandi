using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words{
    public class BilingualDefinition : Definition{
        /// <summary>
        /// The definition using the SourceLanguage, see also <seealso cref="Definition"/>.
        /// </summary>
        public string SecondaryDef { get; private set; }

        /// <summary>
        /// Construct a new <see cref="BilingualDefinition"/>.
        /// </summary>
        /// <param name="primaryDef"></param>
        /// <param name="secondaryDef"></param>
        /// <param name="exampleSentences"></param>
        public BilingualDefinition(string primaryDef, string secondaryDef, List<ExampleSentence> exampleSentences) : base(primaryDef, exampleSentences){
            this.SecondaryDef = secondaryDef;
        }
    }
}