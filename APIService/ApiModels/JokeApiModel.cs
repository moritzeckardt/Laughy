using System;

namespace Laughy.Adapter.ApiService.ApiModels
{
    public class JokeApiModel
    {
        //Properties
        public Guid DbId { get; set; }
        public string Joke { get; set; } // type: single
        public string Setup { get; set; } // type: two part
        public string Delivery { get; set; } // type: two part
        public string Category { get; set; }
        public bool Favourite { get; set; }
        public bool Selfcreated { get; set; }
    }
}
