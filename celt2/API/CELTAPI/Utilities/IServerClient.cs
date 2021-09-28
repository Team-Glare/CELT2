using System.Threading.Tasks;

namespace CELTAPI.Utilities
{
    /// <summary>
    /// Interface for server client.
    /// </summary>
    public interface IServerClient
    {
        Task<TResult> GetAsync<TResult>(string relativeUrl);
        Task<TResult> PostAsync<TResult, TPayload>(string relativeUrl, TPayload payload);
        Task<TResult> PutAsync<TResult, TPayload>(string relativeUrl, TPayload payload);
    }
}