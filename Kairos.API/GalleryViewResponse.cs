using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// Response information for gallery/view call 
    /// </summary>
    public class GalleryViewResponse : ImageBase
    {
        public string status { get; set; }
        public List<string> subjectIds { get; set; }
        public List<Errors> Errors { get; set; }

        public GalleryViewResponse()
        {
            this.subjectIds = new List<string>();
            this.Errors = new List<Errors>();
        }
    }
}
