/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

using System.ComponentModel.DataAnnotations;

namespace CELTAPI.Model
{
    /// <summary>
    /// Text input model.
    /// </summary>
    public class TextInput
    {
        [Required]
        public string sentimentText { get; set; }
    }
}
