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
            Candidates = new List<Dictionary<string, string>>();
        }

        public Transaction Transaction { get; set; }
        public List<Dictionary<string, string>> Candidates { get; set; }
    }
}