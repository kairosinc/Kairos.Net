using System.Collections.Generic;

namespace Kairos.Net
{
    /// <summary>
    ///     The response to the facial recognition enroll method
    /// </summary>
    public class EnrollResponse
    {
        /// <summary>
        ///     Our default constructor
        /// </summary>
        public EnrollResponse()
        {
            Images = new List<EnrollImage>();
            Errors = new List<Errors>();
        }

        public List<EnrollImage> Images { get; set; }
        public List<Errors> Errors { get; set; }
    }
}