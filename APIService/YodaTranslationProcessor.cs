using Laughy.Adapter.ApiService.ApiModels;
using Laughy.Adapter.ApiService.Contracts;
using Laughy.Adapter.ApiService.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Laughy.Adapter.ApiService
{
    public class YodaTranslationProcessor : IYodaTranslationProcessor
    {
        //Fields
        private readonly IYodaTranslationAdapterMapper _yodaTranslationAdapterMapper;


        //Properties
        public YodaTranslationApiModel YodaTransApiModel { get; set; } = new YodaTranslationApiModel();


        //Constructor
        public YodaTranslationProcessor(IYodaTranslationAdapterMapper yodaTranslationAdapterMapper)
        {
            //Assignments
            _yodaTranslationAdapterMapper = yodaTranslationAdapterMapper;
        }


        //Methods
        public async Task<YodaTranslationDomainModel> GetYodaTranslation(string message)
        {
            string urlToBeEdited = "https://api.funtranslations.com/translate/yoda.json?text=ToBeEdited";

            string url = urlToBeEdited.Replace("ToBeEdited", message);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "f532242162mshfcf7cd07f406465p146a68jsn307dbd577c73" },
                    { "x-rapidapi-host", "yodish.p.rapidapi.com" },
                },
            };

            using (var response = ApiHelper.ApiClient.SendAsync(request).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var transAsString = await response.Content.ReadAsStringAsync();

                    YodaTransApiModel = JsonConvert.DeserializeObject<YodaTranslationApiModel>(transAsString);

                    YodaTransApiModel.DbId = Guid.NewGuid();

                    var jokeDomainModel = _yodaTranslationAdapterMapper.MapToDomainModel(YodaTransApiModel);

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