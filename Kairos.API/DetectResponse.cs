using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// The response to the facial recognition detect method
    /// </summary>
    public class DetectResponse 
    {
        /// <summary>
        /// Images detected
        /// </summary>
        public List<DetectImage> Images { get; set; }
        public List<Errors> Errors { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DetectResponse()
        {
            this.Images = new List<DetectImage>();
            this.Errors = new List<Errors>();
        }

        public bool HasFaces()
        {
            return this.Images.Any();
        }
    }
}
