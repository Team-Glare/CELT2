using System.ComponentModel.DataAnnotations;

namespace CELTAPI.Model
{
    public class TextInput
    {
        [Required]
        public string SentimentText { get; set; }
    }
}
