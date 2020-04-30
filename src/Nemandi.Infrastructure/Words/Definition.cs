using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words{
    public class Definition{
        /// <summary>
        /// The definition using TargetLanguage, see also <seealso cref="BilingualDefinition"/>.
        /// </summary>
        public string PrimaryDef { get; private set; }
        /// <summary>
        /// Example sentences.
        /// </summary>
        public List<ExampleSentence> ExampleSentences { get; private set;}

        /// <summary>
        /// Construct a new <see cref="Definition"/> class.
        /// </summary>
        /// <param name="def"></param>
        /// <param name="exampleSentences"></param>
        public Definition(string def, List<ExampleSentence> exampleSentences){
            this.PrimaryDef = def;
            this.ExampleSentences = exampleSentences;
        }
    }
}
