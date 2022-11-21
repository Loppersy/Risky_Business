using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Risky_Business
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CallGateway.Initialize();


                       
        }
        
        private void txtSearch_TextChanged(Object sender, TextChangedEventArgs e)

        {
            TxtSearchPlaceholder.Visibility = TxtSearch.Text != "" ? Visibility.Hidden : Visibility.Visible;
        }

        private void RunButtonPressed(object sender, RoutedEventArgs e)
        {
            string input = TxtSearch.Text;
            input = input.Trim();

            //** Put code that uses input here**//


            private async Task GetData()
            {
                var data = await ReturnData(apiUrl, input);
                // unfinished
            }


        }
    }
}