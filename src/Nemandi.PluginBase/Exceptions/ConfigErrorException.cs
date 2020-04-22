using System;
namespace Nemandi.PluginBase.Exceptions {
    public class ConfigErrorException : Exception {
        public ConfigErrorException(string configName, string message) : base($"{configName} error, {message}"){ }
    }
}
