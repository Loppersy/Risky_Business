using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Risky_Business
{
    public static class CallGateway
    {
        public static HttpClient APIClient { get; set; }
        // set up client, one per session (thread safe, multiple call handling)

        public static void Initialize()
        {
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
