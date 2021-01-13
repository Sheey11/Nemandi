using System;
using System.Collections.Generic;

namespace Nemandi.Infrastructure.Words {
    public class PartOfSpeech {
        /// <summary>
        /// Part of speech.
        /// </summary>
        public string POS { get; set; }
        /// <summary>
        /// Definitions under this part of speech.
        /// </summary>
        public List<Definition> Definitions { get; set; }

        /// <summary>
        /// Construct a new <see cref="PartOfSpeech"/> class.
        /// </summary>
        /// <param name="pos">
        /// Part of speech.
        /// </param>
        /// <param name="defs">
        /// Definitions.
        /// </param>
        public PartOfSpeech(string pos, List<Definition> defs) {
            this.POS = pos;
            this.Definitions = defs;
        }
    }
}
