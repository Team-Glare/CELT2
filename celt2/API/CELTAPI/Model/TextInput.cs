using System.ComponentModel.DataAnnotations;

namespace CELTAPI.Model
{
    public class TextInput
    {
        [Required]
        public string sentimentText { get; set; }
    }
}
