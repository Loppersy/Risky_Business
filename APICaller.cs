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
        public async Task ReturnStatus(string url0, string url1)
        {
            string apiUrl = url0;
            string targetUrl = url1;

            using (HttpResponseMessage response = await CallGateway.APIClient.GetAsync(apiUrl))
            // await a response from the api and record the response code
            {
                if(response.IsSuccessStatusCode)
                {
                    // Deal with returned data
                }
            }
        }
    }
}
