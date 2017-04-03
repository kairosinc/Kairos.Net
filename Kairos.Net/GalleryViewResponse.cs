using System.Collections.Generic;

namespace Kairos.Net
{
    /// <summary>
    ///     Response information for gallery/view call
    /// </summary>
    public class GalleryViewResponse : ImageBase
    {
        public GalleryViewResponse()
        {
            subjectIds = new List<string>();
            Errors = new List<Errors>();
        }

        public string status { get; set; }
        public List<string> subjectIds { get; set; }
        public List<Errors> Errors { get; set; }
    }
}