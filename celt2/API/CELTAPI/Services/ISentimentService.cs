using CELTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CELTAPI.Services
{
    public interface ISentimentService
    {
        Task<string> CalculateSentiment(TextInput input);
    }
}
