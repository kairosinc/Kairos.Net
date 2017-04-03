using System.Collections.Generic;

namespace Kairos.API
{
    /// <summary>
    ///     Contains a list of gallery names and the status of the transaction
    /// </summary>
    public class GalleryListResponse : ImageBase
    {
        public GalleryListResponse()
        {
            galleryIds = new List<string>();
            Errors = new List<Errors>();
        }

        public string status { get; set; }
        public List<string> galleryIds { get; set; }
        public List<Errors> Errors { get; set; }
    }
}