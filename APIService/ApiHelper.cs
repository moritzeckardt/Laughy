using System.Net.Http;
using System.Net.Http.Headers;

namespace Laughy.Adapter.ApiService
{
    public class ApiHelper
    {
        //Properties
        public static HttpClient ApiClient { get; set; } // HttpClient once per application (one browser) -> static -> unusual


        //Methods
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new System.Uri(""); -> In case you call only one API (one website)
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}
