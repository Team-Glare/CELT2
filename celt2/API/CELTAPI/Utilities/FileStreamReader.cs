/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

using System.IO;

namespace CELTAPI.Utilities
{
    /// <summary>
    /// File stream reader which implements IStreamReader
    /// </summary>
    public class FileStreamReader : IStreamReader
    {
        /// <summary>
        /// Method for getting a StreamReader.
        /// </summary>
        /// <param name="inputStream">Stream input.</param>
        /// <returns>An instance of StreamReader with the inputted Stream.</returns>
        public StreamReader GetReader(Stream inputStream)
        {
            return new StreamReader(inputStream);
        }
    }
}
