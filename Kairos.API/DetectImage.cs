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
    /// Image information after detecting it from a URL
    /// </summary>
    public class DetectImage : ImageBase
    {
        public string status { get; set; }
        public string file { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<Face> Faces { get; set; }        

        /// <summary>
        /// Our default constructor
        /// </summary>
        public DetectImage()
        {
            this.Faces = new List<Face>();            
        }
    }
}
