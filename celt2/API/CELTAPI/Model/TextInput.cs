using System.ComponentModel.DataAnnotations;

namespace CELTAPI.Model
{
    public class TextInput : ITextInput
    {
        [Required]
        public string sentimentText { get; set; }
    }
}
