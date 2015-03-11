/*************************************************************************
* 
* 18 SIGNALS CONFIDENTIAL
* __________________
* 
*  [2013] 18 SIGNALS, LLC
*  All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains
* the property of 18 SIGNALS, LLC and its suppliers,
* if any.  The intellectual and technical concepts contained
* herein are proprietary to 18 SIGNALS, LLC and its suppliers 
* and may be covered by U.S. and Foreign Patents, patents in process, 
* and are protected by trade secret or copyright law.
* Dissemination of this information or reproduction of this material
* is strictly forbidden unless prior written permission is obtained
* from 18 SIGNALS, LLC.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// Information about the users detected after trying to recognize the face
    /// </summary>
    public class RecognizeImage : ImageBase
    {
        public Kairos.API.Transaction Transaction { get; set; }
        public List<Dictionary<string, string>> Candidates { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecognizeImage()
        {
            this.Transaction = new Transaction();
            this.Candidates = new List<Dictionary<string, string>>();
        }
    }
}
