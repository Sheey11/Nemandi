using System;
using System.Collections.Generic;
using Nemandi.PluginBase;

namespace Nemandi.Plugins.MojiJisho {
    class SearchResult {
        public string searchText { get; set; }
        public int count { get; set; }
        public string tarId { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string objectId { get; set; }
    }
}
