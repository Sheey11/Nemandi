using System;
using System.Collections.Generic;
using Nemandi.PluginBase;

namespace Nemandi.Plugins.MojiJisho {
    class SearchWord {
        public string excerpt { get; set; }
        public string spell { get; set; }
        public string accent { get; set; }
        public string pron { get; set; }
        public string romaji { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string objectId { get; set; }
    }
}
