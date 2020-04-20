using System;
using Nemandi.PluginBase;

namespace Nemandi.Plugins.MojiJisho {
    public partial class MojiJishoPlugin : IPlugin {
        struct SearchData {
            public string searchText;
            public static bool needWords = true;
            public static string langEnv = "zh-CN_ja";
            public static string _ApplicationId = "E62VyFVLMiW7kvbtVq3p";
            public static string _ClientVersion = "js2.10.0";
            public static string _InstallationId = "b200eee6-4ff3-44c0-a916-9a75336be5c0";
            public static string _SessionToken = "";
        }
    }
}