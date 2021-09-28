using CELTAPI.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CELTAPI.Services
{
    /// <summary>
    /// Interface for sentiment service which calculates sentiments.
    /// </summary>
    public interface ISentimentService
    {
        Task<string> CalculateSentimentFromText(TextInput input);

        Task<string> CalculateSentimentFromTextFile(IFormFile file);
    }
}
