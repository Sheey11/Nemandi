using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Nemandi.Infrastructure.Words;

namespace Nemandi.MVVM {
    public class ObservablePreviewWords : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PreviewWord> _previewWords;

        public List<PreviewWord> PreviewWords {
            get => _previewWords;
            set {
                _previewWords = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
