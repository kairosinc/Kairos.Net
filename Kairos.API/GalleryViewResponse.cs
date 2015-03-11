using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    public class GalleryViewResponse : ImageBase
    {
        public string status { get; set; }
        public List<string> subjectIds { get; set; }
    }
}
