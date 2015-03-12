using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// Image information after a user has been enrolled
    /// </summary>
    public class EnrollImage : ImageBase
    {
        public Transaction Transaction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public EnrollImage()
        {
            this.Transaction = new Transaction();
        }
    }
}
