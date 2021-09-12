using CELTAPI.Models;
using CELTAPI.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace CELTAPI.Controllers
{
    [RoutePrefix("api/sentiment")]
    public class SentimentController : ApiController
    {
        private readonly ISentimentService _sentimentService;

        public SentimentController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpPost]
        public async Task<string> GenerateSentiment(TextInput input)
        {
            var result = await _sentimentService.CalculateSentiment(input);

            return result;
        }
    }
}
