using System;

namespace Nemandi.Base {
    /// <summary>
    /// Specify which feature the plugin support;
    /// </summary>
    public enum Features {
        Definition = 0x01,
        Pronunciation = 0x02,
        Phrase = 0x04,
        Infection = 0x08,
    }
}