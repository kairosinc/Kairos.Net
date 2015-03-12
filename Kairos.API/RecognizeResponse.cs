 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// Response information after recognizing a previously enrolled image
    /// </summary>
    public class RecognizeResponse
    {
        public List<Kairos.API.RecognizeImage> Images { get; set; }
        public List<Errors> Errors {get; set;}

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecognizeResponse()
        {
            this.Images = new List<RecognizeImage>();
            this.Errors = new List<Errors>();
        }
    }
}
