using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        new string[] apiList = { "https://safebrowsing.googleapis.com/v4/threatMatches:find?key=AIzaSyC9qH7P3w_1iLRdIZ4iS8SYLNtZcThTCdI" };
        new string[] apiHeaderList = { null };
        string requestBody;
        // create list of APIs and their required content



        //BodyModel googleBody = new BodyModel();
        //googleBody.Client =  "\"client\": {\"clientId\": \"riskybusiness\", \"clientVersion\": \"0.3\" }, ";
        //googleBody.URL = 
        //google 

        //new BodyModel[] apiBodyList = { };

        //new string[] apiBodyList = { "\"client\": {\"clientId\": \"yourcompanyname\", \"clientVersion\": \"1.5.2\" }, \"threatInfo\": {\"threatTypes\": [\"MALWARE\"], \"platformTypes\": [\"WINDOWS\"],\"threatEntryTypes\": [\"URL\"],\"threatEntries\": [{\"url\": \"http://www.urltocheck1.org/ \"}]}}" };



        APICaller Caller = new APICaller();
        public MainWindow()
        {
            InitializeComponent();
            CallGateway.Initialize();


                       
        }
        
        private void txtSearch_TextChanged(Object sender, TextChangedEventArgs e)

        {
            TxtSearchPlaceholder.Visibility = TxtSearch.Text != "" ? Visibility.Hidden : Visibility.Visible;
        }

        private async Task RunButtonPressedAsync(object sender, RoutedEventArgs e)
        {
            string input = TxtSearch.Text;
            input = input.Trim();
            List<bool> isGoodList;

            //input = $"https/{ input }";
            //check on https start? or otherwise good input?

            for (int iteration = 0; iteration < apiList.Length; iteration++)
            {

                // Create a request to the API URL
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiList[iteration]);
                request.ContentType = "application/json";
                // set content type, should be the same for all APIs
                


                if (iteration == 0)
                {
                    request.Method = "POST";
                    // create list of APIs and their required content
                    requestBody =  $"\"client\": {{\"clientId\": \"riskybusiness\", \"clientVersion\": \".3\" }}, \"threatInfo\": {{\"threatTypes\": [\"MALWARE\"], \"platformTypes\": [\"WINDOWS\"],\"threatEntryTypes\": [\"URL\"],\"threatEntries\": [{{\"url\": \"{ input }\"}}]}}";

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

                

                // Get the response stream and read it into a string
                //StreamReader responseReader = new StreamReader(response.GetResponseStream());
                //string responseData = responseReader.ReadToEnd();

                //** Put code that uses input here**//





                //private async Task GetData()
                //{
                //    var data = await ReturnData(apiUrl, input);
                //     unfinished
                //}



            }
    }
}