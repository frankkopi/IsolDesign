using System.Collections.Generic;
using System.Web;
using IsolDesign.Domain.Helpers;

namespace IsolDesign.Domain.Handlers
{
    public class SavePortfolioImages_Handler
    {
        private HttpFileCollectionBase _images;
        private CreateApplicant_Handler _handler;

        public SavePortfolioImages_Handler(CreateApplicant_Handler handler, HttpFileCollectionBase images)
        {
            this._handler = handler;
            this._images = images;
        }

        public void SavePortfolioImages()
        {
            IEnumerable<HttpFileCollectionBase> imagesPortfolio1 = new List<HttpFileCollectionBase>();

            // Save images for portfolioSubject1 and portfolioSubject1
            for (int i = 1; i <= 6; i++)
            {
                var portfolioImage = _images.Get(i);
                if (!portfolioImage.HasFile()) continue;
                if(i <= 3)
                {
                    _handler.SaveImage(portfolioImage, "portfolio1", i);
                }
                else
                {
                    _handler.SaveImage(portfolioImage, "portfolio2", i);
                }
                
            }
        }


    }
}
