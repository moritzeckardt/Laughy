using System.Collections.Generic;

namespace Laughy.Adapter.ApiService.ApiModels
{
    public class JokeApiModel
    {
        //Properties
        public int Id { get; set; }
        public string Joke { get; set; } // type: single
        public string Setup { get; set; } // type: two part
        public string Delivery { get; set; } // type: two part
        public string Category { get; set; }
        public string Type { get; set; }
    }
}
