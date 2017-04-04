using System.Collections.Generic;

namespace Kairos.Net
{
    /// <summary>
    ///     Information about the users detected after trying to recognize the face
    /// </summary>
    public class RecognizeImage : ImageBase
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public RecognizeImage()
        {
            Transaction = new Transaction();
            Candidates = new List<Candidate>();
        }

        public Transaction Transaction { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}