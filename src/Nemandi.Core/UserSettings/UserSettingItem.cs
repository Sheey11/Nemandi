using System;
namespace Nemandi.Core.UserSettings {
    public class UserSettingItem : Attribute {
        public readonly string _AttributeName;
        public string AttributeName { get; set; }
        public UserSettingItem(string attributeName) {
            this.AttributeName = attributeName;
        }
    }
}
