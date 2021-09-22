using CELTAPI.Model;
using CELTAPI.Utilities;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CELTAPI.Services
{
    public class SentimentService : ISentimentService
    {
        private readonly IStreamReader _reader;

        public SentimentService(IStreamReader reader)
        {
            _reader = reader;
        }

        public async Task<string> CalculateSentimentFromText(TextInput input)
        {
            return "Positive";
        }


        public async Task<string> CalculateSentimentFromTextFile(IFormFile file)
        {
            var input = "";
            using (StreamReader streamReader = _reader.GetReader(file.OpenReadStream()))
            {
                input = streamReader.ReadToEnd();
                streamReader.Close();
            }


            return "Negative";
        }
    }
}
