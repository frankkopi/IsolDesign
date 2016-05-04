using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.WebUI.Models
{
    public class ApplicantsIndexViewModel
    {
        public IEnumerable<ApplicantModel> Applicants { get; set; }

    }
}