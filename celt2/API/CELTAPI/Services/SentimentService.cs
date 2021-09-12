using CELTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CELTAPI.Services
{
    public class SentimentService : ISentimentService
    {
        public async Task<string> CalculateSentiment(TextInput input)
        {
            return "positive";
        }
    }
}