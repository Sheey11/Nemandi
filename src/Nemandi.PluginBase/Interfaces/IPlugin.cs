using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.PluginBase {
    public interface IPlugin {
        string Name { get; }
        string Author { get; }
        string Website { get; }
        Version Version { get; }
        string Email { get; }
        string Description { get; }
        
        Languages SourceLang { get; }
        Languages QueryLang { get; }
        Features SupportedFeature { get; }
        
        void OnInit(PluginInitContext context);
        List<PreviewWord> Autocomplete(string queryString);
        List<Word> Query(PreviewWord word);

        Task<List<PreviewWord>> AutocompleteAsync(string queryString) {
            return Task.Run(() => Autocomplete(queryString));
        }

        Task<List<Word>> QueryAsync(PreviewWord word) {
            return Task.Run(() => Query(word));
        }
    }
}
