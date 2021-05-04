using Laughy.Adapter.ApiService.ApiModels;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace Laughy.Adapter.ApiService
{
    public class JokeProcessor
    { 
        //Methods
        public static async Task<JokeApiModel> LoadJoke()
        {
            string url = "https://jokeapi-v2.p.rapidapi.com/joke/Any?type=single%2Ctwopart&format=json";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "f532242162mshfcf7cd07f406465p146a68jsn307dbd577c73" },
                    { "x-rapidapi-host", "jokeapi-v2.p.rapidapi.com" },
                },
            };

            using (HttpResponseMessage response = ApiHelper.ApiClient.SendAsync(request).Result)
            {
                if(response.IsSuccessStatusCode)
                {
                    var responseAsString = await response.Content.ReadAsStringAsync();
                    var responseAsApiModel = JsonConvert.DeserializeObject<JokeApiModel>(responseAsString);

                    return responseAsApiModel;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
