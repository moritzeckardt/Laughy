using System;
using System.ComponentModel;

namespace Laughy.Models.UiModels
{
    public class JokeUiModel
    {
        //Properties
        public Guid DbId { get; set; }
        public string Joke { get; set; } // joke type: single
        public string Setup { get; set; } // joke type: two part
        public string Delivery { get; set; } // joke type: two part   
        public string Category { get; set; }
    }
}
