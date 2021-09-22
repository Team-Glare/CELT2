using CELTAPI.Model;
using CELTAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CELTAPI.Controllers
{
    [Route("sentiment")]
    [ApiController]
    public class SentimentController : Controller
    {
        private readonly ISentimentService _sentimentService;

        public SentimentController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpPost]
        [Route("text")]
        public async Task<string> GenerateSentimentFromText(TextInput input)
        {
            var result = await _sentimentService.CalculateSentimentFromText(input);

            return result;
        }

        [HttpPost]
        [Route("text/file")]
        public async Task<string> GenerateSentimentFromFile(IFormFile file)
        {
            var result = await _sentimentService.CalculateSentimentFromTextFile(file);

            return result;
        }
    }
}

