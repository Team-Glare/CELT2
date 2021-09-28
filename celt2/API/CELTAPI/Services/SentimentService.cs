using CELTAPI.Model;
using CELTAPI.Utilities;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CELTAPI.Services
{
    /// <summary>
    /// The service for calculating the sentiment.
    /// </summary>
    public class SentimentService : ISentimentService
    {
        private readonly IStreamReader _reader;
        private readonly IServerClient _serverClient;

        /// <summary>
        /// Constructor for SentimentService with the injected depenedencies.
        /// </summary>
        /// <param name="reader">the IServerClient for the connection to server.</param>
        /// <param name="serverClient">The IStreamReader for reading stream for file.</param>
        public SentimentService(IStreamReader reader, IServerClient serverClient)
        {
            _reader = reader;
            _serverClient = serverClient;
        }

        /// <summary>
        /// Calculates the sentiment from plain text.
        /// </summary>
        /// <param name="input">The plain text input.</param>
        /// <returns>The calculated sentiment label with cumalative probability.</returns>
        public async Task<string> CalculateSentimentFromText(TextInput input)
        {
            var result = await _serverClient.PostAsync<SentimentResult, TextInput>($"sentiment/text", input);

            return result.label;
        }

        /// <summary>
        /// Calculates the sentiment from text file.
        /// </summary>
        /// <param name="file">The input text file.</param>
        /// <returns>The calculated sentiment label with cumalative probability.</returns>
        public async Task<string> CalculateSentimentFromTextFile(IFormFile file)
        {
            var input = new TextInput();

            using (StreamReader streamReader = _reader.GetReader(file.OpenReadStream()))
            {
                input.sentimentText = streamReader.ReadToEnd();
                streamReader.Close();
            }

            var result = await _serverClient.PostAsync<SentimentResult, TextInput>($"sentiment/text", input);

            return result.label;
        }
    }
}
