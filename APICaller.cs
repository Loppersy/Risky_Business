using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Risky_Business
{
    public static class APICaller
    {


        // set guard properties



        public async Task<ResponseModel> ReturnStatus(string url0, string url1)
        {
            string apiUrl = url0;
            string targetUrl = url1;

            using (HttpResponseMessage response = await CallGateway.APIClient.GetAsync(apiUrl))
            // await a response from the api and record the response code
            {


                // set guard statements



                if(response.IsSuccessStatusCode)
                {
                    ResponseModel data = await response.Content.ReadAsAsync<ResponseModel>();
                    // Deal with reponse data

                    return data;
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
