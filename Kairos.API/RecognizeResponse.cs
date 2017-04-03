using System.Collections.Generic;

namespace Kairos.API
{
    /// <summary>
    ///     Response information after recognizing a previously enrolled image
    /// </summary>
    public class RecognizeResponse
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public RecognizeResponse()
        {
            Images = new List<RecognizeImage>();
            Errors = new List<Errors>();
        }

        public List<RecognizeImage> Images { get; set; }
        public List<Errors> Errors { get; set; }
    }
}