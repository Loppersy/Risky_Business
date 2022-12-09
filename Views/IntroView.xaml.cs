using System;
using System.Windows;
using System.Windows.Controls;
using Risky_Business.ViewModels;

namespace Risky_Business.Views
{
    public partial class IntroView : UserControl
    {
        public static TextBox inputTextBox;
        public IntroView()
        {
            InitializeComponent();

            inputTextBox = TxtSearch;
        }
        
        private void txtSearch_TextChanged(Object sender, TextChangedEventArgs e)

        {
            TxtSearchPlaceholder.Visibility = TxtSearch.Text != "" ? Visibility.Hidden : Visibility.Visible;
            (Application.Current.MainWindow as MainWindow).IsAnalyseButtonEnabled = TxtSearch.Text != "";
        }
    }
}