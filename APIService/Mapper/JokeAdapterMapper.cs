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
                Category = jokeDomainModel.Category,
                Favourite = jokeDomainModel.Favourite,
                Selfcreated = jokeDomainModel.Selfcreated
            };

            if (!String.IsNullOrWhiteSpace(jokeDomainModel.SecondPart))
            {
                apiModel.Joke = jokeDomainModel.FirstPart;
            }

            else
            {
                apiModel.Setup = jokeDomainModel.FirstPart;
                apiModel.Delivery = jokeDomainModel.SecondPart;
            }

            return apiModel;
        }

        public JokeDomainModel MapToDomainModel(JokeApiModel jokeApiModel)
        {
            var domainModel = new JokeDomainModel()
            {
                DbId = jokeApiModel.DbId,
                Category = jokeApiModel.Category,
                Favourite = jokeApiModel.Favourite,
                Selfcreated = jokeApiModel.Selfcreated
            };

            if(String.IsNullOrWhiteSpace(jokeApiModel.Setup))
            {
                domainModel.FirstPart = jokeApiModel.Joke;
            } 

            else
            {
                domainModel.FirstPart = jokeApiModel.Setup;
                domainModel.SecondPart = jokeApiModel.Delivery;
            }

            return domainModel;
        }
    }
}
