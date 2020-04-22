using System;

namespace Nemandi.PluginBase.Configurations {
    public delegate void ValueChangedHandler(ConfigurationItem item, object value, bool isInit = false);
}
