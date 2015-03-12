using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// Contains a list of gallery names and the status of the transaction
    /// </summary>
    public class GalleryListResponse : ImageBase
    {
        public string status { get; set; }
        public List<string> galleryIds { get; set; }
        public List<Errors> Errors { get; set; }

        public GalleryListResponse()
        {
            this.galleryIds = new List<string>();
            this.Errors = new List<Errors>();
        }
    }
}
