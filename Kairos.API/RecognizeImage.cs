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
