using System;
using System.IO;
using System.Text.Json.Serialization;
using Nemandi.PluginBase;
using Nemandi.PluginBase.Configurations;
using Nemandi.Infrastructure;
using Nemandi.Core.PluginSupport;

namespace Nemandi.Core.PluginSupport.CSharp {
    public class CSharpPluginInfo : PluginInfo {

        public IPlugin Instance { get; set; }

        public override string FilePath { get; protected set; }
        public override string Name => Instance.Name;
        public override string Author => Instance.Author;
        public override string Website => Instance.Website;
        public override Version Version => Instance.Version;
        public override string Email => Instance.Email;
        public override string Description => Instance.Description;

        public override Languages SourceLang => Instance.SourceLang;
        public override Languages QueryLang => Instance.TargetLang;
        public override Features SupportedFeature => Instance.SupportedFeature;

        public override bool Enabled { get; set; }

        public CSharpPluginInfo(IPlugin instance, string path) {
            this.FilePath = path;
            this.Instance = instance;
        }
    }
}