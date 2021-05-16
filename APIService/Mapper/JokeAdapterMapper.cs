using Laughy.Adapter.ApiService.ApiModels;
using Laughy.Adapter.ApiService.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using System;

namespace Laughy.Adapter.ApiService.Mapper
{
    public class JokeAdapterMapper : IJokeAdapterMapper
    {
        //Methods
        public JokeApiModel MapToApiModel(JokeDomainModel jokeDomainModel)
        {
            var apiModel = new JokeApiModel()
            {
                DbId = jokeDomainModel.DbId,
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
                Joke = jokeApiModel.Joke,
                Setup = jokeApiModel.Setup,
                Delivery = jokeApiModel.Delivery,
                Category = jokeApiModel.Category
            };

            if(jokeApiModel.DbId == null)
            {
                domainModel.DbId = Guid.NewGuid();
            }

            else
            {
                domainModel.DbId = jokeApiModel.DbId;
            }

            return domainModel;
        }
    }
}
