using System.Threading.Tasks;

namespace CELTAPI.Utilities
{
    public interface IServerClient
    {
        Task<TResult> GetAsync<TResult>(string relativeUrl);
        Task<TResult> PostAsync<TResult, TPayload>(string relativeUrl, TPayload payload);
        Task<TResult> PutAsync<TResult, TPayload>(string relativeUrl, TPayload payload);
    }
}