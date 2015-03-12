using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KairosApp
{
    using System.Drawing;

    /// <summary>
    /// Converts images to base64 encoded strings
    /// </summary>
    public static class ConvertToBase64
    {
        public static string ConvertImage(string path)
        {
            using (Image image = Image.FromFile(path)) 
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    
                    return Convert.ToBase64String(imageBytes);
                    
                }
            }
        }

        public static string ConvertImage(System.Drawing.Image image)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();

                return Convert.ToBase64String(imageBytes);
            }
        }

    }
}
