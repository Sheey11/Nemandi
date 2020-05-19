using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Nemandi.Core.PluginSupport;
using Nemandi.PluginBase;

namespace Nemandi.Test.Plugins {
    public static class PluginTest {
        public static string PluginFolder = Path.GetFullPath("plugins/");
        public static PluginsManager PluginManager = new PluginsManager(PluginFolder);
        public static List<PluginInfo> LoadedPlugin = PluginManager.LoadPlugins().Loaded;
    }
}
