using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// The response to the facial recognition enroll method
    /// </summary>
    public class EnrollResponse
    {
        public List<EnrollImage> Images { get; set; }

        /// <summary>
        /// Our default constructor
        /// </summary>
        public EnrollResponse()
        {
            this.Images = new List<EnrollImage>();
        }
    }
}
