using System.ComponentModel.DataAnnotations;

namespace CELTAPI.Model
{
    /// <summary>
    /// Text input model.
    /// </summary>
    public class TextInput
    {
        [Required]
        public string sentimentText { get; set; }
    }
}
