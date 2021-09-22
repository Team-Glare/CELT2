using CELTAPI.Models;
using CELTAPI.Services;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CELTAPI.Controllers
{
    [RoutePrefix("sentiment")]
    public class SentimentController : ApiController
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
        public async Task<string> GenerateSentimentFromFile()
        {
            var result = await _sentimentService.CalculateSentimentFromTextFile();

            return result;
        }
    }
}
