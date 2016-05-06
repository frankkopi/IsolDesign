using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.WebUI.Models
{
    public class ApplicantsIndexViewModel
    {
        public IEnumerable<ApplicantModel> Applicants { get; set; }

        public PortfolioSubjectModel PortfolioSubjectModel1 { get; set; }

        public PortfolioSubjectModel PortfolioSubjectModel2 { get; set; }

    }
}