using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    public class GalleryListResponse : ImageBase
    {
        public string status { get; set; }
        public List<string> galleryIds { get; set; }
    }
}
