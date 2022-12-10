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

        private void OpenGitHub(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Loppersy/Risky_Business");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode==-2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}