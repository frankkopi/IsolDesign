using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.WebUI.Models
{
    public class CreateApplicantViewModel
    {
        public ApplicantModel ApplicantModel { get; set; }

        public PortfolioSubjectModel PortfolioSubject1 { get; set; }

        public PortfolioSubjectModel PortfolioSubject2 { get; set; }

        public IEnumerable<CompetencyModel> Competencies { get; set; }
    }
}