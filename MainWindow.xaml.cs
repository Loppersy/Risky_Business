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
using Risky_Business;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;

namespace Risky_Business
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        // google APIKEY:AIzaSyC9qH7P3w_1iLRdIZ4iS8SYLNtZcThTCdI

        new string[] apiList =
            {"https://safebrowsing.googleapis.com/v4/threatMatches:find?key=AIzaSyC9qH7P3w_1iLRdIZ4iS8SYLNtZcThTCdI"};

        new string[] apiHeaderList = {null};

        string requestBody;
        // create list of APIs and their required content



        //BodyModel googleBody = new BodyModel();
        //googleBody.Client =  "\"client\": {\"clientId\": \"riskybusiness\", \"clientVersion\": \"0.3\" }, ";
        //googleBody.URL = 
        //google 

        //new BodyModel[] apiBodyList = { };

        //new string[] apiBodyList = { "\"client\": {\"clientId\": \"yourcompanyname\", \"clientVersion\": \"1.5.2\" }, \"threatInfo\": {\"threatTypes\": [\"MALWARE\"], \"platformTypes\": [\"WINDOWS\"],\"threatEntryTypes\": [\"URL\"],\"threatEntries\": [{\"url\": \"http://www.urltocheck1.org/ \"}]}}" };



        APICaller Caller = new APICaller();
        public static MainViewModel mainViewModel = new MainViewModel();

        public MainWindow()
        {

            InitializeComponent();


            //Source for changing views https://github.com/SingletonSean/wpf-tutorials/tree/master/SwitchingViewsMVVM
            DataContext = mainViewModel;

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

        private async void AnalyseButtonPressed(object sender, RoutedEventArgs e)
        {

            mainViewModel.UpdateViewCommand.Execute("Analysis");

            AnalysisButton.IsEnabled = false;
            IntroButton.IsEnabled = true;

            string input = "";

            input = IntroView.inputTextBox.Text;


            input = input.Trim();
            List<bool> isGoodList = null;

            input = $"https/{ input }";
            //check on https start? or otherwise good input?
            
             for (int iteration = 0; iteration < apiList.Length; iteration++)
             {
            
                 // Create a request to the API URL
                 HttpWebRequest request = (HttpWebRequest) WebRequest.Create(apiList[iteration]);
                 request.ContentType = "application/json";
                 // set content type, should be the same for all APIs
            
            
            
                 if (iteration == 0)
                 {
                     request.Method = "POST";
                     // create list of APIs and their required content
                     requestBody =
                         $"\"client\": {{\"clientId\": \"riskybusiness\", \"clientVersion\": \".3\" }}, \"threatInfo\": {{\"threatTypes\": [\"MALWARE\"], \"platformTypes\": [\"WINDOWS\"],\"threatEntryTypes\": [\"URL\"],\"threatEntries\": [{{\"url\": \"{input}\"}}]}}";
            
                 }
                 // if google API
            
            
                 if ((apiHeaderList[iteration]) != null)
                 {
                     request.Headers.Add(apiHeaderList[iteration]);
                 }
                 // add the header if necessary
            
                 // Execute the request and get the response            
                 // HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                 HttpResponseMessage responseMessage = await CallGateway.APIClient.GetAsync(apiList[iteration]);
            
                 if (responseMessage.IsSuccessStatusCode)
                 {
            
                     ResponseModel data = await responseMessage.Content.ReadAsAsync<ResponseModel>();
                     // Capture response data
            
                     isGoodList.Add(data.matches == null);
                     // if no hits in the malware database then perfect
                 }
                 else
                 {
                     throw new Exception(responseMessage.ReasonPhrase);
                     // create a reason labeled exception
            
                 }
            
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
            await Task.Delay(100);
            ///////
            // Test variables, replace with actual analysis output later
            string[] notes = {"All gucci","","Yes","idk rick, looks fake to me","ok sure"};
            int[] votes = {0, 2, 0,1,0};
            ///////
            
            AnalysisView.DisplayResults(input,votes,notes);
        }
    }
}