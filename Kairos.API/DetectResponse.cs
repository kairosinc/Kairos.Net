using System.Collections.Generic;
using System.Linq;

namespace Kairos.API
{
    /// <summary>
    ///     The response to the facial recognition detect method
    /// </summary>
    public class DetectResponse
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public DetectResponse()
        {
            Images = new List<DetectImage>();
            Errors = new List<Errors>();
        }

        /// <summary>
        ///     Images detected
        /// </summary>
        public List<DetectImage> Images { get; set; }

        public List<Errors> Errors { get; set; }

        public bool HasFaces()
        {
            return Images.Any();
        }
    }
}