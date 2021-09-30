/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

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
