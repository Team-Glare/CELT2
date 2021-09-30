/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

using CELTAPI.Model;
using CELTAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CELTAPI.Controllers
{
    /// <summary>
    /// Controller for calculating sentiment.
    /// </summary>
    [Route("sentiment")]
    [ApiController]
    public class SentimentController : Controller
    {
        private readonly ISentimentService _sentimentService;
        /// <summary>
        /// Constructor for SentimentController with the injected dependencies.
        /// </summary>
        /// <param name="sentimentService">The ISentimentService for calculating the sentiments.</param>
        public SentimentController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        /// <summary>
        /// Endpoint for calculating sentiment from plain text.
        /// </summary>
        /// <param name="input">The plain text input.</param>
        /// <returns>The calculated sentiment label with cumulative probability.</returns>
        [HttpPost]
        [Route("text")]
        public async Task<string> GenerateSentimentFromText(TextInput input)
        {
            var result = await _sentimentService.CalculateSentimentFromText(input);

            return result;
        }

        /// <summary>
        /// Endpoint for calculating sentiment from text file.
        /// </summary>
        /// <param name="file">The input text file.</param>
        /// <returns>The calculated sentiment label with cumulative probability.</returns>
        [HttpPost]
        [Route("text/file")]
        public async Task<string> GenerateSentimentFromFile(IFormFile file)
        {
            var result = await _sentimentService.CalculateSentimentFromTextFile(file);

            return result;
        }
    }
}

