using System;
using System.Collections.Generic;
using Nemandi.Base;
using Nemandi.Base.Words;

namespace Nemandi.PluginBase {
    public interface IPlugin {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        string Email { get; }
        string Description { get; }
        
        Languages SourceLang { get; }
        Languages QueryLang { get; }
        Features SupportedFeature { get; }
        
        void OnInit();
        List<PreviewWord> Autocomplete(string queryString);
        List<Word> Query(PreviewWord word);
    }
}
