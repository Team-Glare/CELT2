using CELTAPI.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CELTAPI.Services
{
    public interface ISentimentService
    {
        Task<string> CalculateSentimentFromText(TextInput input);

        Task<string> CalculateSentimentFromTextFile(IFormFile file);
    }
}
