using System.Collections.Generic;

namespace Kairos.Net
{
    /// <summary>
    ///     Image information after detecting it from a URL
    /// </summary>
    public class DetectImage : ImageBase
    {
        /// <summary>
        ///     Our default constructor
        /// </summary>
        public DetectImage()
        {
            Faces = new List<Face>();
        }

        public string status { get; set; }
        public string file { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<Face> Faces { get; set; }
    }
}