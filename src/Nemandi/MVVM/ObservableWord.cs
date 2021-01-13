using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Nemandi.Infrastructure.Words;

namespace Nemandi.MVVM {
    public class ObservableWord : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private Word _word;

        public Word Word {
            get => _word;
            set {
                _word = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
