using IsolDesign.Data.Models;
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
        //public string ProfileImagePath { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile, string type, int? count)
        {
            if (image == null) return;

            string filename = Guid.NewGuid().ToString();
            ImageModel.ResizeAndSave(
                serverPath + pathToFile, filename,
                image.InputStream, 200);

            
            if(type == "profile")
            {
                Applicant applicant = CreateApplicant_Handler.GetApplicant();
                applicant.ProfileImagePath = pathToFile + filename + ".jpg";
                //ProfileImagePath = pathToFile + filename + ".jpg";
            }
            else if(type == "portfolio1")
            {
                PortfolioSubject portfolio1 = CreateApplicant_Handler.GetPortfolioSubject("portfolio1");
                switch (count)
                {
                    case 1:
                        portfolio1.ImagePath1 = pathToFile + filename + ".jpg";
                        break;
                    case 2:
                        portfolio1.ImagePath2 = pathToFile + filename + ".jpg";
                        break;
                    case 3:
                        portfolio1.ImagePath3 = pathToFile + filename + ".jpg";
                        break;
                }
                
            }
            else if (type == "portfolio2")
            {
                PortfolioSubject portfolio2 = CreateApplicant_Handler.GetPortfolioSubject("portfolio2");
                switch (count)
                {
                    case 4:
                        portfolio2.ImagePath1 = pathToFile + filename + ".jpg";
                        break;
                    case 5:
                        portfolio2.ImagePath2 = pathToFile + filename + ".jpg";
                        break;
                    case 6:
                        portfolio2.ImagePath3 = pathToFile + filename + ".jpg";
                        break;
                }
            }

        }
    }
}
