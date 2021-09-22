using CELTAPI.Models;
using System.Threading.Tasks;

namespace CELTAPI.Services
{
    public interface ISentimentService
    {
        Task<string> CalculateSentimentFromText(TextInput input);

        Task<string> CalculateSentimentFromTextFile();
    }
}
