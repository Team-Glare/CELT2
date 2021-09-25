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
        private readonly IServerClient _serverClient;
        private readonly ITextInput _textInput;

        public SentimentService(IStreamReader reader, IServerClient serverClient, ITextInput textInput)
        {
            _reader = reader;
            _serverClient = serverClient;
            _textInput = textInput;
        }

        public async Task<string> CalculateSentimentFromText(TextInput input)
        {
            var result = await _serverClient.PostAsync<SentimentResult, TextInput>($"sentiment/text", input);

            return result.label;
        }


        public async Task<string> CalculateSentimentFromTextFile(IFormFile file)
        {
            using (StreamReader streamReader = _reader.GetReader(file.OpenReadStream()))
            {
                _textInput.sentimentText = streamReader.ReadToEnd();
                streamReader.Close();
            }

            var result = await _serverClient.PostAsync<SentimentResult, TextInput>($"sentiment/text", (TextInput)_textInput);

            return result.label;
        }
    }
}
