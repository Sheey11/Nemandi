using System;
using System.Collections.Generic;
using Nemandi.PluginBase;

namespace Nemandi.Plugins.MojiJisho {
    class Result {
        public string originalSearchText { get; set; }
        public IList<SearchResult> searchResults { get; set; }
        public IList<SearchWord> words { get; set; }
    }
}
