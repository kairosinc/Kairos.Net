﻿/*************************************************************************
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
    /// Transaction details after an enrollment
    /// </summary>
    public class Transaction
    {
        public string status { get; set; }
        public string subject { get; set; }
        public string face_id { get; set; }
        public string subject_id { get; set; }
        public string confidence { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int topLeftX { get; set; }
        public int topLeftY { get; set; }
        public string image_id { get; set; }
        public string timestamp { get; set; }
        public string gallery_name { get; set; }
    }
}
