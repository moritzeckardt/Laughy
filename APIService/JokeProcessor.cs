using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Laughy.Models.DomainModels;
using Laughy.Adapter.ApiService.ApiModels;
using Laughy.Adapter.ApiService.Mapper.Interfaces;

namespace Laughy.Adapter.ApiService.Contracts
{
    public class JokeProcessor : IJokeProcessor
    {
        //Fields
        private readonly IJokeAdapterMapper _jokeAdapterMapper;


        //Properties
        public JokeApiModel JokeApiModel { get; set; } = new JokeApiModel();


        //Constructor
        public JokeProcessor(IJokeAdapterMapper jokeAdapterMapper)
        {
            //Assignments
            _jokeAdapterMapper = jokeAdapterMapper;
        }


        //Methods
        public async Task<JokeDomainModel> GetJokeByCategory(string category)
        {
            string urlToBeEdited = "https://jokeapi-v2.p.rapidapi.com/joke/ToBeEdited?type=single%2Ctwopart&format=json";

            string url = urlToBeEdited.Replace("ToBeEdited", category);

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

            using (var response = ApiHelper.ApiClient.SendAsync(request).Result)
            {
                if(response.IsSuccessStatusCode)
                {
                    var jokeAsString = await response.Content.ReadAsStringAsync();

                    JokeApiModel = JsonConvert.DeserializeObject<JokeApiModel>(jokeAsString);

                    JokeApiModel.DbId = Guid.NewGuid();

                    var jokeDomainModel = _jokeAdapterMapper.MapToDomainModel(JokeApiModel);

                    return jokeDomainModel;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
