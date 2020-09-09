using System;
using System.IO;
using System.Text.Json.Serialization;
using Nemandi.PluginBase;
using Nemandi.PluginBase.Configurations;
using Nemandi.Infrastructure;
using Nemandi.Core.PluginSupport.CSharp;

namespace Nemandi.Core.PluginSupport {
    public abstract class PluginInfo {
        public abstract string FilePath { get; protected set; }
        public abstract string Name { get; }
        public abstract string Author { get; }
        public abstract string Website { get; }
        public abstract Version Version { get; }
        public abstract string Email { get; }
        public abstract string Description { get; }

        public abstract Languages SourceLang { get; }
        public abstract Languages QueryLang { get; }
        public abstract Features SupportedFeature { get; }

        public abstract bool Enabled { get; set; }

        public static CSharpPluginInfo CreateCSharpPluginInfo(IPlugin instance, string path) {
            return new CSharpPluginInfo(instance, path);
        }
    }
}