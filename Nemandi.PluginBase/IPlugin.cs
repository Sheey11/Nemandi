using System;
using System.Collections.Generic;
using Nemandi.Base;
using Nemandi.Base.Words;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.PluginBase {
    public interface IPlugin {
        string Name { get; }
        string Author { get; }
        string Website { get; }
        Version Version { get; }
        string Email { get; }
        string Description { get; }

        List<ConfigurationItem> ConfigurationItems { get; }
        
        Languages SourceLang { get; }
        Languages QueryLang { get; }
        Features SupportedFeature { get; }
        
        void OnInit();
        List<PreviewWord> Autocomplete(string queryString);
        List<Word> Query(PreviewWord word);
    }
}
