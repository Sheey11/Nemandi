using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.PluginBase.Configurations;

namespace Nemandi.PluginBase {
    /// <summary>
    /// Nemandi plugin interface.
    /// </summary>
    public interface IPlugin {
        /// <summary>
        /// Plugin name.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Plugin author.
        /// </summary>
        string Author { get; }
        /// <summary>
        /// Plugin website.
        /// </summary>
        string Website { get; }
        /// <summary>
        /// Version of the plugin.
        /// </summary>
        Version Version { get; }
        /// <summary>
        /// Author's email.
        /// </summary>
        string Email { get; }
        /// <summary>
        /// Description of this plugin.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The language used to query.
        /// </summary>
        Languages SourceLang { get; }
        /// <summary>
        /// The language used to explain the word.
        /// </summary>
        Languages TargetLang { get; }
        /// <summary>
        /// Features this plugin support.
        /// </summary>
        Features SupportedFeature { get; }

        /// <summary>
        /// This method will be called when the plugin is being initilized.
        /// </summary>
        /// <param name="context"></param>
        void OnInit(PluginInitContext context);
        /// <summary>
        /// When the user is typing, this method will be called to autocomplete user's input.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        List<PreviewWord> Autocomplete(string queryString);
        /// <summary>
        /// When the user seleted a word, this method will be called to look up details.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        Word Query(PreviewWord word);

        Task<List<PreviewWord>> AutocompleteAsync(string queryString) {
            return Task.Run(() => Autocomplete(queryString));
        }

        Task<Word> QueryAsync(PreviewWord word) {
            return Task.Run(() => Query(word));
        }
    }
}
