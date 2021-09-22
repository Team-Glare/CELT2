using CELTAPI.Models;
using CELTAPI.Utilities;
using System.IO;
using System.Threading.Tasks;
using System.Web;

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


        public async Task<string> CalculateSentimentFromTextFile()
        {
            var postedFile = HttpContext.Current.Request.Files["file"];
            var input = "";

            using (StreamReader streamReader = _reader.GetReader(postedFile.InputStream))
            {
                input = streamReader.ReadToEnd();
                streamReader.Close();
            }


            return "Negative";
        }
    }
}