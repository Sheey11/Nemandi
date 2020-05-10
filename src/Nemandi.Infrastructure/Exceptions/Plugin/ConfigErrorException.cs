using System;
namespace Nemandi.Infrastructure.Exceptions.Plugin {
    public class ConfigErrorException : Exception {
        public ConfigErrorException(string configName, string message) : base($"{configName} error, {message}"){ }
    }
}
