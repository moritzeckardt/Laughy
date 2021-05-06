using Laughy.Adapter.ApiService.ApiModels;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Laughy.Models.DomainModels;
using Laughy.Adapter.ApiService.Mapper;
using Laughy.Adapter.ApiService.Mapper.Interfaces;
using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;

namespace Laughy.Adapter.ApiService.Contracts
{
    public class JokeProcessor : IJokeProcessor
    {
        //Fields
        private readonly IJokeAdapterMapper _jokeAdapterMapper;


        //Constructor
        public JokeProcessor(IJokeAdapterMapper jokeAdapterMapper)
        {
            _jokeAdapterMapper = jokeAdapterMapper;
        }


        //Methods
        public async Task<JokeDomainModel> GetRandomJoke()
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

            using (var response = ApiHelper.ApiClient.SendAsync(request).Result)
            {
                if(response.IsSuccessStatusCode)
                {
                    var jokeAsString = await response.Content.ReadAsStringAsync();

                    var jokeApiModel = JsonConvert.DeserializeObject<JokeApiModel>(jokeAsString);

                    var jokeDomainModel = _jokeAdapterMapper.MapToDomainModel(jokeApiModel);

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
