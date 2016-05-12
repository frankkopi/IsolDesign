using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Helpers
{
    public class PortfolioConverter
    {
        // convert List<PortfolioSubject> to List<PortfolioSubjectModel>
        public static List<PortfolioSubjectModel> ConvertToPortfolioSubjectModels(ICollection<PortfolioSubject> portfolio)
        {
            var convertedPortfolio = new List<PortfolioSubjectModel>();

            foreach (var portfolioSubject in portfolio)
            {
                PortfolioSubjectModel portfolioSubjectModel = new PortfolioSubjectModel
                {
                    Name = portfolioSubject.Name,
                    Date = portfolioSubject.Date,
                    Description = portfolioSubject.Description,
                    Photo1 = portfolioSubject.ImagePath1,
                    Photo2 = portfolioSubject.ImagePath2,
                    Photo3 = portfolioSubject.ImagePath3
                };
                convertedPortfolio.Add(portfolioSubjectModel);
            }
            return convertedPortfolio;
        }
    }
}
