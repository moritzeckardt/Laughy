using System;

namespace Laughy.Models.DomainModels
{
    public class JokeDomainModel
    {
        //Properties
        public Guid Id { get; set; }
        public string Joke { get; set; } // type: single
        public string Setup { get; set; } // type: two part
        public string Delivery { get; set; } // type: two part
        public string Category { get; set; }
    }
}
