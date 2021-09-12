using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CELTAPI.Models
{
    public class TextInput
    {
        [Required]
        public string SentimentText { get; set; }
    }
}