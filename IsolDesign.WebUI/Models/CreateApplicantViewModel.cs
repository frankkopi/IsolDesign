using IsolDesign.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsolDesign.WebUI.Models
{
    public class CreateApplicantViewModel
    {
        public ApplicantModel ApplicantModel { get; set; }
        //public string Name { get; set; }

        //public string Address { get; set; }

        //public string City { get; set; }

        //public string Country { get; set; }

        //public string Phone { get; set; }

        //public string Email { get; set; }

        //public string Description { get; set; }

        //public string SkypeLink { get; set; }

        //public string Facebook { get; set; }

        //public string LinkedIn { get; set; }

        //public string Homepage { get; set; }

        //public IEnumerable<PortfolioSubjectModel> Portfolio { get; set; }

        public PortfolioSubjectModel portfolioSubject1 { get; set; }

        public PortfolioSubjectModel portfolioSubject2 { get; set; }


    }
}