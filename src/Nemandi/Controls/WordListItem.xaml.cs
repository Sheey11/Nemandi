using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nemandi {
    /// <summary>
    /// WordList.xaml 的交互逻辑
    /// </summary>
    public partial class WordListItem : UserControl {
        public static readonly DependencyProperty HeadWordProperty = 
            DependencyProperty.Register(
                "HeadWord",
                typeof(string),
                typeof(WordListItem)
            );
        public static readonly DependencyProperty POSProperty =
            DependencyProperty.Register(
                "POS",
                typeof(string),
                typeof(WordListItem)
            );
        public static readonly DependencyProperty PreviewDefProperty =
            DependencyProperty.Register(
                "PreviewDef",
                typeof(string),
                typeof(WordListItem)
            );

        
        public string HeadWord {
            get => (string) GetValue(HeadWordProperty);
            set => SetValue(HeadWordProperty, value);
        }
        public string POS {
            get => (string)GetValue(POSProperty);
            set => SetValue(POSProperty, value);
        }
        public string PreviewDef {
            get => (string)GetValue(PreviewDefProperty);
            set => SetValue(PreviewDefProperty, value);
        }

        public WordListItem() {
            InitializeComponent();
        }
    }
}
