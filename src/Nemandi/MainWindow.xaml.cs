using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Nemandi.Core.PluginSupport;
using Nemandi.Core.Querying;
using Nemandi.Infrastructure;
using Nemandi.Infrastructure.Words;
using Nemandi.MVVM;
using SourceChord.FluentWPF;

namespace Nemandi {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow {

        private bool _isExpanded = false;

        public ObservablePreviewWords PreviewWords { get; set; } = new ObservablePreviewWords();

        public MainWindow() {
            InitializeComponent();
            PluginManager.LoadFrom(System.IO.Path.GetFullPath("plugins/"));

            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            this.Top = (SystemParameters.WorkArea.Height - this.Height) / 2 - 100;
        }

        private void FoldWindow() {
            var heightAnime = new DoubleAnimation(
                this.ActualHeight,
                60d,
                new Duration(TimeSpan.FromSeconds(0.5)));
            heightAnime.EasingFunction = new SineEase();
            heightAnime.Completed += (sender, args) => { this._isExpanded = false; };

            this.BeginAnimation(AcrylicWindow.HeightProperty, heightAnime);
        }

        private void ExpandWindow() {
            var heightAnime = new DoubleAnimation(
                this.ActualHeight,
                400d,
                new Duration(TimeSpan.FromSeconds(0.5)));
            heightAnime.EasingFunction = new SineEase();
            heightAnime.Completed += (sender, args) => { this._isExpanded = true; };

            this.BeginAnimation(AcrylicWindow.HeightProperty, heightAnime);
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e) {
            //if (this._isExpanded)
            //    this.FoldWindow();
            //else
            //    this.ExpandWindow();

            if (QueryTextBox.Text == "" && this._isExpanded) {
                this.FoldWindow();
                return;
            }

            if (QueryTextBox.Text != "") {
                var queryText = QueryTextBox.Text;
                Task.Run(() => {
                     var words = Query.Autocomplete(queryText);
                     this.Dispatcher.Invoke(() => {
                         PreviewWords.PreviewWords = words;
                         if (words.Count > 0 && !this._isExpanded)
                             this.ExpandWindow();
                         else if(words.Count == 0 && this._isExpanded)
                             this.FoldWindow();
                     });
                });
            }

            //this.WordList = Nemandi.Core.
        }

        #region OBSOLETE

        [Obsolete]
        public Task<bool> ExpandWindowAsync() {
            var tsc = new TaskCompletionSource<bool>();

            var heightAnime = new DoubleAnimation(
                this.ActualHeight,
                400d,
                new Duration(TimeSpan.FromSeconds(0.5)));
            heightAnime.EasingFunction = new SineEase();
            heightAnime.Completed += (sender, args) => {
                this._isExpanded = true;
                tsc.SetResult(true);
            };

            this.BeginAnimation(AcrylicWindow.HeightProperty, heightAnime);

            return tsc.Task;
        }

        [Obsolete]
        public Task<bool> FoldWindowAsync() {
            var tsc = new TaskCompletionSource<bool>();

            var heightAnime = new DoubleAnimation(
                this.ActualHeight,
                60d,
                new Duration(TimeSpan.FromSeconds(0.5)));

            heightAnime.EasingFunction = new SineEase();
            heightAnime.Completed += (sender, args) => {
                this._isExpanded = false;
                tsc.SetResult(true);
            };

            this.BeginAnimation(AcrylicWindow.HeightProperty, heightAnime);

            return tsc.Task;
        }

        #endregion
    }
}
