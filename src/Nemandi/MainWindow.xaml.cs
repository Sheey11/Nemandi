using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using SourceChord.FluentWPF;

namespace Nemandi {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow {

        private bool isExpanded = false;

        public MainWindow() {
            InitializeComponent();

            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            this.Top = (SystemParameters.WorkArea.Height - this.Height) / 2 - 100;
        }

        public Task<bool> ExpandsWindowAsync() {
            var tsc = new TaskCompletionSource<bool>();

            var heightAnime = new DoubleAnimation(
                this.ActualHeight,
                400d,
                new Duration(TimeSpan.FromSeconds(0.5)));
            heightAnime.EasingFunction = new SineEase();
            heightAnime.Completed += (sender, args) => {
                this.isExpanded = true;
                tsc.SetResult(true);
            };

            this.BeginAnimation(AcrylicWindow.HeightProperty, heightAnime);

            return tsc.Task;
        }

        public Task<bool> FoldWindowAsync() {
            var tsc = new TaskCompletionSource<bool>();

            var heightAnime = new DoubleAnimation(
                this.ActualHeight,
                60d,
                new Duration(TimeSpan.FromSeconds(0.5)));

            heightAnime.EasingFunction = new SineEase();
            heightAnime.Completed += (sender, args) => {
                this.isExpanded = false;
                tsc.SetResult(true);
            };

            this.BeginAnimation(AcrylicWindow.HeightProperty, heightAnime);

            return tsc.Task;
        }

        private async void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e) {
            if (this.isExpanded)
                await this.FoldWindowAsync();
            else
                await this.ExpandsWindowAsync();
        }
    }
}
