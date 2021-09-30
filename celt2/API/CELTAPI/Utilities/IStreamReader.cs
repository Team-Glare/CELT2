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
    /// Interface for stream reader.
    /// </summary>
    public interface IStreamReader
    {
        StreamReader GetReader(Stream inputStream);
    }
}
