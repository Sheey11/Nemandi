using System;

namespace Nemandi.PluginBase.Exceptions {
    public class InternalErrorExecption : Exception {
        public bool CanIgnore { get; internal set; }

        public InternalErrorExecption(string msg, bool canIgnore) : base(msg) {
            this.CanIgnore = canIgnore;
        }
    }
}
