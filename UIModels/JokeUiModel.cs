using System;

namespace Laughy.Models.UiModels
{
    public class JokeUiModel
    {
        //Properties
        public Guid DbId { get; set; }
        public int JokeId { get; set; }
        public string Joke { get; set; } // type: single
        public string Setup { get; set; } // type: two part
        public string Delivery { get; set; } // type: two part
        public string Category { get; set; }
        public string Type { get; set; }
    }
}
