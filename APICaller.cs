using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Risky_Business
{
    public class APICaller
    {


        // set guard properties



        public async Task<ResponseModel> ReturnData(string url, string header)
        {
            string apiUrl = url;
            string apiHeader = header;

            using (HttpResponseMessage response = await CallGateway.APIClient.GetAsync(apiUrl))
            // await a response from the api and record the response code
            {


                if (response.IsSuccessStatusCode)
                {
                    ResponseModel data = await response.Content.ReadAsAsync<ResponseModel>();
                    // Deal with reponse data

                    return data;
                    if (data.)
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                    // create a reason labeled exception
                }
            }
        }
    }
}
