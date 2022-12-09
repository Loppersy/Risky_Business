using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Risky_Business.Commands;
using Risky_Business.ViewModels;
using Risky_Business.Views;

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
            
            //Source for changing views https://github.com/SingletonSean/wpf-tutorials/tree/master/SwitchingViewsMVVM
            DataContext = new MainViewModel();
            

            CallGateway.Initialize();



        }

        private void IntroButtonPressed(object sender, RoutedEventArgs e)
        {
            IntroButton.IsEnabled = false;
        }

        public bool IsAnalyseButtonEnabled
        {
            get => AnalysisButton.IsEnabled;
            set => AnalysisButton.IsEnabled = value;
        }

        private void AnalyseButtonPressed(object sender, RoutedEventArgs e)
        {
            AnalysisButton.IsEnabled = false;
            IntroButton.IsEnabled = true;
            
            string input = "";

            input = IntroView.inputTextBox.Text;

            
            input = input.Trim();
            Trace.WriteLine(input);
            //** Put code that uses input here**//
        
        
            async Task GetData()
            {
                ////// Testing string just so that the program is able to compile
                string apiUrl = "epicGoogleAPI";
                //////
                
                
                var data = await APICaller.ReturnData(apiUrl, input);
                // unfinished
            }
            
        }
    }
}