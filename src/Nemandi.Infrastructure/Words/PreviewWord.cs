using System;

namespace Nemandi.Infrastructure.Words {
    public class PreviewWord {
        /// <summary>
        /// The word.
        /// </summary>
        public string HeadWord { get; private set; }
        /// <summary>
        /// Part of speech.
        /// </summary>
        public string POS { get; private set; }
        /// <summary>
        /// Preview definition.
        /// </summary>
        public string PreviewDef { get; private set; }
        /// <summary>
        /// Other properties.
        /// </summary>
        public object Props { get; set; }

        /// <summary>
        /// Construct a new <see cref="PreviewWord"/> class.
        /// </summary>
        /// <param name="headWord">
        /// The word.
        /// </param>
        /// <param name="pos">
        /// Part of speech.
        /// </param>
        /// <param name="previewDef">
        /// Preview definition.
        /// </param>
        /// <param name="props">
        /// Other properties.
        /// </param>
        public PreviewWord(string headWord, string pos = "", string previewDef = "", object props = null){
            this.HeadWord = headWord;
            this.POS = pos;
            this.PreviewDef = previewDef;
            this.Props = props;
        }
    }
}