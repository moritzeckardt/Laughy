using Laughy.Adapter.ApiService.ApiModels;
using Laughy.Adapter.ApiService.Mapper.Interfaces;
using Laughy.Models.DomainModels;

namespace Laughy.Adapter.ApiService.Mapper
{
    public class JokeAdapterMapper : IJokeAdapterMaper
    {
        //Methods
        public JokeApiModel MapToApiModel(JokeDomainModel jokeDomainModel)
        {
            var apiModel = new JokeApiModel()
            {
                Id = jokeDomainModel.Id,
                Joke = jokeDomainModel.Joke,
                Setup = jokeDomainModel.Setup,
                Delivery = jokeDomainModel.Delivery,
                Category = jokeDomainModel.Category
            };

            return apiModel;
        }

        public JokeDomainModel MapToDomainModel(JokeApiModel jokeApiModel)
        {
            var domainModel = new JokeDomainModel()
            {
                Id = jokeApiModel.Id,
                Joke = jokeApiModel.Joke,
                Setup = jokeApiModel.Setup,
                Delivery = jokeApiModel.Delivery,
                Category = jokeApiModel.Category
            };

            return domainModel;
        }


    }
}
