using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IsolDesign.Domain.Handlers
{
    public class ImageHandler
    {
        public string ProfileImagePath { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;

            string filename = Guid.NewGuid().ToString();
            ImageModel.ResizeAndSave(
                serverPath + pathToFile, filename,
                image.InputStream, 200);

            ProfileImagePath = pathToFile + filename + ".jpg";
        }
    }
}
