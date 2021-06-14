using System;

namespace Laughy.Models.UiModels
{
    public class YodaTranslationUiModel
    {
        //Properties
        public Guid DbId { get; set; }
        public string Yoda { get; set; }       
        public string Translated { get; set; }
        public string ImageSource { get; set; }
        public DateTime Time { get; set; }
    }
}
