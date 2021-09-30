/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

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